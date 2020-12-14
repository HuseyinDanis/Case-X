using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMmberControl : MonoBehaviour
{
    public int memberX, memberY =0;

    private bool selected;
    public GameManager GM;
    

    int countAround;

    private GameObject[] aroundChosen;
    private void OnMouseDown()
    {
        Debug.Log("Click");
        //Debug.Log(memberX);
        //Debug.Log(memberY);


        countAround = 0;
        selected = true;
        signIt();
        CheckMatch();
        
    }

    private void CheckMatch()
    {
        
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                
                    checkIt(i, j);
                
                
            }
        }
       
    }
    private void signIt()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    private void unSignIt()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void checkIt(int i, int j)
    {
        
        if (GM.grid[memberX + i, memberY + j] == null) // Etrafında obje varsa
        {


        }
        else
        {
            if (GM.grid[memberX + i, memberY + j].GetComponent<GridMmberControl>().selected == true)  //  Objeler seçilmişse
            {
                if (countAround < 2)

                {
                    
                    countAround++;
                }
                else
                {
                    destroyIt();
                }

            }
        }
    }

    private void destroyIt()
    {
        selected = false;
        unSignIt();
        GM.matchCounter();  // match counter goes GameManager
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {

                if (GM.grid[memberX + i, memberY + j] != null) // Etrafında obje varsa
                {

                    if (GM.grid[memberX + i, memberY + j].GetComponent<GridMmberControl>().selected == true)  // Etrafındaki Objeler seçilmişse
                    {
                        GM.grid[memberX + i, memberY + j].GetComponent<GridMmberControl>().selected = false;  // Objelerin seçimini kaldır ve yok et
                        //GM.grid[memberX + i, memberY + j].SetActive(false);
                        GM.grid[memberX + i, memberY + j].GetComponent<GridMmberControl>().unSignIt();
                    }
                }
            }
        }
    }
}
