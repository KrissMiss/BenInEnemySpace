using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] Animator door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            door.SetTrigger("Open");
            print("open");
            GetComponent<Animator>().SetTrigger("Open");
            GetComponent<AudioSource>().Play();
        }
    }
}
