using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGeneration : MonoBehaviour
{
    [Space(5)]
    [Header("Ice")]
    [SerializeField] private GameObject[] _prefabsIce;

    private GameObject _ice;

    void Start()
    {
        InvokeRepeating("CollectionSpawnIce", 0.1f, 0.1f);
    }

    private void CollectionSpawnIce()
    {
        SpawnIce(3, 0.6f, 2.0f);
        SpawnIce(-3, 0.6f, 2.0f);

        SpawnIce(-1.3f, 1.6f, 5.5f);
        SpawnIce(0, 1.6f, 5.5f);
        SpawnIce(1.3f, 1.6f, 5.5f);
    }

    private void SpawnIce(float spawnX, float spawnY, float spawnZ)
    {
        _ice = Instantiate(_prefabsIce[Random.Range(0, _prefabsIce.Length)], new Vector3(transform.position.x + spawnX, transform.position.y + spawnY, transform.position.z + spawnZ), Quaternion.identity);
    }

    private void OnEnable()
    {
        PlayerController.OnIceOver += StopSpawnIce; 
    }

    private void OnDisable()
    {
        PlayerController.OnIceOver -= StopSpawnIce; 
    }

    private void StopSpawnIce()
    {
        CancelInvoke("CollectionSpawnIce");
    }
}
