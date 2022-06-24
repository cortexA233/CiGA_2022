using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ObjectsPool
{
    private int maxCount = 1024;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public GameObject prefab;
    private Transform poolTransformParent;
    
    public ObjectsPool(GameObject targetPrefab)
    {
        prefab = targetPrefab;
    }

    public ObjectsPool() {
        poolTransformParent = GameObject.Find("pool_transform_parent").transform;
    }

    public virtual GameObject Get(Vector3 position)
    {
        GameObject result;
        if (pool.Count <= 0)
        {
            result = GameObject.Instantiate(prefab, poolTransformParent);
        }
        else
        {
            result = pool.Dequeue();
            result.SetActive(true);
        }
        result.transform.position = position;
        return result;
    }

    public virtual void Recycle(GameObject obj)
    {
        if (pool.Contains(obj))
        {
            return;
        }

        if (pool.Count > maxCount)
        {
            GameObject.Destroy(obj);
        }
        else
        {
            pool.Enqueue(obj);
            obj.SetActive(false);
        }
    }

    public void ClearPool()
    {
        pool.Clear();
    }
}


public class PlayerBulletPool : ObjectsPool
{
    private static PlayerBulletPool _instance;
    public static PlayerBulletPool instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new PlayerBulletPool();
            }
            return _instance;
        }
    }

    public PlayerBulletPool()
    {
        //base.prefab = Resources.Load<GameObject>("prefabs/player_bullet");
        prefab = Resources.Load<GameObject>("prefabs/player_bullet");
    }

    public override GameObject Get(Vector3 position)
    {
        GameObject result = base.Get(position);
        return result;
    }
}


public class EnemyBulletPool : ObjectsPool
{
    private static EnemyBulletPool _instance;
    public static EnemyBulletPool instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EnemyBulletPool();
            }
            return _instance;
        }
    }

    public EnemyBulletPool()
    {
        prefab = Resources.Load<GameObject>("prefabs/enemy/enemy_bullet");
    }

    public override GameObject Get(Vector3 position)
    {
        GameObject result = base.Get(position);
        return result;
    }
}