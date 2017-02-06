

namespace Lite
{
	public struct Vector2
	{
		public float x;
		public float y;

		public Vector2(float x, float y)
		{
			this.x = x; this.y = y;
		}

		public void Set(float x, float y)
		{
			this.x = x; this.y = y;
		}

		public static Vector2 zero { get { return new Vector2(0, 0); } }

		public static Vector2 one { get { return new Vector2(1, 1); } }

		public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
		{
			return new Vector2(vec1.x + vec2.x, vec1.y + vec2.y);
		}

		public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
		{
			return new Vector2(vec1.x - vec2.x, vec1.y - vec2.y);
		}

		public static Vector2 operator *(Vector2 vec, int n)
		{
			return new Vector2(vec.x*n, vec.y*n);
		}

		public static Vector2 operator *(Vector2 vec, float n)
		{
			return new Vector2(vec.x*n, vec.y*n);
		}

		public static Vector2 operator /(Vector2 vec, int n)
		{
			return new Vector2(vec.x/n, vec.y/n);
		}

		public static Vector2 operator /(Vector2 vec, float n)
		{
			return new Vector2(vec.x/n, vec.y/n);
		}

		public float Length()
		{
			return (float)System.Math.Sqrt(x*x + y*y);
		}

		public void Normalize()
		{
			float len = Length();
			this.x /= len;
			this.y /= len;
		}

		public float Distance(float x, float y)
		{
			float dx = this.x - x;
			float dy = this.y - y;
			return (float)System.Math.Sqrt(dx*dx + dy*dy);
		}

		public float Distance(Vector2 vec)
		{
			return Distance(vec.x, vec.y);
		}

		public float Cross(Vector2 vec)
		{
			return this.x * vec.x + this.y * vec.y;
		}

		

	}
}