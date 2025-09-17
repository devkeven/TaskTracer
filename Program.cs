// See https://aka.ms/new-console-template for more information
using System.Collections;

Console.WriteLine("**Task Tracker Menu**");
List<string> tasks = new List<string>();

string? input;
do
{    
    Console.WriteLine("");
    Console.WriteLine("Insert the operation?");
    input = Console.ReadLine();

    if (input != null)
    {
        var operation = input.Split(" ")[0];
        //Console.WriteLine(operation);

        switch (operation)
        {
            case "add":
                //Console.WriteLine("Add item to task List");
                var task = input.Substring(input.IndexOf(" "));
                task = task.Trim();

                if (task.StartsWith("\"") && task.EndsWith("\""))
                {
                    try
                    {
                        task = task.Remove(task.IndexOf("\""), 1);
                        task = task.Remove(task.LastIndexOf("\""), 1);

                        tasks.Add(task);                        
                        //Console.WriteLine(task);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    
                }
                else
                {
                    Console.WriteLine("Invalid format for the task name!");
                }
                
                break;

            case "update":
                break;

            case "delete":
                break;

            case "mark-in-progress":
                break;

            case "mark-done":
                break;

            case "list":
                foreach (var item in tasks)
                {
                    Console.WriteLine(item);
                }
                break;

            default:
                Console.WriteLine("Invalid operation!");
                break;
        }

    }

} while (input != "exit");
