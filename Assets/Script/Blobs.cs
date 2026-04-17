using TMPro;
using UnityEngine;

public class Blobs : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float hp;
    [SerializeField] private float shootTimer;
    [SerializeField] private GameObject pellets;
    void Start()
    {
        shootTimer = 5f;
        hp = 3f;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        handleShoot();
    }

    private void handleShoot() {
        shootTimer -= Time.deltaTime; 
        if(shootTimer < 0) {
            shootTimer = 5f;

            GameObject bombInstance = null;
            Vector3 direction = player.transform.position - transform.position;
            direction = Quaternion.Euler(0, 0, 90) * direction;
            bombInstance = Instantiate(pellets, transform.position, Quaternion.LookRotation(direction));
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
