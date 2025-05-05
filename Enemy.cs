using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public bool isAttacked;

    //Health Bar
    public HealthBar healthBar; //reference to Health Bar script

    // Mana Bar
    public ManaBar manaBar; //reference to Mana Bar script

    public UI gm;

    //enemy moves
    public string move1;
    public string move2;
    public string special;

    //enemy hp and mp
    public int hp;
    public int mp;
    public int currentHealth; //store character's current health
    public int currentMana; //store character's current Mana 

    public string enemyName;

    public int movesLeft = 1;

    public int currentOpponent;

    public GabrielScr gScr;
    public MaryScr mScr;
    public FloydScr fScr;

    public bool isChecked = false;

    public Button enemy1Button;
    public Button enemy2Button;
    public Button enemy3Button;


    public Sprite angel;
    public Sprite cherub;
    public Sprite hulaDancer;
    public Sprite tree;
    public Sprite demon;
    public Sprite volcano;
    public Sprite cerebus;

    public bool beatBoss = false;


    //public Sprite angel1;
    // public Sprite angel2;
    //public Sprite gSpecial;





    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {
        if (isChecked == false)
        {


            if (gm.sceneName == "ShaniahScene") //Angels
            {

                if (gm.currentWave == 1)
                {
                    enemy1Button.GetComponent<Image>().sprite = angel;
                    enemy2Button.GetComponent<Image>().sprite = angel;
                    enemy3Button.GetComponent<Image>().sprite = angel;

                    enemyName = "Angel";

                    move1 = "Angel Main Attack"; //-10HP to one character
                    move2 = "Angel Heavy Attack"; //-20HP to one character
                    special = "Angel Beam"; //-5 HP to all of party, -40MP

                    hp = 40;
                    mp = 40;

                    currentHealth = hp;

                    healthBar.SetMaxHealth(hp); //set Angel's max health to hp (100)

                    manaBar.SetMaxMana(40); //set Angel's max mana to 40

                    //manaBar.CurrentValue(0); //set Mana to 0 at the begining of the game

                    isChecked = true;


                }

                if (gm.currentWave == 2) //Cherubs
                {
                    enemy1Button.GetComponent<Image>().sprite = cherub;
                    enemy2Button.GetComponent<Image>().sprite = cherub;
                    enemy3Button.GetComponent<Image>().sprite = cherub;

                    enemyName = "Cherub";

                    //.GetComponent<Image>().sprite = gStanding;

                    move1 = "Cherub Main Attack"; //-5HP to one character
                    move2 = "Cherub Heavy Attack"; //-10HP to one character
                    special = "Cherub's Arrows"; //-15 HP to all of party, -40MP

                    hp = 40;
                    mp = 40;

                    currentHealth = hp;

                    healthBar.SetMaxHealth(hp); //set Gabriel's max health to hp (100)

                    manaBar.SetMaxMana(40); //set Angel's max mana to 40

                    //manaBar.CurrentValue(0); //set Mana to 0 at the begining of the game

                    isChecked = true;

                }

            }


            if (gm.sceneName == "LevelTwo")
            {
                if (gm.currentWave == 1) //Hula Dancers
                {
                    enemy1Button.GetComponent<Image>().sprite = hulaDancer;
                    enemy2Button.GetComponent<Image>().sprite = hulaDancer;
                    enemy3Button.GetComponent<Image>().sprite = hulaDancer;

                    enemyName = "Hula Dancer";

                    move1 = "Hip Bump"; //-10HP
                    move2 = "Spin Attack"; //-15HP
                    special = "Fire Dance"; //-15HP to all enemies, -50MP

                    hp = 50;
                    mp = 50;

                    currentHealth = hp;

                    healthBar.SetMaxHealth(hp); //set Gabriel's max health to hp (100)

                    manaBar.SetMaxMana(50); //set Hula Dancer's max mana to 50

                    //manaBar.CurrentValue(0); //set Mana to 0 at the begining of the game

                    isChecked = true;

                }

                if (gm.currentWave == 2) //Coconut Tree
                {
                    enemy1Button.GetComponent<Image>().sprite = tree;
                    enemy2Button.GetComponent<Image>().sprite = tree;
                    enemy3Button.GetComponent<Image>().sprite = tree;

                    enemyName = "Coconut Tree";

                    move1 = "Coconut Launch"; //-15HP
                    move2 = "Speedy Coconut Launch"; //-20HP 
                    special = "Void Coconut"; //-35HP -30MP

                    hp = 50;
                    mp = 40;

                    currentHealth = hp;

                    healthBar.SetMaxHealth(hp); //set Gabriel's max health to hp (100)

                    manaBar.SetMaxMana(40); //set Coconut Tree's max mana to 40

                    //manaBar.CurrentValue(0); //set Mana to 0 at the begining of the game

                    isChecked = true;

                }


            }

            if (gm.sceneName == "LevelThree")
            {
                if (gm.currentWave == 1)
                {
                    enemy1Button.GetComponent<Image>().sprite = demon;
                    enemy2Button.GetComponent<Image>().sprite = demon;
                    enemy3Button.GetComponent<Image>().sprite = demon;

                    enemyName = "Demon";

                    move1 = "Pitchfork Stab"; //-10HP
                    move2 = "Flaming Pitchfork"; //-30HP
                    special = "Flaming Riff"; //-25HP from all players, 40MP

                    hp = 40;
                    mp = 60;

                    currentHealth = hp;

                    healthBar.SetMaxHealth(hp); //set Gabriel's max health to hp (100)

                    manaBar.SetMaxMana(60); //set Demon's max mana to 60

                    //manaBar.CurrentValue(0); //set Mana to 0 at the begining of the game

                    isChecked = true;
                }

                if (gm.currentWave == 2)
                {
                    enemy1Button.GetComponent<Image>().sprite = volcano;
                    enemy2Button.GetComponent<Image>().sprite = volcano;
                    enemy3Button.GetComponent<Image>().sprite = volcano;

                    enemyName = "Volcano";

                    move1 = "Bubble Over"; //-15HP
                    special = "Erupt"; //-35HP to all party, 30MP

                    hp = 50;
                    mp = 30;

                    currentHealth = hp;

                    healthBar.SetMaxHealth(hp); //set Gabriel's max health to hp (100)

                    manaBar.SetMaxMana(30); //set Volcano's max mana to 30

                    //manaBar.CurrentValue(0); //set Mana to 0 at the begining of the game

                    isChecked = true;
                }

                if (gm.currentWave == 3)
                {
                    enemy1Button.GetComponent<Image>().sprite = cerebus;
                    enemy2Button.GetComponent<Image>().sprite = cerebus;
                    enemy3Button.GetComponent<Image>().sprite = cerebus;


                    enemyName = "Cerberus";

                    move1 = "Bite"; //-25HP
                    move2 = "Snap"; //-35HP
                    special = "Tail Whip"; //-35HP to all enemies -40MP

                    hp = 100;
                    mp = 40;

                    currentHealth = hp;

                    healthBar.SetMaxHealth(hp); //set Gabriel's max health to hp (100)

                    manaBar.SetMaxMana(40); //set Cerberus's max mana to 40

                    //manaBar.CurrentValue(0); //set Mana to 0 at the begining of the game

                    isChecked = true;


                }
            }
        }
    }

    public void TakeDamage(int damage) //take a certain amount of damage
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth); //update health bar to match the character's current health
    }

    public void GainMana(int mana) //gain a certain amount of mana  (should increase by 10 after each turn ends)
    {
        //currentMana += 10;

        currentMana += mana;

        manaBar.SetMana(currentMana); //update mana bar to match the character's current mana status
    }

    public void EnemyMove1(int damage)
    {
        currentOpponent = Random.Range(0, 2);

        Debug.Log(move1);

        if (gm.multi == true)
        {
            currentOpponent = 3;
        }

        if (currentOpponent == 0)
        {
            gScr.TakeDamage(damage);
        }
        if (currentOpponent == 1)
        {
            mScr.TakeDamage(damage);
        }
        if (currentOpponent == 2)
        {
            fScr.TakeDamage(damage);
        }
        if (currentOpponent == 3)
        {
            gScr.TakeDamage(damage);
            mScr.TakeDamage(damage);
            fScr.TakeDamage(damage);
        }

    }
    public void EnemyMove2(int damage)
    {
        currentOpponent = Random.Range(0, 2);

        Debug.Log(move2);

        if (gm.multi == true)
        {
            currentOpponent = 3;
        }

        if (currentOpponent == 0)
        {
            gScr.TakeDamage(damage);
        }
        if (currentOpponent == 1)
        {
            mScr.TakeDamage(damage);
        }
        if (currentOpponent == 2)
        {
            fScr.TakeDamage(damage);
        }
        if (currentOpponent == 3)
        {
            gScr.TakeDamage(damage);
            mScr.TakeDamage(damage);
            fScr.TakeDamage(damage);
        }

    }
    public void EnemySpecial(int damage)
    {

        Debug.Log(special);
        currentOpponent = Random.Range(0, 2);
        manaBar.CurrentValue(0);

        if (gm.multi == true)
        {
            currentOpponent = 3;
        }

        if (currentOpponent == 0)
        {
            gScr.TakeDamage(damage);
        }
        if (currentOpponent == 1)
        {
            mScr.TakeDamage(damage);
        }
        if (currentOpponent == 2)
        {
            fScr.TakeDamage(damage);
        }
        if (currentOpponent == 3)
        {
            gScr.TakeDamage(damage);
            mScr.TakeDamage(damage);
            fScr.TakeDamage(damage);
        }

    }

    public void changeMana()
    {
        if (isChecked == false)
        {
            manaBar.CurrentValue(0); //set Mana to 0 at the begining of the game
        }
    }
}
