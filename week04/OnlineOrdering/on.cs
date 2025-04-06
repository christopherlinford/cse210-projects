using System;
using System.Collections.Generic;

class Comment
{
    private string name;
    private string text;

    public Comment(string name, string text)
    {
        this.name = name;
        this.text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"  - {name}: {text}");
    }
}

class Video
{
    private string title;
    private string author;
    private int length;
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {title}, Author: {author}, Length: {length} sec, Comments: {GetCommentCount()}");
        foreach (var comment in comments)
        {
            comment.DisplayComment();
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video v1 = new Video("Tech Review", "John Doe", 600);
        v1.AddComment(new Comment("Alice", "Great review!"));
        v1.AddComment(new Comment("Bob", "Nice video."));
        v1.AddComment(new Comment("Charlie", "Very informative."));
        videos.Add(v1);

        Video v2 = new Video("Cooking Tips", "Sarah Smith", 450);
        v2.AddComment(new Comment("David", "Love this recipe!"));
        v2.AddComment(new Comment("Emily", "Trying this soon."));
        videos.Add(v2);

        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
