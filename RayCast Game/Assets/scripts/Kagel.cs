using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kagel : MonoBehaviour
{
    public float health = 100f;
    private float speed = 10f;
    private Transform target;
   
   
    // Start is called before the first frame update
    
    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            die();
        }
        if (!target)
        {
            target = GameObject.Find("FisrtPersonPlayer").transform;
        }
        speed += 0.5f;
        
    }

    void die() 
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                target.transform.position,
                Time.deltaTime * speed);
        }
      
    }
}
