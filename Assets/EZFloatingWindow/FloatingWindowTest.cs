/* Author:          #AUTHORNAME#
 * CreateTime:      #CREATETIME#
 * Orgnization:     #ORGNIZATION#
 * Description:     
 */
using UnityEngine;
using UnityEngine.UI;

namespace EZhex1991
{
    public class FloatingWindowTest : MonoBehaviour
    {
        public Button button_GetPermission;
        public Button button_StartService;
        public Button button_StopService;

        private void Start()
        {
            EZFloatingWindow.Init(Application.identifier);
            button_GetPermission.onClick.AddListener(GetPermission);
            button_StartService.onClick.AddListener(StartService);
            button_StopService.onClick.AddListener(StopService);
        }

        private void GetPermission()
        {
            EZFloatingWindow.GetPermission();
        }

        private void StartService()
        {
            EZFloatingWindow.StartService();
        }

        private void StopService()
        {
            EZFloatingWindow.StopService();
        }
    }
}
