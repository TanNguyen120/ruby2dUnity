using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    //Rigidbody2D rigidBody;
    public float speed = 5f;

    public GameObject cog;

    public AudioClip fire;

    public AudioClip questSound;

    public AudioClip hitSound;
    Vector2 lookDirection = new Vector2(1, 0);

    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private Vector3 playerVelocity;
    [SerializeField]
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    Animator animator;

    AudioSource audioSource;

    [SerializeField] Player playerInput;

    void Awake()
    {
        playerInput = new Player();
        playerInput.Enable();

    }
    void Start()
    {
        health = maxHealth;
        //rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moveHandles();

    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
        if (playerInput.Ruby.shoot.triggered)
        {
            Launch();
        }
        //talkToNPC();

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = playerInput.Ruby.move.ReadValue<Vector2>();

        Vector3 move = new Vector3(movement.x, movement.y, 0f);
        controller.Move(move * Time.deltaTime * playerSpeed);
        Debug.Log("move is:" + move);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        animator.SetFloat("Look X", movement.x);
        animator.SetFloat("Look Y", movement.y);
        animator.SetFloat("Speed", move.magnitude);

        // Changes the height position of the player..
        // if (Input.GetButtonDown("Jump") && groundedPlayer)
        // {
        //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        // }

        // playerVelocity.y += gravityValue * Time.deltaTime;
        // controller.Move(playerVelocity * Time.deltaTime);
        if (playerInput.Ruby.openMenu.triggered)
        {
            Debug.Log("press i");
            GameManager.instance.openMenu();
        }
    }

    public void restoreHealth(int amount)
    {
        // Mathf clamp make sure health will not go above maxHealth
        health = Mathf.Clamp(health + amount, 0, maxHealth);


    }

    public void reciveDamage(int amount)
    {
        health -= amount;
        UIHealthBar.instance.SetValue(health / (float)maxHealth);
        audioSource.PlayOneShot(hitSound);
        animator.SetTrigger("Hit");
    }

    // public void moveHandles()
    // {
    //     float horizontal = Input.GetAxis("Horizontal");
    //     float vertical = Input.GetAxis("Vertical");
    //     Vector2 position = transform.position;
    //     position.x = position.x + speed * horizontal * Time.deltaTime;
    //     position.y = position.y + speed * vertical * Time.deltaTime;
    //     rigidBody.MovePosition(position);
    //     Vector2 move = new Vector2(horizontal, vertical);

    //     if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
    //     {
    //         lookDirection.Set(move.x, move.y);
    //         lookDirection.Normalize();
    //     }

    //     

    // }

    void Launch()
    {
        GameObject projectileObject = Instantiate(cog, gameObject.transform.position + Vector3.up * 0.5f, Quaternion.identity);

        CogController projectile = projectileObject.GetComponent<CogController>();
        projectile.Launch(lookDirection, 300);
        audioSource.PlayOneShot(fire);
        animator.SetTrigger("Launch");
    }

    void talkToNPC()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position + Vector3.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<NPCController>() != null)
                {
                    hit.collider.GetComponent<NPCController>().displayDialog();
                    audioSource.PlayOneShot(questSound);
                }
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
            }
        }

    }

    public void playPickUpSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void saveData()
    {
        GameManager.instance.saveGame(gameObject);
    }

    public void loadData()
    {
        GameManager.instance.loadGame(gameObject);
    }



}
