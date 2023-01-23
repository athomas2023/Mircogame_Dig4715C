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

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public float speed = 3.0f;

    public GameObject startText;
    public GameObject lostText;
    public GameObject Esctext;

    


    // Start is called before the first frame update
    void Start()
    {
        charge_Text.text = charge_TimeValue.ToString();
        Charge_valuetext = chargevalue.ToString();
        rigidbody2d = GetComponent<Rigidbody2D>();
        
        StartCoroutine(Startgame());



        // Random select Enviroment/ Change back ground

    }

    // Update is called once per frame
    void Update()
    {
        charge_TimeValue -= 1 * Time.deltaTime;
        charge_Text.text = charge_TimeValue.ToString("0");
        Charge_valuetext = chargevalue.ToString();

        if ( charge_TimeValue <= 0.1)
        {
                lostText.SetActive(true);
                StartCoroutine(Restart());
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
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }


    IEnumerator Startgame()
    {
        
        yield return new WaitForSeconds(2);
        startText.SetActive(false);
        

    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(2);
        lostText.SetActive(false);
        startText.SetActive(true);
        Esctext.SetActive(true);
        charge_TimeValue = 10;
        StartCoroutine(Startgame());
    }
}
