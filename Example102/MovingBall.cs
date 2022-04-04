using System.Numerics; // Vector2
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class MovingBall : SpriteNode
	{
		// your private fields here (add Velocity)
		private Vector2 velocity = new Vector2(500,500);

		// constructor + call base constructor
		public MovingBall() : base("resources/bigball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.ORANGE;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			// Move
			Position.X += velocity.X * deltaTime;
			Position.Y += velocity.Y * deltaTime;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// Bouncing Edges
			if (Position.X > scr_width) {
				velocity.X *= -1;
			} 
			else if (Position.X < 0) {
				velocity.X *= -1;
			}

			if (Position.Y > scr_height) {
				velocity.Y *= -1;
			} 
			else if (Position.Y < 0) {
				velocity.Y *= -1;
			}
		}

	}
}
