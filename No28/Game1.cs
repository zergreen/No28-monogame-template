using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using No28.GameObject;

namespace No28
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GAMESTATE gameState;

        //private Vector2 mousePosition; // Dev

        public enum GAMESTATE
        {
            PAUSE,
            GAME_OVER,
            VICTORY,
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            _graphics.PreferredBackBufferWidth = Singleton.GAMEWIDTH;
            _graphics.PreferredBackBufferHeight = Singleton.GAMEHEIGHT;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Singleton.Instance.TILESPRITE = Content.Load<Texture2D>("tile");
            Singleton.Instance.PLAYERSPRITE = Content.Load<Texture2D>("player");
            Singleton.Instance.ORESPRITE = Content.Load<Texture2D>("ore");
            Singleton.Instance.SHROOMSPRITE = Content.Load<Texture2D>("shroom");
            Singleton.Instance.CHOMPERSPRITE = Content.Load<Texture2D>("chomper");
            Singleton.Instance.HEALTHBAR = Content.Load<Texture2D>("healthbar");
            Singleton.Instance.BOSSSPRITE = Content.Load<Texture2D>("boss");
            Singleton.Instance.INFO = Content.Load<Texture2D>("instruction");
            Singleton.Instance.FALLEN = Content.Load<Texture2D>("fallen");
            Singleton.Instance.BGTUTORIAL = Content.Load<Texture2D>("bg1");
            Singleton.Instance.BGFOREST = Content.Load<Texture2D>("bg2");
            Singleton.Instance.FONT = Content.Load<SpriteFont>("GameFont");

            Vector2 playerSpawnPoint = new Vector2(Singleton.GAMEWIDTH / 2, Singleton.GAMEHEIGHT / 2);

            Singleton.Instance.PLAYER = new GameObject.Player(playerSpawnPoint);
            Singleton.Instance.ENEMY = new GameObject.Enemy();
            Singleton.Instance.BULLET = new GameObject.Bullet();
            Singleton.Instance.BLOCK = new Block();
            Singleton.Instance.LEVEL = new Level();
            Singleton.Instance.PHYSICS = new Physics();
            Singleton.Instance.CAMERA = new GameObject.Camera();
            Singleton.Instance.PROJECTILE = new Projectile();
            Singleton.Instance.INTERFACE = new GameObject.Interface();
            Singleton.Instance.ANIMATOR = new Animator();
            Singleton.Instance.INTERFACE = new Interface();
            Singleton.Instance.BG = new Background();

        }

        protected void Reset()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Dev
            //Singleton.Instance.MOUSESTATE = Mouse.GetState();
            //mousePosition = new Vector2(Singleton.Instance.MOUSESTATE.X / 32, Singleton.Instance.MOUSESTATE.Y / 32);

            switch(gameState)
            {
                case GAMESTATE.PAUSE:
                    break;

                case GAMESTATE.GAME_OVER:
                    break;

                case GAMESTATE.VICTORY:
                    break;
            }

            Singleton.Instance.PLAYER.Update(gameTime);
            Singleton.Instance.PHYSICS.Update(gameTime);
            Singleton.Instance.CAMERA.FollowPlayer(Singleton.Instance.PLAYER.GetPosition());
            Singleton.Instance.BG.Update(gameTime);
            Singleton.Instance.BULLET.Update(gameTime);
            Singleton.Instance.ENEMY.Update(gameTime);
            Singleton.Instance.PROJECTILE.Update(gameTime, Singleton.Instance.CAMERA.GetCameraFollowFrame(Singleton.Instance.PLAYER.GetPosition()));
            Singleton.Instance.ANIMATOR.Update(gameTime);

            Vector2 healthbarPosition = new Vector2(Singleton.Instance.PLAYER.GetPosition().X - Singleton.GAMEWIDTH / 2, 0);

            Singleton.Instance.INTERFACE.GetHealthbarPosition(healthbarPosition);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: Singleton.Instance.CAMERA.translateMatrix);

            Singleton.Instance.BG.Draw(_spriteBatch);
            Singleton.Instance.PLAYER.Draw(_spriteBatch);
            Singleton.Instance.BULLET.Draw(_spriteBatch);
            Singleton.Instance.ENEMY.Draw(_spriteBatch);
            Singleton.Instance.PROJECTILE.Draw(_spriteBatch);
            Singleton.Instance.LEVEL.Draw(_spriteBatch);
            //_spriteBatch.DrawString(Singleton.Instance.FONT, mousePosition.ToString(), Singleton.Instance.MOUSESTATE.Position.ToVector2(), Color.White); //Dev
            Singleton.Instance.INTERFACE.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}