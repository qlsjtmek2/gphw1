using UnityEngine;
using UnityEngine.InputSystem;
using Movement.Provider;

namespace Movement.Adapter
{
    [RequireComponent(typeof(SprintProvider))]
    public class SprintOnButton : MonoBehaviour
    {
        private SprintProvider _sprintProvider;

        private void Start()
        {
            _sprintProvider = GetComponent<SprintProvider>();
        }

        public void OnSprint(InputValue value)
        {
            if (value.isPressed)
            {
                _sprintProvider.IsTrySprint = true;
                _sprintProvider.Sprint();
            }
            else
            {
                _sprintProvider.IsTrySprint = false;
                _sprintProvider.Stop();
            }
        }
    }
}