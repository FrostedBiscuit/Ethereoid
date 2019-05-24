using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuViewer : BaseViewer {

    public static MainMenuViewer Singelton;

    [SerializeField]
    private TextMeshProUGUI HighScoreText;

    public override void Awake() {

        base.Awake();

        Singelton = this;

        //Show();
    }

    public override void Show() {

        base.Show();

        HighScoreText.text = "HIGH SCORE: " + ScoreManager.instance.GetHighestScore();
    }
}
