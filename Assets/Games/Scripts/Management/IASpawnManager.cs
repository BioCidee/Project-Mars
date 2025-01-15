using System.Collections.Generic;
using UnityEngine;

public class IASpawnManager : MonoBehaviour
{
    [Header("Ennemy Spawn Parameters")]
    [SerializeField] private bool isSpawnActive;
    [SerializeField] private int numberEnnemyToSpawn;
    [SerializeField] private int spawnRate;
    [SerializeField] private List<GameObject> ennemyList;

    [Header("Spawn Parameters")]
    [SerializeField] private float altitude;
    [SerializeField] private List<Transform> spawnPointList;

    private void Update() {
        
    }

    private void SpawnEnnemy() {
        if (isSpawnActive) {

        }
    }
}
