using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predator : Enemy
{

    float timer = 0;

    public override void Move()
    {
        GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer > 10)
        {
            transform.Rotate(new Vector3(0, 90, 0));
            timer = 0;
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 100)
        {
            transform.LookAt(player.transform);
            GetComponent<CharacterController>().Move(transform.forward * Time.deltaTime * 4);
            GetComponent<Animator>().SetBool("run", true);
            GetComponent<AudioSource>().mute = false;
        }
    }
    public override void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 8)
        {
            GetComponent<Animator>().SetBool("attack", true);
            if (Vector3.Distance(transform.position, player.transform.position) < 3)
            {
                player.GetComponent<PlayerController>().ChangeHealth(-10);
            }
                
        }
    }
}
