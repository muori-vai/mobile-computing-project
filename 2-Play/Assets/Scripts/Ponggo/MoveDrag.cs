using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDrag : MonoBehaviour {

    public string draggingTag;
    public Camera cam;

    private Vector3 dis;
    private float posX;
    private float posY;

    private bool touched = false;
    private bool dragging = false;

    private Transform toDrag;
    private Rigidbody2D toDragRigidbody;
    private Vector3 previousPosition;

    void FixedUpdate () {

        if (Input.touchCount != 1) //se non stiamo toccando lo schermo
        {
            dragging = false;
            touched = false;
            return;
        }

        Touch touch = Input.touches[0]; //prendiamo il primo touch input
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began) {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out hit) && hit.collider.tag == "Player") { //se il nostro "ray" ha colpito un giocatore, cioè se lo stiamo toccando
                toDrag = hit.transform;
                previousPosition = toDrag.position;
                toDragRigidbody = toDrag.GetComponent<Rigidbody2D>();

                dis = cam.WorldToScreenPoint(previousPosition);
                posX = Input.GetTouch(0).position.x - dis.x;

                touched = true;
            }
        }

        if (touched && touch.phase == TouchPhase.Moved) {
            dragging = true;

            float posXNow = Input.GetTouch(0).position.x - posX;
            Vector3 curPos = new Vector3(posXNow, dis.y, dis.z);

            Vector3 worldPos = cam.ScreenToWorldPoint(curPos) - previousPosition;
            worldPos = new Vector3(worldPos.x, worldPos.y, 0.0f);

            toDragRigidbody.velocity = worldPos / (Time.deltaTime * 10);

            previousPosition = toDrag.position;
        }

        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)) {
            dragging = false;
            touched = false;
            previousPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
        
    }
}