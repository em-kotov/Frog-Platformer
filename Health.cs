using UnityEngine;

public class Health : MonoBehaviour
{
    protected float Points;

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
}
