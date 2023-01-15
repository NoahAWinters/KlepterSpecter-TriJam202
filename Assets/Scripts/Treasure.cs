using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    bool _isHeld;

    void OnTriggerStay2D(Collider2D other)
    {
        if (_isHeld)
            return;
        if (other.GetComponent<Ghost>() == null)
            return;
        Ghost ghost = other.GetComponent<Ghost>();
        ghost.treasure = this;

        transform.parent = ghost.heldObjectTransform;
        this.transform.localPosition = Vector2.zero;
        _isHeld = true;
    }

    public void GetRid()
    {
        this.transform.parent = null;
        Destroy(this.transform.gameObject);
    }

}
