using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; // 점프 힘
    private Rigidbody rb;      // 물리 엔진을 위한 컴포넌트
    public bool isOnGround;      // 바닥에 닿았는지 체크
    public float gravityModifier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
