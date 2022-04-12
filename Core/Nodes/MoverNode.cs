using System.Numerics;
using Raylib_cs;

namespace Movement
{
	abstract class MoverNode : SpriteNode
	{
		public Vector2 Velocity;
		public Vector2 Acceleration;
		private float mass;

		// public Vector2 Velocity { 
		// 	get { return velocity; }
		// 	set { velocity = value; }
		// }
		// public Vector2 Acceleration { 
		// 	get { return acceleration; }
		// 	set { acceleration = value; }
		// }
		// public float Mass { 
		// 	get { return mass; }
		// 	private set { mass = value; }
		// }

		// constructor
		protected MoverNode(string title) : base(title)
		{
			Velocity = new Vector2(0, 0);
			Acceleration = new Vector2(0, 0);
			mass = 1.0f;
		}

		public override void Update(float deltaTime)
		{
			// override in your subclass
		}

		// Protected methods to be called from subclass
		protected void Move(float deltaTime)
		{
			// Motion 101. Apply the rules.
			Velocity += Acceleration * deltaTime;
			Position += Velocity * deltaTime;
			// Reset acceleration
			Acceleration *= 0.0f;

			// output Velocity
			System.Console.WriteLine(Velocity);
		}
		protected void AddForce(Vector2 force)
		{
			Acceleration += force / mass;
		}
		protected void BounceEdges() 
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
		protected void WrapEdges() 
		{
			// some stuff that should be universal, but that I'm too lazy for 
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_heigth = TextureSize.Y;

			// Wrap Edges
			if (Position.X - TextureSize.X / 2 > scr_width) {
				Position.X -= scr_width + TextureSize.X;
			}
			if (Position.X + TextureSize.X / 2 < 0) {
				Position.X += scr_width + TextureSize.X;
			}
			
			if (Position.Y - TextureSize.Y / 2 > scr_height) {
				Position.Y -= scr_height + TextureSize.Y;
			}
			if (Position.Y + TextureSize.Y / 2 < 0) {
				Position.Y += 0 + TextureSize.Y;
			}
		}
		protected void Follow(float deltaTime) 
		{
			// get mouse position & the direction the mouse is in relative to the object
			Vector2 mouse = Raylib.GetMousePosition();
			Vector2 direction = mouse - Position;

			// normalize the magnitude of direction and make it any length we want
			Vector2.Normalize(direction);
			direction *= 1.0f;
			Acceleration = direction;
		}
		protected void PointToMouse(float deltaTime)
		{
			// get mouse position & the direction the mouse is in relative to the object
			Vector2 mouse = Raylib.GetMousePosition();
			Vector2 direction = mouse - Position;

			// use the inverse tangent to get an angle in degrees 
			// set the rotation to the calculated angle
			double angle = System.Math.Atan2(direction.Y, direction.X);
			Rotation = angle;
		}
	}
}
