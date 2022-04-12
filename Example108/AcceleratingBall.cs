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
	class AcceleratingBall : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private Vector2 MaxSpeed = new Vector2(5000,5000);
		

		// constructor + call base constructor
		public AcceleratingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 4 * 3, Settings.ScreenSize.Y / 4);
			Velocity = new Vector2(50.0f,50.0f);
			Color = Color.RED;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Accelerate(deltaTime);
			Move(deltaTime);
			WrapEdges();
		}

		private void Accelerate(float deltaTime) {
			// if max speed not reached, velocity += acceleration
			if (Velocity.X < MaxSpeed.X && Velocity.X > -MaxSpeed.X) {
				Acceleration.X += 5000.0f * deltaTime;
			}
			if (Velocity.Y < MaxSpeed.Y && Velocity.Y > -MaxSpeed.Y) {
				Acceleration.Y += 5000.0f * deltaTime;
			}
		}
	}
}