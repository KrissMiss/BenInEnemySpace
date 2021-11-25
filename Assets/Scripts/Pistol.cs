using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 20;
        cooldown = 0;
        speed = 50;
        auto = false;
        ammoCurrent = 50;
        ammoMax = 50;
        ammoAll = 500;
    }

    protected override void OnShoot()
    {
        GameObject buf = Instantiate(bullet);
        buf.transform.position = rifleStart.transform.position;
        buf.transform.rotation = transform.rotation;
        buf.GetComponent<Bullet>().setDirection(transform.forward);
    }
}
