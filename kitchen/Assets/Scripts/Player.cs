using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Player : MonoBehaviour
{
    public static Player Instance {  get; private  set; }
    
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs {
        public ClearCounter selectedCounter;
    }

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed = 10;
    [SerializeField] private float moveDistance = 6f;
    [SerializeField] private float playerRadius = 0.7f;
    [SerializeField] private float interationDistance = 1f;
    [SerializeField] private InputHandler Input;
    [SerializeField] private LayerMask table;
    private float playerHeight = 2f;
    private Vector2 moveInput;
    private Vector3 moveDir;
    private Vector3 lastMoveDir;
    private bool canMove;
    private bool isWalking;
    private ClearCounter selectedCounter;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("error");
        }
        Instance = this;
    }
    private void Start()
    {
        Input.OnInteractAction += Input_OnInteractAction; 
    }

    public void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }

    private void Input_OnInteractAction(object sender, System.EventArgs e)
    {
        if(selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool ReturnIsWalking()
    {
        return isWalking;
    }
    private void HandleInteractions()
    {
        if (Physics.Raycast(transform.position, lastMoveDir, out RaycastHit raycastHit, interationDistance, table))
        {
            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {

                if (clearCounter != selectedCounter)
                {
                    Debug.Log("123");
                    selectedCounter = clearCounter;
                    SetSelectedCounter(selectedCounter);
                }
            }
            else
            {
                selectedCounter = null;
                SetSelectedCounter(selectedCounter);
            }
        }
        else
        {
            Debug.Log("121113");
            selectedCounter = null;
            SetSelectedCounter(selectedCounter);
        }
    }
    private void HandleMovement() {
        moveInput = Input.GetMovementVector();
        moveDir = new Vector3(moveInput.x, 0, moveInput.y);
        if (moveDir != Vector3.zero && !CheckTwoHot(moveDir))
        {
            lastMoveDir = moveDir;
        }
        canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance, table);

        if (!canMove && CheckTwoHot(moveDir))
        {

            Vector3 MoveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, MoveDirX, moveDistance, table);
            if (canMove)
            {
                moveDir = MoveDirX;
            }
            else
            {
                Vector3 MoveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, MoveDirZ, moveDistance, table);
                if (canMove)
                {
                    moveDir = MoveDirZ;
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * speed * Time.deltaTime;
        }
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotationSpeed);

        isWalking = moveDir != Vector3.zero;
    }
    

    private bool CheckTwoHot(Vector3 vector)
    {
        // Подсчет количества единиц в векторе
        int count = 0;
        if (vector.x != 0) count++;
        if (vector.y != 0) count++;
        if (vector.z != 0) count++;
        // Проверка, что ровно два элемента равны 1
        return count >= 2;
    }
}

