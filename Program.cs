
List<Task> tasks = CsvHelper.LoadTasksFromCsv("tasks.csv");

Console.WriteLine("**Task Tracker Menu**");

string? input;
do
{
    // Display menu options
    Console.WriteLine("");
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("Insert the operation:");
    Console.WriteLine("Add, update, delete, mark-in-progress");
    Console.WriteLine("mark-in-progress, mark-done");
    Console.WriteLine("list, list done, list todo, list in-progress");
    Console.WriteLine("exit to quit the program");
    Console.WriteLine("-----------------------------------------------");

    // Read user input
    input = Console.ReadLine();

    if (input != null)
    {
        var operation = input.Split(" ")[0];
        
        // Determine the operation and call the corresponding method
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

                List<Task> listedTasks = new List<Task>();

                if (input == "list done")
                {
                    listedTasks = tasks.Where(x => x.Status == "done").ToList();
                }
                else if (input == "list todo")
                {
                    listedTasks = tasks.Where(x => x.Status == "todo").ToList();
                }
                else if (input == "list in-progress")
                {
                    listedTasks = tasks.Where(x => x.Status == "in-progress").ToList();
                }
                else if (input == "list")
                {
                    listedTasks = tasks;
                }
                else
                {
                    Console.WriteLine("Invalid list operation!");
                    break;
                }

                foreach (var item in listedTasks)
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


