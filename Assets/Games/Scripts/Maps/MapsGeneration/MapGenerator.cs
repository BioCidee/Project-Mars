using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private int depth;
    [SerializeField] private int offset;
    [SerializeField] private Transform pointZero;
    [SerializeField] private GameObject groundParent;
    [SerializeField] private GameObject ground;

    private List<GameObject> groundList = new List<GameObject>();

    private void Start() {
        Generation();
    }

    private void Generation() {
        for (int h = 0; h < height; h++) {
            for (int w = 0; w < width; w++) {
                GameObject newGround = Instantiate(ground);
                newGround.transform.parent = groundParent.transform;
                newGround.transform.position = new Vector3((1 * w) + offset, 0, (1 * h) + offset);

                groundList.Add(newGround);
            }
        }

        
    }
}
