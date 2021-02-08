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

    private void Awake()
    {
        if (photonView.isMine)
        {
            PlayerCamera.SetActive(true);
            PlayerNameText.text = PhotonNetwork.playerName;
        }
        else
        {
            PlayerNameText.text = photonView.owner.NickName;
            PlayerNameText.color = Color.red;
        }
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            CheckInput();
        }
    }
    private void CheckInput()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        this.gameObject.transform.position += move * moveSpeed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.A))
        {
            photonView.RPC("FlipTrue", PhotonTargets.AllBuffered);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            photonView.RPC("FlipFalse", PhotonTargets.AllBuffered);
        }
    }

    [PunRPC]
    private void FlipTrue()
    {
        sr.flipX = true;
    }

    [PunRPC]
    private void FlipFalse()
    {
        sr.flipX = false;
    }
}

