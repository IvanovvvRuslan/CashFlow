using CashFlowApi.Models;

namespace CashFlowApi.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Email { get; set; }
        public string? Description { get; set; }

        //Navigation properties
        public ICollection<Role> Roles { get; set; }
        public ICollection<UserPhone> Phones { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<Company> ContactCompanies { get; set; }
        public ICollection<Company> CompaniesOwner { get; set; }
    }
}
