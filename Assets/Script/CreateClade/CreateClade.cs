using System;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class CreateClade : MonoBehaviour
{
    static int nb_species = 0;
    [MenuItem("Tools/Create Asset")]
    static void CreateAsset()
    {
        //var pythonArgs = "your_python_program.py param1 param2";
        //System.Diagnostics.Process.Start("python", pythonArgs); // assuming python installed on test machine

        string path = Application.dataPath +"/Resources/dinosaur_tree/Dinosauria";
        Debug.Log("Start creating asset from " + path);
        CreateFolder(path);
        AssetDatabase.SaveAssets();
    }

    static Clade CreateFolder(string path)
    {
        
        Clade clade = null;
        if (Directory.Exists(path))
        {
            string[] subFolders = Directory.GetDirectories(path);
            clade = CreateSO(path);
            //Debug.Log("Clade : " + clade);
            if (subFolders.Length == 0)
            {
                Debug.Log("No subfolders found." + clade);
            }
            else
            {
                Debug.Log($"Found {subFolders.Length} subfolder(s):");
                foreach (string folder in subFolders)
                {
                    nb_species++;
                    if(nb_species>8)
                        return null;
                    // Get only the folder name, not the full path
                    string folderName = Path.GetFileName(folder);
                    //Debug.Log($"- {folderName}");
                    Clade son = CreateFolder(path  +'/'+ folderName);
                    //Debug.Log("Clade : " + clade);
                    //Debug.Log("Son : " + son);
                    //Debug.Log("CladeChildren : " + clade.children == null);
                    if(son != null && clade != null && clade.children != null)
                    {
                        Debug.Log("Add children" + son.name);
                        clade.children.Add(son);
                    }           
                    else
                    {
                        Debug.Log((clade == null) + ":"+ (son == null) +":" +(clade.children == null));
                        Debug.Log("Path son : " +path  +'/'+ folderName );
                    }
                        
                }
            }
        }
        else
        {
            Debug.Log("Folder not existing at " + path);
        }
        return clade;
    }
    static Clade CreateSO(string path)
    {
        Clade asset = ScriptableObject.CreateInstance<Clade>();
       
        string directoryName = path.Substring(path.LastIndexOf('/')+1);
        string newpath = CutAtWord(path,"Assets");
        string assetPath = newpath + '/' +directoryName+".asset";
        string jsonPath = assetPath;
        jsonPath = jsonPath.Remove(0,"Assets/Resources/".Length);
        jsonPath = jsonPath.Replace(".asset","");
        //string jsonPath = "dinosaur_tree" + '/' +directoryName+"/" + directoryName;
        TextAsset jsonFile =  Resources.Load<TextAsset>(jsonPath);
         Debug.Log("Path " + jsonPath);
        if (jsonFile == null)
        {
           Debug.Log("File not found!"); 
        }
            
        //Debug.Log("json " + jsonFile);
        Debug.Log("Path " + assetPath);
       
        
        if(directoryName.EndsWith("oidea"))
        {
            asset.rank = ERank.SUPERFAMILY;
        }
        else if(directoryName.EndsWith("idae"))
        {
            asset.rank = ERank.FAMILY;
        }
        else if(directoryName.EndsWith("inae"))
        {
            asset.rank = ERank.SUBFAMILY;
        }
        else if(directoryName.EndsWith("ini"))
        {
            asset.rank = ERank.TRIBE;
        }
        else 
        {
            asset.rank = ERank.CLADE;
        }
        //Debug.Log("Try asset at " + assetPath);
        AssetDatabase.CreateAsset(asset,assetPath );
       
        //Debug.Log("Create asset at " + assetPath);
        JsonUtility.FromJsonOverwrite(jsonFile.text,asset);
        if(asset == null)
            Debug.Log("Asset NULL");
        return asset;
    }


     public static string CutAtWord(string input, string word, bool ignoreCase = true)
    {
        // Validate inputs
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(word))
            return input;

        // Choose comparison type
        StringComparison comparison = ignoreCase
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        // Find the index of the word
        int index = input.IndexOf(word, comparison);

        // If word not found, return original string
        if (index == -1)
            return input;

        // Return substring up to the word
        Debug.Log("index : " + index + " lenght : "+ (input.Length-1));
        return input.Substring(index, input.Length- index);
    }
}
