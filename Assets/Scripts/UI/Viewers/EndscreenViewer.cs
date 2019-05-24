using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndscreenViewer : BaseViewer {

    public static EndscreenViewer Singelton = null;

    [SerializeField]
    private TextMeshProUGUI EndscreenTitleText;
    [SerializeField]
    private TextMeshProUGUI EndscreenScoreText;
    [SerializeField]
    private TextMeshProUGUI EndscreenHighScoreText;

    public override void Awake() {

        base.Awake();

        Singelton = this;
    }

    public override void Show() { 

        if (isOpen == true)
            return;

        base.Show();

        if (EndscreenTitleText == null) {
            Debug.LogError("No Endscreen Title Text reference assigned!");
        }
        else if (EndscreenScoreText == null) {
            Debug.LogError("No Endscreen Score Text reference assigned!");
        }
        else if (EndscreenHighScoreText == null) {
            Debug.LogError("No Endscreen High Score Text reference assigned!");
        }
        else {

            Debug.Log("EndscreenViewer::Show() => currScore: " + Data.Score + " highScore: " + ScoreManager.instance.GetHighestScore());

            // TODO: Add some kind of phrase library
            EndscreenTitleText.text = Data.Score > ScoreManager.instance.GetHighestScore() ? "HIGH SCORE!" : "GAME OVER";

            EndscreenScoreText.text = "SCORE: " + Data.Score;

            EndscreenHighScoreText.text = Data.Score > ScoreManager.instance.GetHighestScore() ? "HIGH SCORE: " + Data.Score : "HIGH SCORE: " + ScoreManager.instance.GetHighestScore();
        }
    }
}
