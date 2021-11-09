using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForce : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    public Joystick joystick;

    void Update()
    {
        rb.AddForce(2f * new Vector2(joystick.Horizontal * speed, joystick.Vertical * speed));
    }
}
