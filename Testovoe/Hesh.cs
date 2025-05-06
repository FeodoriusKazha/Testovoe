internal class PhoneBook
{
  private Dictionary<int, List<Contact>> contacts = new Dictionary<int, List<Contact>>();

  public void AddContact(string name, string phoneNumber)
  {
    int hashKey = GenerateHash(name);

    if (!contacts.ContainsKey(hashKey))
    {
      contacts[hashKey] = new List<Contact>();
    }

    contacts[hashKey].Add(new Contact(name, phoneNumber));
    Console.WriteLine($"Контакт {name} добавлен.");
  }

  public void RemoveContact(string name)
  {
    int hashKey = GenerateHash(name);

    if (contacts.ContainsKey(hashKey))
    {
      var contactList = contacts[hashKey];
      contactList.RemoveAll(c => c.Name == name);

      if (contactList.Count == 0)
        contacts.Remove(hashKey);

      Console.WriteLine($"Контакт {name} удален.");
    }
    else
    {
      Console.WriteLine($"Контакт {name} не найден.");
    }
  }

  public void EditContact(string name, string newPhoneNumber)
  {
    int hashKey = GenerateHash(name);

    if (contacts.ContainsKey(hashKey))
    {
      var contactList = contacts[hashKey];
      foreach (var contact in contactList)
      {
        if (contact.Name == name)
        {
          contact.PhoneNumber = newPhoneNumber;
          Console.WriteLine($"Номер {name} обновлен.");
          return;
        }
      }
    }

    Console.WriteLine($"Контакт {name} не найден.");
  }

  public void FindContact(string name)
  {
    int hashKey = GenerateHash(name);

    if (contacts.ContainsKey(hashKey))
    {
      var contactList = contacts[hashKey];
      foreach (var contact in contactList)
      {
        if (contact.Name == name)
        {
          Console.WriteLine($"Телефон {name}: {contact.PhoneNumber}");
          return;
        }
      }
    }

    Console.WriteLine($"Контакт {name} не найден.");
  }

  private int GenerateHash(string name)
  {
    int hash = 0;
    foreach (char c in name)
    {
      hash += c;
    }
    return hash;
  }
}

class Contact
{
  public string Name { get; }
  public string PhoneNumber { get; set; }

  public Contact(string name, string phoneNumber)
  {
    Name = name;
    PhoneNumber = phoneNumber;
  }
}

static class HeshProgram
{
  static public void HeshMenu()
  {
    PhoneBook phoneBook = new PhoneBook();
    bool running = true;

    while (running)
    {
      Console.Clear();
      Console.WriteLine("===============");
      Console.WriteLine("     Меню:");
      Console.WriteLine("===============");
      Console.WriteLine("1. Добавить контакт");
      Console.WriteLine("2. Удалить контакт");
      Console.WriteLine("3. Редактировать контакт");
      Console.WriteLine("4. Найти номер по ФИО");
      Console.WriteLine("5. Выход");
      string choice = Readline.TryReadline<string>("Выберите пункт меню: ");
      Console.Clear();

      switch (choice)
      {
        case "1":
          string nameAdd = Readline.TryReadline<string>("Введите ФИО: ");
          string phoneAdd = Readline.TryReadPhoneNumber("Введите номер телефона: ");
          phoneBook.AddContact(nameAdd, phoneAdd);
          break;
        case "2":
          string nameRemove = Readline.TryReadline<string>("Введите ФИО для удаления: ");
          phoneBook.RemoveContact(nameRemove);
          break;
        case "3":
          string nameEdit = Readline.TryReadline<string>("Введите ФИО для редактирования: ");
          string phoneEdit = Readline.TryReadPhoneNumber("Введите новый номер: ");
          phoneBook.EditContact(nameEdit, phoneEdit);
          break;
        case "4":
          string nameFind = Readline.TryReadline<string>("Введите ФИО для поиска номера: ");
          phoneBook.FindContact(nameFind);
          break;
        case "5":
          running = false;
          Console.WriteLine("Выход из программы.");
          break;
        default:
          Console.WriteLine("Некорректный ввод. Попробуйте снова.");
          break;
      }
    }
  }
}