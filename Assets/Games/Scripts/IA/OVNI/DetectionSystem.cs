using System.Collections.Generic;
using UnityEngine;

public class DetectionSystem : MonoBehaviour
{
    // System
    private Collider m_Collider;

    //Detection
    private LayerMask buildLayer;
    private List<GameObject> listObjectsDetected;
    private List<GameObject> listThreat;

    private void Start() {
        m_Collider = GetComponent<Collider>();
    }

    private void Update() {
        if (listObjectsDetected != null) {
            SelectionThreat();
        }
    }

    private void OnTriggerEnter(Collider other) {
        listObjectsDetected.Add(other.gameObject);
    }

    private void SelectionThreat() {
        for(int i = listObjectsDetected.Count; i > 0; i--) {
            if (listObjectsDetected[i].gameObject.layer == buildLayer) {
                listThreat.Add(listObjectsDetected[i]);
            } else {
                listObjectsDetected.RemoveAt(i);
            }
        }
    }
}
