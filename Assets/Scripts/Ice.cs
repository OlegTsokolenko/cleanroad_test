using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;
    public void ExplodeWithDelay()
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

}
