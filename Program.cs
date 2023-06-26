using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

// meeting start time, duration, room, name

var FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "File.csv");
var FileNameForCopy = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileCopy.csv");

const int MaximumRoomLenght = 25;
const int MaximumNameLenght = 50;


if (!File.Exists(FileName))
{
    File.Create(FileName).Close();
}

void ShowAll()
{
    Console.WriteLine($"{"Start time",20}"
        + $"{"Duration",20}"
        + $"{"Room",20}" +
        $"{"Name",20}");

    var fileContent = File.ReadAllLines(FileName);

    foreach (var line in fileContent)
    {
        var meetingContent = line.Split(",");

        Console.WriteLine($"{meetingContent[0],20}" +
              $"{meetingContent[1],20}" +
              $"{meetingContent[2],20}" +
              $"{meetingContent[3],20}");
    }

    //Console.WriteLine("Press any key to return to menu...");
    Console.ReadLine();
}

void RaiseError(string error)
{
    //Console.WriteLine(error);
    throw new Exception(error);
}

void AddMeeting() // meeting start time, duration, room, name
{

    Console.WriteLine("Start date:");
    var dateParsingResult = DateTime.TryParse(Console.ReadLine(), out var startTime);
    if (!dateParsingResult)
    {
        RaiseError("Error! Invalid Start date");
        return;
    }

    Console.WriteLine("Duration in minutes: ");
    var durationParsingResult = int.TryParse(Console.ReadLine(), out var duration);
    if (!durationParsingResult)
    {
        RaiseError("Error! Invalid meeting duration");
        return;
    }

    var meetingEnd = startTime.AddMinutes(duration);

    Console.WriteLine("Room: ");
    var room = Console.ReadLine();
    if (string.IsNullOrEmpty(room))
    {
        RaiseError("Error! Empty room");
        return;
    }

    if (room.Length > MaximumRoomLenght)
    {
        RaiseError($"Error! Room should not be longer than {MaximumRoomLenght} symbols");
        return;
    }

    var fileContent = File.ReadAllLines(FileName);

    foreach (var line in fileContent)
    {

        var meetingContent = line.Split(",");

        if (meetingContent[2] == room)
        {
            if (DateTime.Parse(meetingContent[0]) >= startTime && DateTime.Parse(meetingContent[0]) <= meetingEnd)
            {
                RaiseError("Error! Meeting room occupied at this time!");
                return;
            }
        }

    }


    Console.WriteLine("Name: ");
    var name = Console.ReadLine();
    if (string.IsNullOrEmpty(name))
    {
        RaiseError("Error! Empty name");
        return;
    }
    if (name.Length > MaximumNameLenght)
    {
        RaiseError($"Error! Room should not be longer than {MaximumNameLenght} symbols");
        return;
    }

    foreach (var line in fileContent)
    {

        var meetingContent = line.Split(",");

        if (meetingContent[3].Equals(name))
        {
            RaiseError("Error! This name is already taken!");
            return;
        }
    }

    File.AppendAllText(FileName, $"{startTime},{duration},{room},{name}" + Environment.NewLine);
}

    void Exit()
    {
        Environment.Exit(0);
    }

    void deleteAll()
    {
        File.Delete(FileName);
    }

    void deleteDefine()
    {
        Console.WriteLine("Enter name of meeting you want to delete");
        var deleteMeting = Console.ReadLine();

    var i = 0;

    var fileContent = File.ReadAllLines(FileName);

    foreach (var line in fileContent)
    {

        var meetingContent = line.Split(",");

        if (meetingContent[3].Equals(deleteMeting))
        {
            ++i;
        }
    }

    if(i < 1)
    {
        Console.WriteLine("There is no meeting with this name!");
        Console.ReadLine();
    } 
    else
    {
        File.Copy(FileName, FileNameForCopy);
        File.Create(FileName).Close();

        var fileContentCopy = File.ReadAllLines(FileNameForCopy);

        foreach (var line in fileContentCopy)
        {
            var meetingContent = line.Split(",");

            if (!meetingContent[3].Equals(deleteMeting))
            {
                File.AppendAllText(FileName, line);
            }
        }
        File.Delete(FileNameForCopy);
    }


}

    void editMeetingMenu()
    {
        Console.Clear();
        Console.WriteLine("3. Delete all meetings");
        Console.WriteLine("2. Delete definite meeting");
        Console.WriteLine("1. Exit edit menu");
        Console.WriteLine("0. Exit calendar");

        var keyInfo = int.Parse(Console.ReadLine());

    switch (keyInfo)
    {
        case 0:
            Exit();
            break;

        case 1:
            break;

        case 2:
            deleteDefine();
            break;

        case 3:
            deleteAll();
            break;



        default: break;
    }
}
        
    void Menu()
    {
        Console.Clear();
        Console.WriteLine("3. Show all meetings");
        Console.WriteLine("2. Add meeting");
        Console.WriteLine("1. Open editing menu");
        Console.WriteLine("0. Exit calendar");
    }

while (true)
{
    Menu();
    var keyInfo = int.Parse(Console.ReadLine());
    try
    {
        switch (keyInfo)
        {
            case 0:
                Exit();
                break;
            case 1:
                editMeetingMenu();
                break;
            case 2:
                AddMeeting();
                break;

            case 3:
                ShowAll();
                break;


            default: break;
        }
    }
    catch (Exception e)
    {

        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}



