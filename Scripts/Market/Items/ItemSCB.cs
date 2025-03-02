using UnityEngine;

[CreateAssetMenu(fileName = "Create Item", menuName = "Market/Item", order = 1)]
public class ItemSCB : ScriptableObject
{
    public Sprite ItemSprite;
    public int ItemLevel;
    public float Cost;
}