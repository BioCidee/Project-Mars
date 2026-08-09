using UnityEngine;
using Toolbox;

public class ExplosionSystem : MonoBehaviour
{
    [Header("---- Explosion Parameters ----")]
    [SerializeField] private float explosionRadius;
    [SerializeField] private int explosionDamage;

    [Header("---- Build Layer ----")]
    [SerializeField] private LayerMask buildLayer;

    private void OnCollisionEnter(Collision collision) {
        Explosion();
    }

    private void Explosion() {
        RaycastHit[] hit;

        hit = Physics.SphereCastAll(transform.position, explosionRadius, Vector3.forward);

        foreach (RaycastHit objectHit in hit) {
            I_Damageable objectToDamage;

            if (objectHit.collider.gameObject.TryGetComponent<I_Damageable>(out objectToDamage)) {
                if(Toolbox.LayerCheck.CheckIfLayer(buildLayer.value, objectHit.collider.gameObject)){
                    objectToDamage.TakeDamage(explosionDamage);
                    Debug.Log(objectToDamage);
                }
            }
        }

        Destroy(this.gameObject);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}
