using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    #region Varibles
    public GameObject[] gridPrefabs;
    public int rows;
    public int cols;

    //Set to approximate width of floor X. Might be other way around
    public float roomWidth;

    //Set to approximate height of floor Z Might be other way around
    public float roomHeight;

    private Room[,] grid;

    #endregion Varibles
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GenerateMap();
    }


    public GameObject GetRandomRoomPrefab()
    {
        return gridPrefabs[Random.Range(0, gridPrefabs.Length)];
    }

    public void GenerateMap()
    {
        //Clear the grid
        grid = new Room[cols,rows];

        //For each of our grid rows
        for (int currentRow = 0;currentRow < rows; currentRow++)
        {
            for (int currentCol = 0;currentCol < cols; currentCol++)
            {
                #region Spawn Room Tile
                // Figure out the location
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0.0f, zPosition);

                // Create new Room at Appropriate Location
                GameObject tempRoomObj = Instantiate(GetRandomRoomPrefab(), newPosition, Quaternion.identity);

                // Set its parent
                tempRoomObj.transform.parent = this.transform;

                //Give it a meaningful name
                tempRoomObj.name = "Room_" + currentCol + "," + currentRow;

                //get room object
                Room tempRoom = tempRoomObj.GetComponent<Room>();

                //Save it to grid Array
                grid[currentCol,currentRow] = tempRoom;

                #endregion Spawn Room Tile


                #region Open and Close Doors
                //Open the doors - if we're in the bottom row, open the north door
                if (currentRow == 0)
                {
                    Debug.LogWarning("North Deactivated");
                }
                else if (currentRow == rows - 1)
                {
                    tempRoom.doorSouth.SetActive(false);
                    Debug.LogWarning("South Deactivated");
                }
                else
                {
                    // we are in a middle row so open both
                    tempRoom.doorNorth.SetActive(false);
                    tempRoom.doorSouth.SetActive(false);
                    Debug.LogWarning("North and South Deactivated");
                }


                if (currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                    Debug.LogWarning("East Deactivated");
                }
                else if (currentCol == cols - 1)
                {
                    tempRoom.doorWest.SetActive(false);
                    Debug.LogWarning("West Deactivated");
                }
                else
                {
                    // we are in a middle row so open both
                    tempRoom.doorEast.SetActive(false);
                    tempRoom.doorWest.SetActive(false);
                    Debug.LogWarning("East and West Deactivated");
                }

                #endregion Open and Close Doors
            }
        }
    }
}
