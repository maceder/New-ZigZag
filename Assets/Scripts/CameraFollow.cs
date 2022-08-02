using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 distance;

    void Start()
    {
        distance = transform.position - player.position;
    }

    void Update()
    {
        //Oyuncu düştüyse takibi bırak
        if(BallMove.isFall == false)
        {
            transform.position = player.position + distance;
        }
    }
}
