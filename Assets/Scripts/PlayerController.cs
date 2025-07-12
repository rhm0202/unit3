using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5f; // ���� ��
    private Rigidbody rb;      // ���� ������ ���� ������Ʈ
    public bool isOnGround;      // �ٴڿ� ��Ҵ��� üũ
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
