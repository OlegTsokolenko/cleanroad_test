using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private GameObject _destroyEffect;
    public void ExplodeFinish()
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity);

    }
}
