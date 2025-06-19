using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cysharp.Threading.Tasks;
// using Game.Event;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework; 
using UnityWebSocket;
using UnityEngine;
using Uralstech.Utils.Singleton;
namespace Net
{
   public class BaseRspData
    {
        public string type;
        public bool succ;
    }
    public class RspType
    {
        public const string LOGIN = "login";
        public const string SYNCTIME = "sync_time_response";
        public const string SYNC_INTIAL = "initial_data_response";
        public const string BET_RSP = "betting_rsp_item";
        public const string BUYBALL_RSP = "buyball_rsp_item";

        // public const string QUERY_KAIJIANG_RSP = "stop_betting_info";
        // public const string QUERY_RESULT_RSP = "lottery_inform";
        // public const string SLOT_INFO_RSP = "slot_info";

    }

    public class NetManager : Singleton<NetManager>
    {
        private WebSocketCustom _webSocket;
        private string _token;
        private string _accountID;
        private string _gameID;
        public SyncIntialRspMsg latestSyncInitData;
        private Dictionary<string, object> _rspTag = new Dictionary<string, object>();
        // private void Awake()
        // {
        //     DontDestroyOnLoad(this);
        // }
        protected override void Awake()
        {
            base.Awake();
            Debug.Log("🟢 NetManager Awake, Instance set.");
        }
    
        //----
        public async UniTask Init()
        {
            Debug.Log("NetManager Init");
            _webSocket = new WebSocketCustom();
            await _webSocket.Init();
            InitWebsocketCallback();
            Debug.Log("NetManager Init Success");
        }
        private Dictionary<string, Type> _rspTypes = new Dictionary<string, Type>()
        {
            {RspType.LOGIN,typeof(LoginRspMessage)},
            {RspType.SYNCTIME,typeof(SyncTimeRspMsg)},
            {RspType.SYNC_INTIAL,typeof(SyncIntialRspMsg)},
            {RspType.BET_RSP,typeof(BettingRspMsg)},
            {RspType.BUYBALL_RSP,typeof(BuyBallRspMsg)},
        };
        private void InitWebsocketCallback()
        {
            _webSocket.SetRspListener(this.OnRspCallback);
        }
        private Dictionary<string, List<object>> _netCallbacks = new Dictionary<string, List<object>>();
        public void AddNetListener<T>(string rspType, Action<T> callback)
        {
            if (!_netCallbacks.ContainsKey(rspType))
            {
                _netCallbacks[rspType] = new List<object>();
            }
            _netCallbacks[rspType].Add(callback);
        }
        public void RemoveNetListener<T>(string rspType, Action<T> callback)
        {
            if (_netCallbacks.ContainsKey(rspType))
            {
                _netCallbacks[rspType].Remove(callback);
            }
        }
        private void OnRsp(string rspType, object data)
        {
            if (_netCallbacks.ContainsKey(rspType))
            {
                foreach (var callback in _netCallbacks[rspType])
                {
                    var method = callback.GetType().GetMethod("Invoke");
                    var rspMsgType = _rspTypes[rspType];
                    method.Invoke(callback, new[] { Convert.ChangeType(data, rspMsgType) });
                }
            }
        }
        //登陆请求 / Login requuest
        public void SendLoginReq(string accountID, string gameID, string token)
        {
            Debug.Log("SendLoginReq");
            var request = new LoginRequest();
            var message = new LoginMessage();
            message.token = token;
            message.AccountID = accountID;
            message.GameID = gameID;
            request.message = message;
            _webSocket.SendMsg(request);
        }
        public void SendBetReq(long drawNum, List<BettingReq.Bet> bets)
        {
            var betRequest = new BettingReq();
            betRequest.message = new BettingReq.Msg();
            betRequest.message.DrawNumber = drawNum;
            betRequest.message.Bets = bets.ToArray();
            _webSocket.SendMsg(betRequest);
        }
        public void SendBuyBall(long drawNumber)
        {
            var buyballRequest = new BuyBallReg();
            buyballRequest.message = new BuyBallReg.Msg();
            buyballRequest.message.DrawNumber = drawNumber;
            _webSocket.SendMsg(buyballRequest);
        }
        public void InitWebSocket(WebSocketCustom socket)
        {
            _webSocket = socket;
        }
        public void SendSyncTimeReq()
        {
            var request = new SyncTimeRequest();
            _webSocket.SendMsg(request);
        }
        //初始化数据/Initialize Data
        public void SendInitDataReq()
        {
            var request = new InitializationRequest();
            _webSocket.SendMsg(request);
        }
        //---
        public void SendQueryReq(long index)
        {
            var req = new QueryRequest();
            req.message = new QueryRequest.Msg();
            req.message.DrawNumber = index;
            _webSocket.SendMsg(req);
        }
        public void SendQueryBetResult(long index)
        {
            var req = new QueryBetResultRequest();
            req.message = new QueryBetResultRequest.Message();
            req.message.DrawNumber = index;
            _webSocket.SendMsg(req);
        }
        public void SendSynHistoryRequest()
        {
            var req = new SynHistoryRequest();
            req.message = new SynHistoryRequest.Message();
            _webSocket.SendMsg(req);
        }
        //下注请求
        public void SendSyncRequest(long drawNumber)
        {
            var request = new SyncRequestLotteryRequest();
            request.message = new SyncRequestLotteryRequest.Msg();
            request.message.DrawNumber = drawNumber;
            request.message.AccountID = _accountID;
            request.message.GameID = _gameID;
            _webSocket.SendMsg(request);
        }
        private void OnRspCallback(string rspType, JObject msg)
        {
            if (!_rspTypes.ContainsKey(rspType))
            {
                Debug.LogError($"no type for {rspType}");
                return;
            }
            Debug.Log("Data response from server..." + rspType);
            var data = msg.ToObject(_rspTypes[rspType]);
            _rspTag[rspType] = data;
            OnRsp(rspType, data);
        }
        public UniTask WaitRsp(string rspType)
        {
            _rspTag[rspType] = null;
            return UniTask.WaitUntil(() => _rspTag[rspType] != null);
        }
        public async UniTask<T> WaitRsp<T>(string rspType) where T : class
        {
            _rspTag[rspType] = null;
            await UniTask.WaitUntil(() => _rspTag[rspType] != null);
            return _rspTag[rspType] as T;
        }
        public bool IsConnected()
        {
            return _webSocket != null && _webSocket.IsConnected();
        }
    }
}