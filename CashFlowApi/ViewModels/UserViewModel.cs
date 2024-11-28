using CashFlowApi.Models;

namespace CashFlowApi.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
    }
}
