using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPreabe;
    public Transform[] SpwanPoints;
    public void Start()
    {
        Instantiate(enemyPreabe, SpwanPoints[0].position, SpwanPoints[0].rotation);

        Instantiate(enemyPreabe, SpwanPoints[1].position, SpwanPoints[1].rotation);
    }
    public void InstantitaeEnemy()
    {
        int instiatPositionIndex = Random.Range(0, SpwanPoints.Length); 
        Instantiate(enemyPreabe, SpwanPoints[instiatPositionIndex].position, SpwanPoints[instiatPositionIndex].rotation);
    }

    
}
