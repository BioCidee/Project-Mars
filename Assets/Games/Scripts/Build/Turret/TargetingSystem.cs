using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    // Targeting system
    [SerializeField] private int detectionRadius;
    [SerializeField] private LayerMask ennemyLayer;
    private Vector3 startCanonTarget;
    private Vector3 canonTransform;
    private Vector3 ennemyPosition;
    private bool isAnyTarget;

    // Rotation Parameters
    private Transform currentRotation;

    private void Start()
    {
        canonTransform = startCanonTarget;
    }

    private void FixedUpdate()
    {
        EnnemyDetection();
    }

    private void EnnemyDetection()
    {
        RaycastHit hit;
        isAnyTarget = Physics.SphereCast(canonTransform, detectionRadius, Vector3.forward, out hit);

        if (isAnyTarget){
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Object DETECTED");

            if (hitObject != null && hitObject.layer == ennemyLayer) {
                Debug.Log("OVNI DETECTED");
            }
        }
        else
        {
            return;
        }
    }

    private void UpdateHorizontalRotation()
    {
        
    }

    private void UpdateVerticalRotation()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(canonTransform, detectionRadius);
    }
}
