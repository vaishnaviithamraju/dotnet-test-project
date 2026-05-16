namespace Files;

public class Country
{
    public Name Name { get; set; }
    public Dictionary<string, Currency> Currencies { get; set; }
    public List<string> Capital { get; set; }
}

public class Name
{
    public string Common { get; set; }
    public string Official { get; set; }
    public Dictionary<string, NativeNameItem> NativeName { get; set; }
}

public class NativeNameItem
{
    public string Official { get; set; }
    public string Common { get; set; }
}

public class Currency
{
    public string Name { get; set; }
    public string Symbol { get; set; }
}