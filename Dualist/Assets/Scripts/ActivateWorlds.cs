using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWorlds : MonoBehaviour
{
    public GameObject realWorldObject;
    public GameObject spiritWorldObject;

    public float currentRealWorldTime = 0f;
    public float currentSpiritWorldTime = 0f;
    float startTime = 6f;
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
        if (currentRealWorldTime < -6f)
        {
            currentRealWorldTime = 6f;
        }
        else if (currentRealWorldTime <= 0)
        {
            realWorldObject.SetActive(false);
            spiritWorldObject.SetActive(true);
        }
        else if (currentRealWorldTime > 0)
        {
            realWorldObject.SetActive(true);
            spiritWorldObject.SetActive(false);
        }

    }
}
