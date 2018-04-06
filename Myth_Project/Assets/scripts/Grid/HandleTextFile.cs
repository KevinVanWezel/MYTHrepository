using UnityEngine;
using UnityEditor;
using System.IO;

public class HandleTextFile : MonoBehaviour
{
    private void Start()
    {

    }

    //[MenuItem("Tools/Write file")]
    //static void WriteString()
    //{
    //    string path = "Assets/Resources/test.txt";

    //    //Write some text to the test.txt file
    //    StreamWriter writer = new StreamWriter(path, true);
    //    writer.WriteLine("Test");
    //    writer.Close();

    //    //Re-import the file to update the reference in the editor
    //    AssetDatabase.ImportAsset(path);
    //    TextAsset asset = Resources.Load("test");

    //    //Print the text from the file
    //    Debug.Log(asset.text);
    //}

    [MenuItem("Tools/Read file")]
    public string ReadString(string path)
    {
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        string result = reader.ReadToEnd();
        reader.Close();
        return result;
    }
}