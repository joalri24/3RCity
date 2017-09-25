using UnityEngine;

/// <summary>
/// Entities that can be built by the player
/// </summary>
public abstract class Buildable : MonoBehaviour
{
    [SerializeField]
    protected int cost;

    protected Color originalColor;
    protected Renderer buildingRenderer;

    /// <summary>
    /// Colors green the buildable object
    /// </summary>
    public abstract void ColorGreen();

    /// <summary>
    /// Colors red the buildable object
    /// </summary>
    public abstract void ColorRed();

    /// <summary>
    /// Returns the buildable object color to its original
    /// </summary>
    public abstract void ColorOriginal();

    /// <summary>
    /// Executes when the building is placed
    /// </summary>
    public abstract void Place();

    public int Cost
    {
        get
        {
            return cost;
        }
    }
}
