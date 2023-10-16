using System.Text;

namespace N56_C.Files;

public static class FileExample
{
    public static void Execute()
    {
        var fileAbsolutePath = "2023-07-26 17-36-29.mp4";

        var tempFileName = "temp.txt";

        #region Create - faylni yaratish

        // using var fileStream = File.Create(tempFileName, 2, FileOptions.DeleteOnClose);
        //
        // var buffer = "Hello Files"u8.ToArray();
        // fileStream.Write(buffer, 3, buffer.Length - 3);
        //
        // fileStream.Flush();
        // fileStream.Close();

        #endregion

        #region Encoding - faylga yozish uchun formatni belgilash

        // using var fileStream = File.Create(tempFileName);
        //
        // var buffer = Encoding.UTF8.GetBytes("Hello files 😁😁");
        // fileStream.Write(buffer, 0, buffer.Length);
        //
        // fileStream.Close();
        //
        // var test = File.Open(tempFileName, FileMode.Open);
        //
        // var content = new byte[test.Length];
        // test.Read(content, 0, (int)test.Length);
        //
        // var testValue = Encoding.UTF8.GetString(content);
        // test.Close();

        #endregion

        #region Open - faylni ochish

        // File Mode - faylni yangisini ochish, ichidagi contentni ustiga yoki davomiga yozishga belgilaydi

        // Truncate - qachonki bor faylni contenti formati bizaga kerak bo'lmasa shunchaki o'chirib yozib ketsak
        // using var fileStream = File.Open(tempFileName, FileMode.Truncate);
        // var buffer = Encoding.UTF8.GetBytes("Hello files 😁😁 opening and writing to file");
        // fileStream.Write(buffer, 0, buffer.Length);

        // Append - bor faylni davomiga yozadi
        // using var fileStream = File.Open(tempFileName, FileMode.Append);
        // var buffer = Encoding.UTF8.GetBytes("Hello files 😁😁 opening and writing to file");
        // fileStream.Write(buffer, 0, buffer.Length);

        // var fileStream = File.Open(tempFileName, FileMode.Open,

        #endregion

        #region

        // File copy
        // File.Copy(tempFileName, "temp2.txt");

        // File.Copy(tempFileName, "temp3.txt", true);

        // Delete
        // File.Delete(tempFileName);

        #endregion

        File.Replace(tempFileName, "temp3.txt", "backup.txt");

        //
        // File.Create(tempFileName, 40960, FileOptions.SequentialScan);
        //
        // File.Create(tempFileName, 40960, FileOptions.WriteThrough);
        //
        // File.Create(tempFileName, 40960, FileOptions.DeleteOnClose);


        // var stream = File.Open(fileAbsolutePath, FileMode.Open);
        //
        // var fileContent = stream.Read
        //
        // // stream.Read()
        //
        //
        //
        // // fileStream.Write();
        //
        // fileStream.Flush();
        //
        // fileStream.Close();
        //
        // File.Copy();

        //
        // File.Encrypt("file.txt");
    }

    // public static void Write(Stream stream, string content)
    // {
    //     stream.Write();
    // }
}