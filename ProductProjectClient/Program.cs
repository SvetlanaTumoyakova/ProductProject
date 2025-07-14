using ProductProjectClient.Model;
using System.Net.Http.Json;
using System.Text.Json;

class Program
{
    private static readonly HttpClient httpClient = new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7011/Product")
    };

    static async Task Main(string[] args)
    {
        await GetAllProducts();
        Console.WriteLine("");

        var newProduct = new Product
        {
            Id = 11,
            Name = "Bose QuietComfort 35 II",
            Description = "Wireless noise-cancelling headphones with superior sound quality"
        };

        await AddProduct(newProduct);
        Console.WriteLine(newProduct);
        Console.WriteLine("");
        await GetAllProducts();
        Console.WriteLine("");

        Console.WriteLine("Delete product id:5");
        Console.WriteLine("");
        await DeleteProductAsync(5);
        await GetAllProducts();
        Console.WriteLine("");

        Console.WriteLine("Edit product id:11");
        Console.WriteLine("");
        await EditProduct(11);
        await GetAllProducts();
        Console.WriteLine("");


        Console.WriteLine("Range product skip=2, take=2");
        Console.WriteLine("");
        await GetProductsRange(2, 2);
        Console.WriteLine("");

        Console.WriteLine("Range product skip=5, take=3");
        Console.WriteLine("");
        await GetProductsRange(5, 3);
        Console.WriteLine("");

        Console.ReadLine();
    }

    static async Task GetAllProducts()
    {
        try
        {
            var products = await httpClient.GetFromJsonAsync<List<Product>>("");

            if (products == null)
            {
                throw new InvalidOperationException("Couldn't upload products.");
            }

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
    static async Task AddProduct(Product newProduct)
    {
        var response = await httpClient.PostAsJsonAsync("", newProduct);
        var content = await response.Content.ReadAsStringAsync();
        var productFromBackEnd = JsonSerializer.Deserialize<Product>(content);
    }
    static async Task EditProduct(int productId)
    {
        var newProduct = await httpClient.GetFromJsonAsync<Product>($"product/{productId}");
        newProduct.Name = "Sony WH-1000XM4";
        var response = await httpClient.PutAsJsonAsync<Product>("", newProduct);
    }
    static async Task DeleteProductAsync(int productId)
    {
        var response = await httpClient.DeleteAsync($"product/{productId}");

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("The product was successfully deleted.\n");
        }
        else
        {
            Console.WriteLine($"Error when deleting a product: {response.StatusCode}");
        }
    }
    static async Task GetProductsRange(int skip, int take)
    {
        var products = await httpClient.GetFromJsonAsync<IEnumerable<Product>>($"product/{skip}/{take}");

        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}
