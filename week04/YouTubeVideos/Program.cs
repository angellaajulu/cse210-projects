using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video v1 = new Video("Intro to C#", "Alice", 300);
        Video v2 = new Video("Learning Abstraction", "Bob", 450);
        Video v3 = new Video("OOP Basics", "Carol", 600);

        v1.AddComment(new Comment("John", "Great video!"));
        v1.AddComment(new Comment("Mary", "Very helpful."));
        v1.AddComment(new Comment("Steve", "Thanks for sharing."));

        v2.AddComment(new Comment("Anna", "Awesome explanation!"));
        v2.AddComment(new Comment("Tom", "Clear and concise."));
        v2.AddComment(new Comment("Lucy", "Loved it."));

        v3.AddComment(new Comment("Mike", "Good intro."));
        v3.AddComment(new Comment("Sara", "Nice examples."));
        v3.AddComment(new Comment("Jake", "Well explained."));

        List<Video> videos = new List<Video> {v1, v2, v3};

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (var c in video.GetComments())
            {
                Console.WriteLine($"- {c.CommenterName}: {c.Text}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}