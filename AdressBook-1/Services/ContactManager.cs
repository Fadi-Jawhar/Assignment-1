using AdressBook_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook_1.Services
{
    internal static class ContactManager
    {
        //Innhållet/Alterantiven i menylistan
        public static string OptionsMenu()
        {
            Console.Clear();
            Console.WriteLine("###### ADDRESS BOOK ######");
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. View Contacts");
            Console.WriteLine("3. Search For A Contact");
            Console.WriteLine("4. Update A Contact");
            Console.WriteLine("5. Remove Contact");
            Console.WriteLine("6. Exit Address Book");
            Console.Write("Choose An Option: ");
            return Console.ReadLine() ?? "";
        }

        //Lägga till en kontakt
        public static Contact AddContact()
        {
            var contact = new Contact();

            try
            {
                Console.Clear();
                Console.WriteLine("######  ADD NEW CONTACT  ######");

                Console.Write("First Name: ");
                contact.FirstName = Console.ReadLine() ?? "";

                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine() ?? "";

                Console.Write("Address: ");
                contact.Address = Console.ReadLine() ?? "";

                Console.Write("Postal Code: ");
                contact.PostalCode = Console.ReadLine() ?? "";

                Console.Write("City: ");
                contact.City = Console.ReadLine() ?? "";

                Console.Write("Phone Number:");
                contact.PhoneNumber = Console.ReadLine() ?? "";

                Console.Write("Email: ");
                contact.Email = Console.ReadLine() ?? "";

               

                return contact;
            }
            catch
            {
                Console.WriteLine("Invalid Info Added.");
                Console.ReadKey();
            }

            return null!;
        }

        //Visa alla sparade kontakter
        public static void ViewListMenu(List<Contact> list)
        {
            Console.Clear();
            Console.WriteLine("######  VIEW ADDRESS BOOK  ######");

            foreach (var contact in list)
            {
                Console.WriteLine($"{contact.Id}\n - {contact.FirstName}\n - {contact.LastName}\n - {contact.Address}\n - {contact.PostalCode}\n - {contact.City}\n - {contact.PhoneNumber}\n - {contact.Email}\n");
            }

            Console.ReadKey();
        }

        //Sök efter en specifik kontakt
        public static void search(List<Contact> list)
        {
            Console.Clear();
            Console.WriteLine("######  SEARCH FOR A CONTACT  ######");
            bool found = false;

            Console.Write("Enter The Name Of The Contact You Want To Search For: ");
            string name = Console.ReadLine();

            foreach (var contact in list)
            {
                if(contact.FirstName.ToLower() == name.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine($"{contact.Id}\n - {contact.FirstName}\n - {contact.LastName}\n - {contact.Address}\n - {contact.PostalCode}\n - {contact.City}\n - {contact.PhoneNumber}\n - {contact.Email}");
                    found = true;
                    break;                    
                }
            }

            if (!found)
                Console.WriteLine("\nContact Not Found!");
                Console.ReadKey();
            
        }

        //Uppdatera en kontakt
        public static void update(List<Contact> list)
        {
            Console.Clear();
            Console.WriteLine("######  UPDATE A CONTACT  ######");
            bool found = false;

            Console.Write("Enter The Name Of The Contact You Want To Update: ");
            string name = Console.ReadLine();

            foreach (var contact in list)
            {
                if (contact.FirstName.ToLower() == name.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine($"{contact.Id}\n - {contact.FirstName}\n - {contact.LastName}\n - {contact.Address}\n - {contact.PostalCode}\n - {contact.City}\n - {contact.PhoneNumber}\n - {contact.Email}\n");
                    found = true;

                    Console.WriteLine("Enter New Details: ");
                    Console.Write("First Name: ");
                    contact.FirstName = Console.ReadLine() ?? "";

                    Console.Write("Last Name: ");
                    contact.LastName = Console.ReadLine() ?? "";

                    Console.Write("Address: ");
                    contact.Address = Console.ReadLine() ?? "";

                    Console.Write("Postal Code: ");
                    contact.PostalCode = Console.ReadLine() ?? "";

                    Console.Write("City: ");
                    contact.City = Console.ReadLine() ?? "";

                    Console.Write("Phone Number:");
                    contact.PhoneNumber = Console.ReadLine() ?? "";

                    Console.Write("Email: ");
                    contact.Email = Console.ReadLine() ?? "";
                    break;
                }
            }

            if (!found)
                Console.WriteLine("\nContact Not Found!");
            else
                Console.WriteLine("\nThe Contact Has Been Updated");
            Console.ReadKey();
        }
        
        //Radera en kontakt
        public static void RemoveMenu(ref List<Contact> list)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("######  REMOVE CONTACT  ######");

                Console.Write("Contact Id: ");
                var id = Guid.Parse(Console.ReadLine());

                list = list.Where(x => x.Id != id).ToList();
                Console.WriteLine("\nContact Deleted");
                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Invalid Id selected.");
                Console.ReadKey();
            }

        }

       

    }
    
}
