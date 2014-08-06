.\Misc\OpenCover\OpenCover.console.exe -register:user -target:"C:\Program Files (x86)\NUnit 2.6.3\bin\nunit-console.exe" -targetargs:".\TextfileLines.Test\bin\Debug\TextfileLines.Test.dll  /noshadow" -output:.\CCB.xml

.\Misc\ReportGenerator_1.9.1.0\bin\ReportGenerator.exe -reports:".\CCB.xml" -targetdir:".\CCBericht"

"C:\Program Files (x86)\Mozilla Firefox\firefox.exe" .\CCBericht\index.htm