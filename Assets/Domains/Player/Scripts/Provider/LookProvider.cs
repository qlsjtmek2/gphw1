using System;
using Movement.Data;
using Movement.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Movement.Provider
{
    [Serializable]
    public class LookProvider : MonoBehaviour, ILookProvider
    {
        [Header("Cinemachine")]
        [Tooltip("카메라가 따라갈 Cinemachine Virtual Camera에 설정된 대상")]
        public GameObject CinemachineCameraTarget;

        [Header("Events")]
        public UnityEvent<PlayerLookEvent> OnLook;

        [Header("Settings")]
        [SerializeField]
        private LookingData _data;

        // fields
		private const float _threshold = 0.01f;
        private float _rotationVelocity;
		private Vector2 _lookDir;

		// cinemachine
		private float _cinemachineTargetPitch;

        public Vector2 LookDirection
		{
			get => _lookDir;
			set => _lookDir = value;
		}

		// Properties
        private void LateUpdate()
		{
			CameraRotation();
		}

		private void CameraRotation()
		{
            if (Cursor.lockState == CursorLockMode.None) return;

			// 입력이 있을 경우
			if (LookDirection.sqrMagnitude >= _threshold)
			{
				// // 마우스 입력은 Time.deltaTime으로 나누지 않음
				// float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;
				
				// _cinemachineTargetPitch += _lookDir.y * RotationSpeed * deltaTimeMultiplier;
				// _rotationVelocity = _lookDir.x * RotationSpeed * deltaTimeMultiplier;
				
				_rotationVelocity = LookDirection.x * _data.RotationSpeed;
				_cinemachineTargetPitch += LookDirection.y * _data.RotationSpeed;

				// 피치 회전을 제한
				_cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, _data.BottomClamp, _data.TopClamp);

				// Cinemachine 카메라 대상의 피치 업데이트
				CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

				// 플레이어를 좌우로 회전
				transform.Rotate(Vector3.up * _rotationVelocity);
                
                OnLook.Invoke(new PlayerLookEvent(_rotationVelocity, _cinemachineTargetPitch));
			}
		}

		private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
		{
			if (lfAngle < -360f) lfAngle += 360f;
			if (lfAngle > 360f) lfAngle -= 360f;
			return Mathf.Clamp(lfAngle, lfMin, lfMax);
		}
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if (_data.CursorLocked)
            {
                SetCursorState(_data.CursorLocked);
            }
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}