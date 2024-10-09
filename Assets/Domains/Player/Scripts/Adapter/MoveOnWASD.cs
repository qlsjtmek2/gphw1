using UnityEngine;
using UnityEngine.InputSystem;
using Movement.Provider;

namespace Movement.Adapter
{
    [RequireComponent(typeof(IMovementProvider))]
    public class MoveOnWASD : MonoBehaviour
    {
        private MovementProvider _movementProvider;

        private void Start()
        {
            _movementProvider = GetComponent<MovementProvider>();
        }

        public void OnMove(InputValue value)
        {
            _movementProvider.MoveDirection = value.Get<Vector2>();
        }
    }
}