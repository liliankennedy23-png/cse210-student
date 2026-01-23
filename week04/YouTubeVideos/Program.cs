using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }

    public override string ToString() => $"{CommenterName}: {Text}";
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment) => Comments.Add(comment);
    public int GetNumberOfComments() => Comments.Count;
    public void DisplayComments()
    {
        foreach (var comment in Comments)
        {
            Console.WriteLine("  - " + comment);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        string[] videoTitles = {
            "C# Basics Tutorial",
            "Top 10 YouTube Tips",
            "Funny Cat Compilation",
            "Travel Vlog: Japan",
            "Fitness Workout Routine"
        };

        string[] authors = { "Alice", "Bob", "Charlie", "Diana", "Eve" };
        string[] commenterNames = { "John", "Maria", "Steve", "Lily", "Tom", "Sara", "Nina" };
        string[] sampleComments = {
            "Loved this!", "Very helpful.", "Could be better.", "Amazing content!", "Thanks for sharing.",
            "This made my day!", "I learned something new.", "I disagree with this point.", "Awesome video!"
        };

        List<Video> videos = new List<Video>();

        // Create 3-5 random videos
        int numVideos = rnd.Next(3, 6);
        for (int i = 0; i < numVideos; i++)
        {
            string title = videoTitles[rnd.Next(videoTitles.Length)];
            string author = authors[rnd.Next(authors.Length)];
            int length = rnd.Next(60, 1200); // 1 to 20 minutes in seconds
            Video video = new Video(title, author, length);

            // Random number of comments per video
            int numComments = rnd.Next(3, 8);
            for (int j = 0; j < numComments; j++)
            {
                string commenter = commenterNames[rnd.Next(commenterNames.Length)];
                string text = sampleComments[rnd.Next(sampleComments.Length)];
                video.AddComment(new Comment(commenter, text));
            }

            videos.Add(video);
        }

        // Display videos
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            video.DisplayComments();
            Console.WriteLine(new string('-', 60));
        }
    }
}
