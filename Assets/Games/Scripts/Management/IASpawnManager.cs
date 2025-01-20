using System.Collections.Generic;
using UnityEngine;

public class IASpawnManager : MonoBehaviour
{
    [Header("Ennemy Spawn Parameters")]
    [SerializeField] private bool isSpawnActive;
    [SerializeField] private int numberEnnemyToSpawn;
    [SerializeField] private int spawnRate;
    private float spawnTimer;
    [SerializeField] private List<GameObject> ennemyList;

    [Header("Spawn Parameters")]
    [SerializeField] private float altitude;
    [SerializeField] private List<Transform> spawnPointList;
    private int currentSpawn = 0;
    private bool isEnnemyCanSpawn = false;

    private void Start() {
        EventManager.Instance.SubscribreToEvent("OnEnnemyCanSpawn", StartSpawn);
        EventManager.Instance.SubscribreToEvent("OnEnnemyCantSpawn", StartSpawn);
    }

    private void Update() {
        
    }

    private void SpawnSystem() {
        if (isSpawnActive) {
            SpawnTimer();
        }
    }

    private void SpawnTimer() {
        if(spawnTimer >= spawnRate) {
            spawnTimer = 0;

            //SpawnEnnemy()
        } else {
            spawnTimer += Time.deltaTime;
        }
    }

    private void SpawnEnnemy(GameObject _ennemy, Transform _spawnPosition) {
        GameObject newEnnemy = Instantiate(_ennemy);
        newEnnemy.transform.position = _spawnPosition.position;
    }

    private GameObject GetRandomEnnemy() {
        return null;
    }

    private Transform GetRandomSpawnPosition() {
        return null;
    }

    private void StartSpawn() {
        isSpawnActive = true;
    }

    private void StopSpawn() {
        isSpawnActive = false;
    }
}
