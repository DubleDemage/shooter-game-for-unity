using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Camera FPCamera;
    public float range = 100f;
    [SerializeField] float damage = 20f;

    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;

    AudioClip silencer;
    AudioSource audioSource;

    public Ammo ammoSlot;

    public AmmoType ammoType;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
            {
                Shoot();
                MuzzleFlashEffect();
                audioSource.Play();
                ammoSlot.ReduceCurrentAmmo(ammoType);
            }

        }
    }

    private void MuzzleFlashEffect()
    {
        muzzleFlash.Play();
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        } 
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
