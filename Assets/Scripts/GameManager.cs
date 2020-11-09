using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        START,
        RUNNING,
        END
    }

    [SerializeField] private Text scoreboard;
    [SerializeField] internal Text annoucement;
    [SerializeField] private int MaxScore = 10;
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private Rigidbody2D player1;
    [SerializeField] private Rigidbody2D player2;
    [SerializeField] private Image player1avatar;
    [SerializeField] private Image player2avatar;
    [SerializeField] private Vector3 initBallPlayer1;
    [SerializeField] private Vector3 initBallPlayer2;
    public static int Player1Score = 0;
    public static int Player2Score = 0;
    public static GameState gameState = GameState.END;
    public static GameState matchState = GameState.END;
    public static string matchWinner;
    public static string winner;
    public static Sprite winnerAvatar;

    // Start is called before the first frame update
    void Start()
    {
        player1avatar.sprite = player1.gameObject.GetComponent<Image>().sprite;
        player2avatar.sprite = player2.gameObject.GetComponent<Image>().sprite;

        gameState = GameState.RUNNING;
        matchState = GameState.RUNNING;
        annoucement.text = "";
        matchWinner = "";
        scoreboard.text = "0 - 0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreboard.text = $"{Player1Score} - {Player2Score}";

        if (gameState == GameState.RUNNING)
        {
            if (matchState == GameState.END)
            {
                //annoucement.text = "Match winner is " + matchWinner;
                StartCoroutine(WaitNewMatch());
            }
        }

        if (Player1Score == MaxScore || Player2Score == MaxScore )
        {
            EndGame();
        }

    }

    private void EndGame()
    {
        gameState = GameState.END;
        winner = Player1Score > Player2Score ? player1.gameObject.name : player2.gameObject.name;
        winnerAvatar = Player1Score > Player2Score 
                        ? player1.gameObject.GetComponent<Image>().sprite 
                        : player2.gameObject.GetComponent<Image>().sprite;
        Time.timeScale = 0;
        StartCoroutine(SceneTransition());
    }

    IEnumerator SceneTransition()
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadSceneAsync("EndGame");
        Time.timeScale = 1;
    }

    private void StartNewMatch(string matchWinner)
    {
        annoucement.text = "";
        ball.velocity = Vector2.zero;
        ball.transform.position = matchWinner.Equals("Player 1") ? initBallPlayer2 : initBallPlayer1;
        matchState = GameState.RUNNING;
    }

    IEnumerator WaitNewMatch()
    {
        annoucement.text = "Match winner is " + matchWinner;
        yield return new WaitForSeconds(2);
        StartNewMatch(matchWinner);
    }
}
