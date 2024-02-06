using Microsoft.Xna.Framework;

namespace No28.GameObject
{
    class Camera
    {
        public Matrix translateMatrix;

        public Vector2 position;

        public Camera()
        {

        }

        public void FollowPlayer(Vector2 playerPosition)
        {
            position = new Vector2((Singleton.GAMEWIDTH / 2) - playerPosition.X, 0);

            translateMatrix = Matrix.CreateTranslation(position.X, position.Y, 0f);
        }

        public Rectangle GetCameraFollowFrame(Vector2 playerPosition)
        {
            Rectangle camera = new Rectangle((int)playerPosition.X - Singleton.GAMEWIDTH / 2, 0, Singleton.GAMEWIDTH, Singleton.GAMEHEIGHT);

            return camera;
        }
    }
}
