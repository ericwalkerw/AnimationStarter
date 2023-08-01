using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitValue : MonoBehaviour
{
    public int Gold;
    private int GoldReward;
    public TMP_Text GoldText;
    public TextMeshProUGUI GoldRewardText;
    public Text GoldholderText;
    public Slider GoldSlider;
    [Space]
    public int Gem;
    private int GemReward;
    public TMP_Text GemText;
    public TMP_Text GemRewardText;
    public Text GemholderText;
    public Slider GemSlider;

    private void Start()
    {
        Gold = 0;
        Gem = 0;
        GoldReward = Random.Range(1000, 6000);
        GemReward = Random.Range(20, 100);
        GoldText.text = Gold.ToString();
        GemText.text = Gem.ToString();
        GoldRewardText.text = GoldReward.ToString();
        GemRewardText.text = GemReward.ToString();
    }
    public void Collect()
    {
        GoldholderText.DOCounter(Gold, Gold + GoldReward, 1).OnUpdate(() =>
        {
            GoldText.text = GoldholderText.text;
        });
        Gold += GoldReward;
        GoldSlider.DOValue((float)Gold / 20000, 1f);

        GemholderText.DOCounter(Gem, Gem + GemReward, 1).OnUpdate(() =>
        {
            GemText.text = GemholderText.text;
        });
        Gem += GemReward;
        GemSlider.DOValue((float)Gem / 500, 1f);
    }
}
