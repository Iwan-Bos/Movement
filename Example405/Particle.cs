using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
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
	class Particle : MoverNode
	{
		// variables
		float lifespan;

		// constructor + call base constructor
		public Particle(float x, float y, Color color) : base("resources/spaceship.png")
		{
			Position = new Vector2(x, y);
			Acceleration = new Vector2();
			Velocity = new Vector2();

			Scale = new Vector2(0.25f, 0.25f);
			Color = color;
			lifespan = 255.0f;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			WrapEdges();
			Move(deltaTime);
			lifespan -= 2.0f;
		}

		private bool IsDead() 
		{
			if (lifespan <= 0) { return true; }
			return false;
		}

	}
}
