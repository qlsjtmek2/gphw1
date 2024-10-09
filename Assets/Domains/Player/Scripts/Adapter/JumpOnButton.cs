using UnityEngine;
using UnityEngine.InputSystem;
using Movement.Provider;

namespace Movement.Adapter
{
    [RequireComponent(typeof(MovementProvider))]
    public class JumpOnButton : MonoBehaviour
    {
        [Tooltip("점프 높이 (m)")]
        public float JumpHeight = 1.5f;

        private IMovementProvider _movementProvider;

        private void Start()
        {
            _movementProvider = GetComponent<IMovementProvider>();
        }

        public void OnJump(InputValue value)
        {
            _movementProvider.Jump(JumpHeight);
        }
    }
}