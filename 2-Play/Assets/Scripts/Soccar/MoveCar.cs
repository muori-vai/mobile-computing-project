using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float speed;
    [SerializeField] private float initialRotationSpeed;
    private float rotationSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector2 initialScale = new Vector2(1, 1);
    //[SerializeField] float kickForce;

    [SerializeField] private Joystick joystick;

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
        //rb.velocity = direction * speed;
    }

    public void Restart()
    {
        rb.mass = 1;
        rotationSpeed = initialRotationSpeed;
        this.transform.localScale = initialScale;
        this.transform.position = initialPosition;
        this.transform.localRotation = Quaternion.identity;
        rb.angularVelocity = 0;
        rb.velocity = Vector2.zero;
        this.transform.GetChild(0).gameObject.GetComponent<TrailRenderer>().Clear();
        this.transform.GetChild(1).gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PowerBigger"))
        {
            StartCoroutine(GetBigger());
        }
        if(other.CompareTag("PowerFaster"))
        {
            StartCoroutine(GetLighter());
        }
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
        //Vector2 normal = other.GetContact(0).normal;
        //rb.AddForce(-normal * kickForce/4);
        //other.otherRigidbody.AddForce(normal * kickForce); per qualche motivo, fa "rimbalzare" il personaggio
        //other.otherCollider.GetComponent<Rigidbody2D>().AddForce(normal * kickForce); fa la stessa cosa della riga sopra

    //}

    private IEnumerator GetBigger()
    {
        Vector2 scale = this.transform.localScale;
        while(scale.x < 2)
        {
            scale.x += 0.2f;
            scale.y += 0.2f;
            this.transform.localScale = scale;
            yield return new WaitForSeconds(0.1f);
        }
        rb.mass = 2;
        rotationSpeed -= 90f;
        yield return new WaitForSeconds(8); //power-up, durata default: 8 secondi
        StartCoroutine(GetSmaller());
    }

    private IEnumerator GetSmaller()
    {
        Vector2 scale = this.transform.localScale;
        while(scale.x > 1)
        {
            scale.x -= 0.2f;
            scale.y -= 0.2f;
            this.transform.localScale = scale;
            yield return new WaitForSeconds(0.1f);
        }
        rb.mass = 1;
        rotationSpeed = initialRotationSpeed;
        this.transform.localScale = initialScale;
    }

    private IEnumerator GetLighter()
    {
        rb.mass = 0.8f;
        this.transform.GetChild(1).gameObject.SetActive(true); //durata particle system da cambiare se cambi la durata del power-up
        yield return new WaitForSeconds(8); //power-up, durata default: 8 secondi
        rb.mass = 1;
    }
}