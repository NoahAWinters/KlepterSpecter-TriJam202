using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public string name;
    public int score;
    public Transform heldObjectTransform;
    public Treasure treasure;

    public void IncreaseScore()
    {
        treasure.GetRid();
        treasure = null;
        score += 10;
    }

}
