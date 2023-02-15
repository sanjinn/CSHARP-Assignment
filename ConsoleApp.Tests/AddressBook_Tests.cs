using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Tests
{
    public class AddressBook_Tests
    {
        private AddressBook addressBook;
        Contact contact;

        public AddressBook_Tests()
        {
            // Arrange - förberedelse
            addressBook = new AddressBook();
            contact = new Contact();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            // Act - utförandet
            addressBook.ContactList.Add(contact);
            addressBook.ContactList.Add(contact);

            // Assert - utvärdering
            Assert.Equal(2, addressBook.ContactList.Count);
        }

        [Fact]

        public void Should_Remove_Contact_From_List()
        {
            // Arrange - förberedelse
            addressBook.ContactList.Add(contact);
            addressBook.ContactList.Add(contact);

            // Act - utförandet
            addressBook.ContactList.Remove(contact);

            // Assert - utvärdering
            Assert.Single(addressBook.ContactList);
        }
    }
}