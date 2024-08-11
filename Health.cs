using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Health : MonoBehaviour
{
    protected Animator Animator;
    protected float Points;

    private readonly string _commandIsDead = "IsDead";

    public virtual void LoosePoints()
    {
        float lostPoints = 10;
        Points -= lostPoints;
    }

    public virtual void AddPoints(float addedPoints, float maxPoints)
    {
        Points += addedPoints;

        if (Points > maxPoints)
            Points = maxPoints;
    }

    public virtual void CheckForDeath()
    {
        if (Points <= 0)
            SetDeathAnimation();
    }

    public virtual void SetDeathAnimation()
    {
        Animator.SetBool(_commandIsDead, true);
    }
}
