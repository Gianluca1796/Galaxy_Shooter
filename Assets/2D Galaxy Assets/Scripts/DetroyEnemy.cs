using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyEnemy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3);
    }

}
