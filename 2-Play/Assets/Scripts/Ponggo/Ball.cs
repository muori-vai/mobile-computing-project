using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public float bounce;
    private float y;
    private int byTwo; //ogni due punti, la pallina cambia direzione
    public int spawnTime;

    void Start()
    {
        StartCoroutine(WaitStart());
    }

    public void Reset()
    {
        byTwo++;
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }

    private void Launch()
    {
        if(byTwo%2 == 0) //se la somma dei punteggi è pari, dobbiamo cambiare direzione
        {
            y = y*(-1.0f);
        }

        /* Per l'angolo con cui la palla parte, 
        se minore di 0.5 allora ha un "angolo" compreso tra -1 e -0.5, 
        se maggiore "angolo" compreso tra 0.5 e 1 
        (0.5 invece di 0 per non avere una partenza perfettamente verticale) */
        float x = Random.value < 0.5 ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

        rb.velocity = new Vector2(speed * x, speed * y);
    }

    /* Ogni volta che la pallina collide, aumenta la sua velocità (applicando ad essa una forza perpendicolare alla superficie di collisione) */
    private void OnCollisionEnter2D(Collision2D other)
    { 
        Vector2 normal = other.GetContact(0).normal;
        rb.AddForce(normal * bounce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Goal")
        {
            Reset();
        }
    }

    private IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(spawnTime);
        /* Lancio una "moneta": viene calcolato un numero casuale, 
        se è minore di 0.5 allora la palla viene lanciata sotto, 
        se maggiore di 0.5 la palla viene lanciata sopra */
        y = Random.value < 0.5 ? -1.0f : 1.0f;

        byTwo = -1; //facciamo partire byTwo a -1 perché viene subito chiamato Reset che byTwo di 1ed è come se cominciassimo quindi con 0
        Reset();
    }
}
