using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BensAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("jump");
        }
    }
}
