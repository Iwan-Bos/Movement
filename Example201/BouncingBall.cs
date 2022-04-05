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
	class BouncingBall : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, AddForce method)
		Vector2 Velocity = new Vector2(0,0);
		Vector2 Acceleration = new Vector2(0,0);

		Vector2 wind = new Vector2(0.0f, 0.0f);
		Vector2 gravity = new Vector2(0.0f, 980.0f);
		float mass = 1f;

		// constructor + call base constructor
		public BouncingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 6, Settings.ScreenSize.Y / 4);
			Color = Color.BLUE;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Position += Velocity * deltaTime;
			Move(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT)) { wind.X = 1000f; }
			if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT)) { wind.X = -1000f; }
			AddForce(wind);
			AddForce(gravity);
			Velocity += (Acceleration * mass) * deltaTime;
			Acceleration = Vector2.Zero;
			wind.X = 0f;
		}
		

		private void AddForce(Vector2 force)
		{
			Acceleration += force;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			if (Position.X > scr_width) {
				Velocity.X *= -1;
			} 
			else if (Position.X < 0) {
				Velocity.X *= -1;
			}

			if (Position.Y > scr_height) {
				Velocity.Y *= -1;
			} 
			else if (Position.Y < 0) {
				Velocity.Y *= -1;
			}
		}

	}
}
