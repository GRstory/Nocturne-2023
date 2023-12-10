using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    Vector3 dir;

    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }

    public void resetAnim()
    {
        transform.position = new Vector3(0, 4.85f, 0) ;
        dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), -1).normalized;
    }
}
