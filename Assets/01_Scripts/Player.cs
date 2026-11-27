using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private Rigidbody2D rigid;
    private Collider2D coll;

    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (!IsSpawned || !IsOwner)
            return;

        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 moveVec = new Vector2(horizontal, vertical).normalized;

        rigid.MovePosition((Vector2)transform.position + moveVec * moveSpeed * Time.fixedDeltaTime);
    }
}
