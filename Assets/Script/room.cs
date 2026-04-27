using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    [SerializeField] private int blobCount;
    [SerializeField] private int spawnerCount;
    [SerializeField] private int doorCount;
    [SerializeField] private GameObject[] doorArr;


    private void Update() {
        if(blobCount + spawnerCount == 0) {
            for (int i = 0; i < doorCount; i++) {
                doorArr[i].SetActive(true);
            }
        }
    }

    public void incrementBlobCount() {
        blobCount++;
    }

    public void decrementBlobCount() {
        blobCount--;
    }

    public void decrementSpawnerCount() {
        spawnerCount--;
    }
}
