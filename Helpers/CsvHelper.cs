using System.Collections.Generic;
using System.IO;

public class CsvHelper
{

    
    public static void SaveTasksToCsv(List<Task> tasks, string filePath)
    {
        List<string> lines = new List<string>
        {
            "id,description,status,createdAt,updatedAt" // Header
        };

        foreach (var task in tasks)
        {
            string line = task.Id + "," +
                        task.Description + "," + // Escape quotes in description
                        task.Status + "," +
                        task.CreatedAt.ToString() + "," + // Use round-trip date/time pattern
                        (task.UpdatedAt.HasValue ? task.UpdatedAt.Value.ToString("o") : "null");

            lines.Add(line);
        }

        File.WriteAllLines(filePath, lines);
    }


    // Read from CSV file, skipping the header line
    public static List<Task> LoadTasksFromCsv(string filePath)
    {
        List<Task> tasks = new List<Task>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath).Skip(1).ToArray(); // Skip header
            foreach (var line in lines)
            {
                string[] fields = line.Split(',');
                if (fields.Length == 5) // Ensure there are exactly 5 fields
                {
                    var task = new Task(
                        int.Parse(fields[0]),
                        fields[1],
                        fields[2],
                        DateTime.Parse(fields[3]),
                        fields[4] == "null" ? (DateTime?)null : DateTime.Parse(fields[4])
                    );

                    tasks.Add(task);
                }
            }
        }

        return tasks;
    }
}