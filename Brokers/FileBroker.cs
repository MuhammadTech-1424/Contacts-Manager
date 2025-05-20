using PhoneBook.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace PhoneBook.Brokers;

public class FileBroker
{
    private readonly string filePath = "contacts.json";

    public List<Contact> ReadContacts()
    {
        if (!File.Exists(filePath))
            return new List<Contact>();

        string content = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<Contact>>(content) ?? new List<Contact>();
    }

    public void WriteContacts(List<Contact> contacts)
    {
        string content = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, content);
    }
}
