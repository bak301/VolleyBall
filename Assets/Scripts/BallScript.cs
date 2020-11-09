using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D netPole;
    [SerializeField] private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "sand-floor" && GameManager.matchState == GameManager.GameState.RUNNING)
        {
            if (netPole.transform.position.x < ball.transform.position.x)
            {
                GameManager.Player1Score++;
                GameManager.matchWinner = "Player 1";
            } else if (netPole.transform.position.x > ball.transform.position.x)
            {
                GameManager.Player2Score++;
                GameManager.matchWinner = "Player 2";
            }
            GameManager.matchState = GameManager.GameState.END;
        }
    }

    IEnumerator CalculateBallVelocityAfterCollision()
    {
        yield return null;
    }
}
