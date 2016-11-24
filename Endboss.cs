using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endboss : MonoBehaviour {
    //Movement
    private GameObject player;
    private int lives = 3;
    private Vector3 position;
    //Text Fields and words
    private GameObject inputField;
    public Canvas inputBox;
    private SoundManager audioHandler;
    private WordGenerater generater;
    private string word;
    private string awnser;
    //Encounter
    private bool notSelected;
    private bool setFalse;
    private bool encounterd;
    private float timer;
    private float deathTimer;
    private AudioClip audio2;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        generater = GameObject.Find("WordGen").GetComponent<WordGenerater>();
        inputField = GameObject.Find("Input");
        audioHandler = GameObject.Find("WordGen").GetComponent<SoundManager>();
        timer = 0;
        notSelected = true;
        setFalse = true;
    }

    // Update is called once per frame
    void Update()
    {
        encounter();
        detectCollsion();
    }

    private void encounter()
    {
        if (encounterd)
        {
            setWord();
            if (setFalse && !notSelected)
            {
                timer += Time.deltaTime;
                playAudio();
            }
            if (timer >= 1f)
            {
                setFalse = false;
                inputField.GetComponent<Text>().text = "";
                inputBox.enabled = true;
                timer += Time.deltaTime;
            }
            if (timer >= 10)
            {
                awnser = inputField.GetComponent<Text>().text;
                inputBox.enabled = false;
                if (awnser == word)
                {
                    print("goed gedaan!");
                    player.GetComponent<Player>().addScore(10);
                    generater.upCounter();
                    player.GetComponent<Player>().setEncounter(false);
                    reset();

                }
                if (awnser != word)
                {
                    print("helaas, dat is fout");
                    player.GetComponent<Player>().applyDamage(1);
                    generater.upCounter();
                    player.GetComponent<Player>().setEncounter(false);
                    reset();
                }
            }
        }
    }

    private void setWord()
    {
        if (notSelected)
        {
            generater.Endbosstrue();
            word = generater.getRandomWord();
            audio2 = new AudioClip();
            audio2 = audioHandler.getAudio(word);
            notSelected = false;
        }
    }

    private void playAudio()
    {
        AudioSource source = audioHandler.gameObject.GetComponent<AudioSource>();
        source.clip = audio2;
        source.Play();
    }

    private void detectCollsion()
    {
        Vector3 enemyPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y);
        if (playerPos.x >= (enemyPos.x - 5) && playerPos.x <= (enemyPos.x + 5)) encounterd = true;
    }

    private void reset()
    {
        if(lives >= 0)
        {
            Start();
            lives--;
        }
        if(lives <= 0)
        {
            Destroy(this.gameObject);
            deathTimer += Time.deltaTime;
            if(deathTimer >= 3)SceneManager.LoadScene("Menu");
        }
    }

    public string giveEnemy()
    {
        return "Endboss";
    }
}
