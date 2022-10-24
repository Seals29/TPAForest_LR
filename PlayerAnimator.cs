using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerAnimator : MonoBehaviour
{
    public int maxHP = 1;
    PlayerInfo playerdmg;
    public int currhp;
    [SerializeField] 
    AudioSource tonjok2;
    [SerializeField] 
    AudioSource equip;
    [SerializeField] 
    AudioSource swordswing1;
    [SerializeField] 
    AudioSource swordswing2;
    [SerializeField] 
    AudioSource walk;
    [SerializeField] 
    AudioSource run;

    [SerializeField]
    AudioSource grass;
    bool weaponcheck = false;
    public Movement speed;
    public Canvas canvas;
    private Animator animator;
    private Vector3 direction;
    [SerializeField] SwordInfo swordinfo;
    private float timeCounter;
    [SerializeField]
    private Transform tangan;
    [SerializeField]
    private PlayerTrigger trigger;
    [SerializeField]
    public EnemyTrigger trigger2;
    [SerializeField]
    public AudioClip sfx;
    [SerializeField]
    Slider slider;
    [SerializeField]
    Animator animators;
    bool checkweapon = false;
    SwordInfo swordinfos;
    Cinemachine.CinemachineFreeLook camcinema;
    [SerializeField]
    Slider playerslider;
    public int lvlupcount=0;

    [SerializeField]
    Slider sliderxp;
    bool checkcursor;
    [SerializeField]
    Canvas statcanvas;
    [SerializeField]
    Text lvltext;
    int currlvl = 1;
    // Start is called before the first frame update
    private float deathCounter =0;
    void Start()
    {
        playerdmg = GetComponent<PlayerInfo>();
        currhp = maxHP;
        animators = GetComponentInChildren<Animator>();
        animator = GetComponentInChildren<Animator>();
        trigger = GetComponentInChildren<PlayerTrigger>();
        trigger2 = GetComponentInChildren<EnemyTrigger>();
        lvltext.text = "Level " + currlvl;
    }
    // Update is called once per frame
    void TakeDamage(int dmg)
    {
        currhp -= dmg;
    }
    void Update()
    {
        if (sliderxp.value >= (10 + playerdmg.getSTR()))
        {
            slider.value += maxHP + (playerdmg.getSTR() * 2f);
            sliderxp.value -= (10 + playerdmg.getSTR());
            lvlupcount += 1;
            currlvl++;
            lvltext.text = "Level " + currlvl;
        }
        foreach (GameObject enemylist in trigger2.nearenemies)
        {

        }
            if (lvlupcount >= 1)
        {

            statcanvas.enabled = true;
        }
        else
        {
            statcanvas.enabled = false;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0, vertical);
        
       if(slider.value <= 0)
        {
            animator.SetBool("Death", true);
            if (timeCounter <= 5)
            {
                timeCounter += Time.deltaTime;
            }
            else
            {
                animators.SetTrigger("FadeOut");
                new WaitForSeconds(5f);
                AsyncOperation scene = SceneManager.LoadSceneAsync(2);
            }
        }

        if (direction.magnitude > 0.01f)
        {
            grass.enabled = true;
            //gerak
            walk.enabled = true;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                run.enabled = false;
                animator.SetBool("IsSprint", true);
                speed.speed += 3.5f;

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed.speed -= 3.5f;
                run.enabled = false;
                animator.SetBool("IsSprint", false);
            }
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRun", true);
            animator.SetBool("IsRoll", false);
            animator.SetBool("IsPunch", false);

            if (Input.GetKeyDown(KeyCode.Mouse1)){
                animator.SetBool("IsRoll", true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {

                foreach(GameObject listall in trigger.nearweapon)
                {
                    listall.GetComponent<Animator>().enabled = false;
                    equip.enabled = true;
                    GameObject ambilweapon = Instantiate(listall, tangan);
                    Rigidbody rigid = ambilweapon.GetComponent<Rigidbody>();
                    rigid.useGravity = false;
                    rigid.isKinematic = true;
                    ambilweapon.GetComponent<MeshCollider>().enabled = true;
                    ambilweapon.transform.localPosition = Vector3.zero;
                    ambilweapon.transform.localPosition = new Vector3(0, 0.43f, 0);
                    rigid.useGravity = false;
                    ambilweapon.transform.localRotation = Quaternion.identity;

                    Destroy(listall);
                    animator.SetBool("IsWeapon", true);
                    checkweapon = true;
                    break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0)&&Cursor.visible==false)
            {
                if (weaponcheck == true)
                {
                    animator.SetBool("IsWeapon", true);
                }
                animator.SetBool("IsPunch", true);
                animator.SetBool("IsIdle", false);
                foreach (GameObject enemylist in trigger2.nearenemies)
                {
                    if (checkweapon == true)
                    {
                        
                        enemylist.GetComponentInParent<EnemyInfo>().setHP((int)(enemylist.GetComponentInParent<BearHPControl>().sliderhp.value - (swordinfo.dmg + playerdmg.getPOW())));
                        enemylist.GetComponentInParent<BearHPControl>().sliderhp.value -= swordinfo.dmg;
                        if (enemylist.GetComponentInParent<BearHPControl>().sliderhp.value <= 0)
                        {
                            enemylist.GetComponentInParent<BearMovement>().checkdeath = true;
                            //enemylist.GetComponentInParent<BearMovement>().slider.value = 5;
                        }
                    }
                    else
                    {
                        enemylist.GetComponentInParent<EnemyInfo>().setHP((int)(enemylist.GetComponentInParent<BearHPControl>().sliderhp.value - playerdmg.getPOW()));
                        enemylist.GetComponentInParent<BearHPControl>().sliderhp.value -= playerdmg.getPOW();
                        if (enemylist.GetComponentInParent<BearHPControl>().sliderhp.value <= 0)
                        {
                            enemylist.GetComponentInParent<BearMovement>().checkdeath = true;
                            //enemylist.GetComponentInParent<BearMovement>().slider.value = 5;
                        }
                    }
                }
            }
           
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.SetBool("IsLeft", true);
                animator.SetBool("IsIdle", false);
            }
            if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.W))
            {
                animator.SetBool("IsLeft", false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                animator.SetBool("IsRight", true);
                animator.SetBool("IsIdle", false);
            }
        }
        else
        {
            grass.enabled = false;
            //idle
            walk.enabled = false;
            run.enabled = false;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed.speed += 3.5f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed.speed -= 3.5f;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (GameObject listall in trigger.nearweapon)
                {
                    listall.GetComponent<Animator>().enabled = false;
                    equip.enabled = true;
                    GameObject ambilweapon = Instantiate(listall, tangan);
                    Rigidbody rigid = ambilweapon.GetComponent<Rigidbody>();
                    rigid.useGravity = false;
                    rigid.isKinematic = true;
                    ambilweapon.GetComponent<MeshCollider>().enabled = true;
                    ambilweapon.transform.localPosition = Vector3.zero;
                    ambilweapon.transform.localPosition = new Vector3(0,0.43f,0);
                    rigid.useGravity = false;
                    ambilweapon.transform.localRotation = Quaternion.identity;
                    
                    Destroy(listall);
                    animator.SetBool("IsWeapon", true);
                    checkweapon = true;
                    break;
                }
            }
            animator.SetBool("IsRun", false);
            animator.SetBool("IsRoll", false);
            animator.SetBool("IsPunch", false);
            animator.SetBool("IsLeft", false);
            animator.SetBool("IsRight", false);
            animator.SetBool("IsIdle", true);
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.SetBool("IsLeft", true);
                animator.SetBool("IsIdle", false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                animator.SetBool("IsRight", true);
                animator.SetBool("IsIdle", false);
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && Cursor.visible == false)
            {
                if (weaponcheck == true)
                {
                    animator.SetBool("IsWeapon", true);
                }
                if (Cursor.visible == false)
                {

                
                animator.SetBool("IsPunch", true);
                animator.SetBool("IsIdle", false);
                foreach (GameObject enemylist in trigger2.nearenemies)
                {
                    if (checkweapon == true)
                    {
                        enemylist.GetComponentInParent<EnemyInfo>().setHP((int)(enemylist.GetComponentInParent<BearHPControl>().sliderhp.value - (swordinfo.dmg + playerdmg.getPOW())));
                        enemylist.GetComponentInParent<BearHPControl>().sliderhp.value -= swordinfo.dmg;
                        if (enemylist.GetComponentInParent<BearHPControl>().sliderhp.value <= 0)
                        {

                            enemylist.GetComponentInParent<BearMovement>().checkdeath = true;
                            //enemylist.GetComponentInParent<BearMovement>().slider.value = 5;
                        }
                    }
                    else
                    {
                        enemylist.GetComponentInParent<EnemyInfo>().setHP((int)(enemylist.GetComponentInParent<BearHPControl>().sliderhp.value - playerdmg.getPOW()));
                        enemylist.GetComponentInParent<BearHPControl>().sliderhp.value -= playerdmg.getPOW();
                        if (enemylist.GetComponentInParent<BearHPControl>().sliderhp.value <= 0)
                        {
                            enemylist.GetComponentInParent<BearMovement>().checkdeath = true;
                            //enemylist.GetComponentInParent<BearMovement>().slider.value = 5;
                        }
                    }
                }
            }
            }


        }
        
    }

}
