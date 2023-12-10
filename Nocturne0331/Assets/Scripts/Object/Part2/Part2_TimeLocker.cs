using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part2_TimeLocker : MonoBehaviour
{
    public GameObject closedDoor;
    public List<GameObject> LEDS = new List<GameObject>();
    private List<Renderer> renderers = new List<Renderer>();
    public Material redLED;
    public Material blueLED;
    private int lightIndex = 0;
    private bool open_Flag = false;
    private bool flag_0 = true;
    void Start()
    {
        for (int i = 0; i < LEDS.Count; i++)
        {
            Renderer renderer = LEDS[i].GetComponent<Renderer>();
            renderers.Add(renderer);

            if (renderer != null && redLED != null)
            {
                renderers[i].material = redLED;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(open_Flag == true && flag_0 == true)
        {
            flag_0 = false;
            closedDoor.SetActive(false);
            TimerStart();
        }

    }

    private void TimerStart()
    {   
        
        for(int i = 0; i < LEDS.Count; i++)
        {
            renderers[i].material = blueLED; 
        }
        Invoke("Process_0",1);
    }
    private void Process_0()
    {
        
        renderers[lightIndex].material = redLED;
        lightIndex ++;
        if(lightIndex < renderers.Count) 
        {
            Invoke("Process_0", 1);
        }
        if(lightIndex == renderers.Count)
        {
            open_Flag = false;
            flag_0 = true;
            lightIndex = 0;
            closedDoor.SetActive(true);
        }
        
    }

    public void Interaction()
    {
        open_Flag = true;
    }




}
