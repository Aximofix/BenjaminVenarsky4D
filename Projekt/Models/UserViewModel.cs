using Common.DTO;

namespace Projekt.Models
{
    public class UserViewModel
    {
        public List<UserDTO> userList { get; set; }
        public List<UserDTO> selected { get; set; } = new List<UserDTO>();
    }
}
