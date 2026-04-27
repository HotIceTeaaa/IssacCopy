using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Issac : MonoBehaviour
{
    [SerializeField] private playerMovement movementScript;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject bomb;
    [SerializeField] private float hp;
    [SerializeField] private float maxHP;
    [SerializeField] private RectTransform rt;
    [SerializeField] private GameObject dmgPopup;
    private float widthHPBar;

    void Start()
    {
        widthHPBar = rt.sizeDelta.x;
        hp = 300f;
        maxHP = 305f;
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
            Destroy(bombInstance, 2);
        }
    }

    public void increaseHP(float amount) {
        Debug.Log("increase");
        hp += amount;
        hp = Mathf.Min(hp, maxHP);
    }

    public void takeDamage(float dmg) {
        hp -= dmg;

        updateHealthBar();
        summonDmgPopup();

        if (hp <= 0) {
            Destroy(gameObject);
        }
    }

    public void updateHealthBar() {
        float newWidth = widthHPBar * hp / maxHP;
        Vector2 temp = new Vector2(newWidth, rt.sizeDelta.y);
        rt.sizeDelta = temp;
    }

    public void summonDmgPopup() {
        float angle = 5;
        angle *= Random.Range(-9, 9);
        GameObject text = Instantiate(dmgPopup, transform.position, Quaternion.Euler(0, 0, angle));
        Destroy(text, 1);
    }
}
