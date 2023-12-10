using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2_DoorLocker : MonoBehaviour
{
    public GameObject closedDoorL;
    public GameObject closedDoorR;
    public GameObject openedDoorL;
    public GameObject openedDoorR;
    public GameObject lightOBJ;
    public Material beforeMaterial;
    public Material newMaterial;
    public GameObject key_Object;
    private string key_Name;
    private bool openflag = false;
    private bool flage = true;
    private void Start() 
    {
        key_Name = key_Object.name;
        Renderer renderer = lightOBJ.GetComponent<Renderer>();
        if (renderer != null && newMaterial != null)
        {
            renderer.material = beforeMaterial; 
        }
        openedDoorL.SetActive(false);
        openedDoorR.SetActive(false);
    }


    // Update is called once per frame
    private void Update()
    {
        if(openflag == true&&flage == true)
        {
            flage = false;

            closedDoorL.SetActive(false);
            closedDoorR.SetActive(false);
            openedDoorL.SetActive(true);
            openedDoorR.SetActive(true);
            ChangeMaterial();
        }

    }
    public void ChangeMaterial()
    {
        Renderer renderer = lightOBJ.GetComponent<Renderer>();
        if (renderer != null && newMaterial != null)
        {
            renderer.material = newMaterial; 
        }
    }

    public void Interaction()
    {
        if(GameManager.Instance.ITEMLIST.Contains(key_Name))
        {
            openflag = true;
        }
    }

}
