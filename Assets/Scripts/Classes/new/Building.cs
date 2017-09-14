using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entities that can be built by the player
/// </summary>
public class Building : MonoBehaviour
{
    [SerializeField]
    private int cost;

    [SerializeField]
    private Buildings.Type type;

    public int Cost
    {
        get
        {
            return cost;
        }
    }
}
