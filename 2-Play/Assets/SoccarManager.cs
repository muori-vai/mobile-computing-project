using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccarManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    public GameObject gate1a;
    public GameObject gate1b;
    public GameObject gate2a;
    public GameObject gate2b;

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
        player1text2.GetComponent<TMPro.TextMeshProUGUI>().text = "GOAL!";
        StartCoroutine(this.slowGoal());
    }

    public void Player2Scored()
    {
        player2score++;
        player2text.GetComponent<TMPro.TextMeshProUGUI>().text = player2score.ToString();
        player2text2.GetComponent<TMPro.TextMeshProUGUI>().text = "GOAL!";
        StartCoroutine(this.slowGoal());
    }

    private IEnumerator slowGoal()
    {
        Time.timeScale = 0.4f;
        yield return new WaitForSeconds(1.5f);
        this.Reset();
    }

    private void Reset()
    {
        Time.timeScale = 1.0f;
        player1text2.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        player2text2.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        player1.GetComponent<MoveCar>().Restart();
        player2.GetComponent<MoveCar>().Restart();
        ball.GetComponent<BallGoal>().Restart();
        gate1a.GetComponent<CloseGoal>().Restart();
        gate1b.GetComponent<CloseGoal>().Restart();
        gate2a.GetComponent<CloseGoal>().Restart();
        gate2b.GetComponent<CloseGoal>().Restart();
    }
}
