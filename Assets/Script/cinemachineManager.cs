using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinemachineManager : MonoBehaviour
{
    [SerializeField] private playerMovement movementScript;
    [SerializeField] private CinemachineVirtualCamera room1Camera;
    [SerializeField] private CinemachineVirtualCamera room2Camera;
    [SerializeField] private GameObject room1Node;
    [SerializeField] private GameObject room2Node;

    public void moveFromRoom1ToRoom2() {
        room1Camera.Priority = 0;
        room2Camera.Priority = 1;

        room1Node.SetActive(false);
        room2Node.SetActive(true);

        movementScript.setPosition(12, 0);
    }

    public void moveFromRoom2ToRoom1() {
        room1Camera.Priority = 1;
        room2Camera.Priority = 0;

        room1Node.SetActive(true);
        room2Node.SetActive(false);

        movementScript.setPosition(5.5f, 0);
    }
}
