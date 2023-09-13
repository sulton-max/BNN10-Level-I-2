using N38_C.Models;

namespace N38_C.Services;

public class WeatherReportService
{
    private static string RootPath = Directory.GetCurrentDirectory();
    private static bool IsFirstTime = true;

    public IEnumerable<Task<(string FilePath, WeatherReport report)>> InitializeReportFiles(IList<WeatherReport> reports)
    {
        var tasks = new List<Task<(string FilePath, WeatherReport report)>>();
        var waitTime = new[]
        {
            0,
            10000,
            10000,
            10000,
            10000,
        };

        for (var index = 0; index < reports.Count(); index ++)
        {
            var report = reports[index];
            Console.WriteLine("fayl ochilishi boshlandi");
            tasks.Add(Task.Run(() =>
            {
                Console.WriteLine("\nReport fayl ochilmoqda ...");
                var filePath = Path.Combine(RootPath, $"{report.Id}.txt");
                var fileStream = File.Create(filePath);

                Thread.Sleep(waitTime[index]);

                fileStream.Flush();
                fileStream.Close();
                Console.WriteLine("\nReport yopildi");
                return (filePath, report);
            }));
        }

        Console.WriteLine("Returning tasks...");

        foreach (var task in tasks)
            yield return task;
    }
}