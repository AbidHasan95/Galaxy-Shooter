using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    private float _speed = 4;
    [SerializeField]
    private int powerupId;
    //0-Tripley 1-Speed 2-Shield
    void Update()
    {
        transform.Translate(Vector3.down* Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Collided: " + other.name);
            Player player = other.GetComponent<Player>();
            if(powerupId==0)
            {
                player.TripleyPowerupOn();
            }
            else if(powerupId ==1)
            {
                //Speed PowerUp
                player.SpeedPowerupOn();
            }

            else if (powerupId == 2)
            {
                player.ShieldPowerup();
            }
            
            Destroy(this.gameObject);
        }
    }
}
