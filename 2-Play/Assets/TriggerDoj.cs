using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoj : MonoBehaviour
{
    public bool isPlayer1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball")
        {
            if(isPlayer1)
            {
                GameObject.Find("GameManager").GetComponent<Game>().Player2Scored();
            }
            else
            {
                GameObject.Find("GameManager").GetComponent<Game>().Player1Scored();
            }
        }
    }
}
