using N38_C.Models;

// var reports = new List<WeatherReport>
// {
//     new(Guid.NewGuid(), "Storm", new DateTimeOffset(DateTime.Now.AddHours(-1))),
//     new(Guid.NewGuid(), "Sunny", new DateTimeOffset(DateTime.Now.AddHours(-1))),
//     new(Guid.NewGuid(), "Cloudy", new DateTimeOffset(DateTime.Now.AddHours(-1))),
// };
//
// var service = new WeatherReportService();
// foreach (var reportFileTask in service.InitializeReportFiles(reports))
// {
//     var reportFile = await reportFileTask;
//     Console.WriteLine("Report file tayyor bo'ldi");
//     Console.WriteLine(reportFile.FilePath);
//     Console.WriteLine(reportFile.report);
// }

var filesContainer = new FilesContainer("D:\\Projects\\Repositories\\Training\\Groups\\Bootcamp N10\\Classes\\BNN10-Level-I-2");
// for (var index = 0; index < filesContainer.Count(); index++)
// {
//     Console.WriteLine(filesContainer[index]);
// }

Console.WriteLine(filesContainer["her"]);
// foreach (var fileInfo in filesContainer.Where(file => file.LastWriteTimeUtc > DateTime.UtcNow.AddHours(-1)))
// {
//     Console.WriteLine(fileInfo);
// }