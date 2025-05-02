using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject toSpawn;
    public bool onStart;
    public bool onTime;
    public float SpawnTime;

    public bool activated;

    private GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        if (activated)
        {
            if (onStart)
            {
                Spawn();
            }
            if (onTime)
            {
                StartCoroutine(SpawnTimer(SpawnTime));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallBack()
    {
        spawned.transform.localPosition = new Vector3(0, 0, 0);
    }

    public IEnumerator SpawnTimer(float time)
    {
        yield return new WaitForSeconds(time);

        Spawn();

        StartCoroutine(SpawnTimer(SpawnTime));
    }

    public void Spawn()
    {
        spawned = Instantiate(toSpawn, this.transform.position, toSpawn.transform.rotation, this.transform);
        spawned.GetComponent<SpawnedEnemy>().spawner = this;
    }

    public void StartSpawnerCoroutine()
    {
        StartCoroutine(SpawnTimer(SpawnTime));
    }

    public void StopSpawnerCoroutine()
    {
        StopAllCoroutines();
    }
}
