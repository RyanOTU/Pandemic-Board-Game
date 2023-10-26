using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public GameObject hoveredTile;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // zero z
        transform.position = mouseWorldPos;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tile") hoveredTile = collision.gameObject;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        hoveredTile = null;
    }
}
