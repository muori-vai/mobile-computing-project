using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSprace : MonoBehaviour
{
    public Vector3 initialPos;
    public bool isPlayer1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            Reset();
        }
        if(isPlayer1)
        {
            if(other.CompareTag("Player1"))
            {
                GameObject.Find("GameManager").GetComponent<Game>().Player1Scored();
                Reset();
            }
            if(other.CompareTag("Player2"))
            {
                Reset();
            }
        }
        if(!isPlayer1)
        {
            if(other.CompareTag("Player2"))
            {
                GameObject.Find("GameManager").GetComponent<Game>().Player2Scored();
                Reset();
            }
            if(other.CompareTag("Player1"))
            {
                Reset();
            }
        }
    }

    private void Reset()
    {
        this.transform.position = initialPos;
    }
}
