using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    public GameObject player;
    private object movement;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        Vector2 direction = player.transform.position - this.transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed * Time.deltaTime);
    }
}
