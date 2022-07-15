using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField] private GameObject obstaclePrefab;
    private PlayerController playerControllerScript;

    private float startDelay = 2f;
    private float repeateRate = 2f;

    private Vector3 spawnPosition = new(25, 0, 0);

    //private void OnDestroy() {
    //    PlayerController.GameOver -= OnGameOver;
    //}

    //private void OnGameOver() {
    //    CancelInvoke(nameof(SpawnObstacle));
    //}

    void Start() {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeateRate);
        //PlayerController.GameOver += OnGameOver;

    }

    void Update() {

    }

    private void SpawnObstacle() {
        if (playerControllerScript.IsGameOver == false) {
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
        }
    }

}
