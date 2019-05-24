using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    #region Singelton
    public static TileManager instance;

    void Awake() {

        if(instance != null) {

            Debug.LogError("More than 1 instance of TileManager in the scene!");

            return;
        }

        instance = this;
    }
    #endregion

    public Transform TileArray;

    public List<Vector3> TileCoords { get; protected set; }

    public int ReappearAfter = 2;

    List<Transform> tiles;

	// Use this for initialization
	void Start () {

        Player.instance.RegisterOnPlayerMoveCallback(onPlayerMove);
    }

    public void GetTileCoords() {

        if(TileArray == null) {

            Debug.LogError("TileManager::getTiles() => TileArray is null, you forgot to set it in the inspector.");

            return;
        }

        lastTiles = new Queue<GameObject>();

        moves = 0;

        TileCoords = new List<Vector3>();
        tiles = new List<Transform>();

        foreach(Transform t in TileArray) {

            t.gameObject.SetActive(true);

            TileCoords.Add(t.position);
            tiles.Add(t);
        }
    }

    Queue<GameObject> lastTiles;

    int moves = 0;

    void onPlayerMove(Vector3 lastPos) {

        moves++;

        //Debug.Log("onPlayerMove");

        GameObject result = tiles.Where<Transform>(t => t.position == lastPos).ToList<Transform>()[0].gameObject;

        //Debug.Log(result.name);

        if (lastTiles == null)
            lastTiles = new Queue<GameObject>();

        result.SetActive(false);

        TileCoords.Remove(result.transform.position);

        lastTiles.Enqueue(result);

        //Debug.Log("TileManager::onPlayerMove() => moves: " + moves + ", ReappearAfter: " + ReappearAfter);

        if (moves > ReappearAfter) {

            GameObject t = lastTiles.Dequeue();

            TileCoords.Add(t.transform.position);

            t.SetActive(true);
        }

        //Debug.Log(lastTiles.Count);
    }
}
