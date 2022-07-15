using UnityEngine;

public class MoveLeft : MonoBehaviour {

    [SerializeField] private float speed = 30f;
    private PlayerController playerControllerScript;

    void Update() {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        if (playerControllerScript.gameOver == false) {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }
    }
}