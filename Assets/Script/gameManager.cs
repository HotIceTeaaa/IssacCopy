using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject currentRoom;

    public GameObject Player => player;
    public GameObject getPlayer() {  return player; }

    public GameObject Room => currentRoom;
    public GameObject getCurrentRoom() { return currentRoom; }
    public void setCurrentRoom(GameObject room) { currentRoom = room; }

    void Start()
    {
        instance = this;
    }
}
