using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DapperExercise;

class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        string connString = config.GetConnectionString("DefaultConnection");

        IDbConnection conn = new MySqlConnection(connString);

        var repo = new DapperProductRepository(conn);

        var departments = repo.GetAllProducts();

        Console.WriteLine("All Departments\n");
        foreach (var dept in departments)
        {
            Console.WriteLine(dept.Name);
        }

        Console.WriteLine("Please enter a new Department name");
        var newDeptName = Console.ReadLine();


        var instance = new DapperDepartmentRepository(conn);
        instance.InsertDepartment(newDeptName);

        //Get updated Dept list
        departments = repo.GetAllProducts();

        Console.WriteLine("All Departments\n");
        foreach (var dept in departments)
        {
            Console.WriteLine(dept.Name);
        }

        var prodRepo = new DapperProductRepository(conn);

        var products = prodRepo.GetAllProducts();

        Console.WriteLine("All Products\n");
        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
        }
        Console.WriteLine();

        Console.WriteLine("What is the name of the new product?");
        var prodName = Console.ReadLine();

        Console.WriteLine("What is its price?");
        var prodPrice = double.Parse(Console.ReadLine());

        Console.WriteLine("What is its category ID?");
        var prodCat = int.Parse(Console.ReadLine());

        prodRepo.CreateProduct(prodName, prodPrice, prodCat);

        products = prodRepo.GetAllProducts();

        Console.WriteLine("All Products\n");
        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
        }
        Console.WriteLine();

        //Update Product
        Console.WriteLine("Enter a ProductID to update");
        var prodID = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the updated name");
        var updatedName = Console.ReadLine();

        prodRepo.UpdateProduct(prodID, updatedName);

        products = prodRepo.GetAllProducts();

        Console.WriteLine("All Products\n");
        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
        }
        Console.WriteLine();

        //Delete
        Console.WriteLine("What is the ProductID you want to delete?");
        prodID = int.Parse(Console.ReadLine());

        prodRepo.DeleteProduct(prodID);

        products = prodRepo.GetAllProducts();
        Console.WriteLine("All Products\n");
        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} {prod.Name} {prod.Price}");
        }
        Console.WriteLine();

    }
}

