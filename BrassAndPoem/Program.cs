//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Trumpet",
        Price = 789.98m,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Tuba",
        Price = 1288.98m,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Trombone",
        Price = 1111.99m,
        ProductTypeId = 1,
    },
    new Product()
    {
        Name = "Poet Poet",
        Price = 29.99m,
        ProductTypeId = 2,
    },
    new Product()
    {
        Name = "100 Poems That Will Make You Cry",
        Price = 19.99m,
        ProductTypeId = 2,
    }
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "brass",
        Id = 1
    },
    new ProductType()
    {
        Title = "poem",
        Id = 2
    }
};
//put your greeting here

Console.Write("Welcome to the Brass & Poem shop!");
DisplayMenu();
//implement your loop here
int ?userChoice = null;
while (userChoice != 6)
{
    userChoice = int.Parse(Console.ReadLine());
    switch(userChoice)
    {
        case 1:
        DisplayMenu();
        break;
        case 2:
        DisplayAllProducts(products, productTypes);
        break;
        case 3:
        DeleteProduct(products, productTypes);
        break;
        case 4:
        AddProduct(products, productTypes);
        break;
        case 5:
        UpdateProduct(products, productTypes);
        break;
        default:
        break;
    }
}

void DisplayMenu()
{
    Console.WriteLine("");
    Console.WriteLine("Select an option from the menu below:");
    Console.WriteLine("1. Display Menu");
    Console.WriteLine("2. Display All Products");
    Console.WriteLine("3. Delete Product");
    Console.WriteLine("4. Add Product");
    Console.WriteLine("5. Update Product");
    Console.WriteLine("6. Exit");
    Console.WriteLine("");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    List<Product> brassProducts = products.Where(product => product.ProductTypeId == 1).ToList();
    List<Product> poetryProducts = products.Where(product => product.ProductTypeId == 2).ToList();
    Console.WriteLine("");
    Console.WriteLine("Brass products:");
    for (int i = 0; i < brassProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {brassProducts[i].Name}: ${brassProducts[i].Price}");
    }
    Console.WriteLine("");
    Console.WriteLine("Poetry products:");
    for (int i = 0; i < poetryProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {poetryProducts[i].Name}: ${poetryProducts[i].Price}");
    }
    Console.WriteLine("");
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Choose a product that you want to delete:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    int userChoice = int.Parse(Console.ReadLine());
    try
    {
        products.Remove(products[userChoice - 1]);
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
        Console.WriteLine($"Please choose a proper option from the list");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    int productTypeChoice = 0;
    string productName = null;
    decimal productPrice = 0;

    Console.WriteLine("Enter the name of the product that you would like to add:");
    productName = Console.ReadLine();

    Console.WriteLine("Enter the price of the item:");
    productPrice = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Enter a number for the product type:");
    Console.WriteLine("1. Brass");
    Console.WriteLine("2. Poetry");
    productTypeChoice = int.Parse(Console.ReadLine());

    Product newProduct = new Product();
    newProduct.Name = productName;
    newProduct.Price = productPrice;
    newProduct.ProductTypeId = productTypeChoice;

    products.Add(newProduct);

}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Choose an item that you would like to update");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    int userChoice = int.Parse(Console.ReadLine());
    Product itemToUpdate = products[userChoice - 1];

    Console.WriteLine("Please enter a new name for the item (leave blank if you don't want to change it):");
    string newName = Console.ReadLine();

    Console.WriteLine("Please enter a new price for the item (leave blank if you don't want to change it):");
    string newPrice = Console.ReadLine();

    Console.WriteLine("Please enter the product type of the item (leave blank if you don't want to change it):");
    Console.WriteLine("1 = Brass");
    Console.WriteLine("2 = Poetry");
    string newProductTypeId = Console.ReadLine();

    if (!string.IsNullOrEmpty(newName))
    {
        itemToUpdate.Name = newName;
    }
    if (!string.IsNullOrEmpty(newPrice))
    {
        itemToUpdate.Price = decimal.Parse(newPrice);
    }
    if (newProductTypeId == 1.ToString() || newProductTypeId == 2.ToString())
    {
        itemToUpdate.ProductTypeId = int.Parse(newProductTypeId);
    }
}

// don't move or change this!
public partial class Program { }