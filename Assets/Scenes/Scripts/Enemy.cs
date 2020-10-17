
using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startspeed = 10f;
    
    [HideInInspector]
    public float speed;

    public float health = 100;

    public int value = 50;

    public GameObject deathEffect;

    void Start() {

        speed = startspeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health<= 0)
        {
            Die();
        }
    }

    public void Slow(float amount) {

        speed = startspeed * (1f - amount);
    }

    void Die()
    {
        PlayerStats.Money += value;


        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
