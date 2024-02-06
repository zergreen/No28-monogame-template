using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace No28
{
    class Animator
    {
        private float duration;
        private float rotate;
        private float layer;
        private float scale;
        private float elapsedTime;

        private int maxFrame;
        private int currentFrame;
        private int width;

        private Texture2D texture;

        private Vector2 position;
        private Vector2 origin;

        private Rectangle rectangle;

        private Color color;

        private SpriteEffects effect;

        public Animator()
        {
            
        }

        public float GetDuration() { return duration; }

        public void Animation(Texture2D texture, Vector2 position, Rectangle rectangle, SpriteEffects effect, int maxFrame, float duration)
        {
            this.texture = texture;
            this.position = position;
            this.rectangle = rectangle;
            width = rectangle.Width;
            color = Color.White;
            origin = Vector2.Zero;
            scale = 1f;
            this.effect = effect;
            layer = 1f;
            this.maxFrame = maxFrame;
            this.duration = duration;
            if (currentFrame >= maxFrame)
            {
                currentFrame = 0;
            }
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTime >= duration)
            {
                elapsedTime = 0;
                currentFrame++;
                if (currentFrame >= maxFrame)
                    currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var rect = new Rectangle(rectangle.X + rectangle.Width * currentFrame, rectangle.Y, rectangle.Width, rectangle.Height);
            spriteBatch.Draw(texture, position, rect, color, rotate, origin, scale, effect, layer);
        }
    }
}
