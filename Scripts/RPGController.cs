using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class RPGController : MonoBehaviour
{
    public float speed;
    private Vector2 movement;
    public Tilemap map;
    public Transform targetPosition;
    public LayerMask UnwalkableLayer;
    public LayerMask MoveableLayer;
    private string lastDir = "Down";
    public Animator animator;

    void Start() {
        targetPosition.position = transform.position;
    }
    
    void Update() {
        DoAnimations();

        if (Vector3.Distance(transform.position, targetPosition.position) < .01f &&
            !Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f, UnwalkableLayer)) {
                Collider2D other = Physics2D.OverlapCircle(targetPosition.position + new Vector3(movement.x, movement.y, 0f), .1f, MoveableLayer);
                if (other) {
                    if (!Physics2D.OverlapCircle(targetPosition.position + new Vector3(2*movement.x, 2*movement.y, 0f), .1f, UnwalkableLayer) &&
                        !Physics2D.OverlapCircle(targetPosition.position + new Vector3(2*movement.x, 2*movement.y, 0f), .1f, MoveableLayer)) {
                            targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                            if (Vector3.Distance(other.gameObject.transform.position, other.gameObject.GetComponent<BoxMovement>().boxTargetPos) < .0001f) {
                                other.gameObject.GetComponent<BoxMovement>().boxTargetPos = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                            }
                    }
                } else {
                    targetPosition.position = new Vector3(targetPosition.position.x + movement.x, targetPosition.position.y + movement.y, 0f);
                }
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
    }

    void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
    }

    void DoAnimations() {
        string animName = "";

        if (movement == Vector2.zero) { // if not moving
            animName = "Idle" + lastDir;
        } else {
            if (movement.x < 0.1f) { // moving left
                lastDir = "Left";
                animName = "WalkLeft";
            } else if (movement.x > 0.1f) { // moving right
                lastDir = "Right";
                animName = "WalkRight";
            }
        }
        animator.Play(animName);
    }
}
