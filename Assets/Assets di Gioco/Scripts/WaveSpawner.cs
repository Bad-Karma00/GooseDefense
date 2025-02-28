﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 0;
    public int livelloCorrente;

    public Text waveCountdownText;
    public GameManager gamemanager;

     void Start()
    {
        EnemiesAlive = 0;
        PlayerPrefs.SetInt("livelloCorrente", livelloCorrente);

    }

    void Update()
    {
        if (EnemiesAlive>0) {
            return;
        }
        if (PlayerStats.Lives == 0)
        {
            gamemanager.EndGame();
            this.enabled = false;
            return;
        }
        else if (waveIndex >= waves.Length && EnemiesAlive <= 0)
        {
            if (PlayerStats.Lives <= 0)
            {
                return;
            }
          
            if (PlayerStats.Lives > 0)
            {
                PlayerStats.Rounds++;
                gamemanager.WinLevel();
                this.enabled = false;
                return;
            }

        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = "Next Wave in:\n" + string.Format("{0:00.00}", countdown);
    }
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        PlayerStats.Rounds++;
        EnemiesAlive = wave.count * wave.enemy.Length;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveIndex++;

    }
    void SpawnEnemy(GameObject[] enemy)
    {
        for (int j = 0; j < enemy.Length; j++)
        {
            Instantiate(enemy[j], spawnPoint.position, spawnPoint.rotation);
        }
    }
}
