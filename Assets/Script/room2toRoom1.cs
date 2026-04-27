using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room2toRoom1 : MonoBehaviour
{
    [SerializeField] private cinemachineManager cinemachineManager;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            cinemachineManager.moveFromRoom2ToRoom1();
        }
    }
}
