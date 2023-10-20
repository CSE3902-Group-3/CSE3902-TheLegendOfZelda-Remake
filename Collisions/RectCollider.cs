using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda
{
    

    public class RectCollider : IRectCollider, IDrawable
    {
        public Rectangle Rect { get; set; }
        public CollisionLayer Layer { get; }
        public ICollidable Collidable { get; }

        //The drawing functionality is added in this class because we want all RectColliders to have this capability
        //If we extended RectCollider we would have to change all RectColliders to the extended class and enforce it
        public static bool drawColliders = true;
        private SpriteBatch spriteBatch;
        private Texture2D textureWithWhitePixel;
        private Rectangle locationOfWhitePixel;
        private Color color;

        public Vector2 Pos
        {
            get
            {
                return new Vector2(Rect.Left, Rect.Top);
            }
            set
            {
                Rect = new Rectangle((int) value.X, (int) value.Y, Rect.Width, Rect.Height);
            }
        }

        private bool _active;
        public bool Active
        {
            get
            {
                return _active;
            }
            set
            {
                if(_active == false && value == true)
                {
                    collisionManager.AddRectCollider(this);
                } else if(_active == true && value == false)
                {
                    collisionManager.RemoveRectCollider(this);
                }
                _active = value;
            }
        }

        private CollisionManager collisionManager;

        public RectCollider(Rectangle rect, CollisionLayer layer, ICollidable collidable)
        {
            this.Rect = rect;
            this.Layer = layer;
            this.Collidable = collidable;

            collisionManager = CollisionManager.instance;
            _active = true;
            collisionManager.AddRectCollider(this);

            LevelMaster.RegisterCollider(this);

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
