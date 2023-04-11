using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] Transform _treasurePrefab;
    [SerializeField] Transform _AITarget1;
    [SerializeField] float _timerTime = 30;
    [SerializeField] TextMeshProUGUI _timer;
    public Transform Goal;
    float _currentTime;

    [SerializeField] Transform _AITarget2;

    public void SpawnTreasure()
    {
        int index = Random.Range(0, _spawnPoints.Length);
        int luck = Random.Range(0, 100);

        _treasurePrefab.transform.parent = this.transform;
        _treasurePrefab.position = _spawnPoints[index].position;
        _AITarget2.position = _treasurePrefab.position;
        _AITarget1.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        if (luck > 35)
        {
            _AITarget1.position = _treasurePrefab.position;
        }
        _treasurePrefab.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        _treasurePrefab.GetComponent<Treasure>()._isHeld = false;
    }

    void Awake()
    {
        if (instance != null)
        {
            //Debug.LogWarning("Found more than 1 Controller in scene");
        }
        instance = this;
    }

    void Update()
    {
        _currentTime = _currentTime -= Time.deltaTime;
        _timer.text = _currentTime.ToString();
        if (_currentTime <= 0)
        {
            SwitchScene();
        }

    }

    void Start()
    {
        SpawnTreasure();
        _currentTime = _timerTime;
        _timer.text = "" + _currentTime;
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    public Vector3 GetRandomPoint()
    {
        int movement = Random.Range(0, _spawnPoints.Length);
        return _spawnPoints[movement].position;
    }


    void SwitchScene()
    {
        Score.playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<Ghost>().score;//1
        Score.heckScores = GameObject.FindGameObjectWithTag("Heck").GetComponent<Ghost>().score;//2
        Score.specScores = GameObject.FindGameObjectWithTag("Spec").GetComponent<Ghost>().score;//3

        if (Score.heckScores >= Score.playerScore || Score.specScores >= Score.playerScore)
        {
            //You Lose
            Score.win = true;
        }
        else
        {
            //You Win
            Score.win = false;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }



}
