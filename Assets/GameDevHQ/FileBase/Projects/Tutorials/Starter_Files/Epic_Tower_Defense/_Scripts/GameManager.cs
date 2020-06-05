using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _numOfWaves;
    [SerializeField]
    private int _enemiesWaveMultiplier = 10;
    [SerializeField]
    private int _actualWave = 1;
    [SerializeField]
    private float _delayBetweenWaves = 3f;
    [SerializeField]
    private int _numOfEnemies;
    [SerializeField]
    private float _minDelayBetweenEnemies = 1f;
    [SerializeField]
    private float _maxDelayBetweenEnemies = 2f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    void SpawnEnemy()
    {
        GameObject enemy = SpawnManager.Instance.RequestEnemy();
        enemy.transform.position = SpawnManager.Instance.startPoint.transform.position;
    }

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            int totalEnemies = _actualWave * _enemiesWaveMultiplier;

            if (_numOfEnemies < totalEnemies)
            {
                SpawnEnemy();
                _numOfEnemies++;
                yield return new WaitForSeconds(Random.Range(_minDelayBetweenEnemies, _maxDelayBetweenEnemies));
            }
            else
            {
                _actualWave++;
                _numOfEnemies = 0;
                yield return new WaitForSeconds(_delayBetweenWaves);
            }
        }
    }


   


}
