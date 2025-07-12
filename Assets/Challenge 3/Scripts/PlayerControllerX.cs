using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    float playerY;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    private bool isLowEnough = true;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        playerY = transform.position.y;
        if (playerY >= 15)
        {
            isLowEnough = false;
            playerRb.linearVelocity = Vector3.zero;
        }
        else
        {
            isLowEnough = true;
        }


        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    public AudioClip bounceSound;      // Inspector에서 바닥 효과음 연결
    public float bounceForce = 10f;    // Inspector에서 튀어오르는 힘 조절

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            // 바닥에 닿으면 위로 튕김
            playerRb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);

            // 효과음 재생
            playerAudio.PlayOneShot(bounceSound, 1.0f);
        }
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
