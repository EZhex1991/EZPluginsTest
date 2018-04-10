/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using System;
using UnityEngine;

namespace EZhex1991
{
    public class FloatingWindowListener : AndroidJavaProxy
    {
        public FloatingWindowListener() : base("com.ezhex1991.ezfloatingwindow.IFloatingWindowListener") { }

        public event Action<int, int> onConnectedEvent;
        public event Action onDisconnectedEvent;
        public event Action onClickEvent;
        public event Action<int, int> onMoveEvent;

        public void onConnected(int x, int y)
        {
            if (onConnectedEvent != null) onConnectedEvent(x, y);
        }

        public void onDisconnected()
        {
            if (onDisconnectedEvent != null) onDisconnectedEvent();
        }

        public void onClick()
        {
            if (onClickEvent != null) onClickEvent();
        }

        public void onMove(int x, int y)
        {
            if (onMoveEvent != null) onMoveEvent(x, y);
        }
    }
}
