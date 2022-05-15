using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Move : MonoBehaviour
{
    public bool played;

    public Vector3 actualPos;
    public GameObject board;
    private void Start()
    {
        actualPos = transform.position;
        played = false;
    }

    void OnMouseDrag()
    {
       // transform.position = GetMousePos();
       gameObject.transform.position = GetMousePos();
    }

      private void OnMouseUp()
    {
      if (GetMousePos().x < -4 || GetMousePos().x > 4 || GetMousePos().y < -4 || GetMousePos().y > 4)
        {
            gameObject.transform.position = actualPos;
        }
        else
        {

        }
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1;
        return mousePos;
    }
}
