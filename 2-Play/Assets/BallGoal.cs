using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGoal : MonoBehaviour
{
    [SerializeField]
    private Vector3 initialPosition;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player2"))
        {
            GameObject.Find("GameManager").GetComponent<SoccarManager>().Player1Scored();
        }
        if(other.CompareTag("Player1"))
        {
            GameObject.Find("GameManager").GetComponent<SoccarManager>().Player2Scored();
        }
    }

    public void Restart()
    {
        this.transform.position = initialPosition;
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
