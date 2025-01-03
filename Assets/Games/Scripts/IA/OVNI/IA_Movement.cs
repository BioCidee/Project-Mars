using System.Collections.Generic;
using UnityEngine;

public class IA_Movement : MonoBehaviour
{
    // System
    [SerializeField] private IA_DetectionSystem _detectionSystem;

    // Targets
    private GameObject target;
    private List<GameObject> listTarget;

    // Movement Parameters
    private int moveSpeed;
    private int stopDistance;
    private float fixedHeight;

    private void Start() {
        fixedHeight = transform.position.y;
    }

    private void Update() {
        listTarget = _detectionSystem.ReturnListThreat();
    }

    private void GoToTarget() {
        float distance = Vector3.Distance(transform.position.x, fixedHeight, transform.position.z);
    }

    private void SetTarget() {
        if (listTarget.Count != 0) {
            target = listTarget[0];
        }
    }
}
