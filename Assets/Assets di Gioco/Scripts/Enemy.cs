﻿
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startspeed = 10f;
    
    [HideInInspector]
    public float speed;
   
    [HideInInspector]
    public bool isDead = false;

    public float startHealth = 100;
    private float health;
    public int value = 50;

    public GameObject deathEffect;

    [Header("Unity Image")]
    public Image healthBar;

    void Start() {
        speed = startspeed;
        health = startHealth;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if(health<= 0 && !isDead)
        {
            isDead = true;
            Die();
        }
    }

    public void Slow(float amount) {

        speed = startspeed * (1f - amount);
    }

    void Die()
    {
        PlayerStats.Money += value;
        isDead = true;
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

}
