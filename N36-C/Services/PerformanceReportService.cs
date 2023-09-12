namespace N36_C.Services;

public class PerformanceReportService
{
    public async ValueTask<IEnumerable<(string FilePath, User User)>> InitializeEmployeeFileDataAsync(IEnumerable<User> users)
    {
        var path = Directory.GetCurrentDirectory();

        var filePathsTask = users.Select(async user =>
        {
            var filePath = Path.Combine(path, $"{user.Name}.txt");
            var fileStream = File.Create(filePath);
            await fileStream.FlushAsync();
            fileStream.Close();

            return (filePath, user);
        });

        var userFilePaths = await Task.WhenAll(filePathsTask);

        return userFilePaths;
    }
}