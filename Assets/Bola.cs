using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//By Javier Garcia Palacio
public class Bola : MonoBehaviour
{
    private Rigidbody2D ballRb;
    public float speed = 30;
    public AudioClip choque;

    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
        Launch();

        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;

        choque = (AudioClip)Resources.Load("Audio/choque");
    }

    float reboteY(Vector2 bolaPos, Vector2 raquetaPos, float alturaRaqueta)
    {
        return (bolaPos.y - raquetaPos.y) / alturaRaqueta;
    }

    private void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = Vector2.right * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Raqueta 1")
        {
            float y = reboteY(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            AudioSource.PlayClipAtPoint(choque, transform.position);
        }

        if (col.gameObject.name == "Raqueta 2")
        {
            float y = reboteY(transform.position, col.transform.position, col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            AudioSource.PlayClipAtPoint(choque, transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Gol1"))
        {
            GameManager.Instance.jugador2Puntua();
            GameManager.Instance.Restart();
            Launch();
        }
        else
        {
            GameManager.Instance.jugador1Puntua();
            GameManager.Instance.Restart();
            Launch();
        }
    }

    void Update()
    {
        
    }
}