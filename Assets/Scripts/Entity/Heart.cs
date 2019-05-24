using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Entity {

    [SerializeField]
    private int LivesToAdd = 1;

    [SerializeField]
    private float TurnSpeed = 25f;

    public override void Start() { }

    public override void Update() {

        if (Data.Lives == 0)
            return;

        Rotate();
    }

    public override void Rotate() {

        if (Data.Lives == 0)
            return;

        Vector3 rotation = new Vector3(0, Time.deltaTime, 0) * TurnSpeed;
        model.transform.Rotate(rotation);
    }

    void OnTriggerEnter(Collider col) {

        if (Data.Lives == 0)
            return;

        Data.Lives += Mathf.Abs(LivesToAdd);

        GameplayViewer.Singleton.Show();

        Destroy(gameObject);
    }
}
