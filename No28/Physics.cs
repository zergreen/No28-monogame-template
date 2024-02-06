using Microsoft.Xna.Framework;
using No28.GameObject;
using System.ComponentModel.Design;

namespace No28
{
    class Physics
    {
        public float gravityforce = 1000f;

        private Vector2 gravityDirection = new Vector2(0, 1);

        public Physics()
        {

        }

        public void CheckCollision(Vector2 playerPosition)
        {
            Rectangle player = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, 32, 64);

            foreach (var block in Level.blocks)
            {
                if (block.blockType != Level.Blocks.NONE)
                {
                    if (player.Intersects(block.block))
                    {
                        if (player.Bottom >= block.block.Top)
                        {
                            Singleton.Instance.PLAYER.isGrounded = true;
                            Vector2 newPosition = new Vector2((int)playerPosition.X, block.block.Top - player.Height);
                            Singleton.Instance.PLAYER.SetNewPosition(newPosition);
                        }
                    }
                    else Singleton.Instance.PLAYER.isGrounded = false;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            Singleton.Instance.PLAYER.ApplyGravity(gravityDirection, gravityforce, gameTime);
            CheckCollision(Singleton.Instance.PLAYER.GetPosition());
        }
    }
}
