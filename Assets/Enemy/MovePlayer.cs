using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    public NavMeshAgent enemy;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.transform.position);
    }
}
