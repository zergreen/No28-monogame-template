using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using No28.GameObject;

namespace No28
{
    class Background
    {
        private Vector2 backgroundPosition;

        private Texture2D texture;
        private Texture2D texture1 = Singleton.Instance.BGTUTORIAL;
        private Texture2D texture2 = Singleton.Instance.BGFOREST;

        public Background()
        {

        }

        public void Update(GameTime gameTime)
        {
            Matrix inverseTransform = Matrix.Invert(Singleton.Instance.CAMERA.translateMatrix);
            backgroundPosition = -Singleton.Instance.CAMERA.position;

            if (Singleton.Instance.PLAYER.GetPosition().X > 50 * 32)
            {
                texture = texture2;
            }
            else
            {
                texture = texture1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, backgroundPosition, Color.White);
        }
    }
}
