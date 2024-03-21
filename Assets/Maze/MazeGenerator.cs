using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{

    [SerializeField]
    MazeRoom mazeRoomPrefab;
    // Start is called before the first frame update
    [SerializeField]
    int mazeWidth;
    [SerializeField]
    int mazeDepth;
    
    MazeRoom[,] mazeGrid;
    void Start()
    {
        mazeGrid = new MazeRoom[mazeWidth, mazeDepth];

        for (int x = 0; x < mazeWidth; ++x)
        {
            for (int z = 0; z < mazeDepth; ++z)
            {
                mazeGrid[x,z] = Instantiate(mazeRoomPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }
        GenerateMaze(null, mazeGrid[0,0]);
    }


    void GenerateMaze(MazeRoom previousRoom, MazeRoom currentRoom)
    {
        currentRoom.Visit();
        ClearWalls(previousRoom, currentRoom);


        MazeRoom nextRoom;

        do
        {

        nextRoom = GetNextUnvisitedRoom(currentRoom);

        if (nextRoom != null)
        {
            GenerateMaze(currentRoom, nextRoom);
        }
        } while(nextRoom != null);
    }

    MazeRoom GetNextUnvisitedRoom(MazeRoom currentRoom)
    {
        var unvisitedRooms = GetUnvisitedRooms(currentRoom);

        return unvisitedRooms.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    IEnumerable<MazeRoom> GetUnvisitedRooms(MazeRoom currentRoom)
    {
        int x = (int)currentRoom.transform.position.x;
        int z = (int)currentRoom.transform.position.z;

        if (x + 1 < mazeWidth)
        {
            var cellToEast = mazeGrid[x + 1, z];

            if (cellToEast.isVisited == false)
            {
                yield return cellToEast;
            }
        }
        if (x - 1 >=  0)
        {
            var cellToWest = mazeGrid[x - 1, z];

            if (cellToWest.isVisited == false)
            {
                yield return cellToWest;
            }
        }
        if (z + 1 < mazeDepth)
        {
            var cellToNorth = mazeGrid[x, z + 1];

            if (cellToNorth.isVisited == false)
            {
                yield return cellToNorth;
            }
        }
        if (z - 1 >= 0)
        {
            var cellToSouth = mazeGrid[x, z - 1];

            if (cellToSouth.isVisited == false)
            {
                yield return cellToSouth;
            }
        }
    }


    void ClearWalls(MazeRoom previousRoom, MazeRoom currentRoom)
    {
        if (previousRoom == null)
        {
            return;
        }

        if (previousRoom.transform.position.x < currentRoom.transform.position.x)
        {
            previousRoom.KnockdownEast();
            currentRoom.KnockdownWest();
            return;
        }
        if (previousRoom.transform.position.x > currentRoom.transform.position.x)
        {
            previousRoom.KnockdownWest();
            currentRoom.KnockdownEast();
            return;
        }
        if (previousRoom.transform.position.z < currentRoom.transform.position.z)
        {
            previousRoom.KnockdownNorth();
            currentRoom.KnockdownSouth();
            return;
        }
        if (previousRoom.transform.position.z > currentRoom.transform.position.z)
        {
            previousRoom.KnockdownSouth();
            currentRoom.KnockdownNorth();
            return;
        }




    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
