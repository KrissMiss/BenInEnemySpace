using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Author()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ManagePlayer()
    {
        SceneManager.LoadScene(4);
    }

    public void Exit()
    {
        Application.Quit();
    }

    [SerializeField] GameObject player;
    public void Save()
    {
        Vector3 vector = player.transform.position;
        int health = player.GetComponent<PlayerController>().GetHealth();
        PlayerPrefs.SetFloat("playerX", vector.x);
        PlayerPrefs.SetFloat("playerY", vector.y);
        PlayerPrefs.SetFloat("playerZ", vector.z);
        PlayerPrefs.SetInt("health", health);
        PlayerPrefs.Save();
    }

    public void Reset()
    {
        PlayerPrefs.SetFloat("playerX", 466f);
        PlayerPrefs.SetFloat("playerY", 22.39f);
        PlayerPrefs.SetFloat("playerZ", 107f);
        PlayerPrefs.SetInt("health", 100);
        PlayerPrefs.Save();
    }
}
