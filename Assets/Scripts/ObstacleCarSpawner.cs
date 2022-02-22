using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] itemToSpread;
    [SerializeField] private float itemXSpread;
    [SerializeField] private float itemZSpread;

    void Start()
    {
        SpreadItem();
    }

    void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), transform.position.y, Random.Range(-itemZSpread, itemZSpread)) + transform.position;

        GameObject clone = Instantiate(itemToSpread[Random.Range(0, itemToSpread.Length)], randPosition, Quaternion.Euler(0, Random.Range(0, 90), 0));
    }
}
