using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform firePoint; // The position from which the bullet will be fired
    public float bulletSpeed = 10f; // Speed of the bullet
    public float bulletLifetime = 2f; // Time until the bullet is destroyed after being fired
    public int maxAmmo = 30;
    public int currentAmmo = -1;
    public float reloadTime = 2f;
    private bool isReloading = false;
    // Update is called once per frame

    private void Start()
    {
        if (isReloading)
            return;
        if (currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }
    }
    void Update()
    {
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        // Check if the player presses the fire button (for example, the space key)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire(); // Call the Fire method
        }

    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading....");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Fire()
    {

        currentAmmo--;
        // Instantiate a new bullet object at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Access the Rigidbody component of the bullet object
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Check if the Rigidbody component exists
        if (rb != null)
        {
            // Add force to the bullet in the direction of its forward vector (from firePoint)
            rb.AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody component!");
        }

        // Destroy the bullet after bulletLifetime seconds
        Destroy(bullet, bulletLifetime);
    }
}
