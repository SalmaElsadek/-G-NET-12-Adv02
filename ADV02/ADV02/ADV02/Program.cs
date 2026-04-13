using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ADV02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductModel> catalog = new()
        {
            new ProductModel { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
            new ProductModel { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
            new ProductModel { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
            new ProductModel { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
            new ProductModel { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
            new ProductModel { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
            new ProductModel { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
            new ProductModel { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
            new ProductModel { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150,Stock=40 },
            new ProductModel { Id = 9, Name = "Jacket", Category = "Clothing", Price = 1520,Stock=15 }
        };
            //Task01
            // Uses Func<Product, bool> is good when doing a logic and need to return a value
            //1. All Electronics products 
            Console.WriteLine("\n--Electronics--");
            var electronics = SearchProducts(catalog, p=>p.Category== "Electronics");
            foreach (var p in electronics) Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

            //2. Products cheaper than $50
            Console.WriteLine("\n--- Under $50 ---");
            var cheaperProduct = SearchProducts(catalog, P => P.Price < 50);
            foreach (var p in cheaperProduct) Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

            //3. Products that are in stock (Stock > 0) 
            Console.WriteLine("\n--- In Stock ---");
            var inStock =SearchProducts(catalog, P => P.Stock>0);
            foreach (var p in inStock) Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");

            //4. Clothing products under $100
            Console.WriteLine("\n--- Clothing Under $100 ---");
            var clothes = SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            foreach(var p in clothes) Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");


            //Task03
            //3.1
            //Action<Product> is good for methods that return void(printing)
            Console.WriteLine("\n--- Short Report ---");
            Reports(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine("\n--- Detailed Report ---");
            Reports(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));


            //3.2
            //Func<Product, string> is good when doing a logic and need to return a value
            Console.WriteLine("\n--- Summary List ---");
            var summary=TransformProducts(catalog,p=>$"{p.Name}:(${p.Price})");
            foreach(var item in summary)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n--- Price Labels ---");
            var label=TransformProducts(catalog,p=>$"{p.Name} : {(p.Price>100?"Expensive!":"Affordable")}");
            foreach (var item in label)
            {
                Console.WriteLine(item);
            }


            //3.3
            //Predicate<Product> is always used to returns a boolean
            Console.WriteLine("\n--- Low-Stock Alert ---");
            var lowStock = FilterProducts(catalog, p => p.Stock < 20);
            foreach (var p in lowStock) Console.WriteLine($"[LOW STOCK] {p.Name}: only {p.Stock} left!");



        }
        //Task01
        public static List<ProductModel> SearchProducts(List<ProductModel> products, Func<ProductModel, bool>filtering)
        {
            List<ProductModel> result =new();
            foreach (var item in products)
            {
                if (filtering(item)) result.Add(item);
            }
            return result;
        }

        //Task 3.1
        public static void Reports(List<ProductModel> products, Action<ProductModel> report)
        {
            List<ProductModel> result =new();
            foreach (var item in products)
            {
                report(item);
            }
        }

        //Task 3.2
        public static List<string> TransformProducts(List<ProductModel> products, Func<ProductModel, string> transformer)
        {
            List<string> result = new();
            foreach (var item in products) {
                result.Add(transformer(item));
            }
            return result;
        }

        //Task 3.3
        public static List<ProductModel> FilterProducts(List<ProductModel> products, Predicate<ProductModel> filter)
        {
            List<ProductModel> result = new();
            foreach (var item in products)
            {
                if (filter(item)) result.Add(item);
            }
            return result;
        }
    }
}
