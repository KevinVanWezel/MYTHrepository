using UnityEngine;
using System.IO;

public class HandleTextFile : MonoBehaviour
{
    public string ReadString(string path)
    {
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string result = reader.ReadToEnd();
        reader.Close();
        return result;
    }
}