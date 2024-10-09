using UnityEngine;
using UnityEngine.InputSystem;
using Movement.Provider;

namespace Movement.Adapter
{
    [RequireComponent(typeof(ILookProvider))]
    public class LookWithMouse : MonoBehaviour
    {
        [SerializeField]
        private ILookProvider _lookProvider;

        private void Start()
        {
            _lookProvider = GetComponent<ILookProvider>();
        }

        public void OnLook(InputValue value)
        {
            _lookProvider.LookDirection = value.Get<Vector2>();
        }
    }
}