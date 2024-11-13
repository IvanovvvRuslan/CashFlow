namespace CashFlowApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int? ContactUserId { get; set; }
        public string? CompanyEmail { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Description { get; set; }

        //Navigation properties
        public User CompanyOwner { get; set; }
        public User ContactUser { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
