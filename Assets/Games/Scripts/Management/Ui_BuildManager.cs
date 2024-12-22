using UnityEngine;

public class Ui_BuildManager : MonoBehaviour
{
    [SerializeField] private MouseLogic mouseLogic;

    [InspectorName("Building")]
    [SerializeField] private GameObject Excavator;
    [SerializeField] private GameObject Turret;

    public void BuildExcavator() {
        mouseLogic.GetBuilding(Excavator);
    }

    public void BuildTurret()
    {
        mouseLogic.GetBuilding(Turret);
    }
}
