using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Transform rifleStart;
    [SerializeField] protected GameObject bullet;

    protected bool auto = false;
    protected int damage = 0;
    protected float cooldown = 0;
    protected float speed = 20;

    private float timer = 0;

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                if (ammoCurrent > 0)
                {
                    OnShoot();
                    timer = 0;
                    ammoCurrent = ammoCurrent - 1;
                    AmmoTextUpdate();
                }
                else
                {
                    GetComponent<AudioSource>().Play();
                }
            }
        }
    }
    protected virtual void OnShoot()
    {

    }
    private void Start()
    {
        timer = cooldown;
        AmmoTextUpdate();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        Reload();
    }

    protected int ammoCurrent = 10;
    protected int ammoMax = 10;
    protected int ammoAll = 100;

    [SerializeField] Text ammoText;

    private void AmmoTextUpdate()
    {
        ammoText.text = ammoCurrent + " / " + ammoAll;
    }
    public void Reload()
    {
        if (!Input.GetKeyDown(KeyCode.R)) return; 
        if (ammoCurrent == ammoMax) return;
        if (ammoAll == 0) return;
        Invoke("InvokeReload", 1);
    }

    private void InvokeReload()
    {
        int ammoNeed = ammoMax - ammoCurrent; 
        if (ammoAll >= ammoNeed)
        {
            ammoAll -= ammoNeed;
            ammoCurrent += ammoNeed;
        }
        else 
        {
            ammoCurrent += ammoAll;
            ammoAll = 0;
        }
        AmmoTextUpdate();
    }
}
