using UnityEngine;
using Random = UnityEngine.Random;

public class GroundSpawner : MonoBehaviour
{
    Vector3 last_ground = Vector3.zero;
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Spawner();
        }
    }
    public void Spawner()
    {
        //Rasgele bir şekilde Vector3 dir'i sol veye sağa eşitliyor
        Vector3 dir;
        if(Random.Range(0,2) == 0)
        {
            dir = Vector3.left;//vector3(-1,0,0)
        }
        else
        {
            dir = Vector3.forward;//vector3(0,0,1)
        }
        //Son Yaratılan objenin pozisyonuna dir'i ekleyerek yeniden yaratıyor
        var objectinpool = ObjectPool.Instance.GetPooledObject(0);
        objectinpool.transform.SetParent(transform);
        objectinpool.transform.position = last_ground + dir;
        last_ground = objectinpool.transform.position;
    }
}
