Notes on the live demo deployment.

The application (live demo) is published at https://mavidian.com/DataConveyer_CsvToFlat_wasm/
It is built by GitHub Pages (GHP) from the /docs folder in the master branch (happend automatically
on commit to the https://github.com/mavidian/DataConveyer_CsvToFlat_wasm repo)

The source contains elements specific to hosting Blazor apps (SPAs) on https://github.com/mavidian/DataConveyer_CsvToFlat_wasm, such as:
  - SPA redirection in index.html and 404.html
  - .nojekyll (empty file to prevent jekyll processing during publishing, which is GHP standard)

In order for the live demo to reflect the project source, the /docs folder of the repo must be updated on EVERY commit!
Furthermore, manual update to the build results are required (as of Oct 2020).
Specific steps:

1. Create/update Blazor app (code changes to DataConveyer_CsvToFlat_wasm project, debugging... normal stuff).

2. Build.. Publish DataConveyer_CsvToFlat_wasm to a Folder
   - by default, it will create the site at Publish DataConveyer_CsvToFlat_wasm\bin\Release\netstandard2.1\publish\wwwroot

3. Clear the contents of the docs folder.

3. Copy the contents of the Publish DataConveyer_CsvToFlat_wasm\bin\Release\netstandard2.1\publish\wwwroot folder to the docs folder.

4. In the docs folder(!), edit index.html file to replace the <base href="/" /> in the <head> node to:
    <base href="/DataConveyer_CsvToFlat_wasm/" />

5. Commit the changes and push to GitHub
   - the live demo at https://mavidian.com/DataConveyer_CsvToFlat_wasm/ will be updated soon, usually in a few seconds.
