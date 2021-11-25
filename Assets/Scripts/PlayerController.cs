using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Text hpText;
    int health;
    [SerializeField] GameObject gameOver;
    bool pause = false;

    public void ChangeHealth(int count)
    {
        health += count;
        if (health <= 0)
        {
            gameOver.SetActive(true);
            GetComponent<PlayerLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        hpText.text = health.ToString();
    }

    public int GetHealth()
    {
        return health;
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("playerX"))
        {
            float x = PlayerPrefs.GetFloat("playerX");
            float y = PlayerPrefs.GetFloat("playerY");
            float z = PlayerPrefs.GetFloat("playerZ");
            transform.position = new Vector3(x, y, z);
            ChangeHealth(PlayerPrefs.GetInt("health"));
        }
        else
        {
            ChangeHealth(100);
        }
    }
    [SerializeField] Animator recoil;
    [SerializeField] GameObject PauseUI;

    // Update is called once per frame
    void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
              if (pause == true)
              {
                pause = false;
                GetComponent<PlayerLook>().enabled = true;
                GetComponent<PlayerMove>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                PauseUI.SetActive(false);
                GetComponent<Collider>().enabled = true;
              }
              else
              {
                pause = true;
                GetComponent<PlayerLook>().enabled = false;
                GetComponent<PlayerMove>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                PauseUI.SetActive(true);
                GetComponent<Collider>().enabled = false;

              }
        }
 
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Health")
        {
            print("health");
            Destroy(collider.gameObject);
            ChangeHealth(50);
        }

    }

}
