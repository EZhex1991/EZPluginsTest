/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using System;
using UnityEngine;

namespace EZhex1991
{
    public static class EZFloatingWindow
    {
#if UNITY_ANDROID
        private static AndroidJavaClass unityPlayer;
        private static AndroidJavaObject unityActivity;

        private static FloatingWindowListener listener;
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

        public static event Action<int, int> onEnableEvent { add { listener.onConnectedEvent += value; } remove { listener.onConnectedEvent -= value; } }
        public static event Action onDisableEvent { add { listener.onDisconnectedEvent += value; } remove { listener.onDisconnectedEvent -= value; } }
        public static event Action<int, int> onMoveEvent { add { listener.onMoveEvent += value; } remove { listener.onMoveEvent -= value; } }
        public static event Action onClickEvent { add { listener.onClickEvent += value; } remove { listener.onClickEvent -= value; } }

        static EZFloatingWindow()
        {
            unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            listener = new FloatingWindowListener();
            floatingWindow = new AndroidJavaObject("com.ezhex1991.ezfloatingwindow.FloatingWindow", unityActivity, listener);
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
