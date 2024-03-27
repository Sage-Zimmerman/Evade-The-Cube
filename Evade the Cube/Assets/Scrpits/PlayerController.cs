using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public HUDManager hudManager;

    public Transform leftwall;
    public Transform rightwall;

    private Stats m_Stats;

    private void Start()
    {
        m_Stats = GetComponent<Stats>();
        hudManager.UpdateHealthText(m_Stats.health);
    }

    private void Update()
    {
        if (m_Stats.health <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // x axis
        float horizontalInput = Input.GetAxis("Horizontal");
        // y axis
        float horizontalPosition = transform.position.x + horizontalInput * Time.deltaTime * speed;

        float playerSize = transform.localScale.x/2;
        float leftwallSize = leftwall.transform.localScale.x/2;
        float rightwallSize = rightwall.transform.localScale.x/2;

        if (horizontalPosition - playerSize <= leftwall.position.x + leftwallSize)
        {
            return;
        }
        if (horizontalPosition + playerSize >= rightwall.position.x - rightwallSize)
        {
            return;
        }

        transform.position = new Vector3(
            horizontalPosition,
            1,
            transform.position.z
        );
        
    }
    public void ReceiveDamage()
    {
        m_Stats.UpdateHealth(10);
        hudManager.UpdateHealthText(m_Stats.health);
    }
}





/*
Lecture Notes
************

    //FPS and Diagnostics
    private float m_accTime = 0f;
    private float m_Fps = 0f;
    

    // Approaches
    // Use Awake to initialize obejcts' references and vairables
    // Use or create references to other objects and their components


    // Called only once when script is disabled, before start
    // called when other objects are initalized
    // creat references to objects, called even when script isn't enabled
    void Awake()
    {
        Debug.Log("Calling Awake");
    }


    // Start is called before the first frame update
    // Called when script is enabled, execution of start can be delayed
    void Start()
    {
        Debug.Log("Calling Start");
    }

    // Called when script is enabled (when box is checked)
    void OnEnable()
    {
        Debug.Log("Calling On Enable");
    }

    // Update is called once per frame
    // Not consistent, since not all frames are spaced evently
    // Update is good for receiving input, timer operation, manipulate non-physics objects
    void Update()
    {

        Debug.Log("Calling Update");



        // FPS detector
        m_accTime += Time.deltaTime;
        m_Fps++;

        if (m_accTime >= 1)
        {
            Debug.Log("BUM " + m_accTime);
            Debug.Log("FPS " + m_Fps);
            m_Fps = 0;
            m_accTime = 0f;
        }
    }

    // Consistent framerate
    // manipulate physics, controls ridgedbody components
    // can use Time.fixedDeltaTime
    void FixedUpdate()
    {
        Debug.Log("Calling Fixed Update");
    }

    // called directly after update, good for manipulating camera
    void LateUpdate()
    {
        Debug.Log("Calling Late Update");
    }
************
*/