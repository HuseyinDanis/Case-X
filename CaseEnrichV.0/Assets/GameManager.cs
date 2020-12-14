using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  int gridSize;
    public GameObject GridMemberPrefab;


    public GameObject[,] grid;

    private int cols, rows;
    private float vertical, horizontal;

    private GridMmberControl gridMemberScript;

    private UIcontroller UIcontroller;
    public GameObject UIcontrollerObj;


    public GameObject mainCamera;

    private float gridFitMultiplayer = 1.25f;
    // Start is called before the first frame update // 1000px

    float cubeSize;
    float sizeMultiplayer;



    public int matchCounterGM;
    void Start()
    {
        

        

    }
    public void matchCounter()
    {
        matchCounterGM++;
        UIcontroller.CounterText(matchCounterGM);
       

    }
    public void GameStart()
    {
        UIcontroller = UIcontrollerObj.GetComponent<UIcontroller>();
        gridSize = UIcontroller.GetComponent<UIcontroller>().sizeFromInput;

        cubeSize = (1000f) / gridSize;    //
        sizeMultiplayer = cubeSize / 100f;


        gridFitMultiplayer = sizeMultiplayer;  //2küp arası 100



        cols = gridSize + 2;   //+1 çünkü çerçeve oyun alanına girmiyor
        rows = gridSize + 2;


        grid = new GameObject[rows, cols];
        GenerateGrid();



       

        CamFocus();
    }
    public void CamFocus()
    {
        int lengt0 = grid.GetLength(0);
        int lengt1 = grid.GetLength(1);
        GameObject referenceMiddleMember = grid[lengt0 / 2, lengt1 / 2];   // ortadaki gridMemberi transformunu kullanmak üzere alıyoruz
        mainCamera.transform.position = new Vector3(referenceMiddleMember.transform.position.x, referenceMiddleMember.transform.position.y, mainCamera.transform.position.z);

    }
  
   

    public void GenerateGrid()
    {
        for (int i = 0; i < cols; i++)
        {
            
            for (int j = 0; j < rows; j++)
            {
                
                
                SpawnGridMember(j, i);
            }
        }

    }

    public void SpawnGridMember(int j, int i)
    {
        grid[j, i] = (GameObject)Instantiate(GridMemberPrefab, new Vector2(j, i), Quaternion.identity) ;

        GameObject accesPrefabs = grid[j, i];
        accesPrefabs.transform.parent = transform;

        gridMemberScript = accesPrefabs.GetComponent<GridMmberControl>();
        gridMemberScript.memberX = j;
        gridMemberScript.memberY = i;
        float posX = j * gridFitMultiplayer;
        float posY = i * -gridFitMultiplayer;
        accesPrefabs.transform.position = new Vector2(posX,posY);
        
        grid[j,i].transform.localScale *= sizeMultiplayer;
        

        gridMemberScript.GM = this;

       


        invisbleGrid(j, i);




    }
    public void invisbleGrid(int j , int i)
    {
        if ( i == rows-1 && j ==0)
        {
            SetFalseOutOfGrid(j,i);
        }
        else if (i==rows-1 &&  j !=0 && j != cols -1)
        {
            SetFalseOutOfGrid(j, i);
        }
        else if (i == rows - 1 && j == cols-1 )
        {
            SetFalseOutOfGrid(j, i);
        }
        else if (j == 0  && i != 0)
        {
            SetFalseOutOfGrid(j, i);
        }
        else if (j == cols - 1 && i != 0 && i != rows-1)
        {
            SetFalseOutOfGrid(j, i);
        }
        else if (j == 0 && i == 0)
        {
            SetFalseOutOfGrid(j, i);
        }
        else if (j != 0 && j != cols - 1 && i ==0)
        {
            SetFalseOutOfGrid(j, i);
        }
        else if (j == cols - 1 && i == 0)
        {
            SetFalseOutOfGrid(j, i);
        }
    }
    public void SetFalseOutOfGrid(int j, int i)
    {
        grid[j, i].SetActive(false);
    }
}
