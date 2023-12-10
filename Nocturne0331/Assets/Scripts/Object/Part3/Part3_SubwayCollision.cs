using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part3_SubwayCollision : MonoBehaviour{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.HEALTH = 0;
        }
    }
}
