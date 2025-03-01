using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC Pack", menuName = "Create NPC Pack", order = 1)]
public class PackType : ScriptableObject
{
    public List<NPCType> NPCPack = new();
}