using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potions : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Issac issacScript;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        
        if (collision.gameObject.tag == "Player") {
            Issac issac = player.GetComponent<Issac>();
            issac.increaseHP(2f);
        }

        Destroy(gameObject);
    }
}
