public static class Money
{
    private static int sandDollars = 0;

    public delegate void MoneyChangeHandler(int newValue);
    public static event MoneyChangeHandler onChange;

    public static int GetMoney() => sandDollars;
    public static void SetMoney(int dollars)
    {
        if (dollars <= 0)
        {
            sandDollars = 0;
        }
        else
        {
            sandDollars = dollars;
        }
        onChange?.Invoke(sandDollars);
    }
    public static void AddMoney(int dollars) => SetMoney(sandDollars + dollars);
}
