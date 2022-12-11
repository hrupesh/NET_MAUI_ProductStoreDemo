using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using MAUIPostFeed.Models;

namespace MAUIPostFeed.Services;

public class ProductsService: IProductsRepository
{
    HttpClient client;
    JsonSerializerOptions serializerOptions;

    public ObservableCollection<Product> Products { get; set; }

    private static string BASE_URL { get; set; } = "https://dummyjson.com/";

    public ProductsService()
    {
        client = new HttpClient();
        serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<ObservableCollection<Product>> LoadProducts()
    {
        Products = new ObservableCollection<Product>();

        Uri uri = new Uri(string.Format($"{BASE_URL}products?limit=10", string.Empty));
        try
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Products temp = JsonSerializer.Deserialize<Products>(content, serializerOptions);
                Products = temp.products;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return Products;
    }
}

