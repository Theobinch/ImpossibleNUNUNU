using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NunuChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    
    //permet au monstre de se deplacer vers le joueur 
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
