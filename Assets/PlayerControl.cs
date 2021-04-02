using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Tombol untuk menggerakan ke atas
    public KeyCode upButton = KeyCode.W;

    // Tombol untuk menggerakan ke bawah
    public KeyCode downButton = KeyCode.S;

    // Kecepatan Gerak
    public float speed = 10.0f;

    //Batas atas dan bawah game scene (Batas bawah menggunakan minus (-))
    public float yBoundary = 9.0f;

    //Rigidbody 2D raket ini
    private Rigidbody2D rigidBody2D;

    // Skor pemain
    private int score;

    /* Titik tumbukan terakhir dengan bola, untuk menampilkan variabel
    variabel fisika terkait tumbukan tersebut*/
    private ContactPoint2D lastContactPoint;

    public ContactPoint2D LastContactPoint
    {
        get
        {
            return lastContactPoint;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Dapatkan kecepatan raket sekarang.
        Vector2 velocity = rigidBody2D.velocity;

        // Jika pemain menekan tombol ke atas, beri kecepatan positif ke komponen y (keatas)
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0.0f;
        }
        // Masukkan kembali kecepatanny ke rigidBody2D
        rigidBody2D.velocity = velocity;

        Vector3 position = transform.position;
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }
        transform.position = position;
    }
    public void IncrementScore()
    {
        score++;
    }
    public void ResetScore()
    {
        score = 0;
    }
    //mendaptkan nilai score
    public int Score
    {
        get{ return score;}
    }
}
