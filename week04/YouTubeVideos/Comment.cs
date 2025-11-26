using System;
using System.ComponentModel.Design;

public class Comment
{
    private string _name;
    private string _text;

    public string Name
    {
        get {return _name;}
        set {_name = value;}
    }

    public string Text
    {
        get {return _text;}
        set {_text = value;}
    }

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }
}