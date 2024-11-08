namespace CashFlowApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        //public int RoleId { get; set; }
        public int EmailAccountId { get; set; }
        public int PhoneAccountId { get; set; }
        public string Description { get; set; }

        public ICollection<Role> Roles { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserCompany> UserCompanies { get; set; }
    }
}
