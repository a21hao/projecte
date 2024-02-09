
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NewControls : MonoBehaviour
{
    //private InputActions playerActions;
    [SerializeField] private InputActionAsset playerActions;
    public float moveValue;
    public float zValue;
    public bool isJump;
    public bool isFire;
    static public Vector2 mapMovementDirection;
    static public bool isExitVendingMachine;
    //private Player player;
    //private MovementBehaviour mvb;
    //private Animator anim;
    //private HealthBehavior hb;
    //private bool godMode;
    //private ChangeToMenu ch;
    //private bool god;
    private SpriteRenderer sr;


    private void Awake()
    {
        InputActionMap Player = playerActions.FindActionMap("Player");
        isExitVendingMachine = false;

        /*Player.FindAction("Forward").performed += OnRun;
        Player.FindAction("Forward").canceled += OnStopRun;
        Player.FindAction("Left").performed += OnBack;
        Player.FindAction("Left").canceled += OnStopBack;
        Player.FindAction("Jump").performed += OnnJump;
        Player.FindAction("Jump").canceled += OnStopJump;
        Player.FindAction("LookUp").performed += OnLookUpp;
        Player.FindAction("LookUp").canceled += OnStopLookUp;
        Player.FindAction("LookDown").performed += OnnLookDown;
        Player.FindAction("LookDown").canceled += OnStopLookDown;
        Player.FindAction("Fire").performed += OnnFire;
        Player.FindAction("Fire").canceled += OnStopFire;
        Player.FindAction("Menu").performed += OnnMenu;
        Player.FindAction("GodMode").performed += OnnGoodMode;*/
        Player.FindAction("MoveMap").performed += OnnMoveMap;
        Player.FindAction("MoveMap").canceled += OnnMoveMap;
        Player.FindAction("ExitVendingMachine").performed += OnnExitVendingMachinePressed;
        Player.FindAction("ExitVendingMachine").canceled += OnnExitVendingMachineCanceled;
        /*playerActions = new InputActions();
        playerActions.Player.Forward.performed += OnRun;
        playerActions.Player.Forward.canceled += OnStopRun;
        playerActions.Player.Left.started += OnBack;
        playerActions.Player.Left.canceled += OnStopBack;
        //playerActions.Player.Left.started += OnFlip;
        //playerActions.Player.LookUp.started += OnGodMode;
        playerActions.Player.Jump.started += OnJump;
        playerActions.Player.Jump.canceled += OnStopJump;
        playerActions.Player.LookUp.performed += OnLookUp;
        playerActions.Player.LookUp.canceled += OnStopLookUp;
        playerActions.Player.LookDown.started += OnLookDown;
        playerActions.Player.LookDown.canceled += OnStopLookDown;
        playerActions.Player.Fire.started += OnFire;
        playerActions.Player.Fire.canceled += OnStopFire;
        //playerActions.Player.Jump.started += OnChangeMenu;
        */
        //mvb = GetComponent<MovementBehaviour>();
        //anim = GetComponent<Animator>();
        //player = GetComponent<Player>();
        //hb = GetComponent<HealthBehavior>();
        //sr = GetComponent<SpriteRenderer>();
        moveValue = 0;
        zValue= 0;
        isJump = false;
        isFire = false;
    //god = false;
    }

    private void OnRun(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        moveValue += 1;
        //player.rendersChilds[0].transform.position = new Vector3(transform.position.x - 0.564f, transform.position.y, transform.position.z);
        // Debug.Log("hola");
    }

    private void OnStopRun(InputAction.CallbackContext ctx)
    {
        //player.OnStopMove();
        moveValue -= 1;
    }

    private void OnBack(InputAction.CallbackContext ctx)
    {
        // moveValue = ctx.ReadValue<float>();
        moveValue -= 1;
        //player.rendersChilds[0].transform.position = new Vector3(transform.position.x + 0.564f, transform.position.y, transform.position.z);
    }

    private void OnStopBack(InputAction.CallbackContext ctx)
    {
        // moveValue = ctx.ReadValue<float>();
        moveValue += 1;
        //player.rendersChilds[0].transform.position = new Vector3(transform.position.x + 0.564f, transform.position.y, transform.position.z);
    }


    private void OnnJump(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        isJump = true;

    }

    private void OnStopJump(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        isJump = false;

    }

    private void OnLookUpp(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        zValue = 1;
    }

    private void OnStopLookUp(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        zValue = 0;
    }

    private void OnnLookDown(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        zValue = -1;
    }

    private void OnStopLookDown(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        zValue = 0;
    }

    private void OnnFire(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        isFire = true;
    }

    private void OnStopFire(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        isFire = false;
    }

    private void OnnMenu(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        SceneManager.LoadScene("MenuScene");
    }

    private void OnnGoodMode(InputAction.CallbackContext ctx)
    {
        //moveValue = ctx.ReadValue<float>();
        //godMode = !godMode;
       // hb.SetGodMode(godMode);
    }

    private void OnnMoveMap(InputAction.CallbackContext ctx)
    {
        mapMovementDirection = ctx.ReadValue<Vector2>();
        Debug.Log(mapMovementDirection);
    }

    private void OnnExitVendingMachinePressed(InputAction.CallbackContext ctx)
    {
        isExitVendingMachine = true;
    }

    private void OnnExitVendingMachineCanceled(InputAction.CallbackContext ctx)
    {
        isExitVendingMachine = false;
    }


    /*private void OnFlip(InputAction.CallbackContext ctx)
    {
        player.Flip();       
    }

    private void OnGodMode(InputAction.CallbackContext ctx)
    {
        god = !god;

        hb.godMode= god;
        if (god)
        {
            sr.color = (Color)(new Color32(210, 92, 92, 255));
        }
        else
        {
            sr.color = (Color)(new Color32(255, 255, 255, 255));
        }
    }

    private void OnChangeMenu(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene("MenuScene");
    }*/

    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void OnDisable()
    {
        playerActions.Disable();
    }
}



