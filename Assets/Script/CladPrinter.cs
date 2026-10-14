using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CladPrinter : MonoBehaviour
{
    public Clade rootClade;
    public GameObject canvas;
    public GameObject prefab;

    public float lineWidth;
    void Start()
    {
        lineWidth = prefab.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<RectTransform>().rect.width;
        PrintClade(rootClade, 0);
    }

    GameObject PrintClade(Clade clade, int indent,string genusName= "NONE")
    {
        clade.SetName();


        // SKIP du GENUS
        if (clade.rank == ERank.GENUS && clade.children != null)
        {
            GameObject last = null;

            foreach (var child in clade.children)
            {
                last = PrintClade(child, indent, clade.cladeName);
            }

            return last;
        }

        string spaces = new string(' ', indent * 2);
        string line = "|" +  new string('-', indent);
        string name = spaces+line;
        if(genusName != "NONE")
            name+=genusName +" " + clade.cladeName;
        else
            name+= clade.cladeName;
        //Debug.Log(spaces +line+ clade.cladeName + " (" + clade.rank + ")");
        CladeInfo cladeInfo;
        GameObject go = Instantiate(prefab);
        go.transform.SetParent(canvas.gameObject.transform);
        go.transform.localScale = new Vector3(1,1,1);

        go.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = name;
        go.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = clade.rank.GetColorRank();
        cladeInfo = go.GetComponentInChildren<CladeInfo>();
        //UIManager.instance.dicoByRankGo[clade.rank].Add(go);
        if(clade is Specie)
            DrawLine(clade,ref go);
        
       
        if (clade.children != null)
        {
            foreach (var child in clade.children)
            {
                GameObject childGo;
                if(clade.rank == ERank.GENUS)
                    childGo = PrintClade(child, indent + 1,clade.cladeName);
                else
                    childGo = PrintClade(child, indent + 1);
                cladeInfo.children.Add(childGo);
            }
        }
        return go;
    }
    void DrawLine(Clade clade,ref GameObject go )
    {
        Specie specie = clade as Specie;
        //Line 
        float width = lineWidth;
        float beginYear = -255;
        float endYear = -66;
        float difference = Mathf.Abs(beginYear) - Mathf.Abs(endYear);

        float yearByPixel = width / difference;

        float pixelBegin = (specie.approximatedAge[0] - beginYear) * yearByPixel;
        float pixelEnd = (specie.approximatedAge[1] - beginYear) * yearByPixel;

        //LineRenderer lineRenderer = go.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<LineRenderer>();
        //lineRenderer.SetPosition(0, new Vector2(pixelBegin,0f));
        //lineRenderer.SetPosition(1, new Vector2(pixelEnd,0f));
        GameObject lineRenderer = go.transform.GetChild(0).GetChild(1).GetChild(1).gameObject;
        
        lineRenderer.transform.GetChild(0).gameObject.SetActive(true);
        lineRenderer.transform.GetChild(1).gameObject.SetActive(true);

        lineRenderer.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition  = new Vector3(pixelBegin,0f,0f);
        lineRenderer.transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition  = new Vector3(pixelEnd,0f,0f);

        Debug.Log("Specie " + specie.name + " "+new Vector2(pixelBegin,0f) + " "+ new Vector2(pixelEnd,0f)+""+
        pixelBegin +" " + pixelEnd +"+" +yearByPixel);
        Debug.Log("Specie " + specie.name + " "+ lineRenderer.transform.GetChild(0).name + " " + lineRenderer.transform.GetChild(0).position);
        if(specie.hasBeenFoundInCountry.Count>0)
        {
            //lineRenderer.startColor = specie.hasBeenFoundInCountry[0].GetColorCountry();
            //lineRenderer.endColor = specie.hasBeenFoundInCountry[0].GetColorCountry();
        }
            
    }
}
