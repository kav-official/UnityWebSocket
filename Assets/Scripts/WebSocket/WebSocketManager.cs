using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityWebSocket;
using Uralstech.Utils.Singleton;
using WebSocket = UnityWebSocket.WebSocket;
using WebSocketState = UnityWebSocket.WebSocketState;

namespace Net
{
    public interface WebSocketReq
    {
        public string cmd { get; }
        public string type { get; }
    }
    public class WebSocketRspBase
    {
        public string type;
        public JObject message;
        public bool succ;
    }
    public enum MsgState
    {
        Wait,
        Success,
        Error
    }
    public class WebSocketCustom
    {
        private readonly string address = "wss://server.pgapp.ai/ws";
        private WebSocket _webSocket;
        private Dictionary<string, List<Action<JObject>>> _dictionary = new Dictionary<string, List<Action<JObject>>>();
        public async UniTask Init()
        {
            _webSocket = new WebSocket(address);
            _webSocket.OnOpen += OnOpen;
            _webSocket.OnClose += OnClose;
            _webSocket.OnMessage += OnMessage;
            _webSocket.OnError += OnError;

            _webSocket.ConnectAsync();
            await UniTask.WaitUntil(() => _webSocket.ReadyState == WebSocketState.Open);
            Debug.Log("✅ WebSocket fully initialized and connected!");
        }
        private void OnOpen(object sender, OpenEventArgs openEventArgs)
        {
            Debug.Log("## OnOpen ##");
        }
        private void OnClose(object sender, CloseEventArgs closeEventArgs)
        {
            Debug.Log("## OnClose ##");
        }
        public void Close()
        {
            if (_webSocket != null && _webSocket.ReadyState == WebSocketState.Open)
            {
                _webSocket.CloseAsync();
            }
        }
        public void SendMsg<T>(T msg) where T : WebSocketReq
        {
            if (msg == null)
            {
                return;
            }
            try
            {
                string msgStr = JsonConvert.SerializeObject(msg);
                string msgType = typeof(T).Name;
                _webSocket.SendAsync(msgStr);
            }
            catch (Exception ex)
            {
                Debug.LogError($"❌ SendMsg exception: {ex.Message}\n{ex.StackTrace}");
            }
        }
        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            var data = messageEventArgs.Data;
            Debug.Log($"## OnMessage {data} ##");
            try
            {
                var rsp = JsonConvert.DeserializeObject<WebSocketRspBase>(data);
                if (rsp != null && _callback != null)
                {
                    _callback(rsp.type, rsp.message);
                }
                else
                {
                    Debug.LogWarning("Received invalid response or callback not set.");
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"WebSocket message parse error: {e.Message}");
            }
        }

        private void OnError(object sender, ErrorEventArgs errorEventArgs)
        {
            Debug.LogError($"WebSocket OnError {errorEventArgs.Message}");
        }
        private Action<string, JObject> _callback;
        public void SetRspListener(Action<string, JObject> callback)
        {
            _callback = callback;
        }
        public bool IsConnected()
        {
            return _webSocket != null && _webSocket.ReadyState == WebSocketState.Open;
        }
    }
}
 