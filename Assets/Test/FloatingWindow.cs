/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using UnityEngine;
using UnityEngine.UI;

namespace EZhex1991
{
    public class FloatingWindow : MonoBehaviour
    {
        public Button button_GetPermission;
        public Button button_StartService;
        public Button button_StopService;
        public Button button_ChangeBackground;

        public Texture2D[] textures;
        private int currentIndex = 0;

        private void Start()
        {
            button_GetPermission.onClick.AddListener(GetPermission);
            button_StartService.onClick.AddListener(StartService);
            button_StopService.onClick.AddListener(StopService);
            button_ChangeBackground.onClick.AddListener(ChangeBackground);
        }

        private void Update()
        {
            EZFloatingWindow.SetText(Time.time.ToString());
        }

        private void GetPermission()
        {
            EZFloatingWindow.GetPermission();
        }

        private void StartService()
        {
            EZFloatingWindow.Enable();
        }

        private void StopService()
        {
            EZFloatingWindow.Disable();
        }

        private void ChangeBackground()
        {
            currentIndex++;
            currentIndex = currentIndex % textures.Length;
            EZFloatingWindow.SetBackground(textures[currentIndex].EncodeToPNG());
        }
    }
}
