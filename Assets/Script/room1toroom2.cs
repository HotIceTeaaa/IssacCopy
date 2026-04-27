using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room1toroom2 : MonoBehaviour
{
    [SerializeField] private cinemachineManager cinemachineManager;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            cinemachineManager.moveFromRoom1ToRoom2();
        }
    }
}
