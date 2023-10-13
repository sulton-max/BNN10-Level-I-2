namespace N55_C;

public static class PathExample
{
    public static void Execute()
    {
        // Path turlari

        // absolute - D:\Projects\BNN10-Level-I-2\N55-C\bin\Debug\net7.0\Data\DataStorage\users.json
        // relative - DataStorage\users.json, Data\FilesStorage\23423432-resume.pdf

        // storage root path - D:\Projects\BNN10-Level-I-2\N55-C\bin\Debug\net7.0\

        // separator - umumity path ichidagi qismlarni ajratib turadi

        // Pathlarni qo'shish

        var appFolderPath = "D:\\Projects\\Repositories\\Training\\Groups\\Bootcamp N10\\Classes\\BNN10-Level-I-2\\N55-C\\bin\\Debug\\net7.0";
        var fileRelativePath = "Data\\Resumes\\users.json";
        var fileAbsolutePath = Path.Combine(appFolderPath, fileRelativePath);

        Console.WriteLine(Path.GetRelativePath(appFolderPath, fileAbsolutePath));
        Console.WriteLine(Path.GetFullPath(fileRelativePath));

        var dataDirectory = "Data";
        var dataStorage = "DataStorage";
        var file = "users.json";

        // combine - pathlarni absolute pathni boshiga qo'yib qo'shadi
        // join - pathlarni shunchaki qo'shadi

        var fileAbsolutePathA = Path.Combine(fileRelativePath, appFolderPath, fileRelativePath, appFolderPath);
        var fileAbsolutePathB = Path.Join(fileRelativePath, appFolderPath, fileRelativePath, appFolderPath);

        Console.WriteLine();
        Console.WriteLine($"Combine - {fileAbsolutePathA}");
        Console.WriteLine($"Join - {fileAbsolutePathB}");

        // Path validation

        // Exist - path ni bor yo'qligini teksirish
        // Console.WriteLine(Path.Exists(fileRelativePath));
        // Console.WriteLine(Path.Exists(fileAbsolutePathB));
        // Console.WriteLine(Path.Exists(@"Data\DataStorage\orders.json"));

        // Invalid characters
        var validFileName = "users.json";
        var invalidFileName = "?";

        // Console.WriteLine(validFileName.Any(@char => Path.GetInvalidFileNameChars().Contains(@char)));
        // Console.WriteLine(invalidFileName.Any(@char => Path.GetInvalidFileNameChars().Contains(@char)));

        // Extension
        var fileNameWithoutExtensionA = "Jonibek-Doniyorov-Resume";
        var fileNameWithoutExtensionB = "Jonibek-Doniyorov..Resume";
        var fileNameWithoutExtensionC = "Jonibek-Doniyorov-Resume.jpeg";
        var fileNameWithoutExtensionD = "D:\\";
        var fileNameWithoutExtensionE = "Jonibek-Doniyorov.Resume.jpg";
        var fileExtension = "pdf";

        Console.WriteLine(Path.ChangeExtension(fileNameWithoutExtensionA, fileExtension));
        Console.WriteLine(Path.ChangeExtension(fileNameWithoutExtensionB, fileExtension));
        Console.WriteLine(Path.ChangeExtension(fileNameWithoutExtensionC, fileExtension));
        Console.WriteLine(Path.ChangeExtension(fileNameWithoutExtensionD, fileExtension));
        Console.WriteLine(Path.ChangeExtension(fileNameWithoutExtensionE, fileExtension));

        Console.WriteLine(Path.HasExtension(fileNameWithoutExtensionA));
        Console.WriteLine(Path.HasExtension(fileNameWithoutExtensionB));
        Console.WriteLine(Path.HasExtension(fileNameWithoutExtensionC));
        Console.WriteLine(Path.HasExtension(fileNameWithoutExtensionD));
        Console.WriteLine(Path.HasExtension(fileNameWithoutExtensionE));

        Console.WriteLine(Path.GetExtension(fileNameWithoutExtensionE));

        // Path.IsPathFullyQualified()

        // File va Folder name

        Console.WriteLine(Path.GetFileName(fileRelativePath));
        Console.WriteLine(Path.GetFileNameWithoutExtension(fileRelativePath));
        Console.WriteLine(Path.GetDirectoryName(fileRelativePath));

        // Temp yoki random name

        Console.WriteLine(Path.GetTempPath());
        Console.WriteLine(Path.GetTempFileName());
        Console.WriteLine(Path.GetRandomFileName());
    }
}