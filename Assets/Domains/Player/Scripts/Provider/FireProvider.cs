using UnityEngine;
using Domain.Bullet;

namespace Movement.Provider
{
    public class FireProvider : MonoBehaviour
    {
        public Transform BulletSpawnPoint;

        public void Fire()
        {
            Bullet bullet = BulletManager.Instance.GetFromPool();

            if (bullet == null) return;
            
            bullet.Position = BulletSpawnPoint.position;
            bullet.Direction = Camera.main.transform.forward;
        }
    }
}
