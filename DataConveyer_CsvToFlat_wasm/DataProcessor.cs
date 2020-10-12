// Copyright © 2019-2020 Mavidian Technologies Limited Liability Company. All Rights Reserved.

using Mavidian.DataConveyer.Common;
using Mavidian.DataConveyer.Entities.KeyVal;
using Mavidian.DataConveyer.Orchestrators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataConveyer_CsvToFlat_wasm
{
   internal  class DataProcessor
   {
      private readonly IOrchestrator Orchestrator;

      internal DataProcessor(Func<Task<string>> intakeSupplierAsync, Action<string> outputConsumer, Action<int> progressHandler)
      {
         var config = new OrchestratorConfig()
         {
            ReportProgress = true,
            ProgressInterval = 10,
            ProgressChangedHandler = (s,e) => { if (e.Phase == Phase.Intake) progressHandler(e.RecCnt); },
            PhaseFinishedHandler = (s,e) => { if (e.Phase == Phase.Intake) progressHandler(e.RecCnt); },
            InputDataKind = KindOfTextData.Delimited,
            InputFields = "PlaneDescription,IataCode,IcaoCode",
            AsyncIntake = true,
            TransformerType = TransformerType.Universal,
            UniversalTransformer = FilterAndReorganizeFields,
            AllowTransformToAlterFields = true,
            OutputDataKind = KindOfTextData.Flat,
            OutputFields = "IataCode|4,Hyphen|2,PlaneDescription|70",
            ExcludeExtraneousFields = true
         };
         config.SetAsyncIntakeSupplier(intakeSupplierAsync);
         config.SetOutputConsumer(outputConsumer);

         Orchestrator = OrchestratorCreator.GetEtlOrchestrator(config);
      }


      /// <summary>
      /// Execute Data Conveyer process.
      /// </summary>
      /// <returns>Task containing the process results.</returns>
      internal async Task<ProcessResult> ProcessFileAsync()
      {
         var result = await Orchestrator.ExecuteAsync();
         Orchestrator.Dispose();

         return result;
      }


      /// <summary>
      /// Universal transformer to translate an input cluster into a set of (0 or 1) output clusters.
      /// </summary>
      /// <param name="inClstr">Cluster received from intake.</param>
      /// <returns>A single resulting cluster to be sent to output, or empty if cluster needs to be filtered out. </returns>
      private IEnumerable<ICluster> FilterAndReorganizeFields(ICluster inClstr)
      {
         //Note: Universal transformer is needed because we need to perform 2 distinct transformations:
         //      (1) Filtering (records with \N in IataCode field need to be removed)
         //      (2) Record layout update (IataCode moved to first position, IcaoCode removed, etc.)
         //      If only (1) was needed, then RecordFilter transformer would suffice.
         //      If only (2) was needed, then Recordbound transformer would suffice.
         var inRec = inClstr[0];
         var iataCode = (string)inRec["IataCode"];
         if (iataCode == "\\N") return Enumerable.Empty<ICluster>();

         var outClstr = inClstr.GetEmptyClone();
         var outRec = inClstr[0];
         outRec.AddItem("IataCode", iataCode);
         outRec.AddItem("Hyphen", "-");
         outRec.AddItem("PlaneDescription", inRec["PlaneDescription"]);
         outClstr.AddRecord(outRec);
         return Enumerable.Repeat(outClstr, 1);
      }
   }
}
