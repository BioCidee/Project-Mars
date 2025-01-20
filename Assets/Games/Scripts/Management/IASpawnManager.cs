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
        EventManager.Instance.SubscribreToEvent("OnEnnemyCantSpawn", StopSpawn);
    }

    private void Update() {
        SpawnSystem();
    }

    private void SpawnSystem() {
        if (isSpawnActive) {
            SpawnTimer();
        }
    }

    private void SpawnTimer() {
        if(spawnTimer >= spawnRate) {
            spawnTimer = 0;

            SpawnEnnemy(GetRandomEnnemy(), GetRandomSpawnPosition());
        } else {
            spawnTimer += Time.deltaTime;
        }
    }

    private void SpawnEnnemy(GameObject _ennemy, Transform _spawnPosition) {
        GameObject newEnnemy = Instantiate(_ennemy);
        newEnnemy.transform.position = _spawnPosition.position;
    }

    private GameObject GetRandomEnnemy() {
        if (ennemyList.Count <= 0)
            Debug.LogError("There is no ennemy in the ennemy list");

        int random = Random.Range(0, ennemyList.Count);

        return ennemyList[random];
    }

    private Transform GetRandomSpawnPosition() {
        if (spawnPointList.Count <= 0)
            Debug.LogError("There is no spawn point for the Ennemy , in spawnPointList");

        int random = Random.Range(0, spawnPointList.Count);

        return spawnPointList[random];
    }

    private void StartSpawn() {
        isSpawnActive = true;
        Debug.Log("isSpawnActive on true");
    }

    private void StopSpawn() {
        isSpawnActive = false;
        Debug.Log("isSpawnActive on false");
    }
}
