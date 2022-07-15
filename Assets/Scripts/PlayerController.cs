using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRb;
    private Animator playerAnimator;
    [SerializeField] private float gravityModifier;
    [SerializeField] private bool isOnGround = true;

    //public static event Action GameOver;

    public bool IsGameOver {
        get;
        private set;
    }

    [SerializeField] private float jumpForce = 10f;

    private void Start() {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnimator = GetComponent<Animator>();
        //Jump();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !IsGameOver) {
            Jump();
        }
    }

    private void Jump() {
        playerRb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        playerAnimator.SetTrigger("Jump_trig");
        isOnGround = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            Loose();
            Death();
        }
    }

    private void Loose() {
        Debug.Log("Game Over!");
        //GameOver?.Invoke();
        IsGameOver = true;
    }
    private void Death() {
        playerAnimator.SetBool("Death_b", true);
        playerAnimator.SetInteger("DeathType_int", 1);
    }
}
