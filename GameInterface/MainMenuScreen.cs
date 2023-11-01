using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class MainMenuScreen
    {
        private AnimatedSprite mainSprite;

        // Basically the original main menu was animated and there was a static overlay of the sword and some of the leaves to prevent them from changing
        // but because we don't have a way to change the colors on an image at runtime, we can't do that because the spritesheet is dumb and stupid and one color in both frames
        //private AnimatedSprite overlay;

        public MainMenuScreen()
        {
            mainSprite = SpriteFactory.getInstance().CreateMainMenuSprite();
            //overlay = SpriteFactory.getInstance().CreateMainMenuOverlaySprite();

            mainSprite.UpdatePos(new Vector2(0, 0));
            //overlay.UpdatePos(new Vector2(0, 0));

            mainSprite.RegisterSprite();
            //overlay.RegisterSprite();
        }

    }
}
