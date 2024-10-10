using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Domain.Enemy;

public class EnemyManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    public static EnemyManager Instance { get; private set; }
    public Enemy Prefab;
    public int PoolSize = 20;

    [Header("Spawn Settings")]
    public Transform Target;
    public Transform CenterSpawnPoint;
    public float SpawnRadius = 10f;
    public float SpawnInterval = 5f;

    private Queue<Enemy> _pool;
    private float _timer = 0f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        _pool = new Queue<Enemy>();
        
        for (int i = 0; i < PoolSize; i++) {
            Instantiate(Prefab.gameObject);
        }
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        _timer += Time.deltaTime;

        if (_timer > SpawnInterval)
        {
            Enemy enemy = GetFromPool();

            if (enemy == null) return;

            Vector3 randomPosition = Random.insideUnitSphere * SpawnRadius;
            randomPosition.y = 0.2f;

            enemy.Position = CenterSpawnPoint.position + randomPosition;
            enemy.Direction = Vector3.forward;
            enemy.transform.LookAt(Target);

            _timer = 0f;
        }
    }

    public Enemy GetFromPool() {
        if (_pool.Count > 0) {
            Enemy obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        return null;
    }

    public void ReturnToPool(Enemy obj) {
        _pool.Enqueue(obj);
    }
}