﻿namespace LegendOfZelda.Graphics
{
    //This class tests camera movements. Remove from final build, but keeping for now because it is useful for testing menus.
    public class CameraControllerTest
    {
        private CameraController controller;
        private LevelManager levelMaster;
        private Timer timer;
        private const float wait = 1f;
        private int i = 0;

        public CameraControllerTest()
        {
            controller = CameraController.GetInstance();
            levelMaster = LevelManager.GetInstance();
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
                    controller.OpenItemMenu(NewTimer);
                    break;
                case 1:
                    controller.CloseItemMenu(NewTimer);
                    break;
                case 2:
                    controller.ChangeMenu(Menu.Start);
                    NewTimer();
                    break;
                case 3:
                    controller.ChangeMenu(Menu.End);
                    NewTimer();
                    break;
                case 4:
                    controller.ChangeMenu(Menu.GameOver);
                    NewTimer();
                    break;
                case 5:
                    controller.ChangeMenu(Menu.Item);
                    NewTimer();
                    break;
            }

            i = (i + 1) % 6;
        }
    }
}
