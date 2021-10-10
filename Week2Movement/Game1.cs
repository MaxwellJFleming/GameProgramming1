using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Week2Movement
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private float screenHeight;
        private float screenWidth;
        private SpriteFont Arial;
        private Texture2D Character;

        private Character player1;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            screenHeight = graphics.GraphicsDevice.Viewport.Height;
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            
            player1 = new Character(Keys.Up, 20, 1.4f, new Vector2(screenWidth/2, screenHeight));
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Arial = Content.Load<SpriteFont>("Arial");
            Character = Content.Load<Texture2D>("Player");
            
            //player1.Texture = Character;
        }

        protected override void Update(GameTime gameTime)
        {
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(player1.JumpButton) && player1.Pos.Y == 0)
                player1.Jump();
            
            player1.UpdatePos(time);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(Character, player1.Pos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
