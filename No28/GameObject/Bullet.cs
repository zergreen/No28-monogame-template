using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace No28.GameObject
{
    class Bullet
    {
        public bool isAlive = false;
        public bool isLight = false;
        public bool isHeavy = false;

        private float bulletspeed = 2000f;

        private Vector2 position;
        private Vector2 direction;

        public Bullet() 
        {

        }

        public void SpawnBulletLight(Vector2 playerPosition)
        {
            if (Singleton.Instance.PLAYER.isFacingForward)
            {
                position = new Vector2((int)playerPosition.X, playerPosition.Y);
                direction.X = 1;
            }
            else
            {
                position = new Vector2((int)playerPosition.X, playerPosition.Y);
                direction.X = -1;
            }

            isLight = true;
            isAlive = true;
        }

        public void SpawnBulletHeavy(Vector2 playerPosition)
        {
            if (Singleton.Instance.PLAYER.isFacingForward)
            {
                position = new Vector2((int)playerPosition.X + 15, playerPosition.Y - 7);
                direction.X = 1;
            }
            else
            {
                position = new Vector2((int)playerPosition.X - 15, playerPosition.Y - 7);
                direction.X = -1;
            }

            isHeavy = true;
            isAlive = true;
        }

        public void Update(GameTime gameTime)
        {
            if (isAlive)
            {
                    position += direction * bulletspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isLight && isAlive)
            {
                spriteBatch.Draw(Singleton.Instance.PLAYERSPRITE, position, new Rectangle(352, 64, 32, 32), Color.White);
            }
            else if (isHeavy && isAlive){
                spriteBatch.Draw(Singleton.Instance.PLAYERSPRITE, position, new Rectangle(352, 96, 32, 32), Color.White);
            }
        }

        public bool IsOutOfFrame(Rectangle camera)
        {
            Rectangle bullet = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            return !camera.Intersects(bullet);
        }
    }
}
