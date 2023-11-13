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
