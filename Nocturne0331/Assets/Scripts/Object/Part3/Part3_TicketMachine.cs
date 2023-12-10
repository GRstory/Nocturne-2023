using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part3_TicketMachine : MonoBehaviour
{
    public GameObject ledObject;
    public Material mat1;
    public Material mat2;
    private void OnCollisionEnter(Collision other) {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink(){
        for(int i = 0; i < 10; i++){
            if(i % 2 == 0){
                ledObject.GetComponent<MeshRenderer>().material = mat1;
            }
            else{
                ledObject.GetComponent<MeshRenderer>().material = mat2;
            }
            yield return new WaitForSeconds(5f / 10);
        }
    }
}
