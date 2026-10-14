using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Dictionary<ERank,List<GameObject>> dicoByRankGo = new Dictionary<ERank, List<GameObject>>();
    public TMP_Dropdown dropdownRank;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance == null)
            instance = this;
        for(int i = 0;i<(int)ERank.MAX;i++)
        {
            dicoByRankGo.Add((ERank)i,new List<GameObject>());
        }

        InitRank();
    }

    void InitRank()
    {
        List<string> m_DropOptions = new List<string>(){"ALL"};
        for(int i = 0;i<(int)ERank.MAX;i++)
        {
            m_DropOptions.Add(((ERank)i).ToString());
            
        }
        dropdownRank.AddOptions(m_DropOptions);
    }

    public void OnClickDropdownRank(Int32 value)
    {
        if(value == 0)
        {
            ShowAll();
        }
        else
        {
            ShowParticularRank((ERank)(value-1));
        }
    }

    public void ShowAll()
    {
        for(int i = 0;i<dicoByRankGo.Count;i++)
        {
            for(int j = 0;j<dicoByRankGo[(ERank)i].Count;i++)
            {
                dicoByRankGo[(ERank)i][j].SetActive(true);
            }
        }
    }
    public void ShowParticularRank(ERank rank)
    {
        Debug.Log(rank);
        foreach (ERank key in dicoByRankGo.Keys)
        {
            Debug.Log($"Key: {key}, List: {dicoByRankGo[key]}");
            foreach(GameObject gameObject in dicoByRankGo[key])
            {
                gameObject.SetActive(rank == key);
            }
        }

        /*for(int i = 0;i<dicoByRankGo.Count;i++)
        {
            Debug.Log(i);
            for(int j = 0;j<dicoByRankGo[(ERank)i].Count;i++)
            {
                dicoByRankGo[(ERank)i][j].SetActive(rank == (ERank)i);
            }
        }*/
    }

}
