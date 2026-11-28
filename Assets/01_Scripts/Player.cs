using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private Rigidbody2D rigid;
    private Collider2D coll;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float curHealth;

    [SerializeField] private float damagePerSecond;

    [SerializeField] private bool isInSafeZone;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        curHealth = maxHealth;
    }

    private void FixedUpdate()
    {
        if (!IsSpawned || !IsOwner)
            return;

        Movement();

        if (Input.GetMouseButton(0))
        {
            Attack();
        }

        if (!isInSafeZone)
            curHealth -= damagePerSecond * Time.deltaTime;

    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 moveVec = new Vector2(horizontal, vertical).normalized;

        rigid.MovePosition((Vector2)transform.position + moveVec * moveSpeed * Time.fixedDeltaTime);
    }

    private void Attack() // 코루틴으로?
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 attackDir = (mousePos - transform.position).normalized;

        // 공격 모션 및 판정
    }

    public void SetSafeZoneState(bool state)
    {
        isInSafeZone = state;
    }

    public void Heal(float value)
    {
        curHealth = Mathf.Min(maxHealth, curHealth + value);
    }
}
