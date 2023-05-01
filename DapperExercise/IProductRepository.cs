using System;
namespace DapperExercise
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetAllProducts();

		public void CreateProduct(string name, double price, int categoryID);

		public void UpdateProduct(int productID, string updateedName);

		public void DeleteProduct(int productID);
	}
}

