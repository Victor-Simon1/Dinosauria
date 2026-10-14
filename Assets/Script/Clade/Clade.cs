using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clade", menuName = "ScriptableObjects/Clade")]
[System.Serializable]
public class Clade : ScriptableObject
{
    public string cladeName;
    public ERank rank;               // Exemple : clade, famille, genre, espèce
    public List<Clade> children;

    public virtual void SetName()
    {
        cladeName = name;
    }
}
