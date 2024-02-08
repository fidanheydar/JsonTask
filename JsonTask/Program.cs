using JsonTask;
using System.Net.Cache;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Xml.Linq;
#region Task1
Person person1 = null;
//person1 = new Person()
//{
//    Fullname = "Fidan Heydarova",
//    Age = 19
//};
//SerializeJson(person1);
person1 = DeserializeJson();
Console.WriteLine(person1);

void SerializeJson(Person person)
{
    using (FileStream fs = new FileStream("C:\\Users\\HP\\Desktop\\PB302\\JsonTask\\JsonTask\\Data\\person.json",FileMode.Create))
    {
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Person));
        jsonSerializer.WriteObject(fs, person);
    }
}

Person DeserializeJson()
{
    Person Data = null;
    using (FileStream fs = new FileStream("C:\\Users\\HP\\Desktop\\PB302\\JsonTask\\JsonTask\\Data\\person.json", FileMode.Open))
    {
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Person));
        Data = jsonSerializer.ReadObject(fs) as Person;
    }
    return Data;
}
#endregion

List<Person> personList = new List<Person>();
string opt;

do
{
    Console.WriteLine("1. Person yarat");
    Console.WriteLine("2. Butun personlara bax");
    Console.WriteLine("0. Chixish");
    opt = Console.ReadLine();

    switch (opt)
    {
        case "1":
            AddPerson(personList);
            break;
        case "2":
            DisplayAllPersons(personList);
            break;
        case "0":
            Console.WriteLine("Chixish olunur....");
            break;
        default:
            Console.WriteLine("Duzgun sechim daxil edin!");
            break;
    }
} while (opt != "0");
    

    static void AddPerson(List<Person> personList)
    {
    string fullName;
    byte age;

    do
    {
        Console.Write("Adi daxil edin:");
        fullName = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(fullName));

    do
    {
        Console.Write("Yashi daxil edin:");
        string ageStr = Console.ReadLine();
        if (byte.TryParse(ageStr, out age) && age >= 0)
        {
            break;
        }
        Console.WriteLine("Yashi duzgun daxil edin!");
    } while (true);

    Person newPerson = new Person()
    {
        Fullname = fullName,
        Age = age
    };

    personList.Add(newPerson);
    SerializeJsonList(personList);
}

static void DisplayAllPersons(List<Person> personList)
{
    personList = DeserializeJsonList();

    if (personList.Count == 0)
    {
        Console.WriteLine("List boshdur!");
    }
    else
    {
        foreach (var person in personList)
        {
            Console.WriteLine(person);
        }
    }
}

static void SerializeJsonList(List<Person> personList)
{
    string filePath = "C:\\Users\\HP\\Desktop\\PB302\\JsonTask\\JsonTask\\Data\\personList.json";

    using (FileStream fs = new FileStream(filePath, FileMode.Create))
    {
        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Person>));
        jsonSerializer.WriteObject(fs, personList);
    }
}

static List<Person> DeserializeJsonList()
{
    List<Person> personlist = new List<Person>();
    string filePath = "C:\\Users\\HP\\Desktop\\PB302\\JsonTask\\JsonTask\\Data\\personList.json";

    if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Person>));
            personlist = jsonSerializer.ReadObject(fs) as List<Person>;
        }
    }

    return personlist;
}