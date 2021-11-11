using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private Vector3 initialPosition;

    [SerializeField]
    private Joystick joystick;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Restart();
    }

    void Update () 
    {
        movement = new Vector2(joystick.Horizontal, joystick.Vertical);

        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.AddForce(direction * speed);
    }

    public void Restart()
    {
        this.transform.position = initialPosition;
        this.transform.localRotation = Quaternion.identity;
        rb.angularVelocity = 0;
        rb.velocity = Vector2.zero;
        
    }
}