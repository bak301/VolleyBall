using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] private Text annoucement;
    [SerializeField] private Image winnerAvatar;
    // Start is called before the first frame update
    void Start()
    {
        annoucement.text = "Winner is " + GameManager.winner;
        winnerAvatar.sprite = GameManager.winnerAvatar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
