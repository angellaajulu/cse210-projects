using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video();
        video1.Title = "How to Bake Bread";
        video1.Author = "Kitchen Academy";
        video1.Length = 540;

        video1.AddComment(new Comment("Alice", "This was so easy to follow!"));
        video1.AddComment(new Comment("Brian", "My bread turned out perfect."));
        video1.AddComment(new Comment("Clara", "Thanks for the great tips!"));

        videos.Add(video1);

        // Video
        Video video2 = new Video();
        video2.Title = "C# Classes Explained";
        video2.Author = "Tech Teacher";
        video2.Length = 720;

        video2.AddComment(new Comment("David", "Best explanation I've seen."));
        video2.AddComment(new Comment("Henry", "I feel so relaxed now."));
        video2.AddComment(new Comment("Mary", "Very clear and helpful."));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video();
        video3.Title = "10 Minute Yoga Routine";
        video3.Author = "Wellness Studio";
        video3.Length = 600;

        video3.AddComment(new Comment("Grace", "Perfect morning routine!"));
        video3.AddComment(new Comment("Henry", "Great examples!"));
        video3.AddComment(new Comment("Ivy", "Loved this session!"));

        videos.Add(video3);

        // -------- Display all video information --------
        foreach (Video vid in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {vid.Title}");
            Console.WriteLine($"Author: {vid.Author}");
            Console.WriteLine($"Length: {vid.Length} seconds");
            Console.WriteLine($"Number of Comments: {vid.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment c in vid.GetComments())
            {
                Console.WriteLine($" - {c.Name}: {c.Text}");
            }

            Console.WriteLine();
        }
    }
}