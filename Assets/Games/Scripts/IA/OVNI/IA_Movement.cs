using System.Collections.Generic;
using UnityEngine;

public class IA_Movement : MonoBehaviour
{
    // System
    [Header("---- System Parameters ----")]
    [SerializeField] private IA_DetectionSystem _detectionSystem;
    [SerializeField] private Transform mainShipTransform;
    [SerializeField] private GameManager gameManager;

    // Targets
    [Header("---- Target ----")]
    [SerializeField] private GameObject target;
    [SerializeField] private List<GameObject> listTarget;

    // Movement Parameters
    [Header("Movement Parameters")]
    [SerializeField] private int stopDistance;
    [SerializeField] private int moveSpeed;
    [SerializeField] private float fixedHeight;
    [SerializeField] private bool isReadyToFire = false;

    private void Start() {
        gameManager = GameManager.Instance;

        if(gameManager.ReturnMainShipTransform()!= null){
            mainShipTransform = gameManager.ReturnMainShipTransform();
        }
        
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
        if (mainShipTransform != null) {
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
        } else {
            Debug.LogWarning("There is no main ship ! The UFO cant go anywhere");
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
