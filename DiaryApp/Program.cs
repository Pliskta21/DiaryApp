using System.Formats.Asn1;
using System.Text.Json;
using DiaryApp;
using Newtonsoft.Json;


if (!File.Exists("Data.json")){ 
    File.Create("Data.json");
      
}
diary diary = new diary();
diary.json_load();

void Leave() {
    diary.Data();
    System.Environment.Exit(1);
}
void Create()
{
    int year;
    int month;
    int day;
    string input_year;
    string input_month;
    string input_day;

    Console.Clear();
    Console.WriteLine("Creating a new event");
    Console.WriteLine("Event name:");
    string input_name = Console.ReadLine();
    Console.Clear();

    Console.WriteLine("Event details:");
    string input_details = Console.ReadLine();
    Console.Clear();

    Console.WriteLine("Event date:");
    do
    {
        Console.WriteLine("Year:");
        input_year = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Enter a valid year!");
    }
    while (!int.TryParse(input_year, out year));

    Console.WriteLine("Event date:");
    do
    {
        Console.WriteLine("Month:");
        input_month = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Enter a valid month!");
    }
    while (!int.TryParse(input_month, out month));

    Console.WriteLine("Event date:");
    do
    {
        Console.WriteLine("Day:");
        input_day = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Enter a valid day!");
    }
    while (!int.TryParse(input_day, out day));

    if (input_year != null && input_month != null && input_day != null)
    {
        var input_date = new DateTime(year, month, day);

        diary.veci.Add(new events()
        {
            name = input_name,
            details = input_details,
            date = input_date
        });


    }
}

void Edit()
{
    bool input_check;
    int id;

    Console.Clear();
    View();
    Console.WriteLine("Select Event to Edit");
    Console.WriteLine("ID:");
    string edit = Console.ReadLine();


    input_check = int.TryParse(edit, out id);

    Console.WriteLine("Name edit:");
    Console.WriteLine(diary.veci[id].name);
    string name_edit = Console.ReadLine();
    if (name_edit != null && name_edit != "")
    {
        diary.veci[id].name = name_edit;
    }

    Console.WriteLine("Details edit:");
    Console.WriteLine(diary.veci[id].details);
    string details_edit = Console.ReadLine();
    if (details_edit != null && details_edit != "")
    {
        diary.veci[id].details = details_edit;
    }
}


void Delete()
{
    Console.Clear();
    View();
    Console.WriteLine("Select Event to Delete");
    Console.WriteLine("ID:");
    int delete = int.Parse(Console.ReadLine());


    diary.veci.RemoveAt(delete);
}

void View()
{
    int id = -1;
    if (diary.veci.Count() == 0)
    {
        Console.WriteLine("No events saved atm");
    }
    else
    {
        Console.Clear();
        foreach (var item in diary.veci)
        {
            id += 1;
            Console.WriteLine($"{id} {item.name} {item.details} {item.date}");
        }
        Console.ReadKey();
    }
}

while (true)
{
    Console.WriteLine("Select:");
    Console.WriteLine("(V)iew\n(C)reate\n(E)dit\n(D)elete\n(L)eave");

    string input_menu = Console.ReadLine();

    switch (input_menu)
    {
        case "c" or "C":
            Create();
            break;
        case "e" or "E":
            Edit();
            break;
        case "d" or "D":
            Delete();
            break;
        case "v" or "V":
            View();
            break;
        case "l" or "l":
            Leave();
            break;
        default:
            break;
    }


}
