using TMPro;
using UnityEngine;

public class Blobs : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private float hp;
    [SerializeField] private float shootTimer;
    [SerializeField] private GameObject pellets;
    void Start() {
        shootTimer = 2f;
        hp = 3f;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update() {
        handleShoot();
    }

    private void handleShoot() {
        shootTimer -= Time.deltaTime;
        if (shootTimer < 0) {
            shootTimer = 5f;

            GameObject bombInstance = null;
            Vector2 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
            bombInstance = Instantiate(pellets, transform.position, Quaternion.Euler(0, 0, angle));
            Destroy(bombInstance, 2);
        }
    }
    public void takeDamage(float dmg) {
        hp -= dmg;

        if (hp <= 0) {
            Destroy(gameObject);
        }
    }
}