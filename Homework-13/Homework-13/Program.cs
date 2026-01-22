using Homework_13;

Account heikkisAccount = new Account("Heikki's account", 100.00m);
Account heikkisSwissAccount = new Account("Heikki's account in Switzerland", 1000000.00m);


heikkisAccount.Withdrawal(20);
Console.WriteLine($"The balance of {heikkisAccount.Name} account is now: {heikkisAccount.Amount}");
heikkisSwissAccount.Deposit(200);
Console.WriteLine($"The balance of {heikkisSwissAccount.Name} account is now: {heikkisSwissAccount.Amount}");
