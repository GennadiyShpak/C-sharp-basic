using Homework_14;

var products = new List<Product>()
{
    new Carrot(15),
    new Potato(20, 4),
    new Cucumber(14, 2)
};


VegetableShop shop = new VegetableShop();
shop.AddProducts(products);


shop.PrintProductsInfo();


// Output:
// Product: Carrot, Price: 15
// Product: Potato, Price: 20, Count: 4, Total price: 80
// Product: Cucumber, Price: 14, Count: 2, Total price: 28
// Total products price: 123
