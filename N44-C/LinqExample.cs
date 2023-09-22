using System.Text.Json;

namespace N44_C;

public class LinqExample
{
    public static void Execute()
    {
        // SelectMany
        var numbers = new List<int>
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10
        };

        var accessory = new ProductType(500, "Accessory", "something");
        var laptop = new ProductType(3000, "Laptop", "something");
        var beverages = new ProductType(5, "Beverages", "something");

        var productsTypes = new List<ProductType>()
        {
            accessory,
            laptop,
            beverages
        };

        accessory.Products.Add(new("", "", 30, accessory));
        accessory.Products.Add(new("", "", 45, accessory));
        accessory.Products.Add(new("", "", 67, accessory));


        // v1 - kolleksiya ichida kolleksiya bo'lsa shu objectni va kolleksiya ichidagi har bitta elementni guruhlashga yordam beradi
        // product types -> product type -> products -> product
        // select many -> product type -> product
        var resultMany = productsTypes.SelectMany(productType => productType.Products,
            (productType, product) => new
            {
                product.Price,
                productType.RecommendedPrice
            });

        Console.WriteLine(JsonSerializer.Serialize(resultMany));

        // v2 - kolleksiya - kollesiya
        // array of products 10 tadan -> array of product -> product, ex 10 tadan 5 ta array
        // select many -> array of products - 1 ta array 50 elementi bor
        var numbersSplitted = numbers.Chunk(3);
        var value = numbersSplitted.SelectMany(x => x.Select(y => y));
    }
}

public class ProductType
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Description { get; set; }

    public List<Product> Products { get; set; } = new();
    public int RecommendedPrice { get; set; }

    public ProductType(int recommendedPrice, string name, string description)
    {
        Id = Guid.NewGuid();
        RecommendedPrice = recommendedPrice;
        Name = name;
        Description = description;
    }
}

  public class Product
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public ProductType Type { get; set; }
        public int Price { get; set; }

        public Product(string brand, string model, int price, ProductType type)
        {
            Id = Guid.NewGuid();
            Brand = brand;
            Model = model;
            Price = price;
            Type = type;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Brand: {Brand}, Model: {Model}, Price: {Price}";
        }
    }