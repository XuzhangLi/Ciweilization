using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestPlayer : Photon.MonoBehaviour
{
    public PhotonView photonView;
    public Rigidbody2D rb;
    public GameObject PlayerCamera;
    public SpriteRenderer sr;
    public Text PlayerNameText;

    public float moveSpeed;
    public bool isGrounded;
    public float jumpForce;

    public GameObject testErrorObj;

    public int playerNumber = 0;

    private int G1, G2, G3, G4, R1, R2, R3, R4, Y1, Y2, Y3, Y4, B1, B2, B3, B4;

    private bool Wonder_G1, Wonder_G2, Wonder_G3, Wonder_G4, Wonder_R1, Wonder_R2, Wonder_R3, Wonder_R4,
        Wonder_Y1, Wonder_Y2, Wonder_Y3, Wonder_Y4, Wonder_B1, Wonder_B2, Wonder_B3, Wonder_B4;

    private AudioManager audioManager;

    public GameObject heroObj;

    public GameObject testEmptyObj;

    ////////////////////////////////////////////
    ////////////////////////////////////////////

    public double moves;

    public float xOffset = 0.5f;
    public float yOffset = -0.03f;
    public float zOffset = -0.03f;

    public GameObject playerCenter;

    [HideInInspector] public TestGameManager testGameManager;

    public GameObject[] level1Prefabs;
    public GameObject[] level2Prefabs;
    public GameObject[] level3Prefabs;
    public GameObject[] level4Prefabs;

    public GameObject[] level1Pos;
    public GameObject[] level2Pos;
    public GameObject[] level3Pos;
    public GameObject[] level4Pos;
    public GameObject heroPos;

    private void Awake()
    {
        if (photonView.isMine)
        {
            //PlayerCamera.SetActive(true);
            //PlayerNameText.text = PhotonNetwork.playerName;
        }
        else
        {
            //PlayerNameText.text = photonView.owner.NickName;
            //PlayerNameText.color = Color.red;
        }
    }

    private void Start()
    {
        moves = 0;

        G1 = G2 = G3 = G4 = R1 = R2 = R3 = R4 = Y1 = Y2 = Y3 = Y4 = B1 = B2 = B3 = B4 = 0;

        Wonder_G1 = Wonder_G2 = Wonder_G3 = Wonder_G4 = Wonder_R1 = Wonder_R2 = Wonder_R3 = Wonder_R4
    = Wonder_Y1 = Wonder_Y2 = Wonder_Y3 = Wonder_Y4 = Wonder_B1 = Wonder_B2 = Wonder_B3 = Wonder_B4 = false;
        //Debug.Log(Y4 + " " + Wonder_G1 + " " + Wonder_B4);

        audioManager = FindObjectOfType<AudioManager>();

        testGameManager = FindObjectOfType<TestGameManager>();
    }

    //private void Update()
    //{
    //    if (photonView.isMine)
    //    {
    //        CheckInput();
    //    }
    //}
    //private void CheckInput()
    //{
    //    var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
    //    this.gameObject.transform.position += move * moveSpeed * Time.deltaTime;

    //    if(Input.GetKeyDown(KeyCode.A))
    //    {
    //        photonView.RPC("FlipTrue", PhotonTargets.AllBuffered);
    //    }
    //    else if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        photonView.RPC("FlipFalse", PhotonTargets.AllBuffered);
    //    }
    //}

    //[PunRPC]
    //private void FlipTrue()
    //{
    //    sr.flipX = true;
    //}

    //[PunRPC]
    //private void FlipFalse()
    //{
    //    sr.flipX = false;
    //}
}

