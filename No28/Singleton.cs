using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using No28.GameObject;

namespace No28
{
    class Singleton
    {
        public const int GAMEWIDTH = 1280;
        public const int GAMEHEIGHT = 720;

        public Texture2D TILESPRITE;
        public Texture2D PLAYERSPRITE;
        public Texture2D ORESPRITE;
        public Texture2D SHROOMSPRITE;
        public Texture2D CHOMPERSPRITE;
        public Texture2D HEALTHBAR;
        public Texture2D BOSSSPRITE;
        public Texture2D INFO;
        public Texture2D FALLEN;
        public Texture2D BGTUTORIAL;
        public Texture2D BGFOREST;

        public SpriteFont FONT;

        public KeyboardState KEYSTATE;

        //public MouseState MOUSESTATE;

        public Player PLAYER;
        public Bullet BULLET;
        public Projectile PROJECTILE;
        public Block BLOCK;
        public Camera CAMERA;
        public Level LEVEL;
        public Physics PHYSICS;
        public Interface INTERFACE;
        public Animator ANIMATOR;
        public Enemy ENEMY;
        public Background BG;

        private static Singleton instance;

        private Singleton()
        {

        }

        public static Singleton Instance
        { 
            get 
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }
    }
}
