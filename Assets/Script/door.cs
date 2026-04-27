using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cameraFrom;
    [SerializeField] private CinemachineVirtualCamera cameraTo;
    [SerializeField] private GameObject roomFrom;
    [SerializeField] private GameObject roomTo;
    [SerializeField] private Vector3 landingPos;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            roomTo.SetActive(true);
            cameraFrom.Priority = 0;
            cameraTo.Priority = 1;
            roomFrom.SetActive(false);

            playerMovement playerMovementScript = gameManager.instance.getPlayer().GetComponent<playerMovement>();
            playerMovementScript.setPosition(landingPos);

            gameManager.instance.setCurrentRoom(roomTo);
        }
    }
}
