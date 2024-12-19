using UnityEngine;

public class MouseLogic : MonoBehaviour
{
    private Vector2 mousePosition;
    private GameObject lastGameObjectHit = null;
    private GameObject currentGameObject = null;
    private Color lastColor;
    private MeshRenderer lastMaterial;

    private bool isOnConstructionMode = false;
    [SerializeField] private GameObject objectToBuild;

    private void Update() {
        GetBlocAim();


        if (lastGameObjectHit != null )
            if (Input.GetMouseButtonDown(0) && isOnConstructionMode) {
                if (objectToBuild == null) {
                    Debug.LogError("Construction mode activate, but no building to build");
                } else {
                    BuildObject();
                    isOnConstructionMode = false;
                }
            }
    }

    private void GetBlocAim() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) {
            GameObject objectHit = hit.transform.gameObject;
            currentGameObject = objectHit;

            if (currentGameObject != lastGameObjectHit && isOnConstructionMode /* !!Rajouter le mode Construction plus tard!! */) {
                RemoveHighlight();
                HighLight(currentGameObject);
            }
        } else {
            RemoveHighlight();
        }
    }

    private void BuildObject() {
        if (currentGameObject != null) {

            GroundLogic gL = currentGameObject.GetComponent<GroundLogic>();

            if (gL != null) {
                if (gL.IsGroundFree() == true) {
                    gL.SetObjectOnTop(objectToBuild);
                } else {
                    Debug.Log("There is already a object here");
                    isOnConstructionMode = true;
                }
            }
        }
    }

    private void HighLight(GameObject blocHit) {
        Renderer renderer = currentGameObject.GetComponentInChildren<Renderer>();
        lastColor = renderer.material.color;
        renderer.material.color = Color.red;
        lastGameObjectHit = currentGameObject;
    }

    private void RemoveHighlight() {
        if (lastGameObjectHit != null) {
            Renderer renderer = lastGameObjectHit.GetComponentInChildren<Renderer>();
            renderer.material.color = lastColor;
            lastGameObjectHit = null;
        }
    }

    public void GetBuilding(GameObject _objectToBuild) {
        objectToBuild = null;
        objectToBuild = _objectToBuild;
        isOnConstructionMode = true;
    }
}
