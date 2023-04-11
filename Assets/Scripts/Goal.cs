using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ghost>() == null)
            return;

        Ghost ghost = other.GetComponent<Ghost>();
        Debug.Log("Getting here");

        if (ghost.treasure == null)
            return;
        ghost.IncreaseScore();
        GameManager.GetInstance().SpawnTreasure();
    }
}
