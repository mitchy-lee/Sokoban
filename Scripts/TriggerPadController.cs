using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPadController : MonoBehaviour
{
    public LayerMask triggerPad;
    public bool isOnTriggerPad = false;

    void Update() {
        if (Physics2D.OverlapCircle(transform.position, .1f, triggerPad)) {
            //Debug.Log("is on trigger pad");
            isOnTriggerPad = true;
        } else {
            isOnTriggerPad = false;
        }
    }
}