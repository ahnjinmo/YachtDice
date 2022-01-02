using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    // External References
    public Roll roll;
    public ScoreManager sManager;
    
    public static Vector3 sideOne   = new Vector3(-90, 0, 0);
    public static Vector3 sideTwo   = new Vector3(0, 0, -90);
    public static Vector3 sideThree = new Vector3(0, 0, 0);
    public static Vector3 sideFour  = new Vector3(0, 0, -180);
    public static Vector3 sideFive  = new Vector3(0, 0, 90);
    public static Vector3 sideSix   = new Vector3(90, 0, 0);

    // Public Properties
    public int m_state;     // 0: Waiting,    1: Rolled
    public bool m_chosen;
    
    float m_rotSpeed;
    Vector3 m_initialPos;
    Rigidbody m_diceRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_chosen = false;   m_rotSpeed = 150f;  m_state = 0;
        m_diceRigidbody = GetComponent<Rigidbody>();

        m_initialPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Physics off if dice is chosen
        if (m_chosen) m_diceRigidbody.isKinematic = true;
        else m_diceRigidbody.isKinematic = false;

        // Keep Dice Rotating for Random Results
        if (m_state == 0) gameObject.transform.Rotate(0, 0, m_rotSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R)) ResetDie();
    }

    public void ResetDie()
    {
        sManager.m_diceStatic = false;

        if (!m_chosen)
        {
            Vector3 randomRot = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            gameObject.transform.position = m_initialPos;
            gameObject.transform.eulerAngles = randomRot;
            m_diceRigidbody.useGravity = false;
            m_diceRigidbody.velocity = Vector3.zero;
            m_state = 0;
            roll.m_rolled = false;

            m_rotSpeed = 150f + Random.Range(0, 30f);
        }
        
    }
}