namespace CashFlowApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public int? ContactUserId { get; set; }
        public User ContactUser { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }

        //Navigation properties
        public ICollection<User> Users { get; set; }
    }
}
