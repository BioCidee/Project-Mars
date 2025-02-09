using UnityEngine;

public class MouseMouvement : MonoBehaviour
{
    [Header("Main Camera Parameters")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraMoveSpeed;
    [SerializeField] private float cameraDistance;

    private Vector3 pointZero;
    private Vector3 previousPosition;

    private void Start() {
        SetPointZero();
    }

    private void Update() {
        SetCameraDistance();

        if (Input.GetMouseButtonDown(0)) {
            previousPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0)) {
            Vector3 direction = previousPosition - mainCamera.ScreenToViewportPoint(Input.mousePosition);

            mainCamera.transform.position = pointZero;

            mainCamera.transform.Rotate(new Vector3(cameraMoveSpeed, 0, 0), direction.y * 180);
            mainCamera.transform.Rotate(new Vector3(0,cameraMoveSpeed,0), -direction.x * 180, Space.World);
            mainCamera.transform.Translate(new Vector3(0,0,-50)); 

            previousPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);  
        }
    }

    private void SetCameraDistance() {
        float scrool = Input.GetAxis("Mouse ScrollWheel");
        cameraDistance += scrool * 5f; // 
        cameraDistance = Mathf.Clamp(cameraDistance,0, 50); // Limit the camera distance
    }


    private void SetPointZero() { // Set the point for the camera rotate
        int width;
        int lenght;

        GameManager.Instance.ReturnMapSize(out width, out lenght);

        pointZero = new Vector3((float)(width * 0.5), 0, (float)(lenght * 0.5));
    }
}
