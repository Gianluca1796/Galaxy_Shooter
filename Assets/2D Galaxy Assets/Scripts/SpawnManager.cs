using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerUps;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PoWerupSpawnRoutine());

    }

    public void StartSpawnRoutine()
    {

        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PoWerupSpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {

        while (_gameManager.isGameStarted == true)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-8f, 8f), 5.92f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }

    }

    IEnumerator PoWerupSpawnRoutine()
    {

        while (_gameManager.isGameStarted == true)
        {
            int randomPowerup = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomPowerup], new Vector3(Random.Range(-8f, 8f), 5.92f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);

        }

    }
}
