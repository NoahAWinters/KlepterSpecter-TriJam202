using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public bool _isHeld;
    public Ghost _heldBy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ghost>() == null)
            return;
        Ghost ghost = other.GetComponent<Ghost>();

        Debug.Log("Got here");

        if (_isHeld)
        {
            if (ghost.transform.tag != _heldBy.transform.tag)
            {
                _heldBy.StartStandby();
                ghost.Steal(this);
            }
        }
        else
        {
            ghost.treasure = this;

            transform.parent = ghost.heldObjectTransform;
            this.transform.localPosition = Vector2.zero;
            _isHeld = true;
            ghost.holdingObject = true;
            _heldBy = ghost;
            ghost.canGrab = false;

            GhostAI ai = ghost.GetComponent<GhostAI>();
            if (ai != null)
            {
                ai.walkTarget.position = GameManager.GetInstance().Goal.position;
            }

        }
    }

    // public void GetRid()
    // {
    //     this.transform.parent = GameManager.GetInstance().transform;
    //     this.transform.localPosition = Vector2.zero;
    //     _isHeld = false;
    // }

}
