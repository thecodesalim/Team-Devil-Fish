using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour {
    public GameObject obj;
    private GameObject wall;
    private Camera cam;
    private Vector3 mousePos;

    public float moveSpeed;
    public float offset = 0.05f;
    private bool following;
    // Start is called before the first frame update
    void Start () {
        cam = Camera.main;
        following = false;
        offset += 10;
    }

    // Update is called once per frame
    void Update () {
        mousePos = Input.mousePosition;
        print (mousePos.x);
        print (mousePos.y);
        Vector3 pos = cam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, cam.nearClipPlane));
        print (pos.x);
        print (pos.y);

        float tempX = (Mathf.Floor (pos.x / 0.16f) * 0.16f) + 0.08f;
        print (tempX);
        float tempY = (Mathf.Floor (pos.y / 0.16f) * 0.16f) + 0.08f;
        print (tempY);
        //Instantiate (obj, new Vector3(tempX, tempY, cam.nearClipPlane), Quaternion.identity);

        //The above works perfectly the issue lies below

        if (Input.GetMouseButtonDown (0) && ((Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position).magnitude <= offset)) {
            if (following) {
                following = false;
            } else {
                following = true;
            }
        }
        if (following) {
            if (Input.GetMouseButtonDown (0)) {
                Instantiate (obj, new Vector3 (tempX, tempY, cam.nearClipPlane), Quaternion.identity);
            }
        }

    }
}