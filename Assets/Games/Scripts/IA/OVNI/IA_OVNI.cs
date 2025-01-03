using UnityEngine;
using UnityEngine.AI;

public class IA_OVNI : MonoBehaviour
{
    // System
    private GameManager gameManager;
    private Rigidbody rb;

    // Map Parameters
    private int widthMap;
    private int lenghtMap;

    // Transform
    private Transform shipPosition;

    // Attack
    private Transform target;
    private bool isAnyTarget = false;

    // Movement
    [SerializeField] private int moveSpeed;
    private Transform dir;
    private bool isAnyDir = false;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        gameManager = GameManager.Instance;

        if (gameManager == null)
            Debug.LogError("No Game Manager detected in IA_OVNI");

        gameManager.ReturnMapParameters(out widthMap,out lenghtMap);
    }

    
}
