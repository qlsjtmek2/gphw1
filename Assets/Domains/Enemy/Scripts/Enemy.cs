using System.Diagnostics;
using Movement.Provider;
using UnityEngine;

namespace Domain.Enemy
{
    public interface IEnemyState
    {
        void Collision(Enemy enemy, Collider other);
        void Update(Enemy enemy);
    }

    public class EnableState : IEnemyState
    {
        private float _disableTimer = 0f;

        public void Collision(Enemy enemy, Collider other)
        {
            enemy.Stop();

            if (other.tag == "Bullet")
            {
                enemy.gameObject.SetActive(false);
            }
        }

        public void Update(Enemy enemy)
        {
            enemy.Move();

            _disableTimer += Time.deltaTime;
            if (_disableTimer >= enemy.LifeTime)
            {
                enemy.gameObject.SetActive(false);
            }
        }
    }

    public class DisableState : IEnemyState
    {
        public void Collision(Enemy enemy, Collider other)
        {
            // Do nothing
        }
        
        public void Update(Enemy enemy)
        {
            // Do nothing
        }
    }

    [RequireComponent(typeof(IMovementProvider))]
    public class Enemy : MonoBehaviour
    {
        public float LifeTime = 60f;
        public Vector3 Direction;
        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        private IEnemyState _state;
        private IMovementProvider _movementProvider;

        void Awake()
        {
            _movementProvider = GetComponent<IMovementProvider>();
            gameObject.SetActive(false);
        }

        void OnEnable()
        {
            _state = new EnableState();
        }

        void OnDisable()
        {
            _state = new DisableState();
            EnemyManager.Instance.ReturnToPool(this);
        }

        void Update()
        {
            _state.Update(this);
        }

        void OnTriggerEnter(Collider other)
        {
            _state.Collision(this, other);
        }

        public void Move()
        {
            _movementProvider.MoveDirection = new Vector2(Direction.x, Direction.z);
        }

        public void Stop()
        {
            _movementProvider.MoveDirection = Vector2.zero;
        }
    }
}
