using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public int sizeFromInput ;

    private GameManager GM;
    public GameObject GameManager;

    private GameObject GameManagerInstance;



    public InputField SizeInput;
    public Text MatchCount;

    
    private void Awake()
    {
        

        if (sizeFromInput == 0)
        {
            sizeFromInput = 5;
        }

        

        //DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    private void Start()
    {
        GameManagerCreator();
        
    }
    public void CounterText(int matchCounter)
    {
        MatchCount.text = "Match Count = " + matchCounter.ToString();
    }
    public void Rebuild() 
    {

        
        sizeFromInput = int.Parse( SizeInput.text);

        Destroy(GameManagerInstance);
        GameManagerInstance = GameObject.Find("GameManager").gameObject;


        GameManagerCreator();

    }
    public void GameManagerCreator()
    {
        GameObject GM2 = Instantiate(GameManager);
        GameManagerInstance = GM2;
        GM2.GetComponent<GameManager>().GameStart();

        
    }
}
