using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.DataLayer.Entities
{
    public class UsersEntity
    {
        public int Id { get; set; }
        public Guid PublicId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
