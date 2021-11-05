using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
    public float y;
    public int spawnTime;

    void Start()
    {
        StartCoroutine(WaitStart());
    }

    private void Launch()
    {
        rb.velocity = new Vector2(0, speed * y);
    }

    private IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(spawnTime);
        
        this.transform.position = startPosition;
        Launch();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
