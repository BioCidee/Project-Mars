using UnityEngine;

public class MouseLogic : MonoBehaviour
{
    private Vector2 mousePosition;
    private GameObject lastGameObjectHit = null;
    private Color lastColor;
    private MeshRenderer lastMaterial;

    private bool isOnConstructionMode = false;
    private GameObject objectToBuild;

    private void Update() {
        GetBlocAim();


        if (lastGameObjectHit != null /* !!Rajouter le mode Construction plus tard!! */)
            if (Input.GetMouseButtonDown(0)) {
                if (lastGameObjectHit.GetComponent<GroundLogic>()) {
                    GroundLogic ground = lastGameObjectHit.GetComponent<GroundLogic>();
                    ground.SetObjectOnTop(objectToBuild);
                }
            }
    }

    private void GetBlocAim() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) {
            GameObject objectHit = hit.transform.gameObject;

            if (lastGameObjectHit != objectHit /* !!Rajouter le mode Construction plus tard!! */) {
                RemoveHighlight();
                HighLight(objectHit);
            }
        } else {
            RemoveHighlight();
        }
    }

    private void HighLight(GameObject blocHit) {
        Renderer renderer = blocHit.GetComponentInChildren<Renderer>();
        lastColor = renderer.material.color;
        renderer.material.color = Color.red;
        lastGameObjectHit = blocHit;
    }

    private void RemoveHighlight() {
        if (lastGameObjectHit != null) {
            Renderer renderer = lastGameObjectHit.GetComponentInChildren<Renderer>();
            renderer.material.color = lastColor;
            lastGameObjectHit = null;
        }
    }
}
