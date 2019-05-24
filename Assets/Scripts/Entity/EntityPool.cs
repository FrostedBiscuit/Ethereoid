using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPool : MonoBehaviour {

    #region Singelton
    public static EntityPool instance;

    void Awake() {

        if(instance != null) {

            Debug.LogError("More than 1 instance of EntityPool in the scene!");

            return;
        }

        instance = this;
    }
    #endregion

    GameObject[] allChildren;
    
    // Use this for initialization
    void Start () {
	}

	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyAllEntities() {

        int i = 0;

        allChildren = new GameObject[transform.childCount];

        foreach (Transform child in transform) {

            //Debug.Log(allChildren.Length);

            allChildren[i] = child.gameObject;

            i++;
        }

        foreach(GameObject child in allChildren) {

            Destroy(child.gameObject);
        }
    }
}
