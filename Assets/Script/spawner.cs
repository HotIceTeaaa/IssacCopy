using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject blobs;
    [SerializeField] private float spawnRate;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float hp;

    void Start()
    {
        hp = 15f;
        spawnRate = 2.5f;
        spawnTimer = 0f;
        spawnRadius = 3f;
    }


    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0f) {
            spawnTimer = spawnRate;

            //spawn blobs
            Instantiate(blobs, getSpawnLocation(), Quaternion.Euler(0,0,0));
            room roomScript = gameManager.instance.getCurrentRoom().GetComponent<room>();
            roomScript.incrementBlobCount();
        }

    }

    public void takeDamage(float dmg) {
        hp -= dmg;

        if (hp <= 0f) {
            Destroy(gameObject);
            room roomScript = gameManager.instance.getCurrentRoom().GetComponent<room>();
            roomScript.decrementSpawnerCount();
        }
    }


    private Vector3 getSpawnLocation() {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        return transform.position + direction * spawnRadius;
    }
}
