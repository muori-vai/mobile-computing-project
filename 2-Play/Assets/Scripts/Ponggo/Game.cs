using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public GameObject player1goal;
    public GameObject player2goal;

    public GameObject player1text;
    public GameObject player2text;

    public GameObject player1text2;
    public GameObject player2text2;
    
    private int player1score;
    private int player2score;

    void Start()
    {
        player1score = 0;
        player2score = 0;
    }

    void Update()
    {
        if(Time.timeScale == 0)
        {
            if(player1score > player2score)
            {
                player1text2.GetComponent<TMPro.TextMeshProUGUI>().text = "You Win!";
                player2text2.GetComponent<TMPro.TextMeshProUGUI>().text = "You Lose!";
            }
            else if(player1score < player2score)
            {
                player2text2.GetComponent<TMPro.TextMeshProUGUI>().text = "You Win!";
                player1text2.GetComponent<TMPro.TextMeshProUGUI>().text = "You Lose!";
            }
            else
            {
                player1text2.GetComponent<TMPro.TextMeshProUGUI>().text = "Draw!";
                player2text2.GetComponent<TMPro.TextMeshProUGUI>().text = "Draw!";
            }
            
        }
    }

    public void Player1Scored()
    {
        player1score++;
        player1text.GetComponent<TMPro.TextMeshProUGUI>().text = player1score.ToString();
    }

    public void Player2Scored()
    {
        player2score++;
        player2text.GetComponent<TMPro.TextMeshProUGUI>().text = player2score.ToString();
    }
}
