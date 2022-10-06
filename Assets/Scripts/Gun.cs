using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private GameObject bulletPrefab;
    [SerializeField] private int shootSpeed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Shoot();
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(Resources.Load("Prefabs/Bullet") as GameObject);
        bullet.transform.position = transform.position + transform.forward;
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootSpeed);
    }
}
