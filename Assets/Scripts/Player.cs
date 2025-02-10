using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private TerrainGenerator terrainGenerator;
    [SerializeField] private TMP_Text scoreText;
   
    private Animator animator;
    private bool isHopping;
    private int score;
    private float maxXPosition;

    private void Start()
    {
        animator = GetComponent<Animator>();
        maxXPosition = transform.position.x;
        UpdateScoreText();
    }

   private void Update()
   {
        if(Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            float zDifference = 0;
            if(transform.position.z % 1 != 0)
            {
                zDifference = Mathf.Round(transform.position.z) - transform.position.z;
            }
            MoveCharacter(new Vector3(1, 0, zDifference));
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
            MoveCharacter(new Vector3(0, 0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isHopping)
        {
            MoveCharacter(new Vector3(-1, 0, 0));
        }
   }

   private void OnCollisionEnter(Collision collision)
   {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collided with Obstacle!");
            return;
        }

        if (collision.collider.GetComponent<MovingObject>() != null)
        {
            if (collision.collider.GetComponent<MovingObject>().isLog)
            {
                transform.parent = collision.collider.transform;
            }
            else
            {
                transform.parent = null;
            }
        }
   }

   private void MoveCharacter(Vector3 difference)
   {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position += difference;
        
        if (transform.position.x > maxXPosition)
        {
            maxXPosition = transform.position.x;
            score++;
            UpdateScoreText();
        }
        
        terrainGenerator.SpawnTerrain(false, transform.position);
   }

   private void UpdateScoreText()
   {
        scoreText.text = "Score: " + score;
   }

   public void FinishHop()
   {
        isHopping = false;
   }
}