using UnityEngine;

public class Ui_BuildManager : MonoBehaviour
{
    [SerializeField] private MouseLogic mouseLogic;

    [Header("Building")]
    [SerializeField] private GameObject Excavator;
    [SerializeField] private GameObject Turret;

    private int excavaTorPrice = 0;
    private int turretPrice = 20;

    public void BuildExcavator() {
        mouseLogic.GetBuilding(Excavator, excavaTorPrice);
    }

    public void BuildTurret()
    {
        mouseLogic.GetBuilding(Turret, turretPrice);
    }
}
