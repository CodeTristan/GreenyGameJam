using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;

    public sentence sentences;

    public Sprite sprite;
}

public class sentence
{
    [TextArea(3, 10)]
    public string[] sentences;
    public string SoundName;
}
