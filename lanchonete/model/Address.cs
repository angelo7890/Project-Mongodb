namespace lanchonete.model;

public class Address
{
    public string street { get; set; }
    public int number { get; set; }

    public Address(string street, int number)
    {
        this.street = street;
        this.number = number;
    }
}