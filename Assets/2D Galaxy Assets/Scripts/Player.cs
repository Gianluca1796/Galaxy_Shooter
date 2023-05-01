using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{

    public bool canTripleShoot = false;
    public bool isSpeedBoostActive = false;
    public bool isShieldActive = false;
    public int lives = 3;
    private int hitCount = 0;

    [SerializeField]
    private GameObject[] engines;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _trpleShootPrefab;

    [SerializeField]
    private GameObject _shieldPrefab;

    [SerializeField]
    private GameObject _shieldGameObject;

    [SerializeField]
    private float _fireReat = 0.25f;
    [SerializeField]
    private GameObject _Explosion;

    private float _canfire = 0.0f;

    [SerializeField]
    private float _speed = 5.0f;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private SpawnManager _spawnManager;

    private AudioSource laserShot;


    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(lives);
        }
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager != null)
        {
            _spawnManager.StartSpawnRoutine();
        }

        laserShot = GetComponent<AudioSource>();
        hitCount = 0;
    }
    void Update()
    {
        playerMovement();

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > _canfire)
            {
                if (canTripleShoot)
                {
                    TripleShoot();
                }
                else
                {
                    Shoot();
                }
                _canfire = Time.time + _fireReat;
            }
        }



    }

    private void Shoot()
    {
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);
        laserShot.Play();
    }

    private void TripleShoot()
    {
        Instantiate(_trpleShootPrefab, transform.position, Quaternion.identity);
        laserShot.Play();

    }
    private void playerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vericalInput = Input.GetAxis("Vertical");

        if (isSpeedBoostActive)
        {
            _speed = 15.0f;
        }
        else
        {
            _speed = 5.0f;
        }

        transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * _speed * vericalInput * Time.deltaTime);


        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {

            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 9.5)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }

    public void Damage()
    {



        if (isShieldActive)
        {
            isShieldActive = false;
            _shieldGameObject.SetActive(false);

            return;
        }

        hitCount++;
        if (hitCount == 1)
        {
            engines[0].SetActive(true);
        }
        else if (hitCount == 2)
        {
            engines[1].SetActive(true);
        }



        lives--;
        _uiManager.UpdateLives(lives);

        if (lives < 1)
        {
            Destroy(this.gameObject);
            InstantiateExplosion();
            _gameManager.isGameStarted = false;
            _uiManager.GameOver();

        }

    }
    public void TripleShotPowerUpOn()
    {
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void ShieldPowerUpOn()
    {
        isShieldActive = true;
        _shieldGameObject.SetActive(true);
    }
    public void SpeedUpPowerUpOn()
    {
        isSpeedBoostActive = true;
        StartCoroutine(SpeedUpDownCoroutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }
    public IEnumerator SpeedUpDownCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedBoostActive = false;
    }

    public void InstantiateExplosion()
    {
        Destroy(this.gameObject);
        Instantiate(_Explosion, transform.position, Quaternion.identity);
    }
}
