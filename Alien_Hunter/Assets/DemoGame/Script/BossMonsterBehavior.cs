using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class BossMonsterBehavior : MonoBehaviour
{
    //目標變數
    public GameObject Target;
    //初始特效來源參考
    public GameObject RefBorn;
    //死亡特效來源參考
    public GameObject RefExplosion;

    public BoxCollider collider_Prop;

    //NavMeshAgent組件
    //private NavMeshAgent meshAgent;
    private Animator animator;

    //最近停止距離值
    //private float stopDestionation = 3.5f;
    //生命值
    public int HealthPoint = 30;
    //死亡布林值
    public bool bDeath = false;
    [Header("TriggerBox")]
    public CountScore countScore;
    //Triiger 物件
    public GameObject TriggerBoxRight;
    public GameObject TriggerBoxMid;
    public GameObject TriggerBoxLeft;
    //動畫Hash碼
    private static int state_Idle = Animator.StringToHash("Idle");
//    private static int state_Walk = Animator.StringToHash("Run");
    private static int state_AttackRight = Animator.StringToHash("AttackRight");
    private static int state_AttackMid = Animator.StringToHash("AttackMid");
    private static int state_AttackLeft = Animator.StringToHash("AttackLeft");
    private static int state_Death = Animator.StringToHash("Death");

    void Start ()
    {
        animator = GetComponentInChildren<Animator>();
        countScore = GameObject.Find("Score").GetComponent<CountScore>();//抓取 Score 的 Component
        Target = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator DelayDestory()
    {
        yield return new WaitForSeconds(3.0f);
        Instantiate(RefExplosion, transform.position, transform.rotation);
        countScore.scoreCount(5);
        gameObject.SetActive(false);
        Destroy(this.gameObject);

    }

    public void OnDamage(int Dmg)
    {
        HealthPoint -= Dmg;
        animator.SetTrigger("Death");
        Destroy(this); 
    }
    ////被子彈打到發生碰撞-1
    //void OnColliderEnter(Collision collision)
    //{
    //    Debug.Log("death");

    //    OnDamage(1);
    //    Destroy(gameObject);
    //}
    
    void Update ()
    {
        //Debug.Log("healthPoint"+HealthPoint);
        ////生命值低於0時, 執行死亡行為
        //if (HealthPoint <= 0 && HealthPoint >= -10)
        //{
        //    bDeath = true;
        //    collider_Prop.enabled = false;
        //    this.gameObject.SetActive(false);
        //    //將所有碰撞體關閉
        //    Collider[] cols = GetComponentsInChildren<Collider>();
        //    foreach (var item in cols)
        //    {
        //        item.enabled = false;
        //    }
        //    Destroy(this.gameObject);
        //}

        ////死亡之後的動作
        //if (bDeath)
        //{
        //    //GameObject tmpGM = GameObject.FindGameObjectWithTag("GameModeTag");
        //    //tmpGM.GetComponent<GameMode>().SetScore(10);

        //    HealthPoint = -99;

        //    bDeath = false;
        //    animator.SetTrigger("Death");
        //    StartCoroutine(DelayDestory());
        //    return;
        //}
        


        ////動畫狀態為死亡動畫, 則停止AI行為
        //if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == state_Death)
        //{
        //    meshAgent.isStopped = true;
        //}
        ////給予"Speed"一個速度值, 來判定要撥放Walk or Run動畫
        //animator.SetFloat("Speed", Vector3.Magnitude(meshAgent.velocity));

        //動畫機如果在Idle 或 Walk時, 開始往玩家靠近
        //如果距離低於 stopDestionation值時, 則啟用 "Attack"動畫
        //if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == state_Idle ||
        //    animator.GetCurrentAnimatorStateInfo(0).shortNameHash == state_Walk)
        //{
        //    if (Vector3.Distance(transform.position, Target.transform.position) > stopDestionation)
        //    {
        //        collider_Prop.enabled = false;
        //        meshAgent.isStopped = false;

        //        meshAgent.SetDestination(Target.transform.position);

        //        animator.SetBool("Attack", false);
        //    }
        //    else
        //    {
        //        collider_Prop.enabled = true;
        //        meshAgent.isStopped = true;

        //        animator.SetBool("Attack", true);
        //    }
        //}

        //動畫機為Attack時, 則關閉"Attack"布林值, 讓動畫機返回到Idle狀態
        //if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == state_Attack)
        //{
        //    animator.SetBool("Attack", false);
        //}
    }
    public void OnTriggerStay(Collider Attack)
    {
        if(Attack.gameObject.tag == "Player")
        {
            if (this.gameObject == TriggerBoxRight)
                animator.SetBool("AttackRight", true);
            else if (this.gameObject == TriggerBoxMid)
                animator.SetBool("AttackMid", true);
            else if (this.gameObject == TriggerBoxLeft)
                animator.SetBool("AttackLeft", true);
        }
    }
    
}
