using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [Space(5)]
    [Header("Generation Patform")]
    [SerializeField] private GameObject[] roadPrefabs;
    [Space(5)]
    [Header("Start Patform")]
    [SerializeField] private GameObject[] roadStart;
    [Space(5)]
    [Header("Finish Patform")]
    [SerializeField] private GameObject[] roadFinish;
    [Space(5)]
    [Header("Generation Platform")]
    [SerializeField] private int numberPlatfor; //number of road pieces in the level

    private float pointStartSpawn = -25.0f; //road generation start point
    private float tileLengthZ;

    void Start()
    {
        for (int i = 0; i < numberPlatfor; i++)
        {
            if (i == 0)
            {
                SpawnStart(0);
            }

            if (i > 0 && i < numberPlatfor - 1)
            {
                SpawnTile(Random.Range(0, roadPrefabs.Length));
            }

            if (i == numberPlatfor - 1)
            {
                SpawnFinish(0);
            }
        }
    }

    private void SpawnStart(int tileIndex)
    {
        tileLengthZ = roadStart[tileIndex].transform.localScale.z;

        GameObject nextStart = Instantiate(roadStart[tileIndex], new Vector3(0, roadStart[tileIndex].transform.position.y, pointStartSpawn + (tileLengthZ / 2)), Quaternion.identity);

        pointStartSpawn += tileLengthZ;
    }
    private void SpawnTile(int tileIndex)
    {
        tileLengthZ = roadPrefabs[tileIndex].transform.localScale.z;

        GameObject nextTile = Instantiate(roadPrefabs[tileIndex], new Vector3(0, roadPrefabs[tileIndex].transform.position.y, pointStartSpawn + (tileLengthZ / 2)), Quaternion.identity);

        pointStartSpawn += tileLengthZ;

    }

    private void SpawnFinish(int tileIndex)
    {
        tileLengthZ = roadFinish[tileIndex].transform.localScale.z;

        GameObject nextFinish = Instantiate(roadFinish[tileIndex], new Vector3(0, roadFinish[tileIndex].transform.position.y, pointStartSpawn + (tileLengthZ / 2f)), Quaternion.identity);

        pointStartSpawn += tileLengthZ;
    }

}
