using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    //System
    [Header("---- System ----")]
    [SerializeField] private ResourceManagement rM;
    [SerializeField] private Ui_BuildManager ui_buildManager;

    // HilghLight Parameters
    private Color overallColor;

    //Build Parameters
    [Header("---- Build Parameters ----")]
    [SerializeField] private GameObject objectToBuild;
    [SerializeField] private LayerMask constructionLayer;
    [SerializeField] private GameObject lastGameObjectHit = null;
    private GameObject currentGameObject = null;

    [Header("---- List Of Build ----")]
    [SerializeField] private List<SO_Build> buildList = new List<SO_Build>();

    [Header("---- Next Build ----")]
    [SerializeField] private int priceObjToBuild;
    [SerializeField] private bool isOnConstructionMode = false;

    // Main Ship
    [Header("---- Main Ship ----")]
    [SerializeField] private SO_Build mainShip;
    [SerializeField] private bool isNextBuildIsShip = false;
    [SerializeField] private bool isMainShipIsBuild = false;

    private void Update() {
        GetBlocAim();

        if (lastGameObjectHit != null)
            if (Input.GetMouseButtonDown(0) && isOnConstructionMode) {
                if (objectToBuild == null) {
                    Debug.LogError("Construction mode activate, but no building to build");
                } else {
                    if (isNextBuildIsShip) {
                        BuildMainShip();
                        isOnConstructionMode = false;
                    } else if (isMainShipIsBuild) {
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

    private void BuildObject() {
        if (currentGameObject != null) {

            GroundLogic gL = currentGameObject.GetComponent<GroundLogic>();

            if (gL != null) {
                if (gL.IsGroundFree()){
                    if (rM.CanBuy(priceObjToBuild)){
                        gL.SetObjectOnTop(objectToBuild);
                        rM.OnObjectBuild(priceObjToBuild);
                        RemoveHighlight();
                    } else {
                    }
                } else {
                    isOnConstructionMode = true;
                    RemoveHighlight();
                }
            }
        }
    }

    public List<SO_Build> ReturnBuildList() {
        return buildList;
    }

    // Ground HightLight 
    private void HighLight(GameObject blocHit) {
        Renderer renderer = currentGameObject.GetComponentInChildren<Renderer>();
        overallColor = renderer.material.color;
        renderer.material.color = Color.red;
        lastGameObjectHit = currentGameObject;
    }
    private void RemoveHighlight() {
        if (lastGameObjectHit != null) {
            Renderer renderer = lastGameObjectHit.GetComponentInChildren<Renderer>();
            renderer.material.color = overallColor;
            lastGameObjectHit = null;
        }
    }


    // Main Ship Controller
    public void BuildMainShip() {
        if (currentGameObject != null) {

            GroundLogic gL = currentGameObject.GetComponent<GroundLogic>();

            if (gL != null) {
                if (gL.IsGroundFree() == true) {
                    if (!GameManager.Instance.ReturnMainShipStatue()) { // Check if MainShip didnt already exist
                        gL.SetObjectOnTop(objectToBuild);
                        isMainShipIsBuild = true;
                        RemoveHighlight();
                    } else {
                        isOnConstructionMode = false;
                        objectToBuild = null;
                    }
                } else {
                    isOnConstructionMode = true;
                }
            }
        }
    }

    public void GetShipBuilding(GameObject _objectToBuild) {
        isNextBuildIsShip = true;

        if(objectToBuild != null) 
            objectToBuild = null;

        objectToBuild = _objectToBuild;
        isOnConstructionMode = true;
    }

    public void GetBuilding(GameObject _objectToBuild, int _price) {
        isNextBuildIsShip = false;

        if (objectToBuild != null)
            objectToBuild = null;

        objectToBuild = _objectToBuild;
        priceObjToBuild = _price;
        isOnConstructionMode = true;
    }
}
