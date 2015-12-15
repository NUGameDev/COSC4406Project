using UnityEngine;
using System.Collections;
using System;
using System.IO;


public class ReadFromFile : MonoBehaviour {
    public string TextBox; //reads the text file, and displays it on the screen
    public string Location; //Variable for the location for the text file.
    public string TextBoxString;

    void Start()
    {
        ReadFile(Location); //starts the functon once the scene or canvas loads in Unity.
        
    }
    void Update()
    {
        ReadFile(Location);
    }
    public string ReadFile(string Location) //read file function
    {
        TextReader textr = new StreamReader(Location); //Reads the text file from a certain location that is specified in Unity. Made for reuse.
        TextBox = textr.ReadLine(); //reads line by line on the text file \
        String TextBoxString = "" + TextBox;
        DisplayText(TextBoxString);
        return "Test";
    }
    public string DisplayText(string TextBoxString)
    {
        string Display = "" + TextBox;
        return Display;
    }
}

