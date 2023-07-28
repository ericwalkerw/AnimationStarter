using UnityEngine;

public class InitValue : MonoBehaviour
{
    private int Gold;
    private int Gem;

    public int GoldReward;
    public int GemReward;



    private void Start()
    {
        GoldReward = Random.Range(1000, 6000);
        GemReward = Random.Range(20, 100);
    }
}
