using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 30;
    private float leftBound = -15;
    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
