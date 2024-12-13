using UnityEngine;

public class GroundLogic : MonoBehaviour
{
    [SerializeField] private Transform transformObjectOnTop;
    [SerializeField] private GameObject objectOnTop = null;

    public void SetObjectOnTop(GameObject gameObject) {
        Debug.Log("Launch Fonction SetObjectOnTop");
        if (objectOnTop == null) {
            Debug.Log("Begin Build");
            GameObject myObject = Instantiate(gameObject);
            myObject.transform.position = transformObjectOnTop.transform.position;

            objectOnTop = myObject;
            Debug.Log("Bloc is build on " +  this.name);
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
