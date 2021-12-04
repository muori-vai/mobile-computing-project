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

    public bool isFinished;
    public GameObject pauseMenu;

    public int finishScore;
    public bool isCasual;

    void Start()
    {
        Time.timeScale = 1;
        isFinished = false;
        player1score = 0;
        player2score = 0;
    }

    void Update()
    {
        if(isCasual)
        {
            if(player1score >= finishScore || player2score >= finishScore || isFinished)
            {
                this.Finish();
            }
        }
    }

    public void Finish()
    {
        Time.timeScale = 0f;

        bool winner1 = true;
        if(player1score > player2score)
        {
            player1text2.GetComponent<TMPro.TextMeshProUGUI>().text = "You Win!";
            player2text2.GetComponent<TMPro.TextMeshProUGUI>().text = "You Lose!";
        }
        else if(player1score < player2score)
        {
            winner1 = false;
            player2text2.GetComponent<TMPro.TextMeshProUGUI>().text = "You Win!";
            player1text2.GetComponent<TMPro.TextMeshProUGUI>().text = "You Lose!";
        }
        else
        {
            player1text2.GetComponent<TMPro.TextMeshProUGUI>().text = "Draw!";
            player2text2.GetComponent<TMPro.TextMeshProUGUI>().text = "Draw!";
        }

        pauseMenu.GetComponent<PauseMenu>().SetRestart(winner1);
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
