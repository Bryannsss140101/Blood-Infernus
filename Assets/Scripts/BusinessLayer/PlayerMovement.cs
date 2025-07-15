using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Components")]
    [SerializeField] private float speed;
    private Vector3 direction;

    [Header("Animation Components")]
    private Animator animator;

    [Header("Audio Components")]
    [SerializeField] private AudioClip stepClip;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        HandleMovement();
        HandleAnimation();
    }

    // Handle Movement
    private void HandleMovement()
    {
        direction = new(
                Input.GetAxisRaw("Horizontal"), 0f,
                Input.GetAxisRaw("Vertical"));

        if (direction.magnitude > 1)
            direction.Normalize();

        transform.position += speed * Time.deltaTime * direction;
    }

    // Handle Animation
    private void HandleAnimation()
    {
        animator.SetFloat("horizontal", direction.x);
        animator.SetFloat("vertical", direction.z);
    }

    // Handle Audio
    private void HandleAudio()
    {
        if (direction.magnitude > 0)
            audioSource.PlayOneShot(stepClip, 1f);
    }
}