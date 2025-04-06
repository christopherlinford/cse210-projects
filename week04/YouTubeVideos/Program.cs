using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("New Product Launch Review", "TechGuy", 350);
        video1.AddComment(new Comment("Amy", "Fantastic review!"));
        video1.AddComment(new Comment("Loren", "I loved all of the features."));
        video1.AddComment(new Comment("Gordon", "Looking forward to using this."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Creating the Future", "TechWorld", 520);
        video2.AddComment(new Comment("Diana", "Nice demonstration."));
        video2.AddComment(new Comment("Henry", "Very informative."));
        video2.AddComment(new Comment("Chris", "I got to learn more!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Technology Explained: AI", "GeniusTech", 675);
        video3.AddComment(new Comment("Vince", "Best explanation I’ve seen!"));
        video3.AddComment(new Comment("Sarah", "This made things so much easier to understand."));
        video3.AddComment(new Comment("Harrison", "I need to watch this again! Subscribing now!"));
        videos.Add(video3);

        // Display videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}
