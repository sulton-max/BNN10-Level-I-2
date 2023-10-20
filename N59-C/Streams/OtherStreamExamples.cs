using System.Diagnostics;
using System.IO;

namespace N59_C.Streams
{
    public static class OtherStreamExample
    {
        public static void ExecuteBufferedStream()
        {
            var fileStream = new FileStream("2023-10-19 19-15-55.mp4", FileMode.Open);

            var elapsedTimes = new List<long>();
            var timer = new Stopwatch();
            timer.Start();

            var buffer = new byte[fileStream.Length];
            for (var index = 0; index < 10; index++)
            {
                var content = fileStream.Read(buffer, 0, fileStream.Length);
            }

            timer.Stop();
            elapsedTimes.Add(timer.ElapsedMilliseconds / 10);

            Console.WriteLine("Elapsed times when using stream directly");
            foreach (var time in elapsedTimes)
                Console.WriteLine(time);
        }
    }
}