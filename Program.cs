using System;
using Contacts_Manager.Service;

while (true)
{
    Console.WriteLine(" \t <<< Contacts Manager >>> ");
    Console.WriteLine("1. Kontakt qo'shish");
    Console.WriteLine("2. Kontaktlarni ko'rish");
    Console.WriteLine("3. Kontaktni tahrirlash");
    Console.WriteLine("4. Kontaktni o'chirish");
    Console.WriteLine("0. Chiqish");

    int choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            PhoneBook.AddContact();
            break;
        case 2:
            PhoneBook.ShowContacts();
            break;
        case 3:
            PhoneBook.EditContact();
            break;
        case 4:
            PhoneBook.DeleteContact();
            break;
        case 0:
            Console.WriteLine("Dastur tugadi!");
            break;
    }
    
}