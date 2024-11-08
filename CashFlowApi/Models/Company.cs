namespace CashFlowApi.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int PhoneAccountId { get; set; }
        public int EmailAccountId { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<UserCompany> UserCompanies { get; set; }
    }
}
