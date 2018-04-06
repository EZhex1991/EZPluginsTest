/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using UnityEngine;
using System.IO;

public class StreamingLoader : MonoBehaviour
{
    string text = "";

    void StreamLoad(string path)
    {
        text = EZStreamingLoader.LoadText(path);
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 300, 80), "1"))
        {
            StreamLoad("test.txt");
        }
        GUI.TextField(new Rect(10, 600, 500, 290), text);
    }
}