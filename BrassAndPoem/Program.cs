
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Trumpet",
        Price = 299.99M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Trombone",
        Price = 599.99M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Tuba",
        Price = 799.99M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "The Waste Land",
        Price = 19.99M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Milk and Honey",
        Price = 9.99M,
        ProductTypeId = 2
    },
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Brass",
        Id = 1
    },

    new ProductType()
    {
        Title = "Poem",
        Id = 2
    },
};

//put your greeting here

string greeting = "Welcome to Brass and Poem! We serve your creative needs.";
Console.WriteLine(greeting);
DisplayMenu();


//implement your loop here

void DisplayMenu()
{
    string choice = null;
    while (choice != "5")
    {
        Console.WriteLine(@"Please select an option:
                            1. Display all products
                            2. Delete a product
                            3. Add a new product
                            4. Update product properties
                            5. Exit");

        choice = Console.ReadLine();
        if (choice == "1")
        {
            DisplayAllProducts(products, productTypes);
        }
        else if (choice == "2")
        {
            DeleteProduct(products, productTypes);
        }
        else if (choice == "3")
        {
            AddProduct(products, productTypes);
        }
        else if (choice == "4")
        {
            UpdateProduct(products, productTypes);
        }
        else if (choice == "5")
        {
            Console.WriteLine("Exit Program");
        }
        else
        {
            Console.WriteLine("Invalid entry. Please enter a valid number.");
        }
    }
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        var productType = productTypes.FirstOrDefault(p => p.Id == products[i].ProductTypeId);
        Console.WriteLine($"{i + 1}. Product: {products[i].Name}, Type: {productType?.Title}, Price: ${products[i].Price}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Please enter the number of which product you would like to remove:");
    int selectedProduct;
    if(int.TryParse(Console.ReadLine(), out selectedProduct) && selectedProduct > 0 && selectedProduct <= products.Count)
    {
        products.RemoveAt(selectedProduct - 1);
    }
    else
    {
        Console.WriteLine("Invalid entry. Please enter a valid number.");
    }
    Console.WriteLine("Remaining Product:");
    DisplayAllProducts(products, productTypes);

}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter the name of the product:");
    string name = Console.ReadLine();

    Console.WriteLine("Enter the price of the product:");
    decimal price = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Product Types:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
    }
    Console.WriteLine("Please select the product type:");
    int id = int.Parse(Console.ReadLine());

    Product newProduct = new Product()
    {
        Name = name,
        Price = price,
        ProductTypeId = id
    };
    products.Add(newProduct);
    Console.WriteLine("Your product has been added!");
}


void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Please enter the number of the product you would like to update:");
    int selectedProduct;
    if (int.TryParse(Console.ReadLine(), out selectedProduct) && selectedProduct > 0 && selectedProduct <= products.Count)
    {
        var product = products[selectedProduct - 1];
        var productTypeName = productTypes.FirstOrDefault(p => p.Id == product.ProductTypeId);
        Console.WriteLine($@"Here are the current details of the product you chose:
                                Name: {product.Name}
                                Price: {product.Price}
                                Product Type: {productTypeName?.Title}");
        Console.WriteLine("Enter the new product name (leave blank to keep current):");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName) )
        {
            product.Name = newName;
        }

        Console.WriteLine("Enter the new product price (leave blank to keep current):");
        string newPriceInput = Console.ReadLine();
        if (decimal.TryParse(newPriceInput, out decimal newPrice))
        {
            product.Price = newPrice;
        }

        Console.WriteLine("Select a new product type (leave blank to keep current):");
        foreach (ProductType productType in productTypes)
        {
            Console.WriteLine($"{productType.Id}. {productType.Title}");
        }
        string newProductTypeIdInput = Console.ReadLine();
        if (int.TryParse(newProductTypeIdInput, out int newProductTypeId) && productTypes.Any(pt => pt.Id == newProductTypeId))
        {
            product.ProductTypeId = newProductTypeId;
        }
        Console.WriteLine("Product successfully updated!");
    }
    else
    {
        Console.WriteLine("Product not found.");
    }
}

// don't move or change this!
public partial class Program { }