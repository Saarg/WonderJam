using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour {

    public Bonus currentBonus;

    public Bonus healBonusPrefab;
    [Range(0f, 100)]
    public int healBonusSpawnChance = 50;
    public Bonus boostBonusPrefab;
    [Range(0f, 100)]
    public int boostBonusSpawnChance = 50;
    public Bonus pointBonusPrefab;
    [Range(0f, 100)]
    public int pointBonusSpawnChance = 50;

    float timeBetweenSpawn = 15f;
    float currentTime = 0f;

	
	// Update is called once per frame
	void Update () {
		if(currentBonus == null)
        {
            if(currentTime <= 0f)
            {
                SpawnRandomBonus();
                currentTime = timeBetweenSpawn;
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }
	}

    void SpawnRandomBonus()
    {
        int value = Random.Range(0, pointBonusSpawnChance+ healBonusSpawnChance+ boostBonusSpawnChance);
        if(value <= pointBonusSpawnChance)
        {
            currentBonus = (Bonus)Instantiate(pointBonusPrefab, transform.position, transform.rotation);
        }else if (value <= pointBonusSpawnChance+boostBonusSpawnChance)
        {
            currentBonus = (Bonus)Instantiate(healBonusPrefab, transform.position, transform.rotation);
        }else
        {
            currentBonus = (Bonus)Instantiate(boostBonusPrefab, transform.position, transform.rotation);
        }
    }
}
