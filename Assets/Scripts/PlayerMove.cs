using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    Vector3 direction;
    [SerializeField] float speed = 5;
    [SerializeField] CharacterController controller;
    [SerializeField] float gravity = 20;
    [SerializeField] float jumpForce = 50;
    [SerializeField] Text ScoreText;
    float time = 0;
    int roundTime = 0;
    [SerializeField] Text TimeText;
    [SerializeField] GameObject hurryUp;
    [SerializeField] Collider portal;


    void Update()
    {
        if (crystals < 25)
        {
            time += Time.deltaTime;
            roundTime = Mathf.RoundToInt(time);
            TimeText.text = roundTime.ToString();
        }

        if (crystals >= 25)
        {
            hurryUp.SetActive(true);
            portal.isTrigger = true;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            direction = new Vector3(moveHorizontal, 0, moveVertical);
            direction = transform.TransformDirection(direction) * speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpForce;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 10;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 5;
            }

        }

        direction.y -= gravity;
        controller.Move(direction * Time.deltaTime);

        if (transform.position.y < -10)
        {
            transform.position = startPosition;
        }
    }
    [SerializeField] int crystals = 0;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Crystal")
        {
            print("crystal");
            Destroy(collider.gameObject);
            crystals += 1;
            ScoreText.text = crystals.ToString();
        }
    }


}
