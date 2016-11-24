using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WordGenerater : MonoBehaviour
{
    private List<string> words = new List<string>();
    private List<string> words1 = new List<string>();
    private List<string> words2 = new List<string>();
    private List<string> words3 = new List<string>();
    private int index;
    private string word;
    private int wordCounter;
    private bool horde1;
    private bool horde2;
    private bool horde3;
    private bool endBoss;

    void Start () {
            words.Add("brussel");
            words.Add("donker");
            words.Add("fantasie");
            words.Add("glimlach");
            words.Add("lepeltje");

            words1.Add("camera");
            words1.Add("elleboog");
            words1.Add("geloof");
            words1.Add("medewerking");
            words1.Add("personeel");
            words1.Add("woordenboek");

            words2.Add("accepteren");
            words2.Add("kersenpit");
            words2.Add("benzine");
            words2.Add("kettinkje");
            words2.Add("merkwaardig");
            words2.Add("redactie");
            words2.Add("tandarts");
            words2.Add("thermometer");

            words3.Add("juwelier");
            words3.Add("waterpeil");
            words3.Add("lekkage");
            words3.Add("vermoedelijk");
            words3.Add("veroorloven");
    }

    public string getRandomWord()
    {
        if (horde1)
        {
            index = Random.Range(0, words.Count);
            word = words[index];
            words.RemoveAt(index);
            horde1 = false;
        }
        if (horde2)
        {
            index = Random.Range(0, words1.Count);
            word = words1[index];
            words1.RemoveAt(index);
            horde2 = false;
        }
        if(horde3)
        {
            index = Random.Range(0, words2.Count);
            word = words2[index];
            words2.RemoveAt(index);
            horde3 = false;
        }
        if(endBoss)
        {
            index = Random.Range(0, words3.Count - 1);
            word = words3[index];
            words3.RemoveAt(index);
            endBoss = false;
        }
        return word;
    }

    public void horde1true()
    {
        horde1 = true;
    }

    public void horde2true()
    {
        horde2 = true;
    }

    public void horde3true()
    {
        horde3 = true;
    }

    public void Endbosstrue()
    {
        endBoss = true;
    }

    public int getCounter()
    {
        return wordCounter;
    }

    public void upCounter()
    {
        wordCounter++;
    }
}
