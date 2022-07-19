using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    public bool gameOver {
        get; private set;
    }
    public bool tooHigh {
        get; private set;
    }

    [SerializeField] private float tooHighBound = 14;
    [SerializeField] private float floatForce = 10;
    [SerializeField] private float startForce = 10;
    [SerializeField] private float gravityModifier = 2f;
    [SerializeField] private Rigidbody playerRb;

    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem fireworksParticle;

    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioClip moneySound;
    [SerializeField] private AudioClip explodeSound;
    [SerializeField] private AudioClip bounceSound;

    // Start is called before the first frame update
    void Start() {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * startForce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update() {
        tooHigh = playerRb.transform.position.y > tooHighBound;
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !tooHigh && !gameOver) {
            playerRb.AddForce(Vector3.up * floatForce);
        }

    }

    private void OnCollisionEnter(Collision other) {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb")) {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 2.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Money")) {

            // if player collides with money, fireworks
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 2.0f);
            Destroy(other.gameObject);

        } else if (other.gameObject.CompareTag("Ground") && !gameOver) {
            playerRb.AddForce(Vector3.up * startForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounceSound);
        }

    }

}
