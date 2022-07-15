using UnityEngine;

public class MoveLeft : MonoBehaviour {

    [SerializeField] private float speed = 30f;
    private PlayerController playerControllerScript;

    private void Start() {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //PlayerController.GameOver += OnGameOver;
    }

    //private void OnDestroy() {
    //    PlayerController.GameOver -= OnGameOver;
    //}

    //private void OnGameOver() {
    //    enabled = false;
    //}

    void Update() {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        if (playerControllerScript.IsGameOver == false) {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }
    }
}