using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Entity {

    [SerializeField]
    private int Value = 1;

    [SerializeField]
    private float TurnSpeed = 25f;

    public override void Update() {

        if (Data.Lives > 0)
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

        Data.Score += Value;

        GameplayViewer.Singleton.Show();

        Destroy(gameObject);
    }
}
