using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public float attraction;
    public float bounce;
    private bool falling;
    private Vector3 temp = new Vector3(1, 1, 1);
    public Vector3 startingPosition;
    public GameObject component1;
    public GameObject component2;
    public bool isPlayer1;

    void Start()
    {
        falling = false;
    } 

    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, new Vector3(0, 0, 0));
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0, 0, 0), attraction * Time.deltaTime * distance);

        if(falling)
        {
            temp = this.transform.localScale;
            temp.x -= 0.005f;
            temp.y -= 0.005f;
            this.transform.localScale = temp;
        }

        if(temp.x < 0)
        {
            falling = false;
            Reset();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    { 
        Vector2 normal = other.GetContact(0).normal;
        this.GetComponent<Rigidbody2D>().AddForce(normal * bounce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Goal"))
        {
            falling = true;
            Vector3 pos = this.transform.position;
            pos.z = 2;
            this.transform.position = pos;
            component1.GetComponent<BoxCollider2D>().enabled = false;
            component2.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void Reset()
    {
        if(isPlayer1)
        {
            GameObject.Find("GameManager").GetComponent<Game>().Player2Scored();
        }
        else if(!isPlayer1)
        {
            GameObject.Find("GameManager").GetComponent<Game>().Player1Scored();
        }
        this.transform.localScale = new Vector3(1, 1, 1);
        temp = new Vector3(1, 1, 1);
        this.transform.position = startingPosition;
        component1.GetComponent<BoxCollider2D>().enabled = true;
        component2.GetComponent<BoxCollider2D>().enabled = true;
    }
}
