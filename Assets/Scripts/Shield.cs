using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public class Shield : NetworkBehaviour
{
    float deactiveTimer;
    bool active = true;
    [SerializeField] uint shieldHealth;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("added shield");
        other.gameObject.GetComponent<Health>().shieldActive = shieldHealth;
        Deactive();
    }

    private void Update()
    {
        if(!active)
            if(Time.time > deactiveTimer)
            {
                this.gameObject.GetComponentInChildren<Transform>().position = new Vector3(0, 0.5f, 0);
                active = true;
            }
    }
    private void Deactive()
    {
        this.gameObject.GetComponentInChildren<Transform>().position = new Vector3(999, 999, 999);
        deactiveTimer = Time.time + 10.0f;
        active = false;
    }
}
