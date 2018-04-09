/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991
{
    public static class EZLauncher
    {
#if UNITY_ANDROID
        private static AndroidJavaClass unityPlayer;
        private static AndroidJavaObject unityActivity;

        private static AndroidJavaObject launcher;
#endif

        static EZLauncher()
        {
            unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            launcher = new AndroidJavaObject("com.ezhex1991.ezlauncher.Launcher", unityActivity);
        }

        public static void ShowNavigator()
        {
            launcher.Call("showNavigator");
        }
    }
}
