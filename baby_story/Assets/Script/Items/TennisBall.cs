﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : MonoBehaviour
{
    public float velX;
    public float velZ;

    public float lifetime;
    public int maxHits;
    public int maxRebounds;
    // Start is called before the first frame update
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(velX, 0, velZ) * rb.mass, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Wall")
        {
            if (maxRebounds > 0 && --maxRebounds == 0) Destroy(gameObject);
        }
        else if (collision.collider.gameObject.tag == "Wall" && maxHits > 0)
        {
            if (maxHits > 0 && --maxHits == 0) Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Quaternion.Euler(0, 180, 0) * rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
