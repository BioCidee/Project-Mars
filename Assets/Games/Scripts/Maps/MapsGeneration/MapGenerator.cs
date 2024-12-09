using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //[SerializeField] private int height;
    [SerializeField] private int customSeed = 0;
    [SerializeField] private int length;
    [SerializeField] private int width;
    [SerializeField] private int depth;
    [SerializeField] private int offset;
    [SerializeField] private Transform pointZero;
    [SerializeField] private GameObject groundParent;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject groundMining;
    [SerializeField] private int minableBlockCount;
    [SerializeField] private int maxMinableBlockCount = 10;
    [SerializeField] private int minableBlockChance = 5;
    [SerializeField] private float scale = 0.1f;
    [SerializeField] private int maxHeight;

    private List<GameObject> groundList = new List<GameObject>();

    private void Start() {
        MapGeneration();
    }

    private void MapGeneration() {
        minableBlockCount = 0;
        float mapSeed = (customSeed > 0) ? customSeed : Random.Range(0f, 5000f);

        if (groundList.Count > 0) {
            ClearCurrentGroundList();
        }

        for (int l = 0; l < length; l++) {
            for (int w = 0; w < width; w++) {
                GameObject myGround = GenerateBase(w, l);

                GenerateHeight(w, l, mapSeed, myGround);
            }
        } 
    }

    private void ClearCurrentGroundList() {
        foreach (GameObject go in groundList) {
            Destroy(go);
        }

        minableBlockCount = 0;
        groundList.Clear();
    }

    private GameObject GenerateBase(int w, int l) {
        GameObject newGround = Instantiate(ground);
        newGround.transform.parent = groundParent.transform;
        newGround.transform.position = new Vector3((1 * w) + offset, 0, (1 * l) + offset);
        groundList.Add(newGround);

        return newGround;
    }

    private void GenerateHeight(int w, int l, float _mapSeed, GameObject currentGround) {
        float noiseValue = Mathf.PerlinNoise((l * scale) + _mapSeed, (w * scale) + _mapSeed);
        int height = Mathf.FloorToInt(noiseValue * maxHeight);
        height--;

        for (int h = 0; h < height; h++) {

            GameObject go = ground;
            if (h + 1 >= height && minableBlockCount < maxMinableBlockCount) {
                if (minableBlockCount != 0) {
                    int chance = Random.Range(0, 1);

                    if (chance >= (minableBlockChance / 100)) {
                        go = groundMining;
                        minableBlockCount++;
                    } else {
                        go = ground;
                    }
                } else {
                    go = groundMining;
                    minableBlockCount++;
                }
            }

            GameObject newGroundHeight = Instantiate(go);
            newGroundHeight.transform.parent = currentGround.transform;
            newGroundHeight.transform.position = new Vector3((1 * w) + offset, ((1 * h) + 1) + offset, (1 * l) + offset);
            groundList.Add(newGroundHeight);
        }
    }
}
