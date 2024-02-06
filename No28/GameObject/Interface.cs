using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace No28.GameObject
{
    class Interface
    {
        private Vector2 healthbarPosition;

        private Texture2D texture = Singleton.Instance.HEALTHBAR;

        public Interface()
        {
            
        }

        public void GetHealthbarPosition(Vector2 healthbarPosition) 
        {
            this.healthbarPosition = healthbarPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Singleton.Instance.PLAYER.GetMaxHP() == 5)
            {
                switch (Singleton.Instance.PLAYER.GetCurrentHP())
                {
                    case 0:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(320, 64 * 5, 320, 64), Color.White);

                        break;

                    case 1:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(320, 64 * 4, 320, 64), Color.White);

                        break;

                    case 2:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(320, 64 * 3, 320, 64), Color.White);

                        break;

                    case 3:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(320, 64 * 2, 320, 64), Color.White);

                        break;

                    case 4:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(320, 64 * 1, 320, 64), Color.White);

                        break;

                    case 5:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(320, 64 * 0, 320, 64), Color.White);

                        break;
                }
            }
            else if (Singleton.Instance.PLAYER.GetMaxHP() == 10)
            {
                switch (Singleton.Instance.PLAYER.GetCurrentHP())
                {
                    case 0:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 10, 320, 64), Color.White);

                        break;

                    case 1:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 9, 320, 64), Color.White);

                        break;

                    case 2:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 8, 320, 64), Color.White);

                        break;

                    case 3:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 7, 320, 64), Color.White);

                        break;

                    case 4:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 6, 320, 64), Color.White);

                        break;

                    case 5:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 5, 320, 64), Color.White);

                        break;

                    case 6:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 4, 320, 64), Color.White);

                        break;

                    case 7:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 3, 320, 64), Color.White);

                        break;

                    case 8:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 2, 320, 64), Color.White);

                        break;

                    case 9:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 1, 320, 64), Color.White);

                        break;

                    case 10:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(0, 64 * 0, 320, 64), Color.White);

                        break;
                }
            }
            else if (Singleton.Instance.PLAYER.GetMaxHP() == 15)
            {
                switch (Singleton.Instance.PLAYER.GetCurrentHP())
                {
                    case 0:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(1280, 128 * 5, 320, 96), Color.White);

                        break;

                    case 1:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(1280, 128 * 4, 320, 96), Color.White);

                        break;

                    case 2:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(1280, 128 * 3, 320, 96), Color.White);

                        break;

                    case 3:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(1280, 128 * 2, 320, 96), Color.White);

                        break;

                    case 4:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(1280, 128 * 1, 320, 96), Color.White);

                        break;

                    case 5:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(960, 128 * 5, 320, 96), Color.White);

                        break;

                    case 6:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(960, 128 * 4, 320, 96), Color.White);

                        break;

                    case 7:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(960, 128 * 3, 320, 96), Color.White);

                        break;

                    case 8:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(960, 128 * 2, 320, 96), Color.White);

                        break;

                    case 9:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(960, 128 * 1, 320, 96), Color.White);

                        break;

                    case 10:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(640, 128 * 5, 320, 96), Color.White);

                        break;

                    case 11:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(640, 128 * 4, 320, 96), Color.White);

                        break;

                    case 12:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(640, 128 * 3, 320, 96), Color.White);

                        break;

                    case 13:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(640, 128 * 2, 320, 96), Color.White);

                        break;

                    case 14:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(640, 128 * 1, 320, 96), Color.White);

                        break;

                    case 15:
                        spriteBatch.Draw(texture, healthbarPosition, new Rectangle(640, 128 * 0, 320, 96), Color.White);

                        break;
                }
            }
        }
    }
}
