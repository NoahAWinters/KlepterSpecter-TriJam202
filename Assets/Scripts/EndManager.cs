using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI win;
    [SerializeField] TextMeshProUGUI play;
    [SerializeField] TextMeshProUGUI heck;
    [SerializeField] TextMeshProUGUI spec;

    [SerializeField] float _timerTime = 60;
    float _currentTime;

    // Start is called before the first frame update
    void Start()
    {
        win.text = Score.win ? "You win!" : "You Lose...";
        play.text = Score.playerScore.ToString();
        heck.text = Score.heckScores.ToString();
        spec.text = Score.specScores.ToString();
        _currentTime = _timerTime;
    }

    void Update()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

}
