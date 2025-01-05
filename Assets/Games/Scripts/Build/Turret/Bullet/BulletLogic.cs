using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private int moveSpeed;
    private Transform dir;
    private Rigidbody rb;

    public BulletLogic(Transform _dir) {
        dir = _dir;
    }

    private void Start() {
        rb = GetComponent<Rigidbody>();

        SetRotation();
    }

    private void Update() {
        Movement();
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
            rb.linearVelocity = transform.forward * moveSpeed;
        }
    }
}
