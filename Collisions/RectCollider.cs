using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda
{
    

    public class RectCollider : IRectCollider, IDrawable
    {
        public Rectangle Rect { get; set; }
        public CollisionLayer Layer { get; }
        public ICollidable Collidable { get; }

        public static bool drawColliders = false;
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
                    if (drawColliders)
                    {
                        LevelManager.AddDrawable(this);
                    }
                } else if(_active == true && value == false)
                {
                    collisionManager.RemoveRectCollider(this);
                    if (drawColliders)
                    {
                        LevelManager.RemoveDrawable(this);
                    }
                }
                _active = value;
            }
        }

        private CollisionManager collisionManager;

        public RectCollider(Rectangle rect, CollisionLayer layer, ICollidable collidable, bool persistent = false)
        {
            this.Rect = rect;
            this.Layer = layer;
            this.Collidable = collidable;

            collisionManager = CollisionManager.instance;
            _active = true;
            collisionManager.AddRectCollider(this);

            LevelManager.AddCollider(this, persistent);

            spriteBatch = Game1.getInstance()._spriteBatch;
            textureWithWhitePixel = SpriteFactory.getInstance().linkTexture;
            locationOfWhitePixel = new Rectangle(118, 64, 1, 1);

            color = new Color(255, 0, 0, .25f);

            if (drawColliders)
            {
                LevelManager.AddDrawable(this, persistent);
            }
        }

        public void Draw()
        {
            spriteBatch.Draw(textureWithWhitePixel, Rect, locationOfWhitePixel, color);
        }
    }
}
