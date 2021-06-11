using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _spead;

    private void Update()
    {
        transform.Translate(Vector3.left * _spead * Time.deltaTime);
    }
}
