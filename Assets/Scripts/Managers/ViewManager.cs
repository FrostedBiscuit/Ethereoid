using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum View {
    TOPDOWN, SIDE
}

public class ViewManager : MonoBehaviour {

    #region Singelton
    public static ViewManager instance;

    void Awake() {

        if (instance != null) {

            Debug.LogError("More than 1 instance of ViewManager in the scene!!");

            return;
        }

        instance = this;
    }
    #endregion

    public Transform TopDownPos;
    public Transform SidePos;

    public View Pos = View.TOPDOWN;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        switch(Pos) {
            case View.TOPDOWN:
                topDownView();
                break;
            case View.SIDE:
                sideView();
                break;
        }
	}

    void topDownView() {

        Camera.main.transform.position = TopDownPos.position;
        Camera.main.transform.rotation = TopDownPos.rotation;
    }

    void sideView() {

        Camera.main.transform.position = SidePos.position;
        Camera.main.transform.rotation = SidePos.rotation;
    }
}
