using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public bool canTripleShoot = false;
    public bool isSpeedBoostActive = false;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _trpleShootPrefab;
    [SerializeField]
    private float _fireReat = 0.25f;

    private float _canfire = 0.0f;




    [SerializeField]
    private float _speed = 5.0f;


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
    }

    private void TripleShoot()
    {
        Instantiate(_trpleShootPrefab, transform.position, Quaternion.identity); 
    }
    private void playerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float vericalInput = Input.GetAxis("Vertical");

        if(isSpeedBoostActive)
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

    public void TripleShotPowerUpOn()
    {
        canTripleShoot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
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
}
