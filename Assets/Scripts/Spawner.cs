using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject crystal;
    [SerializeField] float radius = 200;

    void Start()
    {
        GameObject buf1 = Instantiate(crystal);
        float x = Random.Range(-radius, radius);
        float z = Random.Range(-radius, radius);
        buf1.transform.position = transform.position + new Vector3(x, 0, z);
    }

    float timer = 0;
    float cooldown = 70;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            timer = 0;
            GameObject buf = Instantiate(crystal);
            float x = Random.Range(-radius, radius);
            float z = Random.Range(-radius, radius);
            buf.transform.position = transform.position + new Vector3(x, 1, z);
        }
    }
}