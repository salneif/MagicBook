using UnityEngine;

public class Ball : MonoBehaviour

{

    public Transform startPoint;

    public float speed = 8f;

    bool attack = false;

    void Update()

    {

        if (attack)

        {

            transform.position = Vector3.MoveTowards(

                transform.position,

                startPoint.position,

                speed * Time.deltaTime

            );

        }

    }

    public void StartAttack()

    {

        attack = true;

    }

}