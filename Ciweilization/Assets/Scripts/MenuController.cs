using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";

    [SerializeField] private GameObject usernameMenu;
    [SerializeField] private GameObject connectPanel;

    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField createGameInput;
    [SerializeField] private TMP_InputField joinGameInput;

    [SerializeField] private GameObject startButton;

    private AudioManager audioManager;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        usernameMenu.SetActive(true);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUsernameInput()
    {
        if (usernameInput.text.Length >= 1)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
            Debug.Log("Please Enter An Username");
        }
    }

    public void SetUsername()
    {
        audioManager.Play("Click");

        usernameMenu.SetActive(false);
        PhotonNetwork.playerName = usernameInput.text;
    }

    public void CreateGame()
    {
        audioManager.Play("Click");

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 3;

        PhotonNetwork.CreateRoom(createGameInput.text, roomOptions, null);
    }

    public void JoinGame()
    {
        audioManager.Play("Click");

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 3;

        PhotonNetwork.JoinOrCreateRoom(joinGameInput.text, roomOptions, TypedLobby.Default) ;
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Test Scene");
    }
}

