using System; // Console
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
	class SpaceShip : MoverNode
	{
		// your private fields here (rotSpeed, thrustForce)
		private float rotSpeed;
		private float thrustForce;

		// constructor + call base constructor
		public SpaceShip() : base("resources/spaceship.png")
		{
			rotSpeed = (float)Math.PI; // rad/second
			thrustForce = 500f;
			Maxspeed = 99999999999999999999999.0f;

			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 2);
			Color = Color.YELLOW;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			WrapEdges();
			Move(deltaTime);

			Console.Clear();
			Console.WriteLine("Rot: " + Rotation * 180);
			Console.WriteLine("Acc X: " + thrustForce * Math.Cos(Convert.ToSingle(Rotation)));
			Console.WriteLine("Acc Y: " + thrustForce * Math.Sin(Convert.ToSingle(Rotation)));
			Console.WriteLine("Velocity X: " + Velocity.X);
			Console.WriteLine("Velocity Y: " + Velocity.Y);
		}

		// your own private methods
		public void RotateRight(float deltaTime)
		{
			Rotation += rotSpeed * deltaTime;
		}
		public void RotateLeft(float deltaTime)
		{
			Rotation -= rotSpeed * deltaTime;
		}

		public void Thrust()
		{
			Color = Color.ORANGE;
			Acceleration.X += thrustForce * Convert.ToSingle(Math.Cos(Rotation));
			Acceleration.Y += thrustForce * Convert.ToSingle(Math.Sin(Rotation));
		}
		public void Brake(float deltaTime)
		{
			Color = Color.BLUE;
			// Acceleration.X -= brakeForce * Convert.ToSingle(Math.Cos(Rotation));
			// Acceleration.Y -= brakeForce * Convert.ToSingle(Math.Sin(Rotation));
			// if (Velocity.X == 0.0f) { Acceleration.X = 0.0f; }
			// if (Velocity.Y == 0.0f) { Acceleration.Y = 0.0f; }
			Velocity *= 0.8f * deltaTime;
		}
		public void NoThrust() { Color = Color.YELLOW; }
		public void NoBrake() { Color = Color.YELLOW; }

	}
}
