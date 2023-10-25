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
        if (hoveredTile.tag == "Tile") return hoveredTile.GetComponent<Tile>();
        else return null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            hoveredTile = collision.gameObject;
        }
    }
}
