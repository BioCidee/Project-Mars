using UnityEngine;

public class TargetingSystem : MonoBehaviour
{
    // Targeting system
    [SerializeField] private LayerMask ennemyLayer;
    [SerializeField] private Transform Cannon;
    [SerializeField] private GameObject target;
    [SerializeField] private int speedRotation;
    [SerializeField] private float angleTolerated;
    private Vector3 targetPosition;
    private bool isAnyTarget;
    private bool isTargetingReady;
    private BoxCollider Collider;

    private void Start()
    {
        Collider = GetComponent<BoxCollider>();

        if(Collider == null)
        {
            Debug.Log("there is no collider !");
        }
        else
        {
            Debug.Log(Collider);
        }
    }

    private void Update()
    {
        if (target != null) {
            Rotation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Object Out : " + other.gameObject.name);
        target = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Enter : " + other.gameObject.name);
        target = other.gameObject; 
    }

    private void Rotation()
    {
        Vector3 direction = (target.transform.position - Cannon.position).normalized;
        Quaternion newRotation = Quaternion.LookRotation(direction);

        Cannon.rotation = Quaternion.RotateTowards(Cannon.rotation, newRotation, speedRotation * Time.deltaTime);

        float angleDif = Quaternion.Angle(Cannon.rotation, newRotation);

        if (angleDif < angleTolerated) {
            isTargetingReady = true;
        }
        else
        {
            isTargetingReady = false;
        }
    }

    public bool ReturnIfTargetingReady()
    {
        return isTargetingReady;
    }
}
