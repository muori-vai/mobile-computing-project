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

    public float GetSpeed()
    {
        return this.speed;
    }

    public void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
}
