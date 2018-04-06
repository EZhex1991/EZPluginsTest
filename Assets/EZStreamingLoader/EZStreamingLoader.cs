/*
 * Author:      #AUTHORNAME#
 * CreateTime:  #CREATETIME#
 * Description:
 * 
*/
using UnityEngine;

public static class EZStreamingLoader
{
#if UNITY_EDITOR
#elif UNITY_ANDROID
    private static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    private static AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    private static AndroidJavaClass streamingLoader = new AndroidJavaClass("com.ezhex1991.ezstreamingloader.StreamingLoader");
#endif

    public static byte[] LoadFile(string path)
    {
#if UNITY_EDITOR
        path = Application.streamingAssetsPath + "/" + path;
        return System.IO.File.ReadAllBytes(path);
#elif UNITY_ANDROID
        return streamingLoader.CallStatic<byte[]>("loadFile", unityActivity, path);
#endif
    }

    public static string LoadText(string path)
    {
#if UNITY_EDITOR
        path = Application.streamingAssetsPath + "/" + path;
        return System.IO.File.ReadAllText(path);
#elif UNITY_ANDROID
        byte[] bytes = LoadFile(path);
        return bytes == null ? "" : System.Text.Encoding.UTF8.GetString(bytes);
#endif
    }
}