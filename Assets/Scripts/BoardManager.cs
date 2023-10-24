using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class BoardManager : MonoBehaviour
{
    [SerializeField] Tile[] gameTiles;
    [SerializeField] Player[] players;
    [SerializeField] TMP_InputField locationInputBox;
    [SerializeField] TextMeshProUGUI invalidLocationBox;
    [SerializeField] TextMeshProUGUI tileNameTextBox;
    [SerializeField] MouseCursor mouseCursor;
    [SerializeField] Camera mainCamera;
    private Tile currentTile;
    private Tile currentHoveredTile;
    private string moveToLocation;
    private Vector3 cursorTextBoxPos;


    private void Start()
    {
        
    }
    private void Update()
    {
        cursorTextBoxPos = new Vector3(Input.mousePosition.x + 3, Input.mousePosition.y + 5, Input.mousePosition.z);
        tileNameTextBox.transform.position = mainCamera.GetComponent<Camera>().ScreenToViewportPoint(cursorTextBoxPos); //+ new Vector3(tileNameTextBox.transform.localScale.x / 2, 0, 0);
        //tileNameTextBox.text = "GOOB";//currentHoveredTile.name;
        moveToLocation = locationInputBox.GetComponent<TMP_InputField>().text;
        if (IsValidLocation()) currentTile = GameObject.Find(moveToLocation).GetComponent<Tile>();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MoveToTile();
        }
    }
    public void MoveToTile()
    {
        GameObject tile;
        if (IsValidLocation())
        {
            //invalidLocationBox.text = "";
            tile = GameObject.Find(moveToLocation);
            players[0].transform.position = tile.transform.position + new Vector3(0, (tile.transform.localScale.y / 2), 0);
        }
        else
        {
            invalidLocationBox.text = "Invalid Location!";
        }
    }
    public bool IsValidLocation()
    {
        if (GameObject.Find(moveToLocation)) return true;
        else return false;
    }
    public void TreatDisease()
    {
        if (IsValidLocation() && currentTile.GetDiseaseCubes() != null)
        {
            currentTile.RemoveDiseaseCube();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            currentHoveredTile = collision.gameObject.GetComponent<Tile>();
        }
    }
}
