using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallMove : MonoBehaviour
{
    Vector3 _dir;
    public float speed;
    public float addSpeed;
    public GroundSpawner grSpawner;
    public static bool isFall;
    private float _timer;
    void Start()
    {
        _dir = Vector3.zero;
        isFall = false;
        _timer = 0;
    }
    void Update()
    {
        // Oyuncu düşerse isFall true
        if(transform.position.y <= 0.5f)
        {
            isFall = true;
            _timer += Time.deltaTime;
            if(_timer > 3)
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
            if (_dir.x == 0)
            {
                _dir = Vector3.left;
            }
            //Sola gidiyor ise sağa
            else
            {
                _dir = Vector3.forward;
            }
            //Oyuncu her yön değiştirdiğinde hızını artırıyor
            speed += addSpeed;
        }
        //Haraket işlemi
        Vector3 move = _dir * (Time.deltaTime * speed);
        transform.position += move;
    }

    public void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Score.score++;
            //Her küp'ten ayrılınca küp düşüyor yeni küp ekleniyor sonuna ve düşen küp yokoluyor
            grSpawner.Spawner();
            StartCoroutine(Timer(collision.gameObject));
        }
    }

    IEnumerator Timer(GameObject poolobject)
    {
        yield return new WaitForSeconds(3f/speed);
        ObjectPool.Instance.SetPooledObject(poolobject.transform.parent.gameObject,0);
    }
}
