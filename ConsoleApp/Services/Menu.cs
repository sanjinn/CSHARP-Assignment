using ConsoleApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Services
{
    internal class Menu
    {
        private List<Contact> contacts = new List<Contact>();
        private FileManager file = new FileManager();
        // asdasd
        public string FilePath { get; set; } = null!;

        public void OptionsMenu()
        {
            Console.WriteLine("Välkommen till Adressboken");
            Console.WriteLine("1. Skapa en kontakt");
            Console.WriteLine("2. Visa alla kontakter");
            Console.WriteLine("3. Visa en specifik kontakt");
            Console.WriteLine("4. Ta bort en specifik kontakt");
            Console.WriteLine("Välj ett av alternativen ovan: ");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1": OptionOne(); break;
                case "2": OptionTwo(); break;
                case "3": OptionThree(); break;
                case "4": OptionFour(); break;
            }
        }

        private void OptionOne()
        {
            Console.Clear();
            Console.WriteLine("Skapa en ny kontakt.");

            Contact contact = new Contact();

            Console.WriteLine("Ange Förnamn: ");
            contact.FirstName = Console.ReadLine() ?? "";
            Console.WriteLine("Ange Efternamn: ");
            contact.LastName = Console.ReadLine() ?? "";
            Console.WriteLine("Ange E-postadress: ");
            contact.Email = Console.ReadLine() ?? "";
            Console.WriteLine("Ange Telefonnummer: ");
            contact.Phone = Console.ReadLine() ?? "";
            Console.WriteLine("Ange Adress: ");
            contact.Address = Console.ReadLine() ?? "";

            contacts.Add(contact);

            file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
        }

        private void OptionTwo()
        {
            Console.Clear();

            if (contacts.Count < 1)
            {
                Console.WriteLine("Finns inga kontakter i listan.");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(contact.DisplayName);
                }
            }

            Console.ReadLine();
        }

        private void OptionThree()
        {
            Console.Clear();

            if (contacts.Count < 1)
            {
                Console.WriteLine("Finns inga kontakter att visa.");
            }
            else
            {
                Console.WriteLine("Förnamn: " + contacts[0].FirstName);
                Console.WriteLine("Efternamn: " + contacts[0].LastName);
                Console.WriteLine("E-postadress: " + contacts[0].Email);
                Console.WriteLine("Telefonnummer: " + contacts[0].Phone);
                Console.WriteLine("Adress: " + contacts[0].Address);
            }

            Console.ReadLine();
        }

        private void OptionFour()
        {
            Console.Clear();

            if (contacts.Count < 1)
            {
                Console.WriteLine("Finns inga kontakter i listan.");
            }
            else
            {
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.WriteLine(i + ". " + contacts[i].DisplayName);
                }
                Console.WriteLine("Välj vilken användare du vill ta bort genom att ange nummer.");

                int inputInt = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Är du säker på att du vill ta bort denna användare? (Y/N)");
                string confirm = Console.ReadLine();

                if (confirm.ToUpper() == "Y")
                {
                    contacts.RemoveAt(inputInt);
                    file.Save(FilePath, JsonConvert.SerializeObject(new { contacts }));
                    Console.WriteLine("Användaren har tagits bort.");
                }
            }

            Console.ReadLine();
        }
    }
}
