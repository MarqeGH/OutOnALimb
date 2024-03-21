using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRoom : MonoBehaviour
{
    [SerializeField]
    GameObject northWall;
    [SerializeField]
    GameObject southWall;
    [SerializeField]
    GameObject westWall;
    [SerializeField]
    GameObject eastWall;
    [SerializeField]
    GameObject unvisitedBlock;
    public bool isVisited;

    public void Visit()
    {
        isVisited = true;
        unvisitedBlock.SetActive(false);
    }

    public void KnockdownNorth()
    {
        northWall.SetActive(false);
    }
    public void KnockdownSouth()
    {
        southWall.SetActive(false);
    }
    public void KnockdownWest()
    {
        westWall.SetActive(false);
    }
    public void KnockdownEast()
    {
        eastWall.SetActive(false);
    }





}
