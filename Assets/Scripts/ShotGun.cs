using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    void Start()
    {
        damage = 5;
        auto = false;
        cooldown = 0;
        speed = 80;
        ammoCurrent = 30;
        ammoMax = 30;
        ammoAll = 300;
    }

    protected override void OnShoot()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject buf = Instantiate(bullet);
            buf.transform.position = rifleStart.transform.position;
            float x = Random.Range(-30, 30);
            float y = Random.Range(-10, 10);
            buf.transform.rotation = transform.rotation;
            buf.GetComponent<Bullet>().setDirection(transform.forward + new Vector3(x / 500, y / 500, 0));
        }
    }
}
