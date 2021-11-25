using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] List<GameObject> plates = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < (plates.Count - 1); i += 4)
        {
            int index = Random.Range(i, i + 4);
            plates[index].GetComponent<Collider>().enabled = false;
            print(plates[index]);
        }
    }
}

