using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Wizard : MonoBehaviour

{
    void Start()
    {
        Instantiate(targetPrefab);
    }
    public GameObject targetPrefab;
    public GameObject fireballPrefab;
    public float speed = 2.0f;
    private Vector3 lastMovementDirection = Vector3.right; 

    // Update is called once per frame
    void Update()
    {
        
        HandleMovement();
        HandleFireball();
    }

    void HandleMovement()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey("w"))
        {
            movement += Vector3.up;
        }
        if (Input.GetKey("s"))
        {
            movement += Vector3.down;
        }
        if (Input.GetKey("a"))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey("d"))
        {
            movement += Vector3.right;
        }

        if (movement.magnitude > 0)
        {
            movement.Normalize();
            lastMovementDirection = movement; 
            transform.position += movement * speed * Time.deltaTime;
            
            if (movement.x != 0)
            {
                transform.rotation = Quaternion.Euler(0, movement.x > 0 ? 0 : 180, 0);
            }
        }
    }

    void HandleFireball()
    {

        if (Input.GetKey("e") && !DoesFireExist())
        {        Debug.Log("hello");
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            Fireball fireballScript = fireball.GetComponent<Fireball>();
            if (fireballScript != null)
            {
                fireballScript.SetDirection(lastMovementDirection);
            }
            Destroy(fireball, 3);
        }
    }

    bool DoesFireExist()
    {
        return true; // GameObject.Find("Fireball(Clone)") != null;
    }
}
