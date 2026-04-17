using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Issac : MonoBehaviour
{
    [SerializeField] private playerMovement movementScript;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bomb;
    [SerializeField] private float hp;
    void Start()
    {
        hp = 3f;
    }

    void Update()
    {
        handleShoot();
    }
    private void handleShoot() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            GameObject bombInstance = null;
            //0 == w, 1 == a, 2 == s, 3 == d
            if (movementScript.direction == 0) {
                bombInstance = Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, 0));
            } else if (movementScript.direction == 1) {
                bombInstance = Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, 90));
            } else if (movementScript.direction == 2) {
                bombInstance = Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, 180));
            } else if (movementScript.direction == 3) {
                bombInstance = Instantiate(bomb, transform.position, Quaternion.Euler(0, 0, 270));
            }
            animator.SetTrigger("shootTrigger");
            Destroy(bombInstance, 5);
        }
    }

    public void increaseHP(float amount) {
        Debug.Log("increase");
        hp += amount;
        hp = Mathf.Min(hp, 5);
    }

    public void takeDamage(float dmg) {
        hp -= dmg;

        if (hp <= 0) {
            Destroy(gameObject);
        }
    }
}
