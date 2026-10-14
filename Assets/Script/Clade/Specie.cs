using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Specie", menuName = "ScriptableObjects/Specie")]
public class Specie : Clade
{
   // public string specieName;
    //public ERank rank;               // Exemple : clade, famille, genre, espèce
    //public List<Clade> children;
    public List<Specimen> specimens;
    public List<ECountry> hasBeenFoundInCountry;
    public bool isNomenDubium;
    public List<Specie> hasSynonyms;
    public float[] approximatedLenght = new float[2];
    public float[] approximatedWeight = new float[2];
    public float[] approximatedAge = new float[2];
    public override void SetName()
    {
        cladeName = name;
        rank = ERank.SPECIES;
    }
}
