using UnityEngine;
using UnityEngine.AI;

public class IA_OVNI : MonoBehaviour
{
    // Transform
    private Transform shipPosition;

    // Attack
    private Transform target;
    private bool isAnyTarget = false;

    // Movement
    private Transform dir;
    private bool isAnyDir = false;

    private void Update() {
        if(!isAnyTarget && !isAnyDir) GetShipDirection();
        if (!isAnyTarget && isAnyDir) Moving();
        if(isAnyTarget) Attack();
    }

    private void Moving() {

    }

    private void GetShipDirection() {

    }

    private void Attack() {

    }

    private void Death() {

    }
}
