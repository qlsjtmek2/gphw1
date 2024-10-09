using UnityEngine;

namespace Movement.Data
{
    [CreateAssetMenu(fileName = "Movement Data", menuName = "Scriptable Object/Movement Data", order = int.MaxValue)]
    public class MovementData : ScriptableObject
    {
        [Tooltip("캐릭터의 이동 속도 (m/s)")]
        public float MoveSpeed = 4.0f;

        [Tooltip("가속 및 감속")]
        public float SpeedChangeRate = 10.0f;

        [Tooltip("캐릭터가 사용하는 중력 값. 엔진의 기본값은 -9.81f입니다.")]
        public float GravityAcceleration = -15.0f;

        [Header("Player Jump")]
		[Space(10)]
        [Tooltip("다시 점프할 수 있기까지 필요한 시간. 0f로 설정하면 즉시 다시 점프할 수 있습니다.")]
		public float JumpTimeout = 0.1f;
        
        [Tooltip("낙하 상태로 전환되기까지 필요한 시간. 계단을 내려갈 때 유용합니다.")]
		public float FallTimeout = 0.15f;
    }
}