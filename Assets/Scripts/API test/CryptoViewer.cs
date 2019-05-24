using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CryptoViewer : MonoBehaviour {

    public Text price = null;

    void Start()
    {
        price.text = "0";

    }

    public void setPrice()
    {
        CryptoStats.Singleton.UpdateEtherPrice(onSucces, onError);
    }

    private void onSucces()
    {
        price.text = Data.EtherPrice.ToString("n2") + " $";
    }

    private void onError()
    {
        Debug.LogError("There was a problem fetching Ethereum price!");
    }
}
