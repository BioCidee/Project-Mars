using UnityEngine;
using Toolbox;

public class TargetingSystem : MonoBehaviour
{
    // Targeting system
    [Header("---- Target Parameters ----")]
    [SerializeField] private LayerMask ennemyLayer;
    [SerializeField] private GameObject target;

    [Header("---- Turret Part ----")]
    [SerializeField] private Transform Cannon;

    [Header("---- Turret Guidance ----")]
    [SerializeField] private float offset;

    [Header("---- Turret Parameters ----")]
    [SerializeField] private int speedRotation;
    [SerializeField] private float angleTolerated;

    private bool isTargetingReady;

    private void Update()
    {
        if (target != null) {
            Rotation();
        } else {
            isTargetingReady = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Toolbox.LayerCheck.CheckIfLayer(ennemyLayer, other.gameObject)) { // LayerMask 7 = Ennemy
            //Debug.Log("Object Enter : " + other.gameObject.name);
            target = other.gameObject;
        }
    }

    private void Rotation() 
    {
        Vector3 direction = (target.transform.position - Cannon.position).normalized;
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(direction.x + offset, direction.y, direction.z + offset));

        Cannon.rotation = Quaternion.RotateTowards(Cannon.rotation,newRotation, speedRotation * Time.deltaTime);

        float angleDif = Quaternion.Angle(Cannon.rotation, newRotation);

        if (angleDif < angleTolerated) {
            isTargetingReady = true; // Is Ready to fire
        }
        else
        {
            isTargetingReady = false; // Is not ready to fire
        }
    }

    public bool ReturnIfTargetingReady()
    {
        return isTargetingReady;
    }
}
