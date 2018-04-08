/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using UnityEngine;

namespace EZhex1991
{
    public static class EZFloatingWindow
    {
#if UNITY_ANDROID
        private static AndroidJavaClass unityPlayer;
        private static AndroidJavaObject unityActivity;

        private static AndroidJavaObject m_FloatingWindow;
        private static AndroidJavaObject floatingWindow
        {
            get
            {
                if (m_FloatingWindow == null) Debug.LogError("FloatingWindow initialize failed");
                return m_FloatingWindow;
            }
            set
            {
                m_FloatingWindow = value;
            }
        }
#endif

        static EZFloatingWindow()
        {
            unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            floatingWindow = new AndroidJavaObject("com.ezhex1991.ezfloatingwindow.FloatingWindow", unityActivity);
        }

        public static void GetPermission()
        {
#if UNITY_ANDROID
            if (floatingWindow != null) floatingWindow.Call("getPermission");
#endif
        }

        public static void Enable()
        {
#if UNITY_ANDROID
            if (floatingWindow != null) floatingWindow.Call("bindService");
#endif
        }

        public static void Disable()
        {
#if UNITY_ANDROID
            if (floatingWindow != null) floatingWindow.Call("unbindService");
#endif
        }

        public static void SetText(string text)
        {
#if UNITY_ANDROID
            if (floatingWindow != null) floatingWindow.Call("setText", text);
#endif
        }
        public static void SetBackground(byte[] imageBytes)
        {
#if UNITY_ANDROID
            if (floatingWindow != null) floatingWindow.Call("setBackground", imageBytes);
#endif
        }
    }
}
