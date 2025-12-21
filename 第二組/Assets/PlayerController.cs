using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移動與旋轉設定")]
    public float moveSpeed = 5f;
    public float mouseSensitivity = 150f;
    public float jumpForce = 7f;
    public Transform playerCamera;

    private float xRotation = 0f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 60f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);

        CheckGrounded();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            TryInteract();
        }
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDir = transform.right * moveX + transform.forward * moveZ;

        Vector3 targetVelocity = moveDir * moveSpeed;
        targetVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = targetVelocity;
    }

    void CheckGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * 5f, Color.red);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 5f);
    }

    void TryInteract()
    {
        Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50f))
        {
            NPCController npc = hit.collider.GetComponent<NPCController>();
            if (npc != null) npc.ShowDialogue();

            TreasureBox box = hit.collider.GetComponent<TreasureBox>();
            if (box != null) box.OpenBox();
        }
    }

    public void SetDarkness(bool enable)
    {
        RenderSettings.fog = enable;
        RenderSettings.fogColor = new Color(0.01f, 0.01f, 0.01f);
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = enable ? 0.05f : 0f;
    }
}