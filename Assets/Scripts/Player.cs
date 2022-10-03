using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Audio;

public class Player : MonoBehaviour {


    public int maxWeight = 5;
    private int minWeight = 1;
    public int currentWeight;  
    public float velocity = 1f;
    public float repulsionForce;   
    public bool isDead;

    public Level level;

    
    public Animator animator;
    private ParticleSystem ps;
    public Rigidbody2D rb;
    public ExplosionBar explosionBar;


    public CircleCollider2D coll_Weight_4; 
    public CircleCollider2D coll_Weight_3;
    public CircleCollider2D coll_Weight_2;
    public CircleCollider2D coll_Weight_1;
    public BoxCollider2D boxCollider;

    private Shake shake;
    public Score score;
    Touch touch;

    void Start() 
    {
        //INITIALIZE
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
        currentWeight = 2;
        manageColliders();
       
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shake>();

        score = GameObject.Find("Game Controller").GetComponent<Score>();
        explosionBar = GameObject.Find("Explosion Bar").GetComponent<ExplosionBar>();
        explosionBar.SetInitialValues(2, maxWeight);

        boxCollider = GetComponent<BoxCollider2D>();
        ps = GetComponent<ParticleSystem>();

        rb.simulated = true;
    }




    void Update() 
    {
        //Animate if Level is completed
        if(level.isCompleted == true) 
        {            
            disableAllColliders();
          
           rb.simulated = false;                   
        }


        //Jumping

        if ((Input.touchCount > 0) && (level.isCompleted == false)) {

        if (isDead == false) 
            {
                touch = Input.GetTouch(0);

                //If the touch is in the left side of screen
                if ((touch.position.x < Screen.width / 2) && (touch.phase == TouchPhase.Began)) {
                    FindObjectOfType<AudioManager>().Play("jump");
                    rb.velocity = Vector2.up * velocity;
                }           
            }
        }

       

        //Name of the parameter in the animator and value you want to pass
        animator.SetInteger("Weight", currentWeight);  
    }

    
    //To call on Collision (change this to switch statemnt)
    public void OnTriggerEnter2D(Collider2D otherCollider) {

        //IF PLAYER HITS A COOKIE
        if (otherCollider.gameObject.tag == "Cookie") {           
                      
            FindObjectOfType<AudioManager>().Play("Eat");   

            //Manage Player's Weight
            increaseWeight(1);
            manageColliders();
            explosionBar.SetWeight(currentWeight);

        }
        //IF PLAYER HITS A PIE
        else if (otherCollider.gameObject.tag == "Pie") {
           
            FindObjectOfType<AudioManager>().Play("Eat");
            increaseWeight(2);
            manageColliders();
            explosionBar.SetWeight(currentWeight);

        }

        //IF PLAYER HITS A PIZZA
        else if (otherCollider.gameObject.tag == "Pizza") {
           
            FindObjectOfType<AudioManager>().Play("Eat");
            increaseWeight(3);
            manageColliders();
            explosionBar.SetWeight(currentWeight);

        }

        //IF PLAYER HITS A DUMBELL
        else if (otherCollider.gameObject.tag == "Dumbbell") {

            //Update Score
            Score.currentScore++;

            //Play Sound
            FindObjectOfType<AudioManager>().Play("getDB1");           
                    
            //Reduce Weight
            if (currentWeight != minWeight) {
                reduceWeight(1);
                manageColliders();
                explosionBar.SetWeight(currentWeight);
            }

            explosionBar.SetWeight(currentWeight);
        }

        //IF player Hits Super Dumbell
        else if (otherCollider.gameObject.tag == "SuperDumbbell") {
           
            //Update Score
            Score.currentScore += 2;
            
            //Play Sound
            FindObjectOfType<AudioManager>().Play("getDB2");

            //Reduce Weight
            if (currentWeight == 2) {
                reduceWeight(1);
                manageColliders();
                explosionBar.SetWeight(currentWeight);

            } else if (currentWeight != minWeight) {
                reduceWeight(2);
                manageColliders();
                explosionBar.SetWeight(currentWeight);
            }

            explosionBar.SetWeight(currentWeight);
        }

        //UPDATE SCORE UI and check winning conditions
        score.updateCurrentScore();
    }
  
    //Call if player hits something Unhealthy
    void increaseWeight(int changeAmt) {      
       
        currentWeight += changeAmt;
        shake.CamShake();
        //IF PLAYER DIES 
        if (currentWeight >= maxWeight) {
           
            disableAllColliders();
            turnOfRendererAndFreezePlayer();
            ps.Play();
            
            FindObjectOfType<AudioManager>().Play("gameOver");

            StartCoroutine(waitForSeconds());
        }
    }


    //CALLED WHEN PLAYER HITS SOMETHING HEALTHY
    void reduceWeight(int changeAmt) {
        currentWeight -= changeAmt;
     
    }


    public void disableAllColliders() {

            foreach (Collider2D c in GetComponents<Collider2D>()) {
                c.enabled = false;                      
        }
    }

    private void manageBoxCollider() {

        if (!(currentWeight >= maxWeight)) {
            boxCollider.enabled = true;
        }
        else {
            boxCollider.enabled = false;
        }
    }

    public void manageColliders() {

        manageBoxCollider();

        if (currentWeight >= 5) {
            //Deactivate all Circle Colliders
            foreach (CircleCollider2D c in GetComponents<CircleCollider2D>()) {
                c.enabled = false;
            }           
        }
        else if (currentWeight == 4) {            
            coll_Weight_4.enabled = true;
            coll_Weight_3.enabled = false;
            coll_Weight_2.enabled = false;
            coll_Weight_1.enabled = false;
        }
        else if (currentWeight == 3) {
            coll_Weight_4.enabled = false;
            coll_Weight_3.enabled = true;
            coll_Weight_2.enabled = false;
            coll_Weight_1.enabled = false;
        }
        else if (currentWeight == 2) {
            coll_Weight_4.enabled = false;
            coll_Weight_3.enabled = false;
            coll_Weight_2.enabled = true;
            coll_Weight_1.enabled = false;
        }
        else if (currentWeight == 1) {
            coll_Weight_4.enabled = false;
            coll_Weight_3.enabled = false;
            coll_Weight_2.enabled = false;
            coll_Weight_1.enabled = true;
        }
    }
    
    public void turnOfRendererAndFreezePlayer() {
        gameObject.GetComponent<Renderer>().enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY ;
    }

     
    void OnCollisionEnter2D(Collision2D collision) {                    
            if (collision.gameObject.tag == "Low Wall") {
            rb.velocity = Vector2.up * repulsionForce;
            FindObjectOfType<AudioManager>().Play("jump");
        }
    }

    
    IEnumerator waitForSeconds() {
            yield return new WaitForSeconds(1.2f);
            isDead = true;       
    }




}











