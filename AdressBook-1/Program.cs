using AdressBook_1.Models;
using AdressBook_1.Services;
using Newtonsoft.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

var contacts = new List<Contact>();

//json filsökväg
var filePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\AddressBook-1.json";

// Läs kontakterna från en fil och lägga till i listan
contacts = JsonConvert.DeserializeObject<List<Contact>>(FileManager.Read(filePath));

do
{
    // Visa meny alternativ
    var option = ContactManager.OptionsMenu();

    switch (option)
    {
        case "1":
            // Skapa ny kontakt och spara till fil
            var contact = ContactManager.AddContact();
            if (contact != null)
            {
                contacts.Add(contact);
                FileManager.Save(filePath, JsonConvert.SerializeObject(contacts, Formatting.Indented));
            }
            break;

        case "2":
            // Visa Adress boken
            ContactManager.ViewListMenu(contacts);
            break;

        case "3":
            // Sök efter en specifik kontakt
             ContactManager.search(contacts);
            break;
        
        case "4":
            // Uppdatera en kontakt och spara till fil
            ContactManager.update(contacts);
            FileManager.Save(filePath, JsonConvert.SerializeObject(contacts, Formatting.Indented));
            break;

        case "5":
           // Radera en kontakt och spara till listan
            ContactManager.ViewListMenu(contacts);
            ContactManager.RemoveMenu(ref contacts);
            FileManager.Save(filePath, JsonConvert.SerializeObject(contacts, Formatting.Indented));
            break;

        case "6":
            // Stäng av aplikationen(AddressBook)
            Environment.Exit(0);
            break;

        default:
            // ogiltigt val i menyn
            Console.WriteLine("Invalid option selected");
            Console.ReadKey();
            break;

        
    }
} while (true);

