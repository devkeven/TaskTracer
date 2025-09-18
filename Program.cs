// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Data.Common;
using Microsoft.VisualBasic;


// List<string[]> tasks = new List<string[]>();

// // Read from CSV file, skipping the header line
// string[] linhas = File.ReadAllLines("tasks.csv").Skip(1).ToArray();
// foreach (var linha in linhas)
// {
//     string[] campos = linha.Split(',');
//     string[] task = { campos[0], campos[1], campos[2], campos[3], campos[4] };

//     tasks.Add(task);
// }

List<Task> tasks = CsvHelper.LoadTasksFromCsv("tasks.csv");

Console.WriteLine("**Task Tracker Menu**");

string? input;
do
{    
    Console.WriteLine("");
    Console.WriteLine("Insert the operation:");
    Console.WriteLine("Add, update, delete, mark-in-progress");
    Console.WriteLine("mark-in-progress, mark-done");
    Console.WriteLine("list, list done, list todo, list in-progress");
    Console.WriteLine("exit to quit the program");

    input = Console.ReadLine();

    if (input != null)
    {
        var operation = input.Split(" ")[0];
        //Console.WriteLine(operation);

        switch (operation)
        {
            case "add":
                tasks = Task.Add(input, tasks);               
                break;

            case "update":
                tasks =  Task.Update(input, tasks);
                break;

            case "delete":
                tasks = Task.Delete(input, tasks);
                break;

            case "mark-in-progress":
                tasks = Task.MarkInProgress(input, tasks);
                break;

            case "mark-done":
                tasks = Task.MarkDone(input, tasks);
                break;

            case "list":
                Console.WriteLine("List of tasks:");
                Console.WriteLine("--------------");

                foreach (var item in tasks)
                {
                    Console.WriteLine("id: " + item.Id);
                    Console.WriteLine("description: " + item.Description);
                    Console.WriteLine("status: " + item.Status);
                    Console.WriteLine("createdAt: " + item.CreatedAt);
                    Console.WriteLine("updatedAt: " + item.UpdatedAt);
                    Console.WriteLine("--------------");
                }
                break;

            default:
                Console.WriteLine("Invalid operation!");
                break;
        }

    }

} while (input != "exit");


