using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public bool rotate = true;
    public float speed = 4f;
    public Vector3 rotation = Vector3.zero;


    public void Update()
    {
        if (!rotate)
            return;

        var rot = rotation * speed * Time.fixedDeltaTime;

        transform.Rotate(rot);
    }
}
