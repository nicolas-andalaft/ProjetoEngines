using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletOrigin;
    public float force;
    public float interval;
    public bool autoShoot;

    private float start, end;

    private void Start()
    {
        start = Time.deltaTime;
        end = start;
    }

    private void Update()
    {
        end += Time.deltaTime;
            //print(end);

        if (end - start < interval)
            return;

        bool shoot = false;

        if (autoShoot)
            shoot = Input.GetMouseButton(0);
        else
            shoot = Input.GetMouseButtonDown(0);

        if (shoot)
        {
            end = start;
            GameObject bulletGb = Instantiate<GameObject>(bullet, bulletOrigin.position, transform.rotation);
            Rigidbody bulleRb = bulletGb.GetComponent<Rigidbody>();
            bulleRb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}
