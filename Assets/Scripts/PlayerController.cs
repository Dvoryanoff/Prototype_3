using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource playerAudioSource;

    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private float gravityModifier;
    [SerializeField] private bool isOnGround = true;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;

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
        playerAudioSource = GetComponent<AudioSource>();
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
        playerAudioSource.PlayOneShot(jumpSound, 1.0f);
        dirtParticle.Stop();
        isOnGround = false;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            Loose();
            Death();
            playerAudioSource.PlayOneShot(crashSound, 1.0f);

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
        explosionParticle.Play();
        dirtParticle.Stop();
    }

}
