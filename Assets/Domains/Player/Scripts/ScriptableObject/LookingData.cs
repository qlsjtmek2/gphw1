using UnityEngine;

namespace Movement.Data
{
    [CreateAssetMenu(fileName = "Looking Data", menuName = "Scriptable Object/Looking Data", order = int.MaxValue)]
    public class LookingData : ScriptableObject
    {
        [Tooltip("카메라를 위로 얼마나 회전할 수 있는지 (도 단위)")]
        public float TopClamp = 90.0f;

        [Tooltip("카메라를 아래로 얼마나 회전할 수 있는지 (도 단위)")]
        public float BottomClamp = -90.0f;

        [Tooltip("캐릭터의 회전 속도")]
        public float RotationSpeed = 1.0f;


        [Header("Mouse Cursor Settings")]
        public bool CursorLocked = true;
    }
}