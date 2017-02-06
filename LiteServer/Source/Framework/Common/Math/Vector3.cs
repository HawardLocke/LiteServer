

namespace Lite
{
	public struct Vector3
	{
		public float x;
		public float y;
		public float z;

		public Vector3(float x, float y, float z)
		{
			this.x = x; this.y = y; this.z = z;
		}

		public void Set(float x, float y, float z)
		{
			this.x = x; this.y = y;
		}

		public static Vector3 zero { get { return new Vector3(0, 0, 0); } }

		public static Vector3 one { get { return new Vector3(1, 1, 1); } }

		public float sqrMagnitude { get { return Length(); } }

		public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
		{
			return new Vector3(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z);
		}

		public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
		{
			return new Vector3(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z);
		}

		public static Vector3 operator *(Vector3 vec, int n)
		{
			return new Vector3(vec.x * n, vec.y * n, vec.z * n);
		}

		public static Vector3 operator *(Vector3 vec, float n)
		{
			return new Vector3(vec.x * n, vec.y * n, vec.z * n);
		}

		public static Vector3 operator /(Vector3 vec, int n)
		{
			return new Vector3(vec.x / n, vec.y / n, vec.z / n);
		}

		public static Vector3 operator /(Vector3 vec, float n)
		{
			return new Vector3(vec.x / n, vec.y / n, vec.z / n);
		}

		public float Length()
		{
			return (float)System.Math.Sqrt(x*x + y*y + z*z);
		}

		public void Normalize()
		{
			float len = Length();
			this.x /= len;
			this.y /= len;
			this.z /= len;
		}

		public float Distance(Vector3 vec)
		{
			float dx = this.x - vec.x;
			float dy = this.y - vec.y;
			float dz = this.z - vec.z;
			return (float)System.Math.Sqrt(dx * dx + dy * dy + dz * dz);
		}

		public static float Distance(Vector3 vec1, Vector3 vec2)
		{
			return vec1.Distance(vec2);
		}

		public float Cross(Vector3 vec)
		{
			return this.x * vec.x + this.y * vec.y + this.z * vec.z;
		}

		

	}
}