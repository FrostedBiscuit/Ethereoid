using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour {

    [SerializeField]
    BaseViewer mainMenuViewer = null;

    [SerializeField]
    private GameObject EntityPoolObj;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private LayerMask UIMask;
    [SerializeField]
    private LayerMask GameplayMask;

    public int round = 1;

    void Awake() {

        CryptoStats.Singleton.UpdateEtherPrice();
    }
    
    public void Start()
    {
        Player.instance.gameObject.SetActive(false);

        if (EntityPoolObj != null)
            EntityPoolObj.SetActive(false);

        Data.Lives = 0;

        GameplayViewer.Singleton.Hide();
        EndscreenViewer.Singelton.Hide();
        mainMenuViewer.Show();

        EntityManager.Singletone.SetSpawning(false, this.name);
        EntityManager.Singletone.EndProjectileSpawningLoop();
        EntityManager.Singletone.EndHeartSpawningLoop();

        // TODO: get coords only when needed!!
        TileManager.instance.GetTileCoords();

        camera = Camera.main;

        camera.cullingMask = UIMask;
    }

    public void Update() {

        if (Data.Lives == 0) {
            EntityManager.Singletone.EndProjectileSpawningLoop();
            EntityManager.Singletone.EndHeartSpawningLoop();
        }
    }

    public void PlayGame() 
    {
        TileManager.instance.GetTileCoords();

        CryptoStats.Singleton.UpdateEtherPrice();

        mainMenuViewer.Hide();
        GameplayViewer.Singleton.Show();
        EndscreenViewer.Singelton.Hide();
        camera.cullingMask = GameplayMask;

        EntityManager.Singletone.SetSpawning(true, this.name);
        EntityManager.Singletone.StartProjectileSpawningLoop();
        EntityManager.Singletone.StartHeartSpawningLoop();

        EntityPool.instance.DestroyAllEntities();

        Debug.Log("Calling Player");

        if (EntityPoolObj != null)
            EntityPoolObj.SetActive(true);

        Player.instance.gameObject.SetActive(true);
        Player.instance.Start();
    }
 
    IEnumerator GameLoop()
    {

        yield return null;
    }
}
