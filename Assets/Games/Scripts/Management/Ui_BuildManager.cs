using UnityEngine;

public class Ui_BuildManager : MonoBehaviour
{
    [SerializeField] private MouseLogic mouseLogic;

    [InspectorName("Building")]
    [SerializeField] private GameObject Excavator;

    public void BuildExcavator() {
        mouseLogic.GetBuilding(Excavator);
    }
}
