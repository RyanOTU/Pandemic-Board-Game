using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    GameObject hoveredTile;
    void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f; // zero z
        transform.position = mouseWorldPos;
    }
    public Tile GetHoveredTile()
    {
        return hoveredTile.GetComponent<Tile>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hoveredTile = collision.gameObject;
    }
}
