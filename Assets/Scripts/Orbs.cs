using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    // Start is called before the first frame update
    // private GameManager gameManager;
    [SerializeField] private int scoreValue;
    private NonPlayerSoundFx nonPlayerSoundFx;
    // private bool isObtained = false;
    void Start()
    {
        // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        nonPlayerSoundFx = GetComponent<NonPlayerSoundFx>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (isObtained)
        // {
        //     nonPlayerSoundFx.PlayOrbSfx();
        // }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Obtained Orb");
        if(collision.tag == "Player1")
        {
            // isObtained = true;
            // collision.GetComponent<Health>().TakeDamage(damage);
            GameObject.Find("ScoreManager").GetComponent<ScoreManager>().UpdateScore(scoreValue); // update score when clicked
            nonPlayerSoundFx.PlayOrbSfx();
            // Destroy(this.gameObject);
            Invoke("DestroyOrb", 0.35f);
           
        }
    }

    private void DestroyOrb()
    {
        // isObtained = false;
        Destroy(this.gameObject);
    }
}
