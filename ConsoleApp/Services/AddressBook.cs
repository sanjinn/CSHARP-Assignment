using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    public class AddressBook
    {
        public List<Contact> ContactList { get; set; } = new List<Contact>();
    }
}
