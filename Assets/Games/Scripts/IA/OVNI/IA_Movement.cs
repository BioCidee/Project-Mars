using System.Collections.Generic;
using UnityEngine;

public class IA_Movement : MonoBehaviour
{
    // System
    [SerializeField] private IA_DetectionSystem _detectionSystem;
    private Transform mainShipTransform;
    private GameManager gameManager;

    // Targets
    private GameObject target;
    private List<GameObject> listTarget;

    // Movement Parameters
    [Header("Movement Parameters")]
    [SerializeField] private int stopDistance;
    [SerializeField] private int moveSpeed;
    [SerializeField] private float fixedHeight;
    private bool isReadyToFire = false;

    private void Start() {
        gameManager = GameManager.Instance;
        mainShipTransform = gameManager.ReturnMainShipTransform();

        listTarget = new List<GameObject>();
    }

    private void Update() {
        if(target == null) {
            isReadyToFire = false;
            SetTarget();
            GoToMainShip();
        } else {
            GoToTarget();
        }  
    }

    public void SetThreatList(List<GameObject> _ThreatList) {
        listTarget = _ThreatList;
    }

    public bool ReturnIfIsReadyToFire() {
        return isReadyToFire;
    }

    private void GoToMainShip() {
        Vector3 targetPosition = new Vector3(mainShipTransform.position.x, fixedHeight, mainShipTransform.position.z);

        float distance = Vector3.Distance(new Vector3(transform.position.x, fixedHeight, transform.position.z),
                                          new Vector3(targetPosition.x, fixedHeight, targetPosition.z));

        if (distance > stopDistance) {
            Vector3 dir = (targetPosition - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
            isReadyToFire = false;
        } else {
            isReadyToFire = true;
        }
    }

    private void GoToTarget() {
        Vector3 targetPosition = new Vector3(target.transform.position.x, fixedHeight, target.transform.position.z);

        float distance = Vector3.Distance(new Vector3(transform.position.x, fixedHeight, transform.position.z),
                                          new Vector3(targetPosition.x, fixedHeight, targetPosition.z));

        if (distance > stopDistance) {
            Vector3 dir = (targetPosition - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
            isReadyToFire = false;
        } else {
            isReadyToFire = true;
        }
    }

    private bool SetTarget() {
            if (listTarget.Count != 0) {
                target = listTarget[0];
                return true;
            } else {
                return false;
            }
    }   
}
