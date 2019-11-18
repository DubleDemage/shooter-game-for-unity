using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Camera FPCamera;
    public float range = 100f;
    public float damage = 30f;
    public ParticleSystem muzzleFlash;

 
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayMuzzleFlash();
            Shoot();
        }
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void Shoot()
    {
        ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hit this thing: " + hit.transform.name);
            //add hit effects to the weapon
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
