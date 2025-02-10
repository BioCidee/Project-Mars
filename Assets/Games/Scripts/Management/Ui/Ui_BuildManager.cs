using UnityEngine;

public class Ui_BuildManager : MonoBehaviour
{
    [SerializeField] private BuildSystem buildSystem;

    [Header("Building")]
    [SerializeField] private GameObject Excavator;
    [SerializeField] private GameObject Turret;
    [SerializeField] private GameObject MainShip;

    private int excavaTorPrice = 10;
    private int turretPrice = 20;

    public void BuildExcavator() {
        buildSystem.GetBuilding(Excavator, excavaTorPrice);
    }

    public void BuildTurret()
    {
        buildSystem.GetBuilding(Turret, turretPrice);
    }

    public void BuildMainShip() {
        buildSystem.GetShipBuilding(MainShip);
    }
}