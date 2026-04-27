using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour {
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float pelletSpeed;
    [SerializeField] private float pelletDmg;

    void Start() {
        pelletSpeed = 5;
        pelletDmg = 1;
    }

    void Update() {
        travelInAir();
    }

    private void travelInAir() {
        rigidBody.velocity = transform.up * pelletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Issac issac = other.GetComponent<Issac>();
            issac.takeDamage(pelletDmg);

            //destroy self
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "walls") {
            Destroy(gameObject);
        }
    }
}
