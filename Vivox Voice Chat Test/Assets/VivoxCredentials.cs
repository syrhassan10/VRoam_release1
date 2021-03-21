using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VivoxUnity;
using System.ComponentModel;
using System;
using UnityEngine.UI;
using TMPro;

public class  VivoxCredentials : MonoBehaviour
{
    VivoxUnity.Client client;
    private Uri server = new Uri("");
    private string issuer = "";
    private string domain  = "";
    private string tokenKey = "";
    private TimeSpan timespan = new TimeSpan(90);
    private AsyncCallback loginCallback;

    private ILoginSession loginSession;

    #region UI Variables
    // Updated UI variables not shown In my first video
    // The rest of the code is fairly the same
    [SerializeField] Text txt_UserName;
    [SerializeField] Text txt_ChannelName;
    [SerializeField] Text txt_Message_Prefab;
    [SerializeField] TMP_InputField tmp_Input_Username;
    [SerializeField] TMP_InputField tmp_Input_ChannelName;
    [SerializeField] TMP_InputField tmp_Input_SendMessages;
    [SerializeField] Image container;

    #endregion


    private void Awake()
    {
        client = new Client();
        client.Uninitialize();
        client.Initialize();
        DontDestroyOnLoad(this);
    }

    private void OnApplicationQuit()
    {
        client.Uninitialize();

    }

    void Start()
    {
        Instantiate(txt_Message_Prefab, container.transform);
        Instantiate(txt_Message_Prefab, container.transform);
        Instantiate(txt_Message_Prefab, container.transform);
        Instantiate(txt_Message_Prefab, container.transform);
        Instantiate(txt_Message_Prefab, container.transform);
        Instantiate(txt_Message_Prefab, container.transform);
        Instantiate(txt_Message_Prefab, container.transform);
        Instantiate(txt_Message_Prefab, container.transform);
        Instantiate(txt_Message_Prefab, container.transform);
    }

    public void Bind_Login_Callback_Listeners(bool bind, ILoginSession loginSesh)
    {
        if (bind == true)      // subscribes to the event
        {
            loginSesh.PropertyChanged += Login_Status;
        }
        else            // unsubscribes to the event
        {
            loginSesh.PropertyChanged -= Login_Status;
        }
    }

    public void LoginUser()
    {
        Login("Test_Name");
    }

    public void Login(string username)
    {
        AccountId accountId = new AccountId(issuer,username, domain);
        Bind_Login_Callback_Listeners(true, loginSession);
        loginSession = client.GetLoginSession(accountId);
        loginSession.BeginLogin(server, loginSession.GetLoginToken(tokenKey, timespan), ar => 
        {
            try
            {
                loginSession.EndLogin(ar);
            }
            catch (Exception e)
            {
                //if there is an error, unbind
                Bind_Login_Callback_Listeners(false, loginSession);
                Debug.Log(e.Message);
            }
            // u can now run more code here but you are still not logged in
        });
    }

    public void Login_Result(IAsyncResult asyncResult)
    {
        try
        {
            loginSession.EndLogin(asyncResult);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public void LogOut()
    {
        loginSession.Logout();
        Bind_Login_Callback_Listeners(false, loginSession);
    }

    public void Login_Status(object sender, PropertyChangedEventArgs Login_Args)
    {
        var source = (ILoginSession)sender;
        
        switch (source.State)
        {
            case LoginState.LoggingIn:
                Debug.Log("LOGGING IN");
                break;

            case LoginState.LoggedIn:
                Debug.Log($"LOGGED IN {loginSession.LoginSessionId.Name}");
                break;
        }


    }
}
