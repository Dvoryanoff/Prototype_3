using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRb;
    [SerializeField] private float gravityModifier;
    [SerializeField] private bool isOnGround = true;
    [SerializeField] public bool gameOver = false;

    [Range(1, 20)]
    [SerializeField] private float jumoForce = 10f;

    void Start() {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        Jump();

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            Jump();
            isOnGround = false;
        }

    }

    void Jump() {
        playerRb.AddForce(jumoForce * Vector3.up, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            GameOver();
        }

    }
    private void GameOver() {
        Debug.Log("Game Over!");
        gameOver = true;
    }

}
