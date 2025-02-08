using UnityEngine;

public class MouseMouvement : MonoBehaviour
{
    [Header("Maps Parameters")]
    [SerializeField] private int mapLenght;
    [SerializeField] private int mapWidth;
    [SerializeField] private int mapHeight;
    private Vector3 mapCenter;

    [Header("Cirle Pivot")]
    [SerializeField] private float circleRadius;
    [SerializeField] private Transform pivot; // GameObject Pivot ( Empty ) 
    [SerializeField] private Transform cameraTransform; // Camera Reference

    [Header("Rotation Setting")]
    [SerializeField] private float rotationSpeed = 10f; // Rotation speed

    private void Start() {
        GameManager.Instance.ReturnMapSize(out mapWidth, out mapLenght);

        Debug.Log(mapWidth + mapLenght);

        SetMapCenter();

        SetCircleRadius();

        SetCameraPosition();
    }

    private void LateUpdate() {
        GameManager.Instance.ReturnMapSize(out mapWidth, out mapLenght);
        SetMapCenter();
    }

    private void Update() {
        pivot.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void SetMapCenter() {
        mapCenter = new Vector3((float)(mapWidth * 0.5f), mapHeight, (float)(mapLenght * 0.5f));
        pivot.position = mapCenter;
    }

    private void SetCircleRadius() {
        circleRadius = Mathf.Max(mapWidth, mapLenght) * 0.6f;
    }

    private void SetCameraPosition() {
        cameraTransform.localPosition = new Vector3(0, circleRadius * 0.5f, -circleRadius);
        cameraTransform.LookAt(pivot.position);
    }
}
