using CashFlowApi.Enum;

namespace CashFlowApi.Models
{
    public class UserPhone
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }
        public string? Description { get; set; }

        //Navigation properties
        public User PhoneUser { get; set; }
    }
}
