public class Address
{
    private string street;
    private string city;
    private string stateOrPrivince;
    private string country;

    public Address(string street, string city, string stateOrPrivince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrPrivince = stateOrPrivince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrPrivince}\n{country}";
    }
}