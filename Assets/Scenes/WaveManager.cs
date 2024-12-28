using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPositionsHolder;
    [SerializeField] private GameObject enemyToSpawn;

    void Start()
    {
        foreach(Transform point in spawnPositionsHolder.transform){
            //Instantiate(enemyToSpawn, );
        }
    }

}
