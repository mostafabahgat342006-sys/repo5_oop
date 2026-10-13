namespace c__oop_ass5;

public struct DeliveryAddress
{
    public string City;
    public string Street;
    public int BuildingNumber;

    public DeliveryAddress(string c, string s, int b)
    {
        City = c;
        Street = s;
        BuildingNumber = b;

    }

    public string GetFullAddress()
    {
        return BuildingNumber + " " + Street + ", " + City;
    }

}
