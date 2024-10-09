using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance { get; private set; }
    public Bullet Prefab;
    public int PoolSize = 20;
    
    private Queue<Bullet> _pool;

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
        _pool = new Queue<Bullet>();
        
        for (int i = 0; i < PoolSize; i++) {
            Bullet obj = Instantiate(Prefab.gameObject).GetComponent<Bullet>();
            // obj.SetActive(false); // 비활성화 상태로 유지
            _pool.Enqueue(obj);
        }
    }

    public bool BulletSpawn(Vector3 position, Vector3 direction, float velocity)
    {
        return true;
    }

    public Bullet GetFromPool() {
        if (_pool.Count > 0) {
            Bullet obj = _pool.Dequeue();
            // obj.SetActive(true); // 활성화하여 사용
            return obj;
        }
        return null;
    }

    public void ReturnToPool(Bullet obj) {
        _pool.Enqueue(obj);
    }
}
