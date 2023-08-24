using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDuksae : MonoBehaviour
{
    Vector2 MousePosition;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = camera.ScreenToWorldPoint(MousePosition);

            transform.position = MousePosition;

        }
    }
}
