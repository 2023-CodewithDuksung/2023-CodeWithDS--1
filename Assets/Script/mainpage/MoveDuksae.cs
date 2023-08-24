using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuksae : MonoBehaviour
{
    Vector2 MousePosition;
    Camera Dcamera;
    // Start is called before the first frame update
    void Start()
    {
        Dcamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Dcamera.ScreenToWorldPoint(MousePosition);
            MousePosition.x = MousePosition.x -1.5f;
            MousePosition.y = MousePosition.y -1.5f;
            transform.position = MousePosition;

        }
    }
}
