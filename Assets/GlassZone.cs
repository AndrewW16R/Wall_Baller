using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassZone : MonoBehaviour
{
    public int glassHealth;
    public int glassMaxHealth;
    public GameObject ballObject;
    public Ball activeBall;

    public GameObject gameManagerObject;
    public GameManager gameManager;

    public GameObject glassSprite;
    public GameObject glassCrackedSprite;
    public GameObject glassCollision;

    public float firstCollisionHitStop;
    public float secondCollisionHitStop;

    public bool glassWallDown;

    // Start is called before the first frame update
    void Start()
    {
        ballObject = GameObject.FindWithTag("Ball");
        activeBall = ballObject.GetComponent<Ball>();

        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        glassSprite = GameObject.Find("Tilemap_Glass");
        glassCrackedSprite = GameObject.Find("Tilemap_GlassCracked");
        glassCollision = GameObject.Find("Tilemap_GlassCollision");

        glassMaxHealth = glassHealth;

        glassSprite.SetActive(true);
        glassCrackedSprite.SetActive(false);
        glassCollision.SetActive(true);

        glassWallDown = false;
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

                if (glassHealth == 1)
                {
                    glassSprite.SetActive(false);
                    glassCrackedSprite.SetActive(true);
                    gameManager.ApplyHitStop(firstCollisionHitStop);
                }

            }

            if (glassHealth == 0)
            {
                gameManager.ApplyHitStop(secondCollisionHitStop);
                glassCrackedSprite.SetActive(false);
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
}
