# DataConveyer_CsvToFlat_wasm

DataConveyer_CsvToFlat_wasm is a [Web Assembly](https://webassembly.org/) that demonstrates versatility of Data Conveyer.
It uses Data Conveyer confined within a web browser to convert a CSV file to a flat (fixed-width field) file.

The input file is expected to contain aircraft data along with IATA and ICAO codes. Like so:

```
"Airbus A320","320","A320"
"Boeing 747","747",\N
```

There is a sample input file (200+ lines, 8+KB) included in ...Data folder. The file is a copy of
[planes.dat](https://github.com/jpatokal/openflights/blob/master/data/planes.dat) file, which is
licensed under [Open Database License](https://github.com/jpatokal/openflights/blob/master/data/LICENSE).

Upon execution, the original input and converted data are displayed side-by-side in the browser window. The coverted data contains
translations between the IATA code and the aircraft names (ICAO codes get discarded), i.e.:

```
320 - Airbus A320
747 - Boeing 747
```

**Disclaimer:** The solution relies on [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/client) technology, which
as of June 2019 is in preview and not officially released. It is known that Blazor-based Web Asseblies currently take long time to load.
This demo application may perform poorly and should not be used as an example of any production-level solution.

**Note:** The compiled version of this web application is [available online](https://mavidian.github.io/DataConveyer_CsvToFlat_wasm/).
It can be used instead of installing and building it by following steps 3 to 8 below (the input file, e.g. planes.dat is still needed on local machine).

## Installation

* Fork this repository and clone it onto your local machine, or

* Download this repository onto your local machine.

## Usage

1. Open DataConveyer_ConvertCsvToFlat solution in Visual Studio 2019. Note that the Visual Studio version needs to support client-side Blazor projects.
As of June 2019, the easiest way to do so is to obtain [Visual Studio Preview](https://visualstudio.microsoft.com/vs/preview/).

2. Build and run the application, e.g. hit F5

    - a bowser window will show up; upon loading, a "Data Conveyer in a web browser" page will be displayed.

3. Click the "Browse" button (or the "Choose File" button or similar - this depends on the web browser you use).

4. In the Open file dialog that shows up, select input file, e.g. planes.dat.

5. Hit the "Read and Conver Airplane Data" button.

    - the file will get processed as reported on the browser page.

6. Review the contents of the "Input Data" and "Output Data" text areas displayed in your browser window.

7. (optional) Repeat steps 3-6 for other additional input file(s).

8. To exit application, close the browser window.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[Apache License 2.0](https://choosealicense.com/licenses/apache-2.0/)

## Copyright

```
Copyright © 2019 Mavidian Technologies Limited Liability Company. All Rights Reserved.
```
