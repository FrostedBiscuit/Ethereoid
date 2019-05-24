using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

    [SerializeField]
    private int Damage = 1;

    [SerializeField]
    private float TurnSpeed = 25f;

    public override void Update() {

        if(Data.Lives > 0)
            base.Update();

        Rotate();
    }

    public override void Rotate() {

        if (Data.Lives == 0)
            return;

        Vector3 rotation = new Vector3(1f, 1f, 1f) * Time.deltaTime * TurnSpeed;
        model.transform.Rotate(rotation);
    }

    void OnTriggerEnter(Collider col) {

        Data.Lives = Data.Lives >= Damage ? Data.Lives - Damage : 0;

        GameplayViewer.Singleton.Show();
        /*
        if (Data.Lives == 0)
            EndscreenViewer.Singelton.Show();
        */
        Destroy(gameObject);
    }
}