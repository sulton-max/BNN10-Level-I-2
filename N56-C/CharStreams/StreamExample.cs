namespace N56_C.CharStreams;

public static class StreamExample
{
    public static void Execute()
    {
        // using console as stream
        // Standard output - ctd:out
        // Standard input - ctd:in
        Write(Console.OpenStandardOutput());

        // using file as stream
        Write(File.OpenWrite("stream.txt"));
    }

    private static void Write(Stream stream)
    {
        using var streamWriter = new StreamWriter(stream);
        streamWriter.WriteLine("Hello streams!");

        streamWriter.Flush();
    }
}