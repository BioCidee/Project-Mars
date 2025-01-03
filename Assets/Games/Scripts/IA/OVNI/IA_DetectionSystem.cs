using System.Collections.Generic;
using UnityEngine;

public class IA_DetectionSystem : MonoBehaviour
{
    // System
    private Collider m_Collider;

    //Detection
    [Header("Detection Parameters")]
    [SerializeField] private LayerMask buildLayer;
    private List<GameObject> listObjectsDetected = new List<GameObject>();
    private List<GameObject> listThreat = new List<GameObject>();

    private void Start() {
        m_Collider = GetComponent<Collider>();
    }

    private void Update() {
        if (listObjectsDetected.Count != 0) {
            SelectionThreat();
        }
    }

    private void OnTriggerEnter(Collider other) {
        listObjectsDetected.Add(other.gameObject);
    }

    private void SelectionThreat() {
        for(int i = listObjectsDetected.Count - 1; i >= 0; i--) {
            if (listObjectsDetected[i].gameObject.layer == 8) {
                Debug.Log("Start Thread Adding");
                AddThreat(listObjectsDetected[i]);
            } else {
                listObjectsDetected.RemoveAt(i);
                Debug.Log("Detection Removed");
            }
        }
    }

    private void AddThreat(GameObject _potentialThreat) {
        if (listThreat.Contains(_potentialThreat)) {
            Debug.Log("Threat already in list");
            return;
        } else {
            listThreat.Add(_potentialThreat);
            Debug.Log("Add threat");
        }
    }

    public List<GameObject> ReturnListThreat() {
        return listThreat;
    }
}
