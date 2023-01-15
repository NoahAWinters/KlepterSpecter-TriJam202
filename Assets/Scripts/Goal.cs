using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Ghost>() == null)
            return;

        Ghost ghost = other.GetComponent<Ghost>();
        ghost.IncreaseScore();
        GameManager.GetInstance().SpawnTreasure();
    }
}
