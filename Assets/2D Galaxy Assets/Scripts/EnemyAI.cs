using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;
    //[SerializeField]
    //private GameObject _enemy;
    [SerializeField]
    private GameObject _enemyExplosion;




    void Start()
    {
      
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        RespawnEnemy();
    }


    private void RespawnEnemy()
    {
        if (transform.position.y < -6.07f)
        {
            float posX = Random.Range(-8f, 8f);
            transform.position = new Vector3(posX, 5.92f, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            Instantiate(_enemyExplosion, this.transform.position, Quaternion.identity);
            Destroy(_enemyExplosion, 5);
            Destroy(this.gameObject);
        }
        else if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
                //player.InstantiateExplosion();
                Instantiate(_enemyExplosion, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
