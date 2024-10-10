using UnityEngine.InputSystem;
using Movement.Provider;
using UnityEngine;

namespace Movement.Adapter
{
    [RequireComponent(typeof(FireProvider))]
    public class FireOnButton : MonoBehaviour
    {
        private FireProvider _fireProvider;

        private void Start()
        {
            _fireProvider = GetComponent<FireProvider>();
        }

        public void OnFire(InputValue value)
        {
            _fireProvider.Fire();
        }
    }
}