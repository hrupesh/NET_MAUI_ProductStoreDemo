using System;
using System.Collections.ObjectModel;

namespace MAUIPostFeed.Models;

public class Product
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int price { get; set; }
    public double discountPercentage { get; set; }
    public double rating { get; set; }
    public int stock { get; set; }
    public string brand { get; set; }
    public string category { get; set; }
    public string thumbnail { get; set; }
    public List<string> images { get; set; }
}

public class Products
{
    public ObservableCollection<Product> products { get; set; }
    public int total { get; set; }
    public int skip { get; set; }
    public int limit { get; set; }
}
