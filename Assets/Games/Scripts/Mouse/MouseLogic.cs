using UnityEngine;

public class MouseLogic : MonoBehaviour
{
    private Vector2 mousePosition;

    private void Update() {
        GetBlocAim();
    }

    private void GetBlocAim() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) {
            GameObject objectHit = hit.transform.gameObject;
        }
    }

    private void GetMousePosition() {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        mousePosition = new Vector2(x, y);
    }
}
