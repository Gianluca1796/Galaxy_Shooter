using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int powerUpID;

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if(transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                if (powerUpID == 0)
                {
                    player.TripleShotPowerUpOn();
                }
                else if (powerUpID == 1)
                {
                    player.SpeedUpPowerUpOn();
                }
                else if(powerUpID == 2)
                {
                    player.ShieldPowerUpOn();
                }
            }

            Destroy(this.gameObject);
        }
    }
}

