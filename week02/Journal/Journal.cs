using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            // Write a header row so the CSV is easy to understand
            outputFile.WriteLine("Date,Prompt,Response");

            foreach (Entry entry in _entries)
            {
                // Escape commas and quotes properly
                string safePrompt = entry._promptText.Replace("\"", "\"\"");
                string safeResponse = entry._entryText.Replace("\"", "\"\"");

                outputFile.WriteLine($"\"{entry._date:o}\",\"{safePrompt}\",\"{safeResponse}\"");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        // Skip the first line if it is a header
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = ParseCsvLine(line);

            Entry entry = new Entry();
            entry._date = DateTime.Parse(parts[0]);
            entry._promptText = parts[1];
            entry._entryText = parts[2];

            _entries.Add(entry);
        }
    }

    // Helper method to handle CSV parsing with quotes
    private string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool insideQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == '\"')
            {
                insideQuotes = !insideQuotes;
            }
            else if (c == ',' && !insideQuotes)
            {
                fields.Add(current);
                current = "";
            }
            else
            {
                current += c;
            }
        }
        fields.Add(current);

        // Unescape quotes
        for (int i = 0; i < fields.Count; i++)
        {
            fields[i] = fields[i].Replace("\"\"", "\"").Trim('"');
        }

        return fields.ToArray();
    }
}
