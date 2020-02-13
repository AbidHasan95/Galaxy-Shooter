using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private UIManager _uIManager;
    private float _speed = 4f;
    public GameObject EnemyExplosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y<-6.4f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 6.4f, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Laser")
        {
            _uIManager.UpdateScore(10);
            Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.Damage();
            Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
