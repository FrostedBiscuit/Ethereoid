using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInput : MonoBehaviour, IDragHandler, IEndDragHandler {

    public PlayerMotor playerMotor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrag(PointerEventData ped) { }

    public void OnEndDrag(PointerEventData ped) {

        if(Data.Lives == 0)
            return;

        Vector3 dragDir = (ped.position - ped.pressPosition).normalized;

        //Debug.Log(dragDir);

        float posX = Mathf.Abs(dragDir.x);
        float posY = Mathf.Abs(dragDir.y);

        if(posX > posY) {

            if (dragDir.x > 0) { playerMotor.MoveRight(); }
            else { playerMotor.MoveLeft(); }
        }
        else if(ViewManager.instance.Pos != View.SIDE) {

            if(dragDir.y > 0) { playerMotor.MoveUp(); }
            else { playerMotor.MoveDown(); }
        }
    }
}
