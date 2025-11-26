public class Address
{
    private string _street;
    private string _city;
    private string _stateOrPrivince;
    private string _country;

    public string Street
    {
        get {return _street;}
        set {_street = value;}
    }

    public string City
    {
        get {return _city;}
        set {_city = value;}
    }

    public string StateOrProvince
    {
        get {return _stateOrPrivince;}
        set {_stateOrPrivince = value;}
    }

    public string Country
    {
        get {return _country;}
        set {_country = value;}
    }

    public Address(string street, string city, string stateOrPrivince, string country)
    {
       _street = street;
       _city = city;
       _stateOrPrivince = stateOrPrivince;
       _country = country; 
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrPrivince}\n{_country}";
    }
}