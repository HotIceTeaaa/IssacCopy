using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float bombSpeed;
    [SerializeField] private float bombDmg;

    void Start()
    {
        bombSpeed = 20;
        bombDmg = 1;
    }

    void Update()
    {
        travelInAir();
    }

    private void travelInAir() {
        rigidBody.velocity = transform.up * bombSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Blob") {
            Blobs blob = other.GetComponent<Blobs>();
            blob.takeDamage(bombDmg);

            //destroy self
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "chest") {
            Chest chest = other.GetComponent<Chest>();
            chest.takeDamage(bombDmg);

            //destroy self
            Destroy(gameObject);
        }
    }
}
