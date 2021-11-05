using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ball") //se il gol collide con la palla, allora:
        {
            if(!isPlayer1Goal)
            {
                /* Troviamo un game object chiamato "Game" e prendiamo lo script, poi chiamiamo la funziona Player1Scored */
                GameObject.Find("Game").GetComponent<Game>().Player1Scored();
            }
            else
            {
                GameObject.Find("Game").GetComponent<Game>().Player2Scored();
            }
        }
    }
}
