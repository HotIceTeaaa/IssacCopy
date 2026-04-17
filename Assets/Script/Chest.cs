using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject potion;
    [SerializeField] private float hp;
    void Start()
    {
        hp = 3;
    }

    void Update()
    {
        
    }
    public void takeDamage(float dmg) {
        hp -= dmg;

        if (hp <= 0) {
            animator.SetTrigger("destroyedTrigger");
            GetComponent<BoxCollider2D>().enabled = false;
            Instantiate(potion, transform);
        }
    }
}
