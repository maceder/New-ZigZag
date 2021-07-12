using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    Vector3 dir;
    public float speed;
    public float addSpeed;
    public GroundSpawner grSpawner;
    public static bool isFall;

    private float timer;
    void Start()
    {
        dir = Vector3.zero;
        isFall = false;
        timer = 0;
    }

    void Update()
    {
        // Oyuncu düşerse isFall true
        if(transform.position.y <= 0.5f)
        {
            isFall = true;
            timer += Time.deltaTime;
            if(timer > 3)
            {
                //Düştükten sonra 3 saniye geçip oyunu tekrar başlatıcak
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        // Oyuncu düşerse sağa sola dönemesin
        if(isFall == true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            //Sağa gidiyor ise sola 
            if (dir.x == 0)
            {
                dir = Vector3.left;
            }
            //Sola gidiyor ise sağa
            else
            {
                dir = Vector3.forward;
            }
            //Oyuncu her yön değiştirdiğinde hızını artırıyor
            speed += addSpeed * Time.deltaTime;
        }
        //Haraket işlemi
        Vector3 move = dir * Time.deltaTime * speed;
        transform.position += move;
    }

    public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Score.score++;
            //Her küp'ten ayrılınca küp düşüyor yeni küp ekleniyor sonuna ve düşen küp yokoluyor
            grSpawner.Spawner();
            collision.gameObject.AddComponent<Rigidbody>();
            Destroy(collision.gameObject, 3f);
        }
    }
}
