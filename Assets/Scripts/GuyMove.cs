using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuyMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5;
    Vector3 direction;
    Vector3 startPosition;
    [SerializeField] Text TimeText;
    [SerializeField] GameObject finishGame;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    float time = 0;
    bool finish = false;
    int roundTime = 0;
    void Update()
    {
        if (finish == false)
        {
            time += Time.deltaTime;
            roundTime = Mathf.RoundToInt(time);
            TimeText.text = roundTime.ToString();
        }

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 5)
        {
            rb.AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
            GetComponent<AudioSource>().Play();
        }

        if (transform.position.y < -10)
        {
            transform.position = startPosition;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = transform.TransformDirection(horizontal, 0, vertical);
        rb.MovePosition(transform.position + speed * direction * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            finish = true;
            finishGame.SetActive(true);
        }
    }
}
