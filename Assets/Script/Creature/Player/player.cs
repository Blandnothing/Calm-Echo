using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    [Header("Health Info")]
    [SerializeField] private float m_Recovery_percentage = 0.01f;

    [Header("Input Info")]
    [SerializeField] public float xInput;
    [SerializeField] public float yInput;
    #region Components 
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public Transform transf { get; private set; }
    #endregion 

    #region  
    public PlayerStateMashine mashine { get; private set; }
    public LookAtMouse lookAtMouse { get; private set; }

    public PlayerIdle idle { get; private set; }

    public PlayerFrontMove frontMove { get; private set; }

    public PlayerBackMove backMove { get; private set; }

    public PlayerLeftMove leftMove { get; private set; }

    public PlayerRightMove rightMove { get; private set; }

    public PlayerBackIdle backIdle { get; private set; }

    public PlayerLeftIdle leftIdle { get; private set; }

    public PLayerRightIdle rightIdle { get; private set; }
    #endregion  


    private void Awake()
    {
        mashine = new PlayerStateMashine();
 
        lookAtMouse = new LookAtMouse(this,this.transform);

        idle = new PlayerIdle(this, mashine, "Idle");
        backIdle = new PlayerBackIdle(this, mashine, "Idle");
        leftIdle = new PlayerLeftIdle(this, mashine, "Idle");
        rightIdle = new PLayerRightIdle(this, mashine, "Idle");
        frontMove = new PlayerFrontMove(this, mashine, "Move");
        backMove = new PlayerBackMove(this, mashine, "Move");
        leftMove = new PlayerLeftMove(this, mashine, "Move");
        rightMove = new PlayerRightMove(this, mashine, "Move");
    }
    private void Start()
    {
        PlayerBaseInformation(100f, 1.5f, 0f);

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transf = transform.Find("Main Camera").GetComponent<Transform>();

        mashine.Initialized(idle);
    }

    private void Update()
    {
        mashine.currentState.Update();

        anim.SetFloat("P_x", lookAtMouse.IdleControl().x);
        anim.SetFloat("P_y", lookAtMouse.IdleControl().y);

        Input();

        AddPlayerSpeed();

        BreathReturnBlood(this);

    }

    private void Input()
    {
        xInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        yInput = UnityEngine.Input.GetAxisRaw("Vertical");
    }


    ///人物基础信息设置
    private void PlayerBaseInformation(float _maxHealth, float _m_speed, float _m_ATK)
    {
        maxHealth = _maxHealth;
        m_currentHealth = maxHealth;
        m_speed = _m_speed;
        m_ATK = _m_ATK;
    }

    public void SetPlayerSpeed(float x, float y)
    {
        rb.velocity = new Vector2(x * m_speed, y * m_speed);
    }


    ///长按LeftShift加速
    public void AddPlayerSpeed()
    {
        if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            m_speed = 3.0f;
        else
            m_speed = 1.5f;
    }

    ///呼吸回血
    public void BreathReturnBlood(Player player)
    {
        if (m_currentHealth < maxHealth)
        {
            if (m_currentHealth + maxHealth * m_Recovery_percentage * Time.deltaTime > maxHealth)
                m_currentHealth = maxHealth;
            else
                m_currentHealth += m_Recovery_percentage * maxHealth * Time.deltaTime;
        }
    }

}
