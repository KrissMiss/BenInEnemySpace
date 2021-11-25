using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    
    float area = 40;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject rifleStart;
    float timer = 0;
    float cooldown = 3;
    bool pause = false;

    public override void Move()
    {
        
    }
    public override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < area)
        {
            transform.LookAt(player.transform);

            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                timer = 0;
                GameObject buf = Instantiate(bullet);
                buf.GetComponent<Bullet>().setDirection(transform.forward);
                buf.transform.position = rifleStart.transform.position;
                buf.transform.rotation = transform.rotation;
                GetComponentInChildren<ParticleSystem>().Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == true)
            {
                pause = false;
                area = 25;
            }
            else
            {
                pause = true;
                area = 0;

            }
        }
    }
}
