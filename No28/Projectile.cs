using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using No28.GameObject;
using System.Collections.Generic;

namespace No28
{
    class Projectile
    {
        private List<Bullet> bullets = new List<Bullet>();

        public Projectile() 
        {
            
        }

        public void SpawnBulletLight(Vector2 playerPosition)
        {
            Bullet bullet = new Bullet();
            bullet.SpawnBulletLight(playerPosition);
            bullets.Add(bullet);
        }

        public void SpawnBulletHeavy(Vector2 playerPosition)
        {
            Bullet bullet = new Bullet();
            bullet.SpawnBulletHeavy(playerPosition);
            bullets.Add(bullet);
        }

        public void Update(GameTime gameTime, Rectangle camera)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);
            }

            bullets.RemoveAll(bullet => bullet.IsOutOfFrame(camera));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }
    }
}
