namespace CashFlowApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int UserEmail { get; set; }
        public string? Description { get; set; }

        //Navigation properties
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection <UserPhone> UserPhones { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Company> ContactCompanies { get; set; }
        public ICollection<Company> CompaniesOwner { get; set; }
    }
}
