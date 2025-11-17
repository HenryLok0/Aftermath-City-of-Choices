using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    public bool canMove = true;

    // 八個場景：初始傳送點
    public Vector3[] scenePositions = new Vector3[]
    {
        new Vector3(8, 8, 0),     // 場景1
        new Vector3(23, -7, 0),   // 場景2
        new Vector3(40, 5, 0),    // 場景3（可自行替換座標）
        new Vector3(60, 8, 0),    // 場景4
        new Vector3(80, -2, 0),   // 場景5
        new Vector3(105, 6, 0),   // 場景6
        new Vector3(130, 0, 0),   // 場景7
        new Vector3(155, -5, 0)   // 場景8
    };

    // 八個場景：邊界限制
    public Vector2[] minBounds = new Vector2[]
    {
        new Vector2(-10, -8),  // 場景1
        new Vector2(20, -8),   // 場景2
        new Vector2(36, 1),    // 場景3
        new Vector2(58, 6),    // 場景4
        new Vector2(76, -7),   // 場景5
        new Vector2(100, 1),   // 場景6
        new Vector2(126, -4),  // 場景7
        new Vector2(151, -9)   // 場景8
    };
    public Vector2[] maxBounds = new Vector2[]
    {
        new Vector2(10, 8),   // 場景1
        new Vector2(41, 8),   // 場景2
        new Vector2(44, 9),   // 場景3
        new Vector2(62, 10),  // 場景4
        new Vector2(84, 2),   // 場景5
        new Vector2(110, 10), // 場景6
        new Vector2(134, 8),  // 場景7
        new Vector2(159, 3)   // 場景8
    };

    private int currentRegion = 0;

    // 給Fungus用，直接切換區域
    public void TeleportToScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < scenePositions.Length)
        {
            currentRegion = sceneIndex;
            transform.position = scenePositions[sceneIndex];
        }
    }
    public void SetPlayerCanMoveTrue() { canMove = true; }
    public void SetPlayerCanMoveFalse()
    {
        canMove = false;
        if (animator != null)
        {
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", 0f);
        }
        movement = Vector2.zero;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!canMove)
        {
            if (animator != null)
            {
                animator.SetFloat("Horizontal", 0f);
                animator.SetFloat("Vertical", 0f);
            }
            movement = Vector2.zero;
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
            return;

        Vector2 nextPos = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        // 限制在當前場景的範圍
        nextPos.x = Mathf.Clamp(nextPos.x, minBounds[currentRegion].x, maxBounds[currentRegion].x);
        nextPos.y = Mathf.Clamp(nextPos.y, minBounds[currentRegion].y, maxBounds[currentRegion].y);
        rb.MovePosition(nextPos);
    }
}
