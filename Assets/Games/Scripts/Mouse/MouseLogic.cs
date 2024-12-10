using UnityEngine;

public class MouseLogic : MonoBehaviour
{
    private Vector2 mousePosition;
    private GameObject lastGameObjectHit;
    private Color lastColor;
    private MeshRenderer lastMaterial;

    private void Update() {
        GetBlocAim();
    }

    private void GetBlocAim() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit)) {
            GameObject objectHit = hit.transform.gameObject;

            

            if (lastGameObjectHit != objectHit && lastGameObjectHit != null) {
                // Re mettre la dernière couleur du bloc au bloc 
                lastGameObjectHit.GetComponentInChildren<MeshRenderer>().material.color = lastMaterial.material.color;
                // Sauvegarder la couleur du nouveau bloc 
                lastMaterial = objectHit.GetComponentInChildren<MeshRenderer>();
                // Highlight le nouveau bloc
                objectHit.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                lastGameObjectHit = objectHit;
            } 
        }
    }

    private void GetMousePosition() {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        mousePosition = new Vector2(x, y);
    }
}
