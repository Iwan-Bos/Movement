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
	class BouncingBall : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, AddForce method)
		Vector2 wind = new Vector2(0.0f, 0.0f);
		Vector2 gravity = new Vector2(0.0f, 980.0f);
		float mass = 2f;

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
			MoveWithForce(deltaTime);
			BounceEdgesForBoll();
			// WrapEdges();
		}

		// your own private methods
		private void MoveWithForce(float deltaTime)
		{
			// Wind conditions on input
			if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_RIGHT)) { wind.X = 1000f; }
			else if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT)) { wind.X = -1000f; }
			else { wind.X = 100f; }
			
			// adding forces to Acceleration
			AddForce(wind);
			AddForce(gravity);

			// Changing the position according to the Velocity 
			// Move() resets Acceleration
			Move(deltaTime);
			wind.X = 0f;
		}
		protected void BounceEdgesForBoll() 
		{
			// some stuff that should be universal, but that I'm too lazy for 
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// Bouncing edges
			if (Position.X + TextureSize.X / 2 > scr_width) {
				Velocity.X *= -1;
			} 
			else if (Position.X - TextureSize.X / 2 < 0) {
				Velocity.X *= -1;
			}

			if (Position.Y + TextureSize.Y / 2 > scr_height) {
				Velocity.Y *= -1;
			} 
			else if (Position.Y - TextureSize.Y / 2 < 0) {
				Velocity.Y *= -1;
			}

		}

	}
}
