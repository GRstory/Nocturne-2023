using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Part2_NextMap : MonoBehaviour
{
    public GameObject fadeout;
    private void OnCollisionEnter(Collision other)
    {
        fadeout.SetActive(true);
        Invoke("Part3", 3);
    }

    private void Part3()
    {
        GameManager.Instance.BGM_INDEX = 7;
        GameManager.Instance.BGM_INDEX_B = 7;
        SceneManager.LoadScene("Part3");
    }
}
