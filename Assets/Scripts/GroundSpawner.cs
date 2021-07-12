using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject last_ground;

    private void Awake()
    {
        //Başlamadan önce haritayı oluşturuyor
        for (int i = 0; i < 20; i++)
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
            dir = Vector3.left;
        }
        else
        {
            dir = Vector3.forward;
        }
        //Son Yaratılan objenin pozisyonuna dir'i ekleyerek yeniden yaratıyor
        last_ground = Instantiate(last_ground, last_ground.transform.position + dir , last_ground.transform.rotation);

    }
}
