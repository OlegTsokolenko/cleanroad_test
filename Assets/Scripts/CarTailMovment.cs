using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTailMovment : MonoBehaviour
{
    [SerializeField] private GameObject playerTruck;
    [SerializeField] private PlayerVariable _speedPlayer;
    [SerializeField] private float stopDistance;

    void Start()
    {
        playerTruck = GameObject.FindGameObjectWithTag("Player");

        _speedPlayer.valueSpeed = 0;
    }

    void FixedUpdate()
    {

        if (Vector3.Distance(transform.position, playerTruck.transform.position) > stopDistance)
        {
            transform.LookAt(playerTruck.transform);

            Quaternion targetRotation = Quaternion.LookRotation(playerTruck.transform.position - transform.position);

            transform.position += transform.forward * _speedPlayer.valueSpeed * Time.deltaTime;
        }
    }
}
