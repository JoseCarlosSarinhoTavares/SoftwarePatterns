namespace SoftwarePatterns.Creational.Builder.CustomerProfile
{
    public class SimpleCustomer
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string PhoneNumber { get; private set; }

        public SimpleCustomer(
            string name,
            string address,
            string postalCode,
            string city,
            string country,
            string phoneNumber)
        {
            Name = name;
            Address = address;
            PostalCode = postalCode;
            City = city;
            Country = country;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return
                $"""
                ==============================
                       CLIENTE SIMPLES
                ==============================
                Nome      : {Name}
                Endereço  : {Address}
                CEP       : {PostalCode}
                Cidade    : {City}
                País      : {Country}
                Telefone  : {PhoneNumber}
                """;
        }
    }
}