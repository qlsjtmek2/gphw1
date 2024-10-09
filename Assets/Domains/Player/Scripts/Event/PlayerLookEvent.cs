namespace Movement.Events
{
    [System.Serializable]
    public class PlayerLookEvent
    {
        public float RotationVelocity;
        public float VerticalAngle;

        public PlayerLookEvent(float rotationVelocity, float verticalAngle)
        {
            RotationVelocity = rotationVelocity;
            VerticalAngle = verticalAngle;
        }
    }
}