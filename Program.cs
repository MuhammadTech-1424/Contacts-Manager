using System;
using PhoneBook.Brokers;
using PhoneBook.Services;

var logger = new LoggingBroker();
var fileBroker = new FileBroker();
var service = new PhoneBookService(fileBroker, logger);

while (true)
{
    Console.WriteLine(" \t <<< Contacts Manager >>> ");
    Console.WriteLine("\n1. Qo'shish\n2. Ko'rish\n3. Qidirish\n4. O'chirish\n5. Tahrirlash\n0. Chiqish");
    Console.Write("Tanlang: ");
    string choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1": service.AddContact(); break;
        case "2": service.ShowAllContacts(); break;
        case "3": service.SearchByName(); break;
        case "4": service.DeleteContact(); break;
        case "5": service.EditContact(); break;
        case "0": return;
        default: Console.WriteLine("Noto'g'ri ma'lumot kiritdingiz!."); break;
    }
    Console.WriteLine();
}
