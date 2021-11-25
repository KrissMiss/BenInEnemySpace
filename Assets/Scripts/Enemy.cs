using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int damage;
    protected int health;
    protected GameObject player; 
    bool dead = false;
    float timer;

    public virtual void Move()
    {

    }
    public virtual void Attack()
    {

    }
    public void OnDeath() 
    {
        dead = true;
        GetComponent<Animator>().SetBool("dead", true); 
        GetComponent<CharacterController>().enabled = false;
        //Destroy(gameObject);
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject; 
    }

    private void Update()
    {
        if (!dead)
        {
            Move();
            Attack();
        }

        if (dead == true)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
