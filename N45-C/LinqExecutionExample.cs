namespace N45_C;

public static class LinqExecutionExample
{
    public static void Execute()
    {
        // Evaluation - query har bitta element uchun hozir bajariladimi yoki keyinmi


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

        // info
        // metainfo

        // data
        // meta data

        // execution
        // meta execution = evaluation

        // execution
        // var result = query.ToList();

        // evaluation - biror ifodani qiymatga o'girish jarayoni, ifoda yoki query
        // var c = a + b;
        // var result = query.Where(x => condition).Where(x => condition);

        // Lazy evaluation - query ni execute qilganda faqat har bitta element uchun kerakli vaqtda bajariladi
        // Console.WriteLine("Lazy evaluation");
        // var elementA = query.First();

        foreach(var number in query)
            Console.WriteLine(number);

        // Eager evaluation - query ni execute qilganda hamma element uchun bajariladi
        // Console.WriteLine("Eager evaluation");
        // var elementB = query.Order().First();

        foreach(var number in query.Order())
            Console.WriteLine(number);
    }
}