using System.Collections;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private int moveSpeed;
    [SerializeField] private int damage;
    private Transform dir;
    private Rigidbody rb;

    [Header("Auto Death Parameters")]
    [SerializeField] private float lifeTime;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(AutoDeath());
    }

    private void Update() {
        Movement();
    }

    private void OnTriggerEnter(Collider collision) {
        if(collision.gameObject.layer == 7) {
            GameObject ufo = collision.gameObject;
            I_Damageable life = ufo.GetComponent<I_Damageable>();
            if (life != null) {
                life.TakeDamage(damage);
                Destroy(this.gameObject);
            } else {
                Debug.LogWarning("There is no Damageale on this object");
            }
        }
    }

    private void SetRotation() {
        if (dir != null) {
            transform.rotation = dir.rotation;
        } else {
            Debug.LogWarning("There is no direction for this bullet");
        }
    }

    private void Movement() {
        if (rb != null) {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

    private IEnumerator AutoDeath() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(this.gameObject);
    }
}
