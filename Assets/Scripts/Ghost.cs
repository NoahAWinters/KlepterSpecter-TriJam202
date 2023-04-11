using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ghost : MonoBehaviour
{
    public string name;
    public int score = 0;
    public Transform heldObjectTransform;
    public Treasure treasure;
    public bool canGrab = true;

    public bool holdingObject;

    public TextMeshProUGUI scoreCard;

    public void IncreaseScore()
    {
        //treasure.transform.parent = GameManager.GetInstance().transform;
        score += 10;
        holdingObject = false;
        scoreCard.text = "" + score;
    }

    public void Steal(Treasure treasure)
    {
        treasure.transform.parent = heldObjectTransform;
        treasure.transform.localPosition = Vector2.zero;
        treasure._heldBy.holdingObject = false;
        treasure._heldBy.canGrab = true;
        if (treasure._heldBy.GetComponent<GhostAI>() != null)
            treasure._heldBy.GetComponent<GhostAI>().walkTarget.position = treasure.transform.position;

    }

    public void StartStandby()
    {
        StartCoroutine(Standby());
    }
    IEnumerator Standby()
    {
        canGrab = false;
        yield return new WaitForSeconds(2f);
        canGrab = true;
        holdingObject = false;
    }

}
