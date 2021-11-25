using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10;
    Vector3 direction;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<AudioSource>().pitch = Random.Range(1.0f, 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    public void setDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().ChangeHealth(-20);
        }
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy>().OnDeath();
            Destroy(gameObject);
        }
    }
}

