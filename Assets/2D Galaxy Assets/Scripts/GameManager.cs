using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameStarted = false;
    [SerializeField]
    private GameObject _playerPrefab;
    private UIManager _manager;


    private void Start()
    {
        _manager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void Update()
    {
        if (!isGameStarted)
        {
            if(Input.GetKeyUp(KeyCode.Space)) 
            {
                Instantiate(_playerPrefab,Vector3.zero, Quaternion.identity);
                isGameStarted = true;

                _manager.StartGame();
            }
        }
    }
}
