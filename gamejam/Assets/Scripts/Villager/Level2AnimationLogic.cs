using UnityEngine;

[RequireComponent(typeof(ForceBasedMovement))]
public class Level2AnimationLogic : MonoBehaviour
{

    [SerializeField] private Animator anim;
    private ForceBasedMovement movementScript;

    [SerializeField] private float initialAnimatorSpeed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementScript = GetComponent<ForceBasedMovement>();
        anim.SetFloat("speed", 1);
        anim.speed = initialAnimatorSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        updateAnimatorSpeed();

    }

    void updateAnimatorSpeed()
    {
        float scale = movementScript.getCurrentSpeed() / movementScript.maxSpeed;
        anim.speed = initialAnimatorSpeed * scale;
    }




}
