using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float takeOffRotation, landingRotation;
    public Animator animator; // Attach your Animator here

    private float rotZ;

    public void ApplyRotation(float velocityY)
    {
        if (rotZ > landingRotation)
        {
            float offset = 1f;
            velocityY = Mathf.Abs(velocityY);
            if (velocityY > 0.5f) offset = velocityY;
            offset = Mathf.Abs(offset);
            rotZ -= rotationSpeed * Time.deltaTime / offset;
            transform.localEulerAngles = new Vector3(0, 0, rotZ);
        }
    }

    public void StartRotation()
    {
        rotZ = takeOffRotation;
    }

    public void PlayShootAnimation()
    {
        animator.SetTrigger("Shoot"); // Ensure there's a trigger named "Shoot" in the Animator
    }
}