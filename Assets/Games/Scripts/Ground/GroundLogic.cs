using UnityEngine;

public class GroundLogic : MonoBehaviour
{
    [SerializeField] private Transform transformObjectOnTop;
    [SerializeField] private GameObject objectOnTop = null;

    public void SetObjectOnTop(GameObject gameObject) {
        if (objectOnTop == null) {
            GameObject myObject = Instantiate(gameObject);
            myObject.transform.position = transformObjectOnTop.transform.position;

            objectOnTop = myObject;
        }
    }

    public Transform ReturnTransformTop() {
        return transformObjectOnTop;
    }

    public bool IsGroundFree() {
        if (objectOnTop != null) {
            return false;
        } else {
            return true;
        }
    }

    public void RemoveObjectOnTop() {
        if (objectOnTop != null) {
            Destroy(objectOnTop.gameObject);
        }
    }
}
