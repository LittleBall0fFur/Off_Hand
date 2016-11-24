using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Horde3 : MonoBehaviour
{
    //Movement
    private GameObject player;
    private int counter;
    private Vector3 position;
    //Text Fields and words
    private GameObject inputField;
    public Canvas inputBox;
    private SoundManager audioHandler;
    private WordGenerater generater;
    private string word;
    private string awnser;
    //Encounter
    private bool notSelected = true;
    private bool setFalse = true;
    private bool encounterd;
    private float timer;
    private AudioClip audio2;
    // Use this for initialization
    void Start()
    {
        generater = GameObject.Find("WordGen").GetComponent<WordGenerater>();
        inputField = GameObject.Find("Input");
        audioHandler = GameObject.Find("WordGen").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        encounter();
        detectCollsion();
        if (!encounterd) player.GetComponent<Player>().setEncounter(false);
    }

    private void encounter()
    {
        word = null;
        player = GameObject.Find("Player");
        if (encounterd)
        {
            player.GetComponent<Player>().setEncounter(true);
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
                //player.GetComponent<Player>().attackAnimationHandler();
                awnser = inputField.GetComponent<Text>().text;
                inputBox.enabled = false;
                if (awnser == word)
                {
                    print("goed gedaan!");
                    player.GetComponent<Player>().addScore(10);
                    counter++;
                    generater.upCounter();
                    player.GetComponent<Player>().setEncounter(false);
                    Destroy(this.gameObject);
                    timer = 0;
                    encounterd = false;
                }
                if (awnser != word)
                {
                    print("helaas, dat is fout");
                    player.GetComponent<Player>().applyDamage(1);
                    counter++;
                    generater.upCounter();
                    player.GetComponent<Player>().setEncounter(false);
                    Destroy(this.gameObject);
                    timer = 0;
                    encounterd = false;
                }
            }
        }
    }

    private void setWord()
    {
        if (notSelected)
        {
            generater.horde3true();
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
        if (playerPos.x >= (enemyPos.x - 4) && playerPos.x <= (enemyPos.x + 4) && playerPos.y >= (enemyPos.y - 3) && playerPos.y <= (enemyPos.y + 3)) encounterd = true;
    }

    public string giveEnemy()
    {
        return "Horde3";
    }
}
