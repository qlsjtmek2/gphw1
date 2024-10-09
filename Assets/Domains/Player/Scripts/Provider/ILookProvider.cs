using UnityEngine;

namespace Movement.Provider
{
    public interface ILookProvider
    {
        Vector2 LookDirection { get; set; }
    }
}