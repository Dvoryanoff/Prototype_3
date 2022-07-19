using UnityEngine;

public class PlayerControllerX : MonoBehaviour {
    public bool gameOver;
    public bool tooHigh;

    private float tooHighBound = 14;
    public float floatForce = 10;
    public float startForce = 10;
    private float gravityModifier = 2f;
    public Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    public AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;

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
