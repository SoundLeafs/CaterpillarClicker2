using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//need this to use math functions
using System;
using System.Runtime.CompilerServices;

public class ClickerCalculator : MonoBehaviour
{
    public int itemNo;
    public int item1Level;
    public int item2Level;
    public int item3Level;
    public int item4level;
    public int item5level;
    public int item6Level;
    public int item7Level;
    public int item8Level;
    public int item9Level;
    public Text textItem1;
    public Text textItem2;
    public Text textItem3;
    public Text textItem4;
    public Text textItem5;
    public Text textItem6;
    public Text textItem7;
    public Text textItem8;
    public Text textItem9;

    //Show Levels of items
    public Text item1LVtxt;
    public Text item2LVtxt;
    public Text item3LVtxt;
    public Text item4LVtxt;
    public Text item5LVtxt;
    public Text item6LVtxt;
    public Text item7LVtxt;

    //Skills text box

    public Text skill1Text;
    public Text skill2Text;
    public Text skill3Text;

    //Sprites for AutoEat, using gameobject to keep attached animation vs sprite
    public GameObject humanArmySprite;
    public GameObject insectArmySprite;
    public GameObject armsSprite;
    public Transform parentTransform;
    //made a oublic canvas
    public Canvas canvas1;

    //Slider related
    public Slider sliderSkill01;
    public Slider sliderSkill02;
    public Slider sliderSkill03;

    //Caterpillar animations sprites
    
    [SerializeField] GameObject _showCater1;
    
    [SerializeField] GameObject _showCater2;
   
    [SerializeField] GameObject _showCater3;
    
    [SerializeField] GameObject _showCater4;
    
    [SerializeField] GameObject _showCater5;

    public int unlock = 1;

    //this function will set the caterpillar image based in what has been unlocked
    public void SetCater()    
    {
        switch (unlock) 
        {
                case 1:
               
                break;

                case 2:
                //show 2nd image and hide first
                _showCater2.SetActive(true);
                _showCater1.SetActive(false);
                break;

                case 3:
                _showCater3.SetActive(true);
                _showCater2.SetActive(false);
                break;

                case 4:
                //show 2nd image and hide first
                _showCater4.SetActive(true);
                _showCater3.SetActive(false);
                break;

                case 5:
                //show 2nd image and hide first
                _showCater5.SetActive(true);
                _showCater4.SetActive(false);
                break;

        } 

    }

    public void SetSlider01()
    {
        sliderSkill01.value = 0.5f;
    }

    public void SetSlider02(int time)
    {
        sliderSkill01.value = Mathf.Clamp01(skills2Cooldown/60);
    }

    public void SetSlider03(int time)
    {
        sliderSkill01.value = Mathf.Clamp01(skills3Cooldown/90);
    }


    //Audio stuff
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3, sfx4, sfx5, sfx6;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject canvas;

    public static bool showItemBox1 = false;
    [SerializeField] GameObject _showItemBox1;

    public static bool showItemBox2 = false;
    [SerializeField] GameObject _showItemBox2;

    public static bool showItemBox3 = false;
    [SerializeField] GameObject _showItemBox3;

    public static bool showItemBox4 = false;
    [SerializeField] GameObject _showItemBox4;

    public static bool showItemBox5 = false;
    [SerializeField] GameObject _showItemBox5;

    public static bool showItemBox6 = false;
    [SerializeField] GameObject _showItemBox6;

    public static bool showItemBox7 = false;
    [SerializeField] GameObject _showItemBox7;

    public static bool showItemBox8 = false;
    [SerializeField] GameObject _showItemBox8;

    public static bool showItemBox9 = false;
    [SerializeField] GameObject _showItemBox9;

    //Item level description

    public static bool showItemLV1Box = false;
    [SerializeField] GameObject _showItemLv1Box;

    public static bool showItemLV2Box = false;
    [SerializeField] GameObject _showItemLv2Box;
    
    public static bool showItemLV3Box = false;
    [SerializeField] GameObject _showItemLv3Box;

    public static bool showItemLV4Box = false;
    [SerializeField] GameObject _showItemLv4Box;

    public static bool showItemLV5Box = false;
    [SerializeField] GameObject _showItemLv5Box;

    public static bool showItemLV6Box = false;
    [SerializeField] GameObject _showItemLv6Box;

    public static bool showItemLV7Box = false;
    [SerializeField] GameObject _showItemLv7Box;

    //skills box
    public static bool showSkillsBox1 = false;
    [SerializeField] GameObject _showSkillsBox1;

    public static bool showSkillsBox2 = false;
    [SerializeField] GameObject _showSkillsBox2;

    public static bool showSkillsBox3 = false;
    [SerializeField] GameObject _showSkillsBox3;



    //Skills Bool
    public static bool skills1Active;
    public static bool skills1Bought;
    public static int skills1Cooldown;
    public static int skills1ActiveTime;

    public static bool skills2Active;
    public static bool skills2Bought;
    public static int skills2Cooldown;
    public static int skills2ActiveTime;

    public static bool skills3Active;
    public static bool skills3Bought;
    public static int skills3Cooldown;
    public static int skills3ActiveTime;

    //Create new sprite function
    /*
     * Looks like i dont need this after all
    void CreateNewInsect()
    {
        GameObject newGameObject = Instantiate(insectArmySprite);
        RectTransform rectTransform = newGameObject.AddComponent<RectTransform>();
    }
    */

    //Hide TextBox when not in use

    //My delayfunction, call this to wait 0.1 before continueing
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        Debug.Log("CoRoutine Working");
    }

    #region Show Clicks
    public void ShowClicks(string text)
        //This Method will turn clicks into floating text
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, canvas.transform);
            prefab.GetComponentInChildren<Text>().text = text;
        }
    }
    #endregion


    //create an array with all variables for items, eg array is 9X3 so nine arrays with three objects each, will contain (Item name, price, value of mulriplier)
    //Nevermind I need them to all be int, so just price and value 9,2
    //this array is public so can be edit in ItemPriceArray Under Game
    public int[] itemPriceArray = new int[9]; 

    //Create array with variables for ClickGain
    public int[] itemEatRate = new int[9];

    //Create array with variables for AutoClickGain
    public int[] itemAutoRate= new int[9];


    private void Start()
    {
        item1Level= 1;
        item2Level= 1;
        item3Level= 1;
        item4level= 1;
        item5level= 1;
        item6Level= 1;
        item7Level= 1;
        item8Level= 1;
        item9Level =1;    
        itemNo= 0;

        humanArmySprite.SetActive(false);
        insectArmySprite.SetActive(false);
        armsSprite.SetActive(false);
        _showCater1.SetActive(true);
        _showCater2.SetActive(false);
        _showCater3.SetActive(false);
        _showCater4.SetActive(false);
        _showCater5.SetActive(false);



    }

    

    #region Skills Methods
    public void Skill1Activate()
        //triple click, all clicks worth triple
    {
        //Check if we have purchased skill, if yes then go to next line, else purchase or play bad sounds
        if (skills1Bought)
        {
            //if cooldown is 0 then we can use 
            if (skills1Cooldown <=0)
            {
                skills1Active= true;
                Debug.Log("Skill1 is active");
                //set cooldown to 30 seconds
                skills1Cooldown= 30;
                skills1ActiveTime= 10;
            }   
        }

        else
        {
            //if we dont have it and click and we have >5000 then we buy it
            if (GameManager.foodResource >= 5000)
            {
                GameManager.foodResource -= 5000;
                skills1Bought = true;
                src.clip = sfx1;
                src.Play();
               
              
            }
            else
            {
                src.clip = sfx2;
                src.Play();
            }
        }
       

    }

    public void Skill2Activate()
    {
        //Check if we have purchased skill, if yes then go to next line, else purchase or play bad sounds
        if (skills2Bought)
        {
            //if cooldown is 0 then we can use 
            if (skills2Cooldown <= 0)
            {
                skills2Active = true;
                //set cooldown to 60 seconds
                skills2Cooldown = 60;
                skills2ActiveTime= 15;
                Debug.Log("Skill2 is active");
            }
        }

        else
        {
            //if we dont have it and click and we have >5000 then we buy it
            if (GameManager.foodResource >= 7500)
            {
                GameManager.foodResource -= 7500;
                skills2Bought = true;
                src.clip = sfx1;
                src.Play();
               
               
            }
            else
            {
                src.clip = sfx2;
                src.Play();
            }
        }
    }
    
    public void Skill3Activate()
    {
        //Check if we have purchased skill, if yes then go to next line, else purchase or play bad sounds
        if (skills3Bought)
        {
            //if cooldown is 0 then we can use 
            if (skills3Cooldown <= 0)
            {
                skills3Active = true;
                //set cooldown to 90 seconds
                skills3Cooldown = 90;
                skills3ActiveTime= 15;
                Debug.Log("Skill3 is Active");
            }
        }

        else
        {
            //if we dont have it and click and we have >5000 then we buy it
            if (GameManager.foodResource >= 10000)
            {
                GameManager.foodResource -= 10000;
                skills3Bought = true;
                src.clip = sfx1;
                src.Play();


            }
            else
            {
                src.clip = sfx2;
                src.Play();
            }
        }
    }

    #endregion

    public void Eating()
        //this is code applied when we click the apple
    {


        if (GameManager.tripleHead == true)
        {
            if (skills1Active)
            {
                //run 3 times
                for (int i = 0; i < 3; i++)
                {
                    ShowClicks((3 * GameManager.eatRate).ToString());
                    GameManager.foodResource += 3 * GameManager.eatRate;
                    //if we have triple head then all clicks are worth triple
                    GameManager.totalFoodConsumed += 3 * GameManager.eatRate;
                    //update the total food consumed
                    StartCoroutine(WaitCoroutine());
                }
            }
            else
            {
                ShowClicks((3 * GameManager.eatRate).ToString());
                GameManager.foodResource += 3 * GameManager.eatRate;
                //if we have triple head then all clicks are worth triple
                GameManager.totalFoodConsumed += 3 * GameManager.eatRate;
                //update the total food consumed
            }


        }

        else if (GameManager.doubleHead == true)

        {
            if (skills1Active)
            {
                //we run 3 times if skills1active
                for (int i = 0; i < 3; i++)
                {
                    ShowClicks((2 * GameManager.eatRate).ToString());
                    GameManager.foodResource += 2 * GameManager.eatRate;
                    //if we have double head then all clicks are worth double
                    GameManager.totalFoodConsumed += 2 * GameManager.eatRate;
                    //update the total food consumed
                    StartCoroutine(WaitCoroutine());

                }

            }
            else
            {
                ShowClicks((2 * GameManager.eatRate).ToString());
                GameManager.foodResource += 2 * GameManager.eatRate;
                //if we have double head then all clicks are worth double
                GameManager.totalFoodConsumed += 2 * GameManager.eatRate;
                //update the total food consumed
            }



        }   
       
        

        else
        {
            if (skills1Active) 
            {
                for (int i = 0; i < 3; i++)
                {
                    ShowClicks(GameManager.eatRate.ToString());
                    GameManager.foodResource += GameManager.eatRate;
                    //if we have neither of these then all clicks are worth 1 x whatever other additons we have earned
                    GameManager.totalFoodConsumed += GameManager.eatRate;
                    //update the total food consumed
                    StartCoroutine(WaitCoroutine());
                }
            }
            else
            {
                ShowClicks(GameManager.eatRate.ToString());
                GameManager.foodResource += GameManager.eatRate;
                //if we have neither of these then all clicks are worth 1 x whatever other additons we have earned
                GameManager.totalFoodConsumed += GameManager.eatRate;
                //update the total food consumed
            }


        }

    }

    public void Shopping(int num)
        //this is the code we run when clicking on a Item to buy
    {
        switch (num)
        {
            case 1:
                //Teeth Item
                int foodCost = itemPriceArray[0] * item1Level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += itemEatRate[0];
                    GameManager.autoEatRate += itemAutoRate[0];
                    src.clip = sfx1;
                    src.Play();
                    item1Level++;
                    MouseOver(1);
                    if (2>unlock)
                    {
                        unlock = 2;
                        SetCater();    
                    }
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
              
                break;
                
            case 2:
                //DoubleHead item
                foodCost = itemPriceArray[1] * item2Level;
                if ((GameManager.foodResource >= foodCost) && GameManager.doubleHead == false)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.doubleHead= true;
                    src.clip = sfx1;
                    src.Play();
                    MouseOver(2);
                    if (3 > unlock)
                    {
                        unlock = 3;
                        SetCater();
                    }
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 3:
                //Insect Army
                foodCost = itemPriceArray[2] * item3Level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += itemEatRate[2];
                    GameManager.autoEatRate += itemAutoRate[2]; 
                    src.clip = sfx1;
                    src.Play();
                    item3Level++;
                    MouseOver(3);
                    //Create a new sprite which has animation
                    // Sprite newSprite = Instantiate(insectArmySprite); This did not work, only does sprite with no animation? Not on canvas? Dunno
                    //did not give any world direction, hopefully takes from parent
                    //This works but does not appear on canvas
                    //GameObject newGameObject = Instantiate(insectArmySprite, parentTransform);
                    //This was bad for performance, just gonna have one
                    insectArmySprite.SetActive(true);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 4:
                //Blackhole Stomach
                foodCost = itemPriceArray[3] * item4level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate +=  itemEatRate[3];
                    GameManager.autoEatRate += itemAutoRate[3];
                    src.clip = sfx1;
                    src.Play();
                    item4level++;
                    MouseOver(4);
                    if (4 > unlock)
                    {
                        unlock = 4;
                        SetCater();
                    }
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 5:
                //Human Army
                foodCost = itemPriceArray[4] * item5level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate +=  itemEatRate[4];
                    GameManager.autoEatRate += itemAutoRate[4];
                    src.clip = sfx1;
                    src.Play();
                    item5level++;
                    MouseOver(5);
                    humanArmySprite.SetActive(true);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 6:
                foodCost = itemPriceArray[5] * item6Level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += itemEatRate[5];
                    GameManager.autoEatRate +=  itemAutoRate[5]; 
                    src.clip = sfx1;
                    src.Play();
                    item6Level++;
                    MouseOver(6);
                    armsSprite.SetActive(true);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 7:
                foodCost = itemPriceArray[6] * item7Level;
                if (GameManager.foodResource >= foodCost && GameManager.tripleHead == false)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.tripleHead= true;
                    src.clip = sfx4;
                    src.Play();
                    MouseOver(7);
                    if (5 > unlock)
                    {
                        unlock = 5;
                        SetCater();
                    }
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 8:
                //not in use
                foodCost = itemPriceArray[7] * item8Level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate +=  itemEatRate[7];
                    GameManager.autoEatRate += itemAutoRate[7];
                    src.clip = sfx1;
                    src.Play();
                    item8Level++;
                    MouseOver(8);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 9:
                //not in use
                foodCost = itemPriceArray[8] * item9Level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += itemEatRate[8];
                    GameManager.autoEatRate +=  itemAutoRate[8]; 
                    src.clip = sfx1;
                    src.Play();
                    item9Level++;
                    MouseOver(9);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;
        }
    }
    public void MouseOver(int num)
    //this is the code we run when clicking on a Item to buy
    {
        switch (num)
        {
            case 1:
                //Bite
                //Math Pow will multiple the first number (10) by the next number after comma (item1level)
                _showItemBox1.SetActive(true);
                textItem1.text = "Cost = "+ itemPriceArray[0] * item1Level + "\n Gain + 1 Food Per Click";
                
                break;

            case 2:
                //Double Head
                if (GameManager.doubleHead == false)
                    //if we dont have double head display price, if we do then dont
                {
                    _showItemBox2.SetActive(true);
                    textItem2.text = "Cost = " + itemPriceArray[1] * item2Level + "\n All Clicks worth Double";
                    break;
                }
                break;

            case 3:
                //Insect Army
                _showItemBox3.SetActive(true);
                textItem3.text = "Cost = " + itemPriceArray[2] * item3Level + "\n Gain + 2 Auto Eat";
                break;

            case 4:
                //Blackhole Stomach
                _showItemBox4.SetActive(true);
                textItem4.text = "Cost = " + itemPriceArray[3] * item4level + "\n Gain + 25 Food Per Click";
                break;

            case 5:
                //Human Army
                _showItemBox5.SetActive(true);
                textItem5.text = "Cost = " + itemPriceArray[4] * item5level + "\n Gain + 15 Auto Eat";
                break;

            case 6:
                //Arms
                _showItemBox6.SetActive(true);
                textItem6.text = "Cost = " + itemPriceArray[5] * item6Level + "\n +15 per click and +15 Auto";
                break;

            case 7:
                //Dragon Head
                if (GameManager.tripleHead == false)
                    //if we dont have triple head
                {
                    _showItemBox7.SetActive(true);
                    textItem7.text = "Cost = " + itemPriceArray[6] * item7Level + "\n All Clicks worth TRIPLE";
                    break;
                }
               
                break;

                //SKILLS BELOW

            case 8:
                //Skill 1
                _showSkillsBox1.SetActive(true);
                if (skills1Bought)
                {
                    skill1Text.text = "Triple-Click: Active for 15Seconds \n 60 Second Cooldown";
                }
                else
                {
                    skill1Text.text = "$5,000 Unlock Triple-click";
                }
                
                break;

            case 9:
                //Skill 2
                _showSkillsBox2.SetActive(true);
                if (skills2Bought)
                {
                    skill2Text.text = "Propaganda: Increase rate of Auto-Clicks by 3x \n Active 15 Seconds, 60 Second Cooldown";
                    break;
                }
                else
                {
                    skill2Text.text = "$7,500 Unlock Propaganda";
                    break;
                }
               

            case 10:
                //Skill 3
                _showSkillsBox3.SetActive(true);
                if (skills3Bought)
                {
                    skill3Text.text = "Magnet: Brings back the money spent on your last upgrade, \n 60 Second Cooldown";
                    break;
                }
                else
                {
                    skill3Text.text = "$10,000 Unlock Resource Magnet";
                    break;
                }
                

        }
    }

   

    public void MouseAway(int num)
    //this is the code we run when clicking on a Item to buy
    {
        switch (num)
        {
            case 1:
                item1LVtxt.text = "Bite \n Lv" + item1Level;
                _showItemLv1Box.SetActive(true);
                _showItemBox1.SetActive(false);
                break;

            case 2:
                item2LVtxt.text = "Twin Head = " + GameManager.doubleHead;
                _showItemLv2Box.SetActive(true);
                _showItemBox2.SetActive(false);
                break;
                

            case 3:
                item3LVtxt.text = "InsectArmy \n Lv" + item3Level;
                _showItemLv3Box.SetActive(true);
                _showItemBox3.SetActive(false);
                break;

            case 4:
                item4LVtxt.text = "Blackhole Stomach \n Lv" + item4level;
                _showItemLv4Box.SetActive(true);
                _showItemBox4.SetActive(false);
                break;

            case 5:
                item5LVtxt.text = "Human Army \n Lv" + item5level;
                _showItemLv5Box.SetActive(true);
                _showItemBox5.SetActive(false);
                break;

            case 6:
                item6LVtxt.text = "Grabby Hands \n Lv" + item6Level;
                _showItemLv6Box.SetActive(true);
                _showItemBox6.SetActive(false);
                break;;

            case 7:
                item7LVtxt.text = "Dragon Head = " + GameManager.tripleHead;
                _showItemLv7Box.SetActive(true);
                _showItemBox7.SetActive(false);
                break;

                //SKILLS BELOW

            case 8:
                //not in use
                
               
                _showSkillsBox1.SetActive(false);
                break;

            case 9:
                //not in use
              
                _showSkillsBox2.SetActive(false);
                break;

            case 10:
                _showSkillsBox3.SetActive(false); 
                break;
        }
    }
}
