using UnityEngine;
using UnityEngine.Events;

namespace Movement.Provider
{
    [RequireComponent(typeof(IMovementProvider))]
    public class SprintProvider : MonoBehaviour
    {
		[Range(1f, 5f)]
		[SerializeField]
		[Tooltip("캐릭터의 스프린트 속도 증가율")]
		private float SprintSpeed = 1.5f;

        [Header("Events")]
        public UnityEvent OnSprintStart;
        public UnityEvent OnSprintStop;

        public bool IsSprint { get; private set; }
        public bool IsTrySprint { get; set; }

        // Reference
        private IMovementProvider _movementProvider;

		public void Sprint()
		{
            if (IsSprint) return;
			if (_movementProvider.MoveDirection.y <= 0f) return;
            
            IsSprint = true;

            _movementProvider.MoveSpeed = _movementProvider.MoveSpeed * SprintSpeed;

            OnSprintStart.Invoke();
		}

		public void Stop()
		{
            if (!IsSprint) return;

			IsSprint = false;

            _movementProvider.MoveSpeed = _movementProvider.MoveSpeed / SprintSpeed;

			OnSprintStop.Invoke();
		}

        private void Start()
        {
            _movementProvider = GetComponent<IMovementProvider>();
        }

        private void Update()
        {
            CheckCondition();
        }

		private void CheckCondition()
		{
			if (_movementProvider.MoveDirection.y <= 0f && IsSprint)
			{
				Stop();
			}

			if (IsTrySprint && !IsSprint)
			{
				Sprint();
			}
		}
    }
}
