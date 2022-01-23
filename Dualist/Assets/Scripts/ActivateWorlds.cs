using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWorlds : MonoBehaviour
{
    public GameObject realWorldObject;
    public GameObject spiritWorldObject;
    public float realWorldIsActive;

    public float currentRealWorldTime = 0f;
    public float currentSpiritWorldTime = 0f;
    public float startTime = 0f;
    public float resetTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        currentRealWorldTime = startTime;
        currentSpiritWorldTime = startTime;
}

    // Update is called once per frame
    void Update()
    {
        currentRealWorldTime -= Time.deltaTime;
        if (currentRealWorldTime < resetTime)
        {
            currentRealWorldTime = startTime;
        }
        else if (currentRealWorldTime <= 0)
        {
            realWorldIsActive = 0; //Reeal World is Inactive
            realWorldObject.SetActive(false);
            spiritWorldObject.SetActive(true);
        }
        else if (currentRealWorldTime > 0)
        {
            realWorldIsActive = 1; //Real World is Active
            realWorldObject.SetActive(true);
            spiritWorldObject.SetActive(false);
        }

    }
}
