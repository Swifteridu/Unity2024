using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject replaceTargetPrefab;
    private Vector3 fireballDirection;

    public void SetDirection(Vector3 direction)
    {
        Debug.Log(direction);
        fireballDirection = direction.normalized;

        float angle = Mathf.Atan2(fireballDirection.y, fireballDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Update()
    {
        transform.position += fireballDirection * Time.deltaTime * 5f; 
        
        

    }
    void OnCollisionEnter2D(Collision2D col){
        Destroy(gameObject);
        Destroy(col.gameObject);
        Instantiate(replaceTargetPrefab).transform.position = new Vector3(Random.Range(-9, 9), Random.Range(-2, 5), 0.0f);
    }
}
