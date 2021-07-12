using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    Vector3 distance;

    void Start()
    {
        distance = transform.position - Player.position;
    }

    void Update()
    {
        //Oyuncu düştüyse takibi bırak
        if(BallMove.isFall == false)
        {
            transform.position = Player.position + distance;
        }
    }
}
