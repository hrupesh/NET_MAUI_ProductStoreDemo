using System.Collections.ObjectModel;
using MAUIPostFeed.Services;

namespace MAUIPostFeed.Models
{
    public class AllProducts
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
        readonly IProductsRepository ProductsRepository = new ProductsService();

        public AllProducts() =>
            LoadProducts();

        public async void LoadProducts()
        {
            ObservableCollection<Product> temp = await ProductsRepository.LoadProducts();
            for (int i = 0; i < temp.Count; i++)
            {
                Products.Add(temp[i]);
            }
        }
    }
}

