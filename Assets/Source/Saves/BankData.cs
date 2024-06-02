
public class BankData
{
    public int MoneyBalance { get; private set; }
    public int DiamondBalance { get; private set; }

    public BankData(Bank bank)
    {
        MoneyBalance = bank.Money;
        DiamondBalance = bank.Diamond;
    }
}
