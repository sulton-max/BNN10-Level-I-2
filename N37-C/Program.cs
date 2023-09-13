using N37_C;
using N37_C.Models;
using N37_C.Services;

var reports = new List<WeatherReport>
{
    new WeatherReport(Guid.NewGuid(), "Storm", new DateTimeOffset(DateTime.Now.AddHours(-1))),
    new WeatherReport(Guid.NewGuid(), "Sunny", new DateTimeOffset(DateTime.Now.AddHours(-1))),
    new WeatherReport(Guid.NewGuid(), "Cloudy", new DateTimeOffset(DateTime.Now.AddHours(-1))),
};

// iterating - bitta narsani qayta qayta bajarish
// enumerating - enumerable ichidan barcha elementlarni olish
// enumerable - sanasi bo'ladigan narsa

// var reportsModified = reports.Select(report =>
// {
//     Console.WriteLine("Report uchun so'rov bo'ldi {0}", report);
//     return report;
// });
//
// foreach (var report in reportsModified)
// {
//     await Task.Delay(100);
//     Console.WriteLine("Report uchun javob keldi {0}", report);
// }

var numbers = new[]
{
    1,
    2,
    3,
};
var number = numbers[0];

foreach (var index in Enumerable.Range(0, 100))
{
    // Do Something A
}

foreach (var index in Enumerable.Range(0, 100))
{
    // Do Something B
}

reports.Select(report =>
    {
        Console.WriteLine("\nReport fayl ochilmoqda");
        Console.WriteLine("Report fayl tayyor");
        return report;
    })
    .Select(report =>
    {
        Console.WriteLine("Report qabul qilindi bo'ldi");
        return report;
    })
    .ToList();

var service = new WeatherReportService();
foreach (var reportFile in service.InitializeReportFiles(reports))
{
    Console.WriteLine("Report file tayyor bo'ldi");
    Console.WriteLine(reportFile.FilePath);
    Console.WriteLine(reportFile.report);
}


namespace N37_C
{
}