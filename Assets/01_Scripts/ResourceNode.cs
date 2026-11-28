using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    // 자원 데이터 에셋을 가지고 거기서 밸류 및 인덱스, 아이템 스프라이트 관리하기? 일단 임시로
    [SerializeField] private int index = 0;
    [SerializeField] private float value;

    [SerializeField] private float maxHealth;
    [SerializeField] private float curHealth;

    // 공격을 받으면 체력 감소
    public void TakeDamage()
    {
        curHealth--;

        if (curHealth <= 0)
        {
            ItemDrop();
        }
    }

    // 체력이 0이 되면 사라지면서 아이템화 된 자원 드랍 (1~3개 랜덤)
    private void ItemDrop()
    {
        int dropCount = Random.Range(1, 4);

        // PoolManager 에서 item 생성, 생성 위치 기존 자원 위치에서 약간의 랜덤값+
        for (int i = 0; i < dropCount; i++)
        {
            ResourceItem item = PoolManager.Instance.GetResource(index);

            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector3 diffPos = new Vector2(x, y);

            item.transform.position = transform.position + diffPos;
        }
    }
}
