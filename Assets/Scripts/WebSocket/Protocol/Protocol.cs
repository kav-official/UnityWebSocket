using System;
using Net;
using Newtonsoft.Json;

//-- LOGIN
public class LoginMessage
{
    public string token;
    public string AccountID;
    public string GameID;
}
public class LoginRequest : WebSocketReq
{
    public LoginMessage message;
    public string cmd => "Login";
    public string type => "login";
}
public class LoginRspMessage
{
    public int issucc;
    public int uid;
    public int utype;
    public string account;
    public string currency;
    public long money;
}
//-- SyncInitial Request
public class SyncInitialReq:WebSocketReq
{
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SyncInitialDataRequest";
}
public class SyncIntialRspMsg
{
    public long current_time;
    public int base_bet;
    public class PeiLv
    {
        public int x;
        public int y;
        public float pei_lv;
    }
    public class LotteryData
    {
        public long draw_number;
        public string lottery_balls;
        public long start_time;
        public long draw_time;
        public PeiLv[] pei_lv;
    }
    public LotteryData[] lottery_data_list;
    public long cur_draw_num;
    public long[] bet_list;
}
//-- Bet Content
public class BettingReq:WebSocketReq
{
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SyncBettingReqRequest";
    public class Bet
    {
        public long BetAmount;
    }
    public class Msg
    {
        public long DrawNumber;
        public Bet[] Bets;
    }
    public Msg message;
}
public class BettingRspMsg
{
    public class Bet
    {
        public long bet_amount;
    }
    public string account_id;
    public string game_id;
    public Bet[] bets;
    public long money;
}
//-- BuyBall Content
public class BuyBallReg:WebSocketReq
{
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SyncGouMaiReqRequest";
    public class Msg
    {
        public long DrawNumber;
    }
    public Msg message;
}
public class BuyBallRspMsg
{
    public long draw_number;
    public string status;
    public int ticket_count;
    public long remaining_money;
}
//-- Change card content
public class ChangeCard:WebSocketReq
{
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SetKaPianDataRequest";
    public class Msg
    {
        public int kaPianCount;
    }
    public Msg message;
}

public class SetKaPianDataRspMsg
{
    public string status;
    public int currentPainCount;
}

public class QueryBetResultResponseMsg
{
    public class Ticket
    {
        public string bet_type;
        public bool is_winner;
        public long winning_amount;
        public float odds;
        public long draw_number;
        public long purchase_date;
        public long bet_amount;
        public string lottery_balls;
    }


    public string account_id;
    public string game_id;
    public Ticket[] tickets;
}
public class QueryRsponeMsg
{
    public class Status
    {
        public const int UN = 0; //未开奖
        public const int ING = 1; //开奖中
        public const int ED = 2; //已开奖
    }


    public long draw_number;
    public int kai_jiang_status;
    public string lottery_balls;

    public class Info
    {
        public int bu;
    }

    public Info[] bi_sai_infos;
}
public class SyncTimeRspMsg
{
    public long current_time;
}
public class SyncTimeRequest : WebSocketReq
{
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SyncTimeRequest";
}
public class InitializationRequest : WebSocketReq
{
    // 请求初始化的地区，以整数形式表示
    //public int Region;
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SyncInitialDataRequest";
    public string rspType => "initial_data_response";
}
public class QueryRequest : WebSocketReq
{
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SyncStopBettingRequest";

    public class Msg
    {
        public long DrawNumber;
    }
    public Msg message;
}
public class QueryBetResultRequest:WebSocketReq
{
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SyncLotteryRecordRequest";

    public class Message
    {
        public long DrawNumber;
    }

    public Message message;
}
public class SynHistoryRequest:WebSocketReq
{
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SynHistoryLotteryRequest";

    public class Message
    {
    }
    public Message message;
}
public class SyncRequestLotteryRequest : WebSocketReq
{
    public string cmd => Constant.WEB_REQUEST_CMD;
    public string type => "SyncRequestLotteryRequest";
    public class Msg
    {
        public long DrawNumber;
        public string AccountID;
        public string GameID;
    }
    public Msg message;
    public string rspType => "lottery_inform";
}