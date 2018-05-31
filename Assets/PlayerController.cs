using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2d;

    Animator anim;

    SpriteRenderer sr;
    public static int life = 3;
    bool isColi = false;
    private Sprite currentSprite;
	public GameObject GOUI;
    float nextImmortalTime = 0f;
    // Use this for initialization

    void Awake(){
        Application.targetFrameRate = 600;
    }
    void Start()
    {
        
    	QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
        currentSprite = sr.sprite;
    }

    public int target = 60;

    // Update is called once per frame
    void Update()
    {

        if( target != Application.targetFrameRate){
            Application.targetFrameRate = target;
        }
        transform.Translate(Vector3.right * 0.2f);
        // Jumping
        if (Input.GetKey(KeyCode.UpArrow) && isColi)
        {
            rb2d.velocity = new Vector2(0, 19);
        }

        if (Input.GetKey(KeyCode.DownArrow) && isColi){
            anim.SetBool("isSlide", true);
		}

        if (Input.GetKeyUp(KeyCode.DownArrow))
            anim.SetBool("isSlide", false);

        if (!currentSprite.Equals(sr.sprite))
        {
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.AddComponent<PolygonCollider2D>();
			currentSprite = sr.sprite;
        }

		if (life <= 0)
        {
            Die();
        }

        if(isImmortal()){
            gameObject.GetComponent<SpriteRenderer>().color =  Color.red;
        }
        else{
            gameObject.GetComponent<SpriteRenderer>().color =  Color.white;
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isColi = true;
        }

        if (other.gameObject.CompareTag("wall"))
        {
            life -= 1;
        }

        if (other.gameObject.CompareTag("ravine"))
        {
            Die();
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
            isColi = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isImmortal())
        {
            if (other.gameObject.CompareTag("wall"))
            {
                life = life - 1;
                nextImmortalTime = Time.time + 3;
                Debug.Log("Hit wall---life: " + life);
            }
        }
        if (other.gameObject.CompareTag("item"))
        {
            other.GetComponent<Item>().getItem(this);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("letter"))
        {
            AnswerBox ab = other.GetComponent<AnswerBox>();
            ab.sentValue(ab.ans);
            Destroy(other.gameObject);
        }
    }

  public void Die()
    {
        GoPlayScene.last = 0;
        GoPrePlayScene.lastScene = 1;
        Destroy(gameObject);
        life = 3;
        HighScore h = HighScore.LoadHighScore();
        h.Add(UIController.score,GetName.getName(),h);
        HighScore.SaveHighScore(h);
        UIController.score = 0;
		Instantiate(GOUI);

    }

    public void setNextImmortalTime(float t)
    {
        nextImmortalTime = Time.time + t;
    }
    public bool isImmortal()
    {
        if (nextImmortalTime > Time.time)
            return true;
        return false;
    }
}
