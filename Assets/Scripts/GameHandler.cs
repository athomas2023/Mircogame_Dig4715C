using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{

    public TextMeshProUGUI charge_Text;
    public int charge_Value = 10;

    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        charge_Text.text = charge_Value.ToString();
        rigidbody2d = GetComponent<Rigidbody2D>();

        // Random select Enviroment/ Change back ground

    }

    // Update is called once per frame
    void Update()
    {
        charge_Text.text = charge_Value.ToString();

        if (Input.GetKeyDown(KeyCode.Space) )
        {
            charge_Value = charge_Value + 1;
            Debug.Log("Charge was Pressed");
            
            
        }
    }
}
