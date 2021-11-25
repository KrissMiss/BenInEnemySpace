using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewLevel : MonoBehaviour
{
    private Collider collider;
    public ParticleSystem iskorki;
    private void Update()
    {
        iskorki = GetComponentInChildren<ParticleSystem>();
        collider = GetComponent<Collider>();
        if (collider.isTrigger == true)
        {
            iskorki.Play();
        }
        else
        {
            iskorki.Pause();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }
    }
}
