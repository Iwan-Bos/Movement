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
	class AcceleratingBall : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private Vector2 Velocity = new Vector2(50,50);
		private Vector2 Acceleration = new Vector2(0.01f,0.01f);
		private Vector2 MaxSpeed = new Vector2(5000,5000);
		

		// constructor + call base constructor
		public AcceleratingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.RED;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			BounceEdges();
			Accelerate();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			Position.X += Velocity.X * deltaTime;
			Position.Y += Velocity.Y * deltaTime;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			if (Position.X > scr_width) {
				Velocity.X *= -1;
				Acceleration.X *= -1;
			} 
			else if (Position.X < 0) {
				Velocity.X *= -1;
				Acceleration.X *= -1;
			}

			if (Position.Y > scr_height) {
				Velocity.Y *= -1;
				Acceleration.Y *= -1;
			} 
			else if (Position.Y < 0) {
				Velocity.Y *= -1;
				Acceleration.Y *= -1;
			}
		}

		private void Accelerate() {
			// if max speed not reached, velocity += acceleration
			if (Velocity.X < MaxSpeed.X && Velocity.X > -MaxSpeed.X) {
				Velocity.X += Acceleration.X;
			}

			if (Velocity.Y < MaxSpeed.Y && Velocity.Y > -MaxSpeed.Y) {
				Velocity.Y += Acceleration.Y;
			}

		}
	}
}
