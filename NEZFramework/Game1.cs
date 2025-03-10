using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Console;
using System.Collections;

namespace NEZFramework
{
    public class Game1 : Nez.Core
    {
        Texture2D playerTexture;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 _playerPosition;
        private Vector2 _originalPosition;
        private Vector2 _centerPosition;

        protected override void Initialize()
        {
            base.Initialize();

            _spriteBatch = new SpriteBatch(Nez.Core.GraphicsDevice);
            playerTexture = Content.Load<Texture2D>("tile_0097");

            _originalPosition = new Vector2(50, 50);
            _centerPosition = new Vector2(GraphicsDevice.Viewport.Width / 2 - playerTexture.Width / 2,
                                          GraphicsDevice.Viewport.Height / 2 - playerTexture.Height / 2);
            _playerPosition = _originalPosition;

            // Start the coroutine
            Core.StartCoroutine(MoveSpriteCoroutine());
        }

        private IEnumerator MoveSpriteCoroutine()
        {
            yield return Coroutine.WaitForSeconds(3f);
            _playerPosition = _centerPosition;

            yield return Coroutine.WaitForSeconds(3f);
            _playerPosition = _originalPosition;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(playerTexture, _playerPosition, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
