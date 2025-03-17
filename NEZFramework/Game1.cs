using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Tweens;

namespace NEZFramework
{
    public class Game1 : Nez.Core
    {
        private Entity _playerEntity;
        private SpriteRenderer _spriteRenderer;

        public Game1() : base() { }

        protected override void Initialize()
        {
            base.Initialize();

            // Create a scene
            var scene = new Scene();
            scene.AddRenderer(new DefaultRenderer());

            // Load the texture
            var texture = scene.Content.Load<Texture2D>("tile_0097");

            // Create the player entity
            _playerEntity = scene.CreateEntity("player");
            _playerEntity.Position = new Vector2(50, 50); // Starting position

            // Add a sprite renderer component
            _spriteRenderer = _playerEntity.AddComponent(new SpriteRenderer(texture));

            // Calculate center position
            Vector2 centerPosition = new Vector2(
                GraphicsDevice.Viewport.Width / 2 - texture.Width / 2,
                GraphicsDevice.Viewport.Height / 2 - texture.Height / 2
            );

            // Manually create a Vector2Tween
            var tween = new Vector2Tween();
            tween.Initialize(new PositionTweenTarget(_playerEntity), centerPosition, 3f);
            tween.SetEaseType(EaseType.QuartInOut);

            // Start the tween
            TweenManager.AddTween(tween);
            tween.Start();

            // Set the active scene
            Scene = scene;
        }
    }

    // Custom TweenTarget for Position
    public class PositionTweenTarget : ITweenTarget<Vector2>
    {
        private Entity _entity;

        public PositionTweenTarget(Entity entity)
        {
            _entity = entity;
        }

        public Vector2 GetTweenedValue()
        {
            return _entity.Position;
        }

        public void SetTweenedValue(Vector2 value)
        {
            _entity.Position = value;
        }

        public void SetTweenedValue(float x, float y)
        {
            _entity.Position = new Vector2(x, y);
        }

        public object GetTargetObject()  // Required by ITweenTarget<Vector2>
        {
            return _entity;
        }
    }
}