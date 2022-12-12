namespace Shop.Models
{
    public class ShopDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
