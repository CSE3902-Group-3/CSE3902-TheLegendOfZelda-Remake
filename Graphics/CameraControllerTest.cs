using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Graphics
{
    //The only purpose of this class is to test the camera controller. Remove from final build
    public class CameraControllerTest
    {
        private CameraController controller;
        private Timer timer;
        private const float wait = 1f;
        private int i = 0;

        public CameraControllerTest()
        {
            controller = CameraController.GetInstance();
            timer = new Timer(wait, OnTimer);
        }

        private void NewTimer()
        {
            timer = new Timer(wait, OnTimer);
        }
        public void OnTimer()
        {
            switch (i)
            {
                case 0:
                    controller.PanCamToRoom(1, Direction.right, NewTimer);
                    break;
                case 1:
                    controller.PanCamToRoom(0, Direction.left, NewTimer);
                    break;
                case 2:
                    controller.PanCamToRoom(2, Direction.up, NewTimer);
                    break;
                case 3:
                    controller.PanCamToRoom(0, Direction.down, NewTimer);
                    break;
                case 4:
                    controller.PanCamToRoom(3, Direction.left, NewTimer);
                    break;
                case 5:
                    controller.PanCamToRoom(0, Direction.right, NewTimer);
                    break;
                case 6:
                    controller.PanCamToRoom(4, Direction.down, NewTimer);
                    break;
                case 7:
                    controller.PanCamToRoom(0, Direction.up, NewTimer);
                    break;
                case 8:
                    controller.OpenItemMenu(NewTimer);
                    break;
                case 9:
                    controller.CloseItemMenu(NewTimer);
                    break;
                case 10:
                    controller.ChangeMenu(Menu.Start);
                    NewTimer();
                    break;
                case 11:
                    controller.ChangeMenu(Menu.End);
                    NewTimer();
                    break;
                case 12:
                    controller.ChangeMenu(Menu.Item);
                    NewTimer();
                    break;
            }

            i = (i + 1) % 13;
        }
    }
}
