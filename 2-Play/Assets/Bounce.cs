using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField]
    private float bounce;

    private void OnCollisionEnter2D(Collision2D other)
    { 
        Vector2 normal = other.GetContact(0).normal;
        this.GetComponent<Rigidbody2D>().AddForce(normal * bounce);
    }
}
