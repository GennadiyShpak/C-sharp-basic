namespace Homework_13;

internal class Account
{
    public decimal Amount { get; private set; } = 0;
    public string Name { get; private set; } = string.Empty;

    public Account (string name, decimal amount)
    {
        Amount = amount;
        Name = name;
    }

    public void Withdrawal(decimal amount) {
        if (!IsWithdrawalPossible(amount)) {
            ShowError();
        } else
        {
            Amount -= amount;
            ShowSuccess();
        }
        
    }

    public void Deposit(decimal amount)
    {
        if (!IsDepositPossible(amount))
        {
            ShowError();
        } else
        {
            Amount += amount;
            ShowSuccess();
        }
        
    }

    private bool IsWithdrawalPossible(decimal amount)
    {
        return Amount >= amount && amount >= 0;
    }

    private bool IsDepositPossible(decimal amount)
    {
        return amount > 0;
    }

    private void ShowSuccess()
    {
        Console.WriteLine("Your operational was success!");
    }

    private void ShowError()
    {
        Console.WriteLine("You provided incorrect ammountm please try again");
    }
}
