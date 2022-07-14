using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField] private GameObject obstaclePrefab;

    private float startDelay = 2f;
    private float repeateRate = 2f;

    private Vector3 spawnPosition = new(25, 0, 0);

    void Start() {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeateRate);
    }

    void Update() {

    }

    private void SpawnObstacle() {
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }

}
