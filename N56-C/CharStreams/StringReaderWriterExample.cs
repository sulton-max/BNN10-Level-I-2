namespace N56_C.CharStreams;

public static class StringReaderWriterExample
{
    public static void Execute()
    {
        // var test = new StringWriter()

        // var binary = new BinaryReader();



        var value = "";

        var streamReader = new StringReader(value);
        var span = new Span<char>();

        streamReader.ReadBlock(span);

    }
}