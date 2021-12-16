using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "floor")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "kagel")
        {
            other.GetComponent<Kagel>().takeDamage(damage);
        }
    }
}
