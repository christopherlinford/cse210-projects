using System;
using System.Collections.Generic;
using System.IO;

static class ScriptureLoader
{
    public static List<Scripture> LoadScriptures(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    string[] refParts = parts[0].Split(' ');
                    if (refParts.Length < 2) continue; // bad reference format

                    string book = refParts[0];
                    string[] chapterVerse = refParts[1].Split(':');

                    if (chapterVerse.Length == 2)
                    {
                        string[] verseRange = chapterVerse[1].Split('-');
                        int chapter = int.Parse(chapterVerse[0]);
                        int startVerse = int.Parse(verseRange[0]);

                        Reference reference = verseRange.Length > 1
                            ? new Reference(book, chapter, startVerse, int.Parse(verseRange[1]))
                            : new Reference(book, chapter, startVerse);

                        scriptures.Add(new Scripture(reference, parts[1]));
                    }
                }
            }
        }

        return scriptures;
    }
}
