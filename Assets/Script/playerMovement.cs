using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    public Vector2 movementVector = new Vector2(0, 0);
    public int direction;

    void Start()
    {
        direction = 3;
        speed = 4f;
    }

    void Update()
    {

        handleMovement();
    }

    private void handleMovement() {
        //0 == w, 1 == a, 2 == s, 3 == d
        if (Input.GetKey(KeyCode.D)) {
            movementVector.x = 1;
            animator.SetFloat("horizontal", 1);
            animator.SetFloat("vertical", 0);
            direction = 3;
        } else if (Input.GetKey(KeyCode.A)) {
            movementVector.x = -1;
            animator.SetFloat("horizontal", -1);
            animator.SetFloat("vertical", 0);
            direction = 1;
        } else {
            movementVector.x = 0;
        }

        if (Input.GetKey(KeyCode.W)) {
            movementVector.y = 1;
            animator.SetFloat("vertical", 1);
            animator.SetFloat("horizontal", 0);
            direction = 0;
        } else if (Input.GetKey(KeyCode.S)) {
            movementVector.y = -1;
            animator.SetFloat("vertical", -1);
            animator.SetFloat("horizontal", 0);
            direction = 2;
        } else {
            movementVector.y = 0;
        }

        rigidBody.velocity = movementVector.normalized * speed;
    }
}
