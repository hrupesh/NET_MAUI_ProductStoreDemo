using System;
using System.Collections.ObjectModel;
using MAUIPostFeed.Models;

namespace MAUIPostFeed.Services
{
	public interface IProductsRepository
	{
		Task<ObservableCollection<Product>> LoadProducts();
	}
}


