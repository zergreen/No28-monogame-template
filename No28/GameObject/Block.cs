using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace No28.GameObject
{
    class Block
    {
        public Level.Blocks blockType;

        public Rectangle block;

        public Vector2 position;

        public Block()
        {

        }

        public Block(Level.Blocks blockType, int positionX, int positionY, int width, int height)
        {
            this.blockType = blockType;
            position = new Vector2(positionX, positionY);
            block = new Rectangle(positionX, positionY, width, height);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
        }
    }
}
