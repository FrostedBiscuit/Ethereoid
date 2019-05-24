using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    #region Singelton
    public static ScoreManager instance;

    void Awake() {

        if(instance != null) {

            Debug.LogError("More than 1 instance of ScoreManager in the scene!");

            return;
        }

        instance = this;
    }
    #endregion

    // Use this for initialization
    void Start () {
		
	}

    public void ResetHighScore() {

        if (PlayerPrefs.HasKey("HighScore")) {

            PlayerPrefs.SetInt("HighScore", 0);
            PlayerPrefs.Save();

            return;
        }

        PlayerPrefs.SetInt("HighScore", 0);
    }

    public void SaveScore() {

        if (PlayerPrefs.HasKey("HighScore") && PlayerPrefs.GetInt("HighScore") < Data.Score) {

            PlayerPrefs.SetInt("HighScore", Data.Score);
            PlayerPrefs.Save();

            return;
        }

        if(!PlayerPrefs.HasKey("HighScore")) {

            PlayerPrefs.SetInt("HighScore", Data.Score);
        }
    }

    public int GetHighestScore() {

        if (PlayerPrefs.HasKey("HighScore"))
            return PlayerPrefs.GetInt("HighScore");
        else
            return 0;
    }
}
