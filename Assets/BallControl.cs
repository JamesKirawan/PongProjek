using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //Objek Bola
    private Rigidbody2D rigidBody2D;
    // Gaya Awal
    public float xInitialForce;
    public float yInitialForce;

    // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;

    void ResetBall()
    {
        // Reset posisi menjadi (0,0)
        transform.position = Vector2.zero;
        // Reset Kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }
    void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);
        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);
        // Kecepatan Bola yang ditetapkan
        float speed = 100.0f;
        // Jika nilainya di bawah 1, bola bergerak ke kiri.
        // Jika tidak, bola bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            // normalized agar nilainya tetap 1 sehingga kecepatan tidak akan berubah meskipun arah berbeda
            rigidBody2D.AddForce(new Vector2(xInitialForce,yRandomInitialForce).normalized * speed);
        }
        else
        {
            // normalized agar nilainya tetap 1 sehingga kecepatan tidak akan berubah meskipun arah berbeda
            rigidBody2D.AddForce(new Vector2(-xInitialForce,yRandomInitialForce).normalized * speed);
        }
    }
    void RestartGame()
    {
        //Kembalikan bola ke posisi semula
        ResetBall();

        //Setelah 2 Detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }
    //Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    public Vector2 TrajectoryOrigin
    {
        get
        {
            return trajectoryOrigin;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
        //Mulai Game
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
