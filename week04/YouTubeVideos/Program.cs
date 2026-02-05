using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C#", "Code Academy", 600);
        video1.AddComment(new Comment("Anna", "Very helpful!"));
        video1.AddComment(new Comment("James", "Clear explanation."));
        video1.AddComment(new Comment("Lily", "Loved this video."));

        Video video2 = new Video("OOP Basics", "Tech World", 480);
        video2.AddComment(new Comment("Mark", "Great examples."));
        video2.AddComment(new Comment("Sara", "Easy to understand."));
        video2.AddComment(new Comment("Tom", "Thanks!"));

        Video video3 = new Video("Abstraction Explained", "Dev Simplified", 720);
        video3.AddComment(new Comment("Chris", "This helped a lot."));
        video3.AddComment(new Comment("Emily", "Perfect timing."));
        video3.AddComment(new Comment("Noah", "Nice breakdown."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}
