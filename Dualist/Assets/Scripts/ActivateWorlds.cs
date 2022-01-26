using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWorlds : MonoBehaviour
{
    public GameObject realWorldObject;
    public GameObject spiritWorldObject;
    public float realWorldIsActive;
    public bool realWorldOn = true;

    public float currentRealWorldTime = 0f;
    public float currentSpiritWorldTime = 0f;
    public float startTime = 0f;
    public float resetTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentRealWorldTime = startTime;
        currentSpiritWorldTime = startTime;
        realWorldOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (realWorldOn)
        {
            realWorldIsActive = 1; //Real World is Inactive
            realWorldObject.SetActive(true);
            spiritWorldObject.SetActive(false);
        }
        else
        {
            realWorldIsActive = 0; //Real World is Active
            realWorldObject.SetActive(false);
            spiritWorldObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            realWorldOn = !realWorldOn;
        }

    }
}
