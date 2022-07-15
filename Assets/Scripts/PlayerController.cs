using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRb;
    [SerializeField] private float gravityModifier;
    [SerializeField] private bool isOnGround = true;

    public static event Action GameOver;

    public bool IsGameOver {
        get;
        private set;
    }

    [Range(1, 20)]
    [SerializeField] private float jumpForce = 10f;

    private void Start() {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        Jump();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            Jump();
        }
    }

    private void Jump() {
        playerRb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        isOnGround = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            Loose();
        }
    }

    private void Loose() {
        Debug.Log("Game Over!");
        GameOver?.Invoke();
        IsGameOver = true;
    }
}
