using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShockWave : MonoBehaviour
{

    public int pointsCount;
    public float maxRadius;
    public float speed;
    public float startWidth;
    public Button powerButton;
    private Shake shake;

    public AudioManager audioManager;

    [Header("Shokwave Power")]
    public Image powerImage;
    public float cooldown = 5f;
    bool isCoolingdown = false;   //Means power button is ready to be press

    private LineRenderer lineRenderer;
    public Transform playerToFollow;


    private void Awake() {

        powerImage.fillAmount = 1;

        powerButton = GameObject.Find("Power Button").GetComponent<Button>();      
        shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shake>();

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointsCount + 1;
    }


    private void Update() {
        transform.position = playerToFollow.position;
        shokWaveCoolDown();
    }




    public void shockWavePower() {
        StartCoroutine(releaseBlast());
    }


    private IEnumerator releaseBlast() {
        

        if (isCoolingdown == false) {
            audioManager.Play("plasma shock");
            float currentRadius = 0f;
          
        //DO THE POWER
        while (currentRadius < maxRadius) {

            
            currentRadius += Time.deltaTime * speed;
            Draw(currentRadius);
            Damage(currentRadius);
            

            yield return null;
           }
        }
        //Enable Cooldown
        isCoolingdown = true;
    }


    //Renders a circle line
    private void Draw(float currentRadius) {

        float angleBetweenPoints = 360f / pointsCount;

        for (int i = 0; i <= pointsCount; i++) {

            float angle = i * angleBetweenPoints * Mathf.Deg2Rad;
            Vector3 direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0f);
            Vector3 position = direction * currentRadius;

            lineRenderer.SetPosition(i, position);
        }

        lineRenderer.widthMultiplier = Mathf.Lerp(0f, startWidth, 1f - currentRadius / maxRadius);
    }



    //Detects food colliders and destroys them
    private void Damage(float currentRadius) {
   
        Collider2D[] hittingObjects = Physics2D.OverlapCircleAll(transform.position, currentRadius);

        for (int i = 0; i < hittingObjects.Length; i++ ) {

            if (hittingObjects[i].gameObject.tag == "Pie" || hittingObjects[i].gameObject.tag == "Cookie" || hittingObjects[i].gameObject.tag == "Pizza") {
                shake.CamShake();               
                Destroy(hittingObjects[i].gameObject);
                

            }
        }
    }



    private void shokWaveCoolDown() {
           
          if (isCoolingdown == false) {              
                powerImage.fillAmount = 1;
            }
 
          if (isCoolingdown == true) {

                powerImage.fillAmount -= 1 / cooldown * Time.deltaTime;

                if (powerImage.fillAmount <= 0) {

                    powerImage.fillAmount = 0;
                    isCoolingdown = false;
                }
            }
    }

}
