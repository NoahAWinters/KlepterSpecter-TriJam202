using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class GhostAI : Ghost
{
    public Transform walkTarget;
    Transform Player;
    public Transform OtherGhost;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (holdingObject)
        {
            walkTarget.position = GameManager.GetInstance().Goal.position;
        }
        else if (Player.GetComponent<Ghost>().holdingObject)
        {
            walkTarget.position = Player.position;
        }
        else if (OtherGhost.GetComponent<Ghost>().holdingObject)
        {
            walkTarget.position = OtherGhost.position;
        }
    }

}
