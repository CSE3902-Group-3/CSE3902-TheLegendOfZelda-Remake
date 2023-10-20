using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda
{
    public class DrawableRectCollider : RectCollider, IDrawable
    {
        public static bool drawColliders = true;
        private SpriteBatch spriteBatch;
        private Texture2D textureWithWhitePixel;
        private Rectangle locationOfWhitePixel;
        private Color color;

        public DrawableRectCollider(Rectangle rect, CollisionLayer layer, ICollidable collidable) : base(rect, layer, collidable)
        {
            spriteBatch = Game1.getInstance()._spriteBatch;
            textureWithWhitePixel = SpriteFactory.getInstance().linkTexture;
            locationOfWhitePixel = new Rectangle(118, 64, 1, 1);

            color = new Color(255, 0, 0, .25f);

            if (drawColliders)
            {
                LevelMaster.RegisterDrawable(this);
            }
        }

        public void Draw()
        {
            spriteBatch.Draw(textureWithWhitePixel, Rect, locationOfWhitePixel, color);
        }
    }
}
