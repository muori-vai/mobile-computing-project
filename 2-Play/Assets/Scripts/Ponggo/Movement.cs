using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    public Joystick joystick;

    void Update()
    {
        rb.velocity = new Vector2(joystick.Horizontal * speed, 0f);
    }

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
    }
}
