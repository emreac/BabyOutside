using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystickController : MonoBehaviour
{

    

    public GameObject confetti;
    Vector3 lastPos;
    public GameObject player;
    public Animator animator;
    //public Rigidbody rb;

    public float speed = 5.0F;
    public DynamicJoystick moveJoystick;
    public DynamicJoystick lookJoystick;
    public bool joystickActive = false;
    public GameObject tutorCanvas;

    public AudioSource yaySound;

    private void Start()
    {
        joystickActive = false;
    }

    void Update()
    {

        Invoke("TutorCanvas", 8f);
        if(player.transform.position != lastPos)
        {
         
            joystickActive = true;
            animator.SetBool("Crawl", true);
        }
        else
        {
            joystickActive = false;
            animator.SetBool("Crawl", false);
        }
        lastPos = player.transform.position;

        updateMoveJoystick();
        updateLookJoystick();


     

    }

    void updateMoveJoystick()
    {

        CharacterController controller = GetComponent<CharacterController>();
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        controller.SimpleMove(direction *speed);
        
 
    }

    void updateLookJoystick()
    {
        float hoz = moveJoystick.Horizontal;
        float ver = moveJoystick.Vertical;
        Vector3 direction = new Vector3(hoz, 0, ver).normalized;
        Vector3 lookAtPosition = transform.position + direction;
        transform.LookAt(lookAtPosition);
    }
    private void FixedUpdate()
    { /*
        if (rb.position.y < -4)
        {
            FindObjectOfType<GameController>().EndGame();
        }
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FinalTrigger")
        {
            yaySound.Play();
            confetti.SetActive(true);
        }
        if (other.tag == "Mom")
        {
            Debug.Log("Game Over!");
        }
    }

    public void TutorCanvas()
    {
        tutorCanvas.SetActive(false);
    }


}
