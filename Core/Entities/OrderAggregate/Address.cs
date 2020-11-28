namespace Core.Entities.OrderAggregate
{
    // Tied to Order
    public class Address
    {
        public Address()
        {
        }

        public Address(string firstName, string lastName, string street, 
            string city, string state, string zip)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            Zip = zip;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}