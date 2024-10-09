using UnityEngine;

namespace Movement.Provider
{
	public interface IMovementProvider
	{
		Vector2 MoveDirection { get; set; }
		float MoveSpeed { get; set; }
		bool IsGrounded { get; }

		public void Jump(float jumpHeight);
	}
}