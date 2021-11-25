using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNPC : MonoBehaviour
{
    bool startnpc = false;
    [SerializeField] GameObject startNPC;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && startnpc == true)
        {

            startnpc = false;
            startNPC.SetActive(false);
            GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.tag == "Player" && startnpc == false)
            {

                    startnpc = true;
                    startNPC.SetActive(true);

            }




        //if (other.tag == "Player")
        //{
        //    if (startnpc == false)
        //    {
        //        startnpc = true;
        //        startNPC.SetActive(true);

        //    }
        //    if (Input.GetKeyDown(KeyCode.Z) && startnpc == true)
        //    {

        //        startnpc = false;
        //        startNPC.SetActive(false);
        //    }
            print(startnpc);
    }


            //startNPC.SetActive(false);
    }
            
            //startNPC.SetActive(false);

        //startNPC = true

