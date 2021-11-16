using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Joystick joystick;

    void Update()
    {
        rb.velocity = new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed);
    }

    /* usato su Pong
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PowerBigger")
        {
            Vector3 temp = this.transform.localScale;
            temp.x += 2.0f;
            this.transform.localScale = temp;
        }
        if(other.tag == "PowerFaster")
        {
            this.speed += 5.0f;
        }
    } */

    public float GetSpeed()
    {
        return this.speed;
    }

    public void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
}
