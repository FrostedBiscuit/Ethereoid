using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region Singelton
    public static Player instance;

    void Awake() {

        if (instance != null) {

            Debug.LogError("More than 1 instance of Player in the scene!");

            return;
        }

        instance = this;
    }
    #endregion

    // Fields
    [SerializeField]
    GameObject Graphics;
    [SerializeField]
    PlayerMotor PlayerMotor;

    public int StartLives = 3;

    // Use this for initialization
    public void Start() {

        Data.Lives = StartLives;
        Data.Score = 0;

        GameplayViewer.Singleton.Show();

        EndscreenViewer.Singelton.Hide();

        PlayerMotor.ResetPosition();
    }

    // Update is called once per frame
    void Update() {

        if (Data.Lives == 0) {

            // TODO: add graphical notifier that the player is dead
            //Debug.Log("Player ded");

            GameplayViewer.Singleton.Show();

            EndscreenViewer.Singelton.Show();

            ScoreManager.instance.SaveScore();
        }
    }

    void OnTriggerEnter(Collider col) {

        //Debug.Log("Hit by " + col.transform.tag);
        /*
        if(col.transform.tag == "Gem") {
            Data.Score++;
        }
        else if(col.transform.tag == "Enemy") {
            Data.Lives = Data.Lives > StartLives ? Mathf.Clamp(Data.Lives - 1, 0, Data.Lives) : Mathf.Clamp(Data.Lives - 1, 0, StartLives);

            if(Data.Lives == 0) {

                // TODO: add graphical notifier that the player is dead
                Debug.Log("Player ded");

                ScoreManager.instance.SaveScore();

                GameplayViewer.Singleton.Show();

                EndscreenViewer.Singelton.Show();

                return;
            }
        }
        else if(col.transform.tag == "Heart") {
            Data.Lives++;
        }

        GameplayViewer.Singleton.Show(); */
    }

    public void RegisterOnPlayerMoveCallback(Action<Vector3> cb) {

        PlayerMotor.RegisterOnPlayerMoveCallback(cb);
    }

    public void UnregisterOnPlayerMoveCallback(Action<Vector3> cb) {

        PlayerMotor.UnregisterOnPlayerMoveCallback(cb);
    }
}
