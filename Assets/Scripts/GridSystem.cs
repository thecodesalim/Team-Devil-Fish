using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour {
    public GameObject obj;
    private GameObject wall;
    private Camera cam;
    private Vector3 mousePos;
    public GameObject ballister;

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

        Vector3 pos = cam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, cam.nearClipPlane));

        float tempX = (Mathf.Floor (pos.x / 0.16f) * 0.16f) + 0.08f;

        float tempY = (Mathf.Floor (pos.y / 0.16f) * 0.16f) + 0.08f;
        //Instantiate (obj, new Vector3(tempX, tempY, cam.nearClipPlane), Quaternion.identity);

        //The above works perfectly the issue lies below

        if (Input.GetMouseButtonDown (0)) {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            Vector2 mousePos2D = new Vector2 (mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast (mousePos2D, Vector2.zero);

            if (hit.collider != null) {
                if (hit.collider.gameObject.tag == "Wall") {
                    Instantiate (ballister, new Vector3 (tempX, tempY, cam.nearClipPlane), Quaternion.identity);
                }
            } else {
                Instantiate (obj, new Vector3 (tempX, tempY, cam.nearClipPlane), Quaternion.identity);
            }
        }

    }
}