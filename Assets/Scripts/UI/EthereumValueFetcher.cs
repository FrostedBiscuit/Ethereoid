using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthereumValueFetcher : MonoBehaviour {

    public string URL = "https://api.coinmarketcap.com/v1/ticker/ethereum/";

    WWW priceUrl;

    float ethPrice = 0f;

    // Use this for initialization
    void Start () {

        priceUrl = new WWW(URL);

        //StartCoroutine(loadETHPrice());
	}

    IEnumerator loadETHPrice() {

        yield return priceUrl;

        ethPrice = JsonUtility.FromJson<Ethereum>(priceUrl.text).price_usd;

        Debug.Log(ethPrice);
    }

    class Ethereum {

        public string id;
        public string name;
        public string symbol;

        public int rank;
        public int last_updated;

        public float price_usd;
        public float price_btc;
        public float _24h_volume_usd;
        public float market_cap_usd;
        public float avalable_supply;
        public float total_supply;
        public float max_supply;
        public float percent_change_1h;
        public float percent_change_24h;
        public float percent_change_7d;
    }
}
