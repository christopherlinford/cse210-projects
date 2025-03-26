using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;

    }
    public void Display()
    {
        Console.WriteLine($"Date: {_date}\nPrompt: {_promptText}\nEntry: {_entryText}\n");
    }
    public string ToFileFormat()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }
    
    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        return new Entry(parts[0], parts[1], parts[2]);
    }
}