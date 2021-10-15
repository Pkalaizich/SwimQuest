using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get => instance; }
    [SerializeField] 
    [Range(0f,100f)]
    public float Oxygen = 100f;
    [SerializeField]
    public float OxygenLossRate;
    [SerializeField]
    public float OxygenGainRate;
    public float CurrentRate;
    [SerializeField]
    protected float verticalSpeed;
    [SerializeField]
    protected float horizontalSpeed;
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;
    private Vector2 cntrl;
    public int KeysObtained =0;
    [SerializeField] float ProtectionTime = 0.5f;
    public float ProtectionTimer = 0f;
    public GameObject mainCamera;
    public GameObject cameraHolder;
    public enum States{ UnderWater, Breathing }
    [SerializeField]
    States state = States.UnderWater;
    public bool win = false;
    private bool end = false;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(this);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        CurrentRate = OxygenLossRate;
    }
    void Start()
    {
        Debug.Log(mainCamera.transform.position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (win !=true&&end==false)
        {
            cameraHolder.transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), cameraHolder.transform.position.z);
            ProtectionTimer = Mathf.Clamp(ProtectionTimer - Time.deltaTime, -0.1f, 1f);
            cntrl = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (cntrl.x != 0)
            {
                sr.flipX = cntrl.x < 0;
            }
            rb.velocity = new Vector2(cntrl.x * horizontalSpeed, cntrl.y * verticalSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            if (state == States.UnderWater)
            {
                Oxygen = Mathf.Clamp(Oxygen - CurrentRate, 0f, 100f);
                OxygenBar.Instance.SetOxygen(Oxygen);
            }

            if (Oxygen <= 0&&end==false)
            {
                GameController.Instance.GameOver();
                end = true;
                this.gameObject.SetActive(false);
            }            

        }
        if(win==true && end==false)
        {
            GameController.Instance.GameOver();
            end = true;
            this.gameObject.SetActive(true);
        }

    }

    public void Damage(float damage)
    {
        Oxygen = Mathf.Clamp(Oxygen - damage, 0f, 100f);
        ProtectionTimer = ProtectionTime;
        SoundController.Instance.HurtSound();
        StartCoroutine(Shake(.15f, .05f));
    }

    IEnumerator Shake (float duration, float magnitude)
    {
        Debug.Log("Shakin");
        Vector3 originalPos = mainCamera.transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            mainCamera.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        mainCamera.transform.localPosition = originalPos;
    }

    
}
