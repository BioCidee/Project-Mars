using UnityEngine;

public class SpawnRule : MonoBehaviour
{
    private GameObject miningGround;
    [SerializeField] private Transform bottom;
    [SerializeField] private LayerMask layerGroundMining;

    private void Start() {
        if (Physics.CheckSphere(bottom.position, 0.2f, layerGroundMining)) {
            Debug.Log("IsOk");
        } else {
            OnBuildIsWrong();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(bottom.position, 0.2f);
    }

    private void OnBuildIsWrong() {
        Debug.LogError("This excavator is not build on a MiningGround");
        Destroy(gameObject);
    }
}
