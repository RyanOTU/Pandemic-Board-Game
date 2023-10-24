using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        Camera.main.ScreenToWorldPoint(transform.position = Input.mousePosition);
    }
}
