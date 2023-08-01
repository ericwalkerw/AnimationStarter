using DG.Tweening;
using UnityEngine;

public class CollectReward : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private GameObject GemPrefab;
    [Header("Location")]
    [SerializeField] private Transform RewardHolder;
    [SerializeField] private Transform SpawnLocation;
    [SerializeField] private Transform endPosCoin;
    [SerializeField] private Transform endPosGem;
    [Header("Value")]
    [SerializeField] private int Amount;
    [SerializeField] private int duration;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    public void CollectRewards()
    {
        SpawnPrefab(CoinPrefab, endPosCoin);
        SpawnPrefab(GemPrefab, endPosGem);
    }

    public void SpawnPrefab(GameObject prefab, Transform endPos)
    {
        for (int i = 0; i < Amount; i++)
        {
            float xPos = SpawnLocation.position.x + Random.Range(minX, maxX);
            float yPos = SpawnLocation.position.y + Random.Range(minY, maxY);

            GameObject Instance = Instantiate(prefab, RewardHolder);
            Instance.transform.position = new Vector3(xPos, yPos);

            Instance.transform.DOMove(endPos.position + new Vector3(Random.Range(-2, 2), 0, 0), duration + Random.Range(-2, 1))
                .SetEase(Ease.InElastic).OnComplete(() =>
                {
                    endPos.DOPunchScale(new Vector3(1.2f, 1.2f, 1.2f), 0.3f).OnComplete(() =>
                    {
                        endPos.DOScale(1f, 0);
                    });
                    Destroy(Instance);
                });
        }
    }
}
