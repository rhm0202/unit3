using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 10;

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
