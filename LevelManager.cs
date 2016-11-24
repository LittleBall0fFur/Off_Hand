using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    private float timer;
    private WordGenerater wordGen;
    private GameObject player;
    private bool setlvl2;
    private bool setlvl3;

    [SerializeField]
    private int level1Enemies;
    [SerializeField]
    private int level2Enemies;

    void Start()
    {
        //Find GameObjects scripts
        player = GameObject.Find("Player");
        wordGen = GameObject.Find("WordGen").GetComponent<WordGenerater>();
    }

    void Update()
    {
        nextLevel();
    }
    
    private void nextLevel()
    {
        if (wordGen.getCounter() == level1Enemies)
        {
            if (!setlvl2)
            {
                player.transform.position = new Vector3(139, player.transform.position.y, player.transform.position.z);
                setlvl2 = true;
            }
        }
        if (wordGen.getCounter() == level2Enemies)
        {
            if (!setlvl3)
            {
                player.transform.position = new Vector3(262, player.transform.position.y, player.transform.position.z);
                setlvl3 = true;
            }
        }
    }
}
