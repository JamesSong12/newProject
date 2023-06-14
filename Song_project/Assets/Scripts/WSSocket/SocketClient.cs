using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;              
using System.Text;
using Newtonsoft.Json;
using UnityEngine.UI;

public class MyData
{
    public string clientID;                    
    public string message;
    public int requestType;                     
}

public class InfoData
{
    public string type;
    public InfoParams myParams;
}

public class InfoParams
{
    public string room;
    public int !oopTimeCount;
}

public class SocketClient : MonoBehaviour
{
    private WebSocket webSocket;
    private bool isConnected = false;
    private int connectionAttempt = 0;             
    private const int maxConnectionAttempts = 3;   

    MyData sendData = new MyData { message = "메세지 전송" };

    public Button sendButton;
    public Button ReconnectButton;
    public Text typeText;
    public Text messageText;
    public text uiLoopCountText;

    public int loopCount;

    void Start()
    {
        ConnectWebSocekt();

        sendButton.onClick.AddListener(() =>
        {
            sendData.reqiest = int.Parse(typeText.text);
            sendData.message = messageText.text;
            string jsonData = JsonConvert.SerializeObject(sendData);

            webSocket.Send(jsonData);

        });

        ReconnectButton.onClick.AddListener(() =>
        {
            ConnectWebSocekt();
        });
    }

    void ConnectWebSocekt()
    {
        webSocket = new WebSocket("ws://localhost:8000");           
        webSocket.OnOpen += OnWebSocketOpen;                        
        webSocket.OnMessage += OnWebSocketMessage;                 
        webSocket.OnClose += OnWebSocketClose;                      

        webSocket.ConnectAsync();
    }

    void OnWebSocketOpen(object sender, System.EventArgs e)       
    {
        Debug.Log("WebSocket connected");
        isConnected = true;
        connectionAttempt = 0;
    }

    void OnWebSocketMessage(object sender, MessageEventArgs e)     
    {
        string jsonData = Encoding.Default.GetString(e.RawData);    
        Debug.Log("Received JSON data : " + jsonData);

        MyData receivedData = JsonConvert.DeserializeObject<MyData>(jsonData);      
        
        InfoData infoData = JsonConvert.DeserializeObject<InfoData>(jsonData);

        if(infoData != null)
        {
            string room = infoData.myParams.room;
            loopCount = infoData.myParams.loopTimeCount;
        }

        if (receivedData != null && !string.IsNullOrEmpty(receivedData.clientID))
        {
            sendData.clientID = receivedData.clientID;                                 
        }

    }

    void OnWebSocketClose(object sender, CloseEventArgs e)             
    {
        Debug.Log("WebSocket connection closed");
        isConnected = false;                                           

        if (connectionAttempt < maxConnectionAttempts)                  
        {
            connectionAttempt++;
            Debug.Log("Attempting to reconnect. Attempt : " + connectionAttempt);
            ConnectWebSocekt();                                                        
        }
        else
        {
            Debug.Log("Failed to connect ");
        }
    }

    void OnApplicationQuit()                       
    {
        DisconnectWebSocket();
    }

    void DisconnectWebSocket()                     
    {
        if (webSocket != null && isConnected)
        {
            webSocket.Close();
            isConnected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (webSocket == null || !isConnected)
        {
            return;
        }

        uiLoopCountText.text = "LoopCount : " + loopCount.ToString()
            ;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            sendData.requestType = 0;
            string jsonData = JsonConvert.SerializeObject(sendData);                

            webSocket.Send(jsonData);

        }
    }
}
