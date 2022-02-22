using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    [SerializeField] private float tilifeTime;
    void Start()
    {
        if (this.gameObject != null)
        {
            Destroy(gameObject, tilifeTime);
        }
    }
}
