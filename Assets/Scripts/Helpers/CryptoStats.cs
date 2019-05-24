using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CryptoStats : MonoBehaviour
{
    private const string API_URL = "https://api.coinmarketcap.com/v2/ticker/1027/";
    public static CryptoStats Singleton = null;

    public void Awake()
    {
        Singleton = this;
    }

    public void UpdateEtherPrice(Action onSuccess, Action onError)
    {
        StartCoroutine(GetEtherPrice(
        () => {
            onSuccess();
        },
        () => {
            onError();
        } ));
    }

    public void UpdateEtherPrice() {

        StartCoroutine(GetEtherPrice(
        () => { },
        () => { })
        );
    }

    IEnumerator GetEtherPrice(Action onSuccess, Action onError)
    {
        UnityWebRequest apiRequest = UnityWebRequest.Get(API_URL);  // Connection to coinamrketcap API
        apiRequest.chunkedTransfer = false;
        yield return apiRequest.SendWebRequest();

        if (apiRequest.isNetworkError)
        {
            onError();
            yield break;
        }

        string jsonResult = System.Text.Encoding.UTF8.GetString(apiRequest.downloadHandler.data);
        JSONObject json = new JSONObject(jsonResult, -5);
        float price = float.Parse(json["data"]["quotes"]["USD"]["price"].ToString());

        Data.EtherPrice = price;

       onSuccess();
    }
}