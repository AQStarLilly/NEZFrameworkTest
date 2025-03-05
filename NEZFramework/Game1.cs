using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;

namespace NEZFramework
{
    public class Game1 : Nez.Core
    {
        Texture2D playerTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

      
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            _spriteBatch = new SpriteBatch(Nez.Core.GraphicsDevice);
            playerTexture = Content.Load<Texture2D>("tile_0097");
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

            _spriteBatch.Begin();
            _spriteBatch.Draw(playerTexture, new Vector2(50, 50), Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
