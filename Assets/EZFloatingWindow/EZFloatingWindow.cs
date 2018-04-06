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

        private static AndroidJavaClass floatingWindowService;
        private static AndroidJavaObject serviceIntent;
#endif

        public static void Init(string windowText)
        {
#if UNITY_ANDROID
            unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            floatingWindowService = new AndroidJavaClass("com.ezhex1991.ezfloatingwindow.FloatingWindowService");
            serviceIntent = floatingWindowService.CallStatic<AndroidJavaObject>("getServiceIntent", unityActivity, windowText);
#endif
        }

        public static void GetPermission()
        {
#if UNITY_ANDROID
            floatingWindowService.CallStatic("getPermission", unityActivity);
#endif
        }

        public static void StartService()
        {
#if UNITY_ANDROID
            floatingWindowService.CallStatic("startService", unityActivity, serviceIntent);
#endif
        }

        public static void StopService()
        {
#if UNITY_ANDROID
            floatingWindowService.CallStatic("stopService", unityActivity, serviceIntent);
#endif
        }
    }
}
