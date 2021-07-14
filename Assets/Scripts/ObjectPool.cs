using System;
using System.Collections.Generic;
using UnityEngine;
public class ObjectPool : Singleton<ObjectPool>
{
  [Serializable]
  public struct Pool
  {
    public Queue<GameObject> PooledObjects;
    public GameObject objectPrefab;
    public int poolSize;
  }
  [SerializeField] private Pool[] pools = null;
  private void Awake()
  {
    for (int j = 0; j < pools.Length; j++)
    {
      pools[j].PooledObjects = new Queue<GameObject>();
      for (int i = 0; i < pools[j].poolSize; i++)
      {
        GameObject obj = Instantiate(pools[j].objectPrefab);
        obj.SetActive(false);
        pools[j].PooledObjects.Enqueue(obj);
      }
    }
  }
  public GameObject GetPooledObject(int objectType)
  {
    if (objectType >= pools.Length) return null;
    GameObject obj = pools[objectType].PooledObjects.Dequeue();
    obj.SetActive(true);
    return obj;
  }
  public void SetPooledObject(GameObject poolobject, int objectType)
  {
    if (objectType >= pools.Length) return;
    pools[objectType].PooledObjects.Enqueue(poolobject);
    poolobject.SetActive(false);
  }
}
