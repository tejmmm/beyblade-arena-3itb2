using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 5;
    float x = 0;
    float z = 0;
    float toBuffDestroy = 4;

    [SerializeField] float maxX = 1;
    [SerializeField] float maxZ = 1;
    [SerializeField] GameObject[] buffy;
    [SerializeField] private GameObject hrac;

    GameObject buff;

    private void Start()
    {
        StartCoroutine(Timer());
    }
    void SpawnBuff()
    {
        x = Random.Range(-maxX, maxX);
        z = Random.Range(-maxZ, maxZ);
        
        buff = Instantiate(buffy[Random.Range(0, buffy.Length)], new Vector3(x, 0.3f, z), Quaternion.identity);
        Destroy(buff, toBuffDestroy);
    }
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnBuff();
        }
    }
}
