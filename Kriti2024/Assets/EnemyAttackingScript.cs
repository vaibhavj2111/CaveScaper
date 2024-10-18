using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{
    public GameObject stone;
    public Transform stonePos;

    private float timer;
    private GameObject player;

    [SerializeField] private AudioSource AttackSound;
    // Start is called before the first frame update
    void Start()

    {// float rot = Mathf.Atan2(direction.x, );
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {



        //  timer += Time.deltaTime;

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if (distance < 1.5)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                 StoneThrow();
                
                AttackSound.Play();

            }


        }

    }

    void StoneThrow()
    {
        Instantiate(stone, stonePos.position, Quaternion.identity);
    }



}
