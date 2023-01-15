using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] Transform[] _spawnPoints;
    [SerializeField] GameObject _treasurePrefab;

    public void SpawnTreasure()
    {
        int index = Random.Range(0, _spawnPoints.Length);

        GameObject newTreasure = Instantiate(_treasurePrefab, _spawnPoints[index].position, Quaternion.identity);
        newTreasure.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
    }

    void Start()
    {
        SpawnTreasure();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

}
