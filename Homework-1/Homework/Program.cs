var orderOne = new

{

    orderId = 1,

    name = "Alice",

    productType = "smartphone",

    productPrice = 305.99,

    currency = "EUR",

    adress = "Moon Street, 10"

};

var orderTwo = new

{

    orderId = 2,

    name = "Tom",

    productType = "laptop",

    productPrice = 570.95,

    currency = "EUR",

    adress = "Terra Street, 17"

};

var orderTree = new

{

    orderId = 3,

    name = "Jack",

    productType = "keyboard",

    productPrice = 5.50,

    currency = "EUR",

    adress = "Green Walley, 32"

};

var orders = new

{

    Alice = orderOne,

    Tom = orderTwo,

    Jack = orderTree

};

string NAME_QUESTION = "What is your name?";

string getClientName()

{

    Console.WriteLine(NAME_QUESTION);

    return Console.ReadLine();

}
;

dynamic getOrderByName(string clientName)
{

    var prop = orders.GetType().GetProperty(clientName);

    if (prop == null)

    {

        throw new Exception($"Order for client '{clientName}' not found!");

    }

    return prop.GetValue(orders);

}

void showOrderInfo(dynamic orderInfo)

{

    Console.WriteLine($@"

        Order No {orderInfo.orderId}

        Client: {orderInfo.name}.

        Product: {orderInfo.productType}, price {orderInfo.productPrice} {orderInfo.currency}.

        Address: {orderInfo.adress}.

    ");

}
;

for (int i = 1; i < 4; i++)

{

    string name = getClientName()?.Trim();

    if (string.IsNullOrWhiteSpace(name)) break;

    object order = getOrderByName(name);

    showOrderInfo(order);

}
