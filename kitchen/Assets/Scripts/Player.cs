using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private InputHandler Input;
    [SerializeField] private LayerMask table;
    private float playerHeight = 2f;
    [SerializeField] private float playerRadius = 0.7f;
    private Vector2 moveInput;
    private Vector3 moveDir;
    private bool canMove;
    private bool isWalking;
    void Start()
    {

    }

    void Update()
    {

        moveInput = Input.GetMovementVector();
        moveDir = new Vector3(moveInput.x, 0, moveInput.y);

        canMove = !Physics.Raycast(transform.position, moveDir, playerRadius, table);

        if (!canMove)
        {
            Vector3 MoveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.Raycast(transform.position, MoveDirX, playerRadius, table);
            if (canMove)
            {
                Debug.Log("x");
                moveDir = MoveDirX;
            }
            else
            {
                Vector3 MoveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.Raycast(transform.position, MoveDirZ, playerRadius, table);
                if (canMove)
                {
                    moveDir = MoveDirZ;
                }
            }
        }

        if (canMove)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);
            transform.position += moveDir * speed * Time.deltaTime;
        }

        isWalking = moveDir != Vector3.zero;
    }

    public bool ReturnIsWalking()
    {
        return isWalking;
    }
}
