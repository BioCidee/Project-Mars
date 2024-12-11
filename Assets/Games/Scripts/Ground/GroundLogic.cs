using UnityEngine;

public class GroundLogic : MonoBehaviour
{
    [SerializeField] private Transform transformObjectOnTop;
    [SerializeField] private GameObject objectOnTop;

    public void SetObjectOnTop(GameObject gameObject) {
        if (objectOnTop != gameObject) {
            GameObject myObject = Instantiate(gameObject);
            myObject.transform.position = transformObjectOnTop.transform.position;

            objectOnTop = myObject;
        }
    }

    public Transform ReturnTransformTop() {
        return transformObjectOnTop;
    }

    public void RemoveObjectOnTop() {
        if (objectOnTop != null) {
            Destroy(objectOnTop.gameObject);
        }
    }
}
