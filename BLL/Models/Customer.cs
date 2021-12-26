using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MCustomer
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PersonType { get; set; }
        public MCustomer() { }
        public MCustomer(Customer c)
        {
            Id = c.id;
            Phone = c.phone;
            Login = c.login;
            Password = c.password;
            Name = c.name;
            PersonType = c.person_type;
        }
    }
}
