using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public Vector3 boxTargetPos;
    public int speed;
    private bool inPlace = false;
    public LayerMask scorePadLayer;

    void Start() {
        boxTargetPos = transform.position;
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, boxTargetPos, speed * Time.deltaTime);

        if (Physics2D.OverlapCircle(transform.position, .1f, scorePadLayer)) {
            inPlace = true;
            //Debug.Log("inPlace: "+inPlace);
        } else {
            inPlace = false;
        }
    }
}
