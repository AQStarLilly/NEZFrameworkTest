using Microsoft.Xna.Framework;
using Nez;
using Nez.Tweens;

public class TweeningScene : Scene
{
    public override void Initialize()
    {
        base.Initialize();

        // Set up a basic renderer
        AddRenderer(new DefaultRenderer());

        // Create an entity
        var entity = CreateEntity("tweenedEntity");

        // Add a sprite (you can replace this with your own texture)
        var texture = Content.Load<Texture2D>("your_texture"); // Replace with actual texture path
        var sprite = entity.AddComponent(new SpriteRenderer(texture));

        // Set the entity's starting position
        entity.Position = new Vector2(100, 100);

        // Apply a tween to move the entity smoothly to (400, 100) over 2 seconds
        entity.TweenPosition(new Vector2(400, 100), 2f)
              .SetEaseType(EaseType.QuartInOut) // Smooth easing
              .Start();
    }
}