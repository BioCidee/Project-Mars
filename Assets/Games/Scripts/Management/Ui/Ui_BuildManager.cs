using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui_BuildManager : MonoBehaviour
{
    [Header("---- System ----")]
    [SerializeField] private BuildSystem buildSystem;

    [Header("---- UI System and Parameters ----")]
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform uiParent;

    [Header("---- Building ----")]
    [SerializeField] private List<SO_Build> buildList;
    [SerializeField] private GameObject Excavator;
    [SerializeField] private GameObject Turret;
    [SerializeField] private GameObject bigTurret;
    [SerializeField] private GameObject MainShip;
    [SerializeField] private GameObject shield;

    private int excavaTorPrice = 10;
    private int turretPrice = 20;
    private int shieldPrice = 0;
    private int bigTurretPrice = 0;

    private void Start() {
        GetBuildList();
        SetBuildUI();
    }

    private void GetBuildList() {
        buildList = new List<SO_Build>();
        buildList = buildSystem.ReturnBuildList();

        if (buildList.Count <= 0) Debug.LogError("There is no build List ! The UI cant be loaded !");
    }

    private void SetBuildUI() {

        foreach (SO_Build build in buildList) {
            CreateNewButton(build.name, build.price, null);
        }
        GameObject newButtonBuild = Instantiate(buttonPrefab, uiParent);
        newButtonBuild.GetComponentInChildren<TextMeshProUGUI>().text = "MyBuild";
        newButtonBuild.GetComponent<Button>().onClick.AddListener(BuildMainShip);  
    }

    private void CreateNewButton(string _name_, int cost, Action _listener) {

    }

    public void BuildExcavator() {
        buildSystem.GetBuilding(Excavator, excavaTorPrice);
    }

    public void BuildTurret()
    {
        buildSystem.GetBuilding(Turret, turretPrice);
    }

    public void BuildMainShip() {
        buildSystem.GetShipBuilding(MainShip);
        Debug.Log("Button pressed");
    }
    
    public void BuildShield() {
        buildSystem.GetBuilding(shield, shieldPrice);
    }

    public void BuildBigTurret() {
        buildSystem.GetBuilding(bigTurret, bigTurretPrice);
    }
}