using System.Runtime.InteropServices;

public class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public Task(int id, string description, string status, DateTime createdAt, DateTime? updatedAt)
    {
        Id = id;
        Description = description;
        Status = status;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static List<Task> Add(string input, List<Task> tasks)
    {
        //Console.WriteLine("Add item to task List");
        var description = input.Substring(input.IndexOf(" "));
        description = description.Trim();

        if (description.StartsWith("\"") && description.EndsWith("\""))
        {
            try
            {
                // Remove the surrounding quotes
                description = description.Remove(description.IndexOf("\""), 1);
                description = description.Remove(description.LastIndexOf("\""), 1);

                // Generate a unique ID for the task
                int id;
                if (tasks.Count > 0)
                {
                    // get the last task id
                    Task lastTask = tasks.Last();
                    int lastId = lastTask.Id;

                    id = lastId + 1;
                }
                else
                {
                    id = 1;
                }


                string status = "todo";
                DateTime createdAt = DateTime.Now;
                DateTime? updatedAt = null;

                // Create a string array to hold the task details
                Task task = new Task(id, description, status, createdAt, updatedAt);
                tasks.Add(task);
                
                CsvHelper.SaveTasksToCsv(tasks, "tasks.csv");
                Console.WriteLine("Tak added successfully (ID: " + id + ")");
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

        return tasks;
    }

    public static List<Task> Update(string input, List<Task> tasks)
    {
        input = input.Substring(input.IndexOf(" ")).Trim();

        var lenght = input.IndexOf(" ");
        string? idInserted = input.Substring(0, input.IndexOf(" ") + 1).Trim();

        if (int.TryParse(idInserted, out int id))
        {
            Task? task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                // Remove the surrounding quotes
                var description = input.Substring(input.IndexOf(" ")).Trim();
                description = description.Remove(description.IndexOf("\""), 1);
                description = description.Remove(description.LastIndexOf("\""), 1);

                task.Description = description;
                task.UpdatedAt = DateTime.Now;
                CsvHelper.SaveTasksToCsv(tasks, "tasks.csv");
                Console.WriteLine("Task with ID " + id + " updated to 'in-progress'.");
            }
            else
            {
                Console.WriteLine("Task with ID " + id + " not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format!");
        }
        
        return tasks;
    }

    public static List<Task> Delete(string input, List<Task> tasks)
    {
        var idInserted = input.Substring(input.IndexOf(" "));
        idInserted = idInserted.Trim();

        if (int.TryParse(idInserted, out int id))
        {
            Task? task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                // Delete the task
                tasks.Remove(task);
                CsvHelper.SaveTasksToCsv(tasks, "tasks.csv");
                Console.WriteLine("Task with ID " + id + "deleted.");
            }
            else
            {
                Console.WriteLine("Task with ID " + id + " not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format!");
        }

        return tasks;
    }

    public static List<Task> MarkInProgress(string input, List<Task> tasks)
    {
        var idInserted = input.Substring(input.IndexOf(" "));
        idInserted = idInserted.Trim();

        if (int.TryParse(idInserted, out int id))
        {
            Task? task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                // Update the task status to "in-progress"
                task.Status = "in-progress";
                task.UpdatedAt = DateTime.Now;
                CsvHelper.SaveTasksToCsv(tasks, "tasks.csv");
                Console.WriteLine("Task with ID " + id + " updated to 'in-progress'.");
            }
            else
            {
                Console.WriteLine("Task with ID " + id + " not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format!");
        }

        return tasks;
    }

    public static List<Task> MarkDone(string input, List<Task> tasks)
    {
        var idInserted = input.Substring(input.IndexOf(" "));
        idInserted = idInserted.Trim();

        if (int.TryParse(idInserted, out int id))
        {
            Task? task = tasks.FirstOrDefault(x => x.Id == id);
            if (task != null)
            {
                // Update the task status to "done"
                task.Status = "done";
                task.UpdatedAt = DateTime.Now;
                CsvHelper.SaveTasksToCsv(tasks, "tasks.csv");
                Console.WriteLine("Task with ID " + id + " updated to 'done'.");
            }
            else
            {
                Console.WriteLine("Task with ID " + id + " not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format!");
        }

        return tasks;
    }
}