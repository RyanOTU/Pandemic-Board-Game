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
    private Vector3 cursorPos;


    private void Start()
    {
        invalidLocationBox.text = "";
        tileNameTextBox.text = "";
    }
    private void Update()
    {
        cursorPos = mouseCursor.transform.position + new Vector3(0.8f, 0.5f, 0);
        tileNameTextBox.transform.position = cursorPos;

        //I attempted to get this to work but it kept throwing null reference exceptions even though I'm checking for it sooooo I gave up :)
        //if (mouseCursor.GetHoveredTile() != null) tileNameTextBox.text = mouseCursor.GetHoveredTile().locationName;

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
            invalidLocationBox.text = "";
            //Remove player from current tile and add player to target tile
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
        //Confused, the currentTile is the target location so I gotta change how that's named/checked so it's not as confusing...
        //FIXXXXXXX
        //ASAPPPPPP
        Tile targetLocation = GameObject.Find(moveToLocation).GetComponent<Tile>();
        Debug.Log(targetLocation.locationName);
        if (targetLocation != null)
        {
            for (int i = 0; i < targetLocation.GetAdjacentTiles().Length; ++i)
            {
                if (currentTile.GetAdjacentTiles()[i].locationName == targetLocation.locationName)
                {
                    return true;
                }
            }
            return false;
        }
        else return false;
    }
    public void TreatDisease()
    {
        if (IsValidLocation() && currentTile.GetDiseaseCubes() != null)
        {
            currentTile.RemoveDiseaseCube();
        }
    }
    
}
