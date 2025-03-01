using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlScript : MonoBehaviour
{
    public Rigidbody player;
    public Collider playerCollider;
    private AudioSource playerAudio;
    Vector3 launchVelocity;

    public bool hasLaunched = false;

    public AudioClip rolling;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Launch(new Vector3(0, 0, 250));
        }
    }

    public void Move(string direction)
    {
        if(hasLaunched == false)
        {
            if (direction == "left")
            {
                player.transform.position -= new Vector3(0.05f, 0, 0);
            }
            if (direction == "right")
            {
                player.transform.position += new Vector3(0.05f, 0, 0);
            }
        }
        
    }
    // Update is called once per frame
    public void Launch(Vector3 velocity)
    {
        if (!hasLaunched && GameManager.instance.CanRoll())
        {
            hasLaunched = true;
            GameManager.instance.ChangeCanRoll(0);
            player.AddForce(velocity, ForceMode.Impulse);
            playerAudio.clip = rolling;  // Koppel het 'rolling' geluid aan de AudioSource
            playerAudio.Play();
        }
    }

    public void ResetPosition()
    {
        playerAudio.Stop();
        hasLaunched = false;

        player.transform.position = new Vector3(0, 0.1f, 0.1f);
        player.velocity = Vector3.zero;
        player.angularVelocity = Vector3.zero;
    }
}
