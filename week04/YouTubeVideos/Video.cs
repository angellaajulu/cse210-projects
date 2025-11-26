using System;
using System.Collections.Generic;


public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments = new List<Comment>();

    public string Title
    {
        get {return _title;}
        set {_title = value;}
    }

    public string Author
    {
        get {return _author;}
        set {_author = value;}
    }

    public int Length
    {
        get {return _length;}
        set {_length = value;}
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}