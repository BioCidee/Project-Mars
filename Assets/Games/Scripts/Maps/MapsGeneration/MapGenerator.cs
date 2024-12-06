using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private int depth;
    [SerializeField] private int offset;
    [SerializeField] private Transform pointZero;
    [SerializeField] private GameObject ground;

    private List<GameObject> groundList = new List<GameObject>();

    private void Start() {
        Generation();
    }

    private void Generation() {
        /*for (int h = 0; h < height; h++) {
            for (int w = 0; w < width; w++) {
                GameObject newGround = Instantiate(ground);
                newGround.transform.position = new Vector3(width * groundList.Count + offset, 0, 0);
                // Instantiate Cube
                // Place cube to the transform, add width and height 
            }
        }*/

        for (int w = 0; w < width; w++) {
            Debug.Log(ground);
            GameObject newGround = Instantiate(ground);
            Debug.Log(newGround);

            groundList.Add(newGround);
        }
    }
}
