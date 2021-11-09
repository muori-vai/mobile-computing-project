using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public float attraction;
    public float bounce;

    void Update()
    {
        float distance = Vector3.Distance(this.transform.position, new Vector3(0, 0, 0));
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0, 0, 0), attraction * Time.deltaTime * distance);
    }

    private void OnCollisionEnter2D(Collision2D other)
    { 
        Vector2 normal = other.GetContact(0).normal;
        this.GetComponent<Rigidbody2D>().AddForce(-normal * bounce);
    }
}
