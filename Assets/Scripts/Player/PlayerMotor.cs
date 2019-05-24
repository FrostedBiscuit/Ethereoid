using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    Action<Vector3> onPlayerMoveCallback;

    //Fields
    [SerializeField]
    private Vector3 Rotation = Vector3.zero;

    [SerializeField]
    private GameObject model = null;

    [SerializeField]
    private float Smoothing = 5f;
    [SerializeField]
    private float RotationSpeed = 5f;

    public int StartX = 0;
    public int StartZ = 0;

    int x;
    int z;

    float t = 0f;

    // Update is called once per frame
    void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.UpArrow)) {

            MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {

            MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {

            MoveRight();
        }

        t += Time.deltaTime * Smoothing;

        transform.position = Vector3.Lerp(transform.position, new Vector3(x, 0, z), Mathf.PingPong(t, 1f));

        Rotate();
    }

    public void ResetPosition() {

        x = StartX;
        z = StartZ;

        transform.position = new Vector3(x, 0, z);
    }

    public void MoveUp()
    {
        //Debug.Log("PlayerMotor::MoveUp()");

        if (TileManager.instance.TileCoords.Contains(transform.position + Vector3.forward) == false)
            return;

        if (onPlayerMoveCallback != null)
            onPlayerMoveCallback(transform.position);

        t = 0f;
        //Rotate();
        z++;
    }

    public void MoveDown()
    {
        //Debug.Log("PlayerMotor::MoveDown()");

        if (TileManager.instance.TileCoords.Contains(transform.position - Vector3.forward) == false)
            return;

        if (onPlayerMoveCallback != null)
            onPlayerMoveCallback(transform.position);

        t = 0f;
        //Rotate();
        z--;
    }

    public void MoveLeft()
    {
        //Debug.Log("PlayerMotor::MoveLeft()");

        if (TileManager.instance.TileCoords.Contains(transform.position - Vector3.right) == false)
            return;

        if (onPlayerMoveCallback != null)
            onPlayerMoveCallback(transform.position);

        t = 0f;
        //Rotate();
        x--;
    }

    public void MoveRight()
    {
        //Debug.Log("PlayerMotor::MoveRight()");

        if (TileManager.instance.TileCoords.Contains(transform.position + Vector3.right) == false)
            return;

        if (onPlayerMoveCallback != null)
            onPlayerMoveCallback(transform.position);

        t = 0f;
        //Rotate();
        x++;
    }

    public void RegisterOnPlayerMoveCallback(Action<Vector3> cb) {

        onPlayerMoveCallback += cb;
    }

    public void UnregisterOnPlayerMoveCallback(Action<Vector3> cb) {

        onPlayerMoveCallback -= cb;
    }

    private void Rotate()
    {
        if (Data.Lives == 0)
            return;

        //float randomX = Random.Range(20f, 60f);
        //float randomY = Random.Range(20f, 60f);
        //float randomZ = Random.Range(20f, 60f);

        Vector3 rotation = Rotation * RotationSpeed * Time.deltaTime;
        model.transform.Rotate(rotation);
    }
}
