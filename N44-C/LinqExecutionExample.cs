namespace N44_C;

public static class LinqExecutionExample
{
    public static void Execute()
    {
        // Execution - LINQ ni bajarilish jarayoni

        // 1. Deferred Execution
        // 2. Immediate Execution
        // 3. Mixed Execution

        var collection = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };

        // Deferred Execution - query, iterator -
        var query = collection.Select(x =>
        {
            Console.WriteLine($"Processing number {x}");
            return x * 2;
        });

        // Immediate Execution - conversion - ToList, ToArray, ToDictionary, ToLookup, ToHashSet
        var result = query.ToList();

        // Mixed execution -
        var mixedQuery = query.Take(3);

        // Evaluation - linqdagi har bitta element uchun queryni bajarilishi

        // Lazy evaluation -
        // Eager evaluation -


    }
}