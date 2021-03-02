using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    public Slider Slider, MinValSlider;

    public TMP_Text Clock;
   

    private int ReverseCounter; //negative force
    private float ReverseSpeed; //time between subtraction
    private int MinimumScore; //Score to win
    private int MaximumScore; //Total Score
    public int Multiplyer; //boost score
    private float Timer;

    private bool GameOver;

    // Start is called before the first frame update
    void Start()
    {
        //Player.GetComponent<PlayerControls>().TapCounter = 0;
        /* GameOver = false;
         ReverseCounter = 0;
         ReverseSpeed = 2;
         MinimumScore = 10;
         Timer = 10;*/

        NewLevel();

        Slider.maxValue = MaximumScore;
        MinValSlider.maxValue = MaximumScore;
        MinValSlider.value = MinimumScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver == false)
        {

            
            

            if (ReverseSpeed > 0)
            {
                ReverseSpeed -= Time.deltaTime;
                if (ReverseSpeed <= 0)
                {
                    Player.GetComponent<PlayerControls>().TapCounter -= ReverseCounter;
                    ReverseSpeed = 2;
                }
            }

            if (Timer <= 0)
            {
                Timer = 0;
                GameOver = true;
            }

            UpdateUI(Timer, Player.GetComponent<PlayerControls>().TapCounter);
        }

        if(GameOver == true)
        {
            WinResults();
        }

       
    }

    public void UpdateUI(float timer, int tapCounter)
    {
        Clock.text = Mathf.FloorToInt(timer % 60).ToString() + "." +(Mathf.FloorToInt(timer * 1000) % 1000).ToString("D2");
        Slider.value = tapCounter;
    }

    public void NewLevel()
    {
        Player.GetComponent<PlayerControls>().TapCounter = 0;
        GameOver = false;
        ReverseCounter = 1;
        ReverseSpeed = Random.Range(0.5f, 3);
        Timer = Random.Range(10, 30);
        MinimumScore = (int)(5f*Timer - Timer / ReverseSpeed);
        MaximumScore = (int)(10f * Timer);

        if (MinimumScore <= 0)
        {
            ReverseSpeed = Random.Range(0.5f, 3);
            Timer = Random.Range(10, 30);
            MinimumScore = (int)(5f * Timer - Timer / ReverseSpeed);
            MaximumScore = (int)(10f * Timer);
        }

        Slider.maxValue = MaximumScore;
        MinValSlider.maxValue = MaximumScore;
        MinValSlider.value = MinimumScore;
    }

    public bool WinResults()
    {
        if (Player.GetComponent<PlayerControls>().TapCounter >= MinimumScore)
            return true;
        else
            return false;
    }

    public void StartTimer()
    {
        Timer -= Time.deltaTime;
    }
}
