using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {
    private GameObject boySprite;
    private GameObject girlSprite;
    private GameObject princes;
    private GameObject prince;
    private GameObject pirateBoy;
    private GameObject pirateGirl;
    private GameObject boyTxt;
    private GameObject girlTxt;
    private Player player;
    private bool girl;
    private bool boy;
    private bool pirate;
    private bool kingly;
    private string pickedClass;
    private string sex;
    private int counter;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
        boySprite = GameObject.Find("Jongen");
        girlSprite = GameObject.Find("Meisje");
        princes = GameObject.Find("Prinses");
        prince = GameObject.Find("Prins");
        pirateBoy = GameObject.Find("PiraatTxt");
        pirateGirl = GameObject.Find("PiraatMeisjeTxt");
        boyTxt = GameObject.Find("JongenTxt");
        girlTxt = GameObject.Find("MeisjeTxt");
        if(princes != null)princes.SetActive(false);
        if (prince != null) prince.SetActive(false);
        if (pirateBoy != null) pirateBoy.SetActive(false);
        if (pirateGirl != null) pirateGirl.SetActive(false);
    }

    public void isGirl()
    {
        player.setGirl();
        girl = true;
        counter++;
        if (counter == 1) chooseClass();
        if (counter == 2)
        {
            isPirate();
            this.gameObject.SetActive(false);
        }
    }

    public void isBoy()
    {
        player.setBoy();
        boy = true;
        counter++;
        if (counter == 1) chooseClass();
        if (counter == 2)
        {
            isPirate();
            this.gameObject.SetActive(false);
        }
    }

    public void chooseClass()
    {
        if (boy)
        {
            boyTxt.SetActive(false);
            prince.SetActive(true);
            pirateBoy.SetActive(true);
            girlSprite.SetActive(false);
        }
        if (girl)
        {
            girlTxt.SetActive(false);
            princes.SetActive(true);
            pirateGirl.SetActive(true);
            boySprite.SetActive(false);
        }
    }

    public void isPirate()
    {
        player.setPirate();
    }

    public void isKingly()
    {
        player.setKingly();
    }
}
