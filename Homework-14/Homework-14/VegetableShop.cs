namespace Homework_14;

internal class VegetableShop
{
    private List<Product> ProductList = new List<Product>();
    private decimal TotalProductsPrice = 0;

    public void AddProducts(List<Product> productList)
    {
        ProductList = productList;
    }

    public void PrintProductsInfo()
    {
        foreach (Product product in ProductList)
        {
            product.ShowProductInfo();
            AddToTotalPrice(product.GetPrice());
        }

        Console.WriteLine($"Total products price: {TotalProductsPrice}");
    }

    private void AddToTotalPrice(decimal productPrice)
    {
        TotalProductsPrice += productPrice;
    }
}