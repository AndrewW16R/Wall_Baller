using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlassZone : MonoBehaviour
{
    public int glassHealth;
    public int glassMaxHealth;
    public bool isVulnerable;

    public GameObject ballObject;
    public Ball activeBall;

    public GameObject gameManagerObject;
    public GameManager gameManager;

    public GameObject cameraObject;
    public Shake cameraShake;

    public GameObject glassSprite;
    public GameObject glassCrackedSprite;
    public GameObject glassBrokenSprite01;
    public GameObject glassBrokenSprite02;
    public GameObject glassCollision;

    public float firstCollisionHitStop;
    public float secondCollisionHitStop;

    public bool glassWallDown;

    public UnityEvent onFirstHitEvent;

    public UnityEvent onSecondHitEvent;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        cameraObject = GameObject.Find("MainCamera");
        cameraShake = cameraObject.GetComponent<Shake>();

      //  glassSprite = GameObject.Find("Tilemap_Glass"); These are now assigned manually in the inspector
       // glassCrackedSprite = GameObject.Find("Tilemap_GlassCracked");
        glassCollision = GameObject.Find("Tilemap_GlassCollision");

        glassMaxHealth = glassHealth;

        glassSprite.SetActive(true);
        glassCrackedSprite.SetActive(false);
        glassBrokenSprite01.SetActive(false);
        glassBrokenSprite02.SetActive(false);
        glassCollision.SetActive(true);

        glassWallDown = false;
        isVulnerable = true;


        if (onFirstHitEvent == null)
        {
            onFirstHitEvent = new UnityEvent();
        }

        if (onSecondHitEvent == null)
        {
            onSecondHitEvent = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject == ballObject)
        {

            ballObject = col.gameObject;


            if (glassHealth > 0)
            {

                glassHealth = glassHealth - 1;

                if (glassHealth == 1 && isVulnerable == true)
                {
                    glassSprite.SetActive(false);
                    glassCrackedSprite.SetActive(true);
                    SetGlassVulnerability(false);//ensures that ball will not damage glass a second time until the ball passes the barrier on the right side of the screen.
                    onFirstHitEvent.Invoke();
                    cameraShake.ActivateShake01();
                    gameManager.ApplyHitStop(firstCollisionHitStop);
                }

            }

            if (glassHealth == 0 && isVulnerable == true)
            {
                cameraShake.ActivateShake02();
                gameManager.ApplyHitStop(secondCollisionHitStop);
                glassCrackedSprite.SetActive(false);
                glassBrokenSprite01.SetActive(true);
                glassBrokenSprite02.SetActive(true);
                onSecondHitEvent.Invoke();
                Invoke("DisableGlassCollision", 0.1f);
                glassWallDown = true;
                glassHealth = glassHealth - 1;
            }
        }

    }

    private void DisableGlassCollision()
    {
        glassCollision.SetActive(false);
    }

    public void SetGlassVulnerability(bool vulnerability)
    {
        isVulnerable = vulnerability;
    }
}
