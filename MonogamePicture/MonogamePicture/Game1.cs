using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogamePicture
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private float screenHeight;
        private float screenWidth;
        private SpriteFont comicSans;
        private Texture2D marbleBackground;
        private Texture2D froggy;
        private Texture2D chimp;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            screenHeight = graphics.GraphicsDevice.Viewport.Height;
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            comicSans = Content.Load<SpriteFont>("comicsans");
            marbleBackground = Content.Load<Texture2D>("marbleBackground");
            froggy = Content.Load<Texture2D>("froggy");
            chimp = Content.Load<Texture2D>("chimp");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(marbleBackground, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(froggy, new Vector2(10, 20), Color.White);
            spriteBatch.Draw(chimp, new Vector2(screenWidth-(screenWidth/8+chimp.Width), 10), Color.White);
            spriteBatch.DrawString(comicSans, "graphic design is my passion", new Vector2(screenWidth/8, screenHeight-(screenHeight/4)), Color.Red);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
