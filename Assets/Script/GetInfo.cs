using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class GenerateDinosaurFolders : MonoBehaviour
{
    [Header("Chemin du CSV depuis Assets/")]
    public string csvPath = "dinosaur_taxonomy_unity.csv";

    [Header("Chemin de création des dossiers")]
    public string rootFolder = "Assets/Dinosauria";

    void Start()
    {

        string path = System.IO.Path.Combine(Application.dataPath,csvPath);
        ///string csvPath2 = /*"D:/UnityProject/Dinosauria/Assets/*/"dinosaur_taxonomy_unity.csv";
       // foreach(string file in Directory.GetFiles(path))
         //   Debug.Log("File " + file);
        if (!File.Exists(path))
        {
            Debug.LogError("CSV introuvable : " + path);
            return;
        }

        // Créer le dossier racine
        if (!Directory.Exists(rootFolder))
            Directory.CreateDirectory(rootFolder);

        // Lire CSV
        var lines = File.ReadAllLines(path);

        // Vérifier l’entête
        int start = 0;
        if (lines[0].Contains("CladeMajeur"))
            start = 1;

        foreach (var line in lines[start..])
        {
            var cols = line.Split(';');
            if (cols.Length < 5)
                continue;

            string cladeMajeur = cols[0].Trim();
            string sousOrdre = cols[1].Trim();
            string family = cols[2].Trim();
            string subfamily = cols[3].Trim();
            string genre = cols[4].Trim();

            string currentPath = rootFolder;

            // Construire l’arborescence
            if (!string.IsNullOrEmpty(cladeMajeur))
            {
                currentPath = Path.Combine(currentPath, cladeMajeur);
                Directory.CreateDirectory(currentPath);
            }

            if (!string.IsNullOrEmpty(sousOrdre))
            {
                currentPath = Path.Combine(currentPath, sousOrdre);
                Directory.CreateDirectory(currentPath);
            }

            if (!string.IsNullOrEmpty(family))
            {
                currentPath = Path.Combine(currentPath, family);
                Directory.CreateDirectory(currentPath);
            }

            if (!string.IsNullOrEmpty(subfamily))
            {
                currentPath = Path.Combine(currentPath, subfamily);
                Directory.CreateDirectory(currentPath);
            }

            if (!string.IsNullOrEmpty(genre))
            {
                currentPath = Path.Combine(currentPath, genre);
                Directory.CreateDirectory(currentPath);
            }
        }

        Debug.Log("Arborescence Dinosauria générée avec succès !");
    }
}
//https://paleobiodb.org/data1.2/taxa/list.csv?base_name=Dinosauria&rank=genus&show=class,order,family,parent&limit=all