using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entityMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float speed;
    [SerializeField] private bool isGoingRight;
    void Start()
    {
        speed = 1.5f;
    }

    void Update()
    {
        if (speed > 0f) {
            if (isHitCollider(transform.right)) {
                goTheOtherWay();
            }
        } else if (speed < 0f){
            if (isHitCollider(-transform.right)) {
                goTheOtherWay();
            }
        }


        moveHorizontally();
    }

    public void moveHorizontally() {
        rigidBody.velocity = new Vector2(speed, 0);
    }

    public void goTheOtherWay() {
        speed *= -1;

        // Rotate the entity to face the direction of movement
        if (speed > 0f) {
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        } else if (speed < 0f) {
            transform.localEulerAngles = Vector3.zero;
        }
    }

    public bool isHitCollider(Vector2 direction) {
        float radius = 0.7f;

        Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, 3);
        return collider != null;
    }
}
