using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    public TextMeshProUGUI charge_Text;
    public float charge_TimeValue = 12;
    public TextMeshProUGUI Charge_valuetext;
    int chargevalue = 0;
    public TextMeshProUGUI Needvalue;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 3.0f;

    public GameObject startText;
    public GameObject lostText;
    public GameObject Esctext;
    public GameObject winText;

    public GameObject Octo;
    public GameObject power;

    public int needed = 50;

    int tries = 0;

    public AudioClip winmusic;
    public AudioClip lostmusic;
    public AudioClip starSound;
    
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        charge_Text.text = charge_TimeValue.ToString();
        Charge_valuetext.text = chargevalue.ToString();
        rigidbody2d = GetComponent<Rigidbody2D>();
        Needvalue.text =  needed.ToString();
        audioSource = GetComponent<AudioSource>();
        
        StartCoroutine(Startgame());



        // Random select Enviroment/ Change back ground

    }

    // Update is called once per frame
    void Update()
    {
        charge_TimeValue -= 1 * Time.deltaTime;
        charge_Text.text = charge_TimeValue.ToString("0");
        Charge_valuetext.text = chargevalue.ToString();
        Needvalue.text =  needed.ToString();

        if ( tries == 1)
        {
            needed = 30;
        }

        if ( tries == 2)
        {
            needed = 60;
        }

        if ( tries == 3)
        {
            needed = 25;
        }

        if ( tries == 4)
        {
            needed = 25;
        }
        

        if ( charge_TimeValue <= 0.1) 
        {
            if (chargevalue != needed)
            {
                PlaySound(lostmusic);
                lostText.SetActive(true);
                StartCoroutine(Restart());
            }


        }



        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            chargevalue = chargevalue + 1;
            Debug.Log("Charge was Pressed");
            
            
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("Game Closed");
        }

        if ( chargevalue == needed)
        {
            PlaySound(winmusic);
            power.SetActive(true);
            Octo.SetActive(false);
            winText.SetActive(true);
            StartCoroutine(Restart());
        }
    
        
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }


    IEnumerator Startgame()
    {
        PlaySound(starSound);
        yield return new WaitForSeconds(2);
       
        startText.SetActive(false);
        Octo.SetActive(true);
        chargevalue = 0;
        

    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        lostText.SetActive(false);
        winText.SetActive(false);
        startText.SetActive(true);
        Esctext.SetActive(true);
        power.SetActive(false);
        charge_TimeValue = 10;
        tries = tries + 1;
        StartCoroutine(Startgame());


    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
