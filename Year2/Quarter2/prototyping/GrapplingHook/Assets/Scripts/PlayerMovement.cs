using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    [Header("References")]
    public CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;
    public GameObject cam;
    public bool activeGrapple;

    public bool wallRunning;
    public string wallSide;

    


    



    void Start()
    {
        // Verzeker dat de CharacterController component is toegewezen
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
    }

    private void Update()
    {
        

        if (activeGrapple)
        {
            HandleGrappleMovement();
        }
        if (wallRunning)
        {
            WallRunning();
        }
        else
        {
            HandleMovement();
            HandleJump();
        }
    }

    private void WallRunning()
    {
        velocity = new Vector3(0,0,0);

        if (Input.GetButtonDown("Jump"))
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * -9.81f);
        }
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.forward * vertical;

        characterController.Move(velocity * Time.deltaTime + move * speed * Time.deltaTime);
    }

    private void HandleGrappleMovement()
    {

        // Pas gravitatie toe
        velocity.y += gravity * Time.deltaTime;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Richting van beweging bepalen
        Vector3 move = (transform.right * horizontal + transform.forward * vertical) / 3f;
        // Beweeg speler met berekende velocity
        characterController.Move((velocity * Time.deltaTime) + move);
        


        // Controleer of de speler de grond raakt om grapple te stoppen
        if (characterController.isGrounded)
        {
            activeGrapple = false;
            velocity = Vector3.zero;
        }
    }

    private void HandleMovement()
    {
        if (activeGrapple) return;
        // Input ophalen voor X- en Z-assen
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Richting van beweging bepalen
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        if (speed > 20f) speed = 20f;
        characterController.Move(move * speed * Time.deltaTime);
    }

    private void HandleJump()
    {
        if (activeGrapple) return;

        // Controleer of het character op de grond staat
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Zorg dat het character stevig op de grond blijft
        }

        // Springen als de speler op de grond staat en op de jump-knop drukt
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravitatie toepassen
        velocity.y += gravity * Time.deltaTime;

        // Verticale snelheid toepassen
        characterController.Move(velocity * Time.deltaTime);

    }


    public void JumpToPosition(Vector3 targetPosition, float trajectoryHeight)
    {
        activeGrapple = true;

        // Bereken de snelheid die nodig is voor de sprong
        velocity = CalculateJumpVelocity(transform.position, targetPosition, trajectoryHeight);
    }

    private Vector3 velocityToSet;
    private void SetVelocity()
    {
        characterController.Move(velocityToSet);
    }

    public void ResetRestrictions()
    {
        activeGrapple = false;
    }


    public Vector3 CalculateJumpVelocity(Vector3 startPoint, Vector3 endPoint, float trajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = endPoint.y - startPoint.y;
        Vector3 displacementXZ = new Vector3(endPoint.x - startPoint.x, 0f, endPoint.z - startPoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * trajectoryHeight);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * trajectoryHeight / gravity)
            + Mathf.Sqrt(2 * (displacementY - trajectoryHeight) / gravity));

        return velocityXZ + velocityY;
    }

    
}
