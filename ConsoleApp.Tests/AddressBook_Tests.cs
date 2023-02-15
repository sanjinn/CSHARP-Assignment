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
            // Arrange - f�rberedelse
            addressBook = new AddressBook();
            contact = new Contact();
        }

        [Fact]
        public void Should_Add_Contact_To_List()
        {
            // Act - utf�randet
            addressBook.ContactList.Add(contact);
            addressBook.ContactList.Add(contact);

            // Assert - utv�rdering
            Assert.Equal(2, addressBook.ContactList.Count);
        }

        [Fact]

        public void Should_Remove_Contact_From_List()
        {
            // Arrange - f�rberedelse
            addressBook.ContactList.Add(contact);
            addressBook.ContactList.Add(contact);

            // Act - utf�randet
            addressBook.ContactList.Remove(contact);

            // Assert - utv�rdering
            Assert.Single(addressBook.ContactList);
        }
    }
}