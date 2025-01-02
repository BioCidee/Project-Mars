using UnityEngine;

public class MouseLogic : MonoBehaviour
{
    [SerializeField] private ResourceManagement rM;
    private Vector2 mousePosition;
    private GameObject lastGameObjectHit = null;
    private GameObject currentGameObject = null;
    private Color lastColor;
    private MeshRenderer lastMaterial;
    [SerializeField] private LayerMask constructionLayer;

    private bool isOnConstructionMode = false;
    [SerializeField] private GameObject objectToBuild;
    private bool isBuildingIsShip = false;
    private int priceObjToBuild;

    private void Update() {
        GetBlocAim();


        if (lastGameObjectHit != null )
            if (Input.GetMouseButtonDown(0) && isOnConstructionMode) {
                if (objectToBuild == null) {
                    Debug.LogError("Construction mode activate, but no building to build");
                } else {
                    if (isBuildingIsShip) {
                        BuildMainShip();
                        isOnConstructionMode = false;
                    } else {
                        BuildObject();
                        isOnConstructionMode = false;
                    }
                }
            }
    }

    private void GetBlocAim() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, constructionLayer)) {
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

    public void BuildMainShip() {
        if (currentGameObject != null) {

            GroundLogic gL = currentGameObject.GetComponent<GroundLogic>();

            if (gL != null) {
                if (gL.IsGroundFree() == true) {
                        if (!GameManager.Instance.ReturnMainShipStatue()) {
                            gL.SetObjectOnTop(objectToBuild);
                        } else {
                            Debug.Log("Main ship already build");
                            isOnConstructionMode = false;
                            objectToBuild = null;
                        }
                } else {
                    Debug.Log("There is already an object here ");
                    isOnConstructionMode = true;
                }
            }
        }
    }

    private void BuildObject() {
        if (currentGameObject != null) {

            GroundLogic gL = currentGameObject.GetComponent<GroundLogic>();

            if (gL != null) {
                if (gL.IsGroundFree() == true){
                    if (rM.CanBuy(priceObjToBuild)){
                        gL.SetObjectOnTop(objectToBuild);
                    } else {
                        Debug.Log("No money");
                    }
                } else {
                    Debug.Log("There is already an object here ");
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

    public void GetShipBuilding(GameObject _objectToBuild) {
        isBuildingIsShip = true;

        if(objectToBuild != null) 
            objectToBuild = null;

        objectToBuild = _objectToBuild;
        isOnConstructionMode = true;
    }

    public void GetBuilding(GameObject _objectToBuild, int _price) {
        isBuildingIsShip = false;

        if (objectToBuild != null)
            objectToBuild = null;

        objectToBuild = _objectToBuild;
        priceObjToBuild = _price;
        isOnConstructionMode = true;
    }
}
