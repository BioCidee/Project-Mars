using UnityEngine;

public class MouseMouvement : MonoBehaviour
{
    [Header("Main Camera Parameters")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float cameraMoveSpeed;
    [SerializeField] private float cameraDistance;

    [SerializeField] private Vector3 pointZero;
    private Vector3 previousPosition;

    private void Start() {
        SetPointZero();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            previousPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetKey(KeyCode.LeftControl)) {
            SetCameraDistance();

            Vector3 direction = previousPosition - mainCamera.ScreenToViewportPoint(Input.mousePosition);

            mainCamera.transform.position = new Vector3(pointZero.x, pointZero.y, pointZero.z);

            mainCamera.transform.Rotate(new Vector3(cameraMoveSpeed, 0, 0), direction.y * 180);
            mainCamera.transform.Rotate(new Vector3(0,cameraMoveSpeed,0), -direction.x * 180, Space.World);
            mainCamera.transform.Translate(new Vector3(0, 0, cameraDistance));

            previousPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);  
        }
    }

    private void SetCameraDistance() {
        float scrool = Input.GetAxis("Mouse ScrollWheel");
        cameraDistance += scrool * 10f; // 
        cameraDistance = Mathf.Clamp(cameraDistance,-50, 50); // Limit the camera distance
    }


    private void SetPointZero() { // Set the point for the camera rotate
        int width;
        int lenght;

        GameManager.Instance.ReturnMapSize(out width, out lenght);

        pointZero = new Vector3((float)(width * 0.5), 0, (float)(lenght * 0.5));
    }
}
