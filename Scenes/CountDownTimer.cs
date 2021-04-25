using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI CountdownTimerText;

    float CurrentTime;
    public float StartingTime;

    public GameObject Player;
    public GameObject Enemy;

    public Rigidbody2D PlayerRb;
    public Rigidbody2D EnemyRb;
    
    void Start()
    {
        CountdownTimerText.gameObject.SetActive(true);
        CurrentTime = StartingTime;

        PlayerRb = Player.GetComponent<Rigidbody2D>();
        EnemyRb = Enemy.GetComponent<Rigidbody2D>();

        Player.GetComponent<PlayerController>().enabled = false;
        PlayerRb.isKinematic = true;

        Enemy.GetComponent<AI>().enabled = false;
        EnemyRb.isKinematic = true;
    }

    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        CountdownTimerText.text = CurrentTime.ToString("0");

        if(CurrentTime <= 0)
        {
            Player.GetComponent<PlayerController>().enabled = true;
            PlayerRb.isKinematic = false;

            Enemy.GetComponent<AI>().enabled = true;
            EnemyRb.isKinematic = false;
            CurrentTime = 0;
            CountdownTimerText.gameObject.SetActive(false);
        }
    }
}
