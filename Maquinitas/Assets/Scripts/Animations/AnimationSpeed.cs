using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationSpeed : MonoBehaviour
{
    public AnimationClip animClip; 
    private Animator animator;
    private bool isMouseDown = false;
    private float originalSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animClip != null)
        {
            animator.Play("CreditsAnim", -1, 0f);
            originalSpeed = animator.speed;
        }
        else
        {
            Debug.LogError("¡No se ha asignado ninguna animación!");
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            isMouseDown = true;
            if (animator != null)
            {
                animator.speed += 2f;
            }
        }
        else
        {
            if (isMouseDown)
            {
                if (animator != null)
                {
                    animator.speed = originalSpeed;
                }
                isMouseDown = false;
            }
        }
    }
}
