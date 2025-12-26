using UnityEngine;

public class ArmIK : MonoBehaviour
{
    private Animator animator;
    public Transform handTarget;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (animator == null) return;

        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);

        animator.SetIKPosition(AvatarIKGoal.RightHand, handTarget.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, handTarget.rotation);
    }
}
