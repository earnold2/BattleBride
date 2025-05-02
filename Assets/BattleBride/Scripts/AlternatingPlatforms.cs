using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingPlatforms : MonoBehaviour
{
    public List<PlatformToggler> platforms;
    public float speed;
    private int currentPlatform;

    public bool startOnStart;
    public int movePattern;
    private IEnumerator co;

    // Start is called before the first frame update
    public void Start()
    {
        if(movePattern == 1)
        {
            if (platforms.Count < 3)
            {
                Debug.Log(this.gameObject.name + " doesn't have enough platforms in it");
            }
            else
            {
                //Set currentPlatform
                currentPlatform = 0;

                //first 2 bools are true
                platforms[0].TurnOn();
                platforms[1].TurnOn();

                //all others start false
                for (int i = 2; i < platforms.Count; i++)
                {
                    platforms[i].TurnOff();
                }

                //StartToggling
                if (startOnStart)
                {
                    StartCoroutine(StartAlternating1());
                }
            }
        }

        if(movePattern == 2)
        {
            if (platforms.Count < 3)
            {
                Debug.Log(this.gameObject.name + " doesn't have enough platforms in it");
            }
            else
            {
                //Set currentPlatform
                currentPlatform = 0;

                //all others start false
                for (int i = 0; i < platforms.Count; i++)
                {
                    if(i % 2 == 0)
                    {
                        platforms[i].TurnOff();
                    }
                    else
                    {
                        platforms[i].TurnOn();
                    }
                }

                //StartToggling
                if (startOnStart)
                {
                    StartCoroutine(StartAlternating2());
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Alternate1()
    {
        if (currentPlatform == platforms.Count - 1) //If current is the last platform
        {
            currentPlatform = 0;

            platforms[currentPlatform + 1].TurnOn();
            platforms[platforms.Count - 1].TurnOff();
        }
        else if (currentPlatform == platforms.Count - 2) //If current is the second to last platform
        {
            currentPlatform++;

            platforms[0].TurnOn();
            platforms[currentPlatform - 1].TurnOff();

        }
        else
        {
            currentPlatform++;

            platforms[currentPlatform + 1].TurnOn();
            platforms[currentPlatform - 1].TurnOff();
        }
    }

    public void Alternate2()
    {
        if (currentPlatform == 0)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (i % 2 == 0)
                {
                    platforms[i].TurnOn();
                }
                else
                {
                    platforms[i].TurnOff();
                }
            }

            currentPlatform = 1;
        }
        else
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (i % 2 == 0)
                {
                    platforms[i].TurnOff();
                }
                else
                {
                    platforms[i].TurnOn();
                }
            }

            currentPlatform = 0;
        }
    }

    public IEnumerator StartAlternating1()
    {
        yield return new WaitForSeconds(speed);

        Alternate1();

        StartCoroutine(StartAlternating1());
    }

    public IEnumerator StartAlternating2()
    {
        yield return new WaitForSeconds(speed);

        Alternate2();

        StartCoroutine(StartAlternating2());
    }

    public void SetAllActive()
    {
        StopAllCoroutines();

        for (int i = 0; i < platforms.Count; i++)
        {
            platforms[i].TurnOn();
        }
    }

    public void SetAllInactive()
    {
        StopAllCoroutines();

        for (int i = 0; i < platforms.Count; i++)
        {
            platforms[i].TurnOff();
        }
    }
}
