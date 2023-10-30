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
        private LevelMaster levelMaster;
        private Timer timer;
        private const float wait = 1f;
        private int i = 0;

        public CameraControllerTest()
        {
            controller = CameraController.GetInstance();
            levelMaster = LevelMaster.GetInstance();
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
                    levelMaster.NavigateInDirection(Direction.right, NewTimer);
                    break;
                case 1:
                    levelMaster.NavigateInDirection(Direction.right, NewTimer);
                    break;
                case 2:
                    levelMaster.NavigateInDirection(Direction.left, NewTimer);
                    break;
                case 3:
                    levelMaster.NavigateInDirection(Direction.up, NewTimer);
                    break;
                case 4:
                    levelMaster.NavigateInDirection(Direction.down, NewTimer);
                    break;
                case 5:
                    levelMaster.NavigateInDirection(Direction.right, NewTimer);
                    break;
                case 6:
                    levelMaster.NavigateInDirection(Direction.left, NewTimer);
                    break;
                case 7:
                    levelMaster.NavigateInDirection(Direction.left, NewTimer);
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
