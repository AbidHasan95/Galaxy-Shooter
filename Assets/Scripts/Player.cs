using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject tripleShotPrefab;
    [SerializeField]
    private GameObject ShieldPrefab;
    public bool canTriple = false;
    public float speed = 15.0f;
    private bool isSpeedPowerup = false;
    private bool isShieldUp = false;
    private float iinpt;
    private float iinpt2;
    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private GameObject _Explosion;
    [SerializeField]
    public GameObject laserPrefab;
    private UIManager _uiManager;
    [SerializeField]
    private readonly float fireRate = 0.25f;
    private float canFire = 0f;
    void Start()
    {
        Debug.Log("Hello Galaxy!!");
        transform.position = new Vector3(0, 0, 0);
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager != null)
        {
            _uiManager.UpdateLives(lives);
            _uiManager.UpdateScore(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("x: "+ transform.position.x);
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
            
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //ShieldPrefab.
            ShieldPrefab.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //ShieldPrefab.
            ShieldPrefab.SetActive(true);

        }


    }
    public void Damage()
    {
        if(isShieldUp==true)
        {
            isShieldUp = false;
            ShieldPrefab.SetActive(false);
            return;
        }

        lives--;
        _uiManager.UpdateLives(lives);
        if (lives < 1)
        {
            Instantiate(_Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void Shoot()
    {
        if (Time.time > canFire)
        {
            if(canTriple==true)
            {
                Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 0.92f, 0), Quaternion.identity);
            } 
            canFire = Time.time + fireRate;
        }
    }

    private void Movement()
    {
        iinpt = Input.GetAxis("Horizontal");
        iinpt2 = Input.GetAxis("Vertical");

        if (isSpeedPowerup == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed *3f* iinpt);
            transform.Translate(Vector3.up * Time.deltaTime * speed *3f* iinpt2);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * iinpt);
            transform.Translate(Vector3.up * Time.deltaTime * speed * iinpt2);
        }
        
        


        //transform.Rotate(0, 0, Time.deltaTime * -20*speed, Space.Self);
        if (transform.position.x <= -8.45f)
            transform.position = new Vector3(-8.45f, transform.position.y, 0);
        else if (transform.position.x >= 8.03f)
            transform.position = new Vector3(8.03f, transform.position.y, 0);
        if (transform.position.y <= -4.2f)
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        else if (transform.position.y >= 3f)
            transform.position = new Vector3(transform.position.x,3f, 0);
    }

    public void TripleyPowerupOn()
    {
        canTriple = true;
        StartCoroutine(TripleyRoutine());
    }

    public IEnumerator TripleyRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        canTriple = false;
    }

    public void SpeedPowerupOn()
    {
        isSpeedPowerup = true;
        StartCoroutine(SpeedPowerupRoutine());
    }

    public IEnumerator SpeedPowerupRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        isSpeedPowerup = false;
    }

    public void ShieldPowerup()
    {
        ShieldPrefab.SetActive(true);
        Debug.Log("Shield picked");
        isShieldUp = true;
    }
}
