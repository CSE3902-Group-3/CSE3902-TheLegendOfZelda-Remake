namespace LegendOfZelda
{
    public class MainMenu
    {
        private AnimatedSprite menuScreen;

        public MainMenu()
        {
            menuScreen = SpriteFactory.getInstance().CreateMainMenuSprite();
            menuScreen.UpdatePos(CameraController.GetInstance().StartLocation);
        }

    }
}
