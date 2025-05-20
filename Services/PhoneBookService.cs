using System;
using System.Linq;
using PhoneBook.Brokers;
using PhoneBook.Models;

namespace PhoneBook.Services;

public class PhoneBookService
{
    private readonly FileBroker fileBroker;
    private readonly LoggingBroker logger;

    public PhoneBookService(FileBroker fileBroker, LoggingBroker logger)
    {
        this.fileBroker = fileBroker;
        this.logger = logger;
    }

    public void AddContact()
    {
        try
        {
            Console.Write("Ism: ");
            string name = Console.ReadLine();

            Console.Write("Telefon raqam: ");
            string phone = Console.ReadLine();

            var contacts = fileBroker.ReadContacts();
            contacts.Add(new Contact { Name = name, PhoneNumber = phone });
            fileBroker.WriteContacts(contacts);

            logger.LogInfo("Kontakt muvaffaqiyatli qo'shildi.");
        }
        catch (Exception ex)
        {
            logger.LogError($"Kontakt qo'shishda xatolik: {ex.Message}");
        }
    }

    public void ShowAllContacts()
    {
        try
        {
            var contacts = fileBroker.ReadContacts();
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Ism: {contact.Name}, Tel: {contact.PhoneNumber}");
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Kontaktlarni o'qishda xatolik: {ex.Message}");
        }
    }

    public void SearchByName()
    {
        try
        {
            Console.Write("Qidirilayotgan ism: ");
            string name = Console.ReadLine();

            var contacts = fileBroker.ReadContacts();
            var found = contacts.FirstOrDefault(c => c.Name == name);

            if (found != null)
                Console.WriteLine($"Topildi: {found.Name} - {found.PhoneNumber}");
            else
                Console.WriteLine("Bunday kontakt topilmadi.");
        }
        catch (Exception ex)
        {
            logger.LogError($"Qidirishda xatolik: {ex.Message}");
        }
    }

    public void DeleteContact()
    {
        try
        {
            Console.Write("O‘chiriladigan ism: ");
            string name = Console.ReadLine();

            var contacts = fileBroker.ReadContacts();
            var updated = contacts.Where(c => c.Name != name).ToList();
            fileBroker.WriteContacts(updated);

            logger.LogInfo("Kontakt o'chirildi (agar mavjud bo'lsa).");
        }
        catch (Exception ex)
        {
            logger.LogError($"Kontaktni o'chirishda xatolik: {ex.Message}");
        }
    }

    public void EditContact()
    {
        try
        {
            Console.Write("Tahrirlanadigan ism: ");
            string name = Console.ReadLine();

            var contacts = fileBroker.ReadContacts();
            var contact = contacts.FirstOrDefault(c => c.Name == name);

            if (contact != null)
            {
                Console.Write("Yangi ism: ");
                contact.Name = Console.ReadLine();
                Console.Write("Yangi telefon: ");
                contact.PhoneNumber = Console.ReadLine();

                fileBroker.WriteContacts(contacts);
                logger.LogInfo("Kontakt yangilandi.");
            }
            else
            {
                Console.WriteLine("Kontakt topilmadi.");
            }
        }
        catch (Exception ex)
        {
            logger.LogError($"Kontaktni tahrirlashda xatolik: {ex.Message}");
        }
    }
}
