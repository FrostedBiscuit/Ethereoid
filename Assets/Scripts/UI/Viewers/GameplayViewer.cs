using UnityEngine;
using TMPro;

public class GameplayViewer : BaseViewer {

    // Singleton
    public static GameplayViewer Singleton = null;

    [SerializeField]
    private TextMeshProUGUI ScoreText = null;
    [SerializeField]
    private TextMeshProUGUI LivesText = null;
    [SerializeField]
    private TextMeshProUGUI EtherPriceText = null;

    [SerializeField]
    private float EtherPriceUpdateDelay = 30f;

    public override void Awake()
    {
        base.Awake();

        Debug.Log("Awake GameplayViewer");

        Singleton = this;
    }

    bool isGettingPrice = false;

    public override void Show() {

        base.Show();

        if (LivesText == null)
            Debug.LogError("Lives Text reference not assigned");
        else
            LivesText.text = Data.Lives.ToString();

        if (ScoreText == null)
            Debug.LogError("Score Text reference not assigned");
        else
            ScoreText.text = Data.Score.ToString();

        if (isGettingPrice == false) { 
            InvokeRepeating("getETHPrice", 0f, EtherPriceUpdateDelay);

            isGettingPrice = true;
        }
    }

    public override void Hide() {

        CancelInvoke("getETHPrice");

        isGettingPrice = false;

        base.Hide();
    }

    void getETHPrice() {

        if (EtherPriceText == null) {
            Debug.LogError("Ethereum Price Text reference not set!");
        }
        else {
            //EtherPriceText.text = "$ " + Data.EtherPrice.ToString("#.00");

            CryptoStats.Singleton.UpdateEtherPrice(
                () => { EtherPriceText.text = "$ " + Data.EtherPrice.ToString("#.00"); },
                () => { EtherPriceText.text = "NO CONNECTION"; }
                );
        } 
    }
}
