using UnityEngine;
using UnityEngine.AI;

public class IA_OVNI : MonoBehaviour
{
    // System
    private GameManager gameManager;
    private int xMap;
    private int zMap;

    // Transform
    private Transform shipPosition;

    // Attack
    private Transform target;
    private bool isAnyTarget = false;

    // Movement
    private Transform dir;
    private bool isAnyDir = false;

    private void Start() {
        gameManager = GameManager.Instance;

        if (gameManager == null)
            Debug.LogError("No Game Manager detected in IA_OVNI");
    }

    private void Update() {
        if(!isAnyTarget && !isAnyDir) GetShipDirection();
        if (!isAnyTarget && isAnyDir) Moving();
        if(isAnyTarget) Attack();
    }

    private void Moving() {

    }

    private void GetShipDirection() {
        if (!shipPosition) Debug.LogWarning("There is not Ship in this game");

        dir = shipPosition;
    }

    private void Attack() {

    }

    private void Death() {

    }
}
