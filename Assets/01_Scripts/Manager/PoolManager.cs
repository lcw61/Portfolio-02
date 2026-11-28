using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [SerializeField] private GameObject[] resourcePrefabs;

    private List<ResourceItem> resources = new();

    [SerializeField] private Transform resourcePool;

    private void Awake()
    {
        Instance = this;
    }

    // 아이템화 자원 생성 (자원 인덱스)
    public ResourceItem GetResource(int index)
    {
        foreach (ResourceItem resource in resources)
        {
            if (!resource.gameObject.activeSelf)
            {
                resource.gameObject.SetActive(true);

                return resource;
            }
        }

        ResourceItem result = Instantiate(resourcePrefabs[index], resourcePool).GetComponent<ResourceItem>();

        return result;
    }
}
