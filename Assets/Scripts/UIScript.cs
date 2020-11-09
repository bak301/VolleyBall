using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button guideButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(() => SceneManager.LoadSceneAsync("Arena"));
        guideButton.onClick.AddListener(() => SceneManager.LoadSceneAsync("Guide"));
        optionsButton.onClick.AddListener(() => SceneManager.LoadSceneAsync("Options"));
        exitButton.onClick.AddListener(() =>
        {
            Debug.Log("Exit game !");
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
