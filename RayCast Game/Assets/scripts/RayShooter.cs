using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public float range = 100f;
    public float shootForce, upwardsForce;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = gameObject.transform.position;
        Vector3 endPos = transform.forward * 10;    
        Debug.DrawRay (startPos, endPos, Color.red, 5);
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();

        }
        
    }

    void shoot()
    {
        Vector3 targetPoint;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
           
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(1);
        }   
        Vector3 directionWithoutSpread = targetPoint - transform.position;
        GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithoutSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithoutSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().velocity = directionWithoutSpread * 3;
    }

}
