using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    private GameObject charSelect;
    private int speed;
    private Vector3 zFix;
    private GameObject health;
    private GameObject background;
    private int currentHealth;
    private int score;
    private bool girl;
    private bool boy;
    private bool kingly;
    private bool pirate;
    private bool selected;
    private bool encounter;
    private bool grounded;
    private bool hasJumped;
    [SerializeField]
    private Sprite sprite1;
    [SerializeField]
    private Sprite sprite2;
    [SerializeField]
    private Sprite sprite3;
    [SerializeField]
    private Sprite sprite4;

    private bool jump;
    // Use this for initialization
    void Start () {
        background = GameObject.Find("CharBackground");
        charSelect = GameObject.Find("CharSelect");
        speed = 5;
        health = GameObject.Find("Health");
        currentHealth = 3;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        healthGui();
        Movement();
        checkDeath();
        zFix = new Vector3(transform.position.x, transform.position.y, 312);
        transform.position = zFix;
    }

    private void Movement()
    {
        if (selected && !encounter) {
            RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down, GetComponent<SpriteRenderer>().bounds.extents.y + 0.05f);
            if (rayDown.transform != null)
            {
                grounded = true;
                hasJumped = false;
            }
            if (Input.GetKey("left") || Input.GetKey("right"))
            {
                //walkAnimationHandler();
                var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                transform.position += move * speed * Time.deltaTime;
                if (Input.GetKey("left")) this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                else { if (Input.GetKey("right")) this.gameObject.GetComponent<SpriteRenderer>().flipX = false; }
            }
            if (Input.GetKey("space") && hasJumped == false)
            {
                jump = true;
            }
            if (jump && grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 7f), ForceMode2D.Impulse);
                hasJumped = true;
                jump = false;
            }
        }
    }
    //HUD
    public void addScore(int point)
    {
        score = score + point;
    }

    public int getScore()
    {
        return score;
    }

    //Health
    public void applyDamage(int damage)
    {
        currentHealth = currentHealth - damage;
    }

    private void checkDeath()
    {
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            print("Helaas je hebt verloren van de hordes!");
            SceneManager.LoadScene("Menu");
        }
    }
    
    private void healthGui()
    {
        if(health != null)
        health.GetComponent<Text>().text = "Levens: " + currentHealth + " Punten: " + score;
    }

    public int getHealth()
    {
        return currentHealth;
    }

    private void death()
    {
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene("Menu");
        }
    }

    //Character select
    private void selectChar()
    {
        if (kingly && girl)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
            charSelect.SetActive(false);
            selected = true;
        }
        if (kingly && boy)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
            charSelect.SetActive(false);
            selected = true;
        }
        if (pirate && girl)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
            charSelect.SetActive(false);
            selected = true;
        }
        if (pirate && boy)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite4;
            charSelect.SetActive(false);
            selected = true;
        }
        if (selected == true &&background != null) background.SetActive(false);
    }

    public void setGirl()
    {
        girl = true;
    }

    public void setBoy()
    {
        boy = true;
    }

    public void setKingly()
    {
        kingly = true;
        selectChar();
    }

    public void setPirate()
    {
        pirate = true;
        selectChar();
    }

    public void setEncounter(bool flag)
    {
        encounter = flag;
    }

    private void walkAnimationHandler()
    {
        if (kingly && girl) GetComponent<Animation>().CrossFade("LoopRidderMeisje", 0.25f);//GetComponent<Animation>().Play("LoopAnimatieRidderMeisje");
        if (kingly && boy) GetComponent<Animation>().CrossFade("LoopAnimatieRidderJongen" , 0.25f);
        if(pirate && girl)GetComponent<Animation>().CrossFade("LoopAnimatiePiraatMeisje", 0.25f);
        //if (pirate && boy) this.gameObject.GetComponent<Animation>().CrossFade("LoopPiraatJongen" , 0.25f);
    }

    public void attackAnimationHandler()
    {
        if (kingly && girl) GetComponent<Animation>().CrossFade("AanvalsPrincesMeisje", 0.25f);//GetComponent<Animation>().Play("LoopAnimatieRidderMeisje");
        if (kingly && boy) GetComponent<Animation>().CrossFade("AanvalsPrinceJongen", 0.25f);
        if (pirate && girl) GetComponent<Animation>().CrossFade("AanvalsPiraatMeisje", 0.25f);
        if (pirate && boy) GetComponent<Animation>().CrossFade("AanvalsPiraatJongen", 0.25f);
    }
}
