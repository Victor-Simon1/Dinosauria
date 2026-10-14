using System.Collections.Generic;
using UnityEngine;
public enum ERank
{
    DOMAIN,
    KINGDOM,
    PHYLUM,
    CLASS,
    ORDER,
    SUBORDER,
    INFRAORDER,
    MICROORDER,
    SUPERFAMILY,
    FAMILY,
    SUBFAMILY,
    TRIBE,
    SUBTRIBE,
    GENUS,
    SUBGENUS,
    SPECIES,
    SUBSPECIES,
    CLADE,
    MAX
}

public static class RankExtension
{
    static List<Color> colors = new List<Color>();
    // Méthode d'extension pour string
    public static void SetColorRank(Color from,Color to)
    {
        int range = (int)ERank.MAX-1; // Makes things a bit easier
        int steps = (int)ERank.MAX;
        for (int i=0; i < steps; i++)
        {
            // i is the proportion of the "to" colour to use.
            // j is the proportion of the "from" colour to use.

            int j = range - i;
            float r = ((from.r * j) + (to.r * i)) / range;
            float g = ((from.g * j) + (to.g * i)) / range;
            float b = ((from.b * j) + (to.b * i)) / range;
            colors.Add(new Color(r, g, b));
        }
    }
    public static Color GetColorRank(this ERank rank)
    {
        if(colors.Count == 0)
            SetColorRank(Color.red,Color.orange);
        Debug.Log("Rank "  + rank +" " + (int)rank);
        Debug.Log("Lenght "  + colors.Count);
        return colors[(int)rank];
    }
}