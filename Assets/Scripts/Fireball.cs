using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 fireballDirection;

    public void SetDirection(Vector3 direction)
    {
        fireballDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += fireballDirection * Time.deltaTime * 5f;
    }
}
