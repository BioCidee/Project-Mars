using System.Collections.Generic;
using UnityEngine;

public class IA_DetectionSystem : MonoBehaviour
{
    // System
    [SerializeField] private IA_Movement _mov;
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
        if (listObjectsDetected.Count > 0) {
            SelectionThreat();
        } else {

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
                _mov.SetThreatList(ReturnListThreat());
            } else {
                listObjectsDetected.RemoveAt(i);
                Debug.Log("Detection Removed");
            }
        }
    }

    private void AddThreat(GameObject _potentialThreat) {
        if (listThreat.Contains(_potentialThreat)) {
            return;
        } else {
            listThreat.Add(_potentialThreat);
        }
    }

    public List<GameObject> ReturnListThreat() {
        return listThreat;
    }
}