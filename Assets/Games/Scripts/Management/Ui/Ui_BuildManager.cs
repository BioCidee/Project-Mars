using UnityEngine;

public class Ui_BuildManager : MonoBehaviour
{
    [SerializeField] private BuildSystem buildSystem;

    [Header("Building")]
    [SerializeField] private GameObject Excavator;
    [SerializeField] private GameObject Turret;
    [SerializeField] private GameObject bigTurret;
    [SerializeField] private GameObject MainShip;
    [SerializeField] private GameObject shield;

    private int excavaTorPrice = 10;
    private int turretPrice = 20;
    private int shieldPrice = 0;
    private int bigTurretPrice = 0;

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
    
    public void BuildShield() {
        buildSystem.GetBuilding(shield, shieldPrice);
    }

    public void BuildBigTurret() {
        buildSystem.GetBuilding(bigTurret, bigTurretPrice);
    }
}