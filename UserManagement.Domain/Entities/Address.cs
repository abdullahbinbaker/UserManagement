namespace UserManagement.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string HouseNo { get; set; }
        public string Country { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
