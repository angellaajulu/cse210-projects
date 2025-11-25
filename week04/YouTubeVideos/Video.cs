using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Video
{
    public string Title {get; set;}
    public string Author {get; set;}
    public int LengthInSeconds {get; set;}

    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds= lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}