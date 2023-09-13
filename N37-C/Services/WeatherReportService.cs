using N37_C.Models;

namespace N37_C.Services;

public class WeatherReportService
{
    private static string RootPath = Directory.GetCurrentDirectory();

    public IEnumerable<(string FilePath, WeatherReport report)> InitializeReportFiles(
        IEnumerable<WeatherReport> reports
    )
    {
        foreach (var report in reports)
        {
            Console.WriteLine("\nReport fayl ochilmoqda");
            var filePath = Path.Combine(RootPath, $"{report.Id}.txt");
            var fileStream = File.Create(filePath);
            fileStream.Flush();
            fileStream.Close();

            Console.WriteLine("Report fayl tayyor");
            yield return (filePath, report);
        }
    }
}