using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;


public class StartAction : MonoBehaviour
{
    public HelpFunctions help;
    public SettingSlideToggle setting;
    public TableManageMent tableManager;
    public Table1 table1;
    public WinlineManager winLine;
    public PathOrder pathOrder;
    public RandomNumber randomNumber;
    public StarMainBallEffect starMainBallEffect;
    public WildBallShake wildBall;
    [Header("Balls nummber Content")]
    public Sprite[] sprite_balls_Numer;
    public Image digit_ball_1;
    public Image digit_ball_2;
    public Image digit_hot_ball_1;
    public Image digit_hot_ball_2;
    [Header("Mainball number Content")]
    public Image digit_mainball_1;
    public Image digit_mainball_2;
    public Image digit_main_extra_1;
    public Image digit_main_extra_2;
    [Header("Prefab Content")]
    public GameObject _ballPrefab;
    public GameObject _starPrefab;
    public GameObject _extraBallPrefab;
    public GameObject _starEffecPrefab;
    public GameObject _starBackGroundEffect;
    [Header("Image Content")]
    public Image _mainBall;
    public Image _childBalls;
    public Image _imageExtraBall;
    public Image _imageMainExtraBall;
    [Header("Sprite Content")]
    public Sprite _spriteRed;
    public Sprite _spriteBlue;
    public Sprite _spriteGreen;
    public Sprite _spritePink;
    public Sprite _spriteYellow;
    public Sprite _normalStar;
    public Sprite _lightStar;
    public Sprite _spriteGoldMainBall;
    [Header("Button Content")]
    public Button buttonStartGame;
    public Button buttonCancle;
    public Button buttonBuyExtra;
    public Button buttonChangeBalls;
    [Header("Text Content")]
    public TextMeshProUGUI textMainBallEffect;
    // public TextMeshProUGUI textMainBall;
    // public TextMeshProUGUI textBallNumber;
    // public TextMeshProUGUI textExtraballNumber;
    // public TextMeshProUGUI _textExtraMainBall;
    [Header("GameObject Content")]
    public GameObject _mainBallExtraEffectPoint;
    public GameObject _extraMainBallBackground;
    public GameObject _objectMainExtraBall;
    public GameObject _buttonShowRolling;
    public GameObject _objectWinningCoin;
    public GameObject _objectRollingBingoReel;
    [Header("General Content")]
    public Transform _startSpawnPoint;
    public CanvasGroup _canvasButtonBuyExtra;
    public List<Transform> centerPoints;
    public List<Transform> ballPoints;
    public List<int> ballNumbers, extraBallNumber;
    public List<Transform> extraBallPoint;
    private List<GameObject> _spawnBalls = new List<GameObject>();
    private List<GameObject> _spawnExtraBall = new List<GameObject>();
    private int currentStarIndex = 0;
    private bool isStartGame = false;
    public int newExtraBallNumber;
    private float moveDuration = 0.5f;
    private float spawnDelay = 0.1f;
    [Header("Star Content")]
    private int starCount = 0;
    public Transform _startStarPosition;
    public List<Transform> startTargets;
    private List<GameObject> _spawnStar = new List<GameObject>();
    [Header("button show content")]
    public float scaleSpeed  = 1.5f;
    public float scaleAmount = 0.2f;
    private Vector3 originalScale;
    void Start()
    {
        if (_buttonShowRolling != null)
            originalScale = _buttonShowRolling.transform.localScale;

        pathOrder.BuildPathOrder();
        help.showExtraBallBackground();
        buttonCancle.onClick.AddListener(DestroyPrefab);

        buttonStartGame.onClick.AddListener(StartSpawn);
        buttonBuyExtra.onClick.AddListener(BuyExtraBall);
        buttonChangeBalls.onClick.AddListener(help.ResetBall);

        _mainBall.gameObject.SetActive(false);
        _extraMainBallBackground.gameObject.SetActive(false);
    }
    private int numberForExtraBall;
    public void BuyExtraBall()
    {
        int currentBallCount = 0;
        _objectMainExtraBall.gameObject.SetActive(true);
        foreach (Transform ballPoint in extraBallPoint)
        {
            if (ballPoint.childCount > 0)
            {
                currentBallCount++;
            }
        }
        if (currentBallCount >= extraBallPoint.Count)
        {
            _objectMainExtraBall.gameObject.SetActive(false);
            _extraMainBallBackground.gameObject.SetActive(false);
            buttonBuyExtra.gameObject.SetActive(false);
            help.ResetBall();
            setting.HidePossiblePanel();

            Debug.Log("All 10 balls are already created.");
            return;
        }

        newExtraBallNumber = randomNumber.GenerateRandomNumbers(1, 1, 99)[0];
        foreach (Transform ballPoint in extraBallPoint)
        {
            if (ballPoint.childCount == 0)
            {

                GameObject ball = Instantiate(_extraBallPrefab, ballPoint);
                _spawnExtraBall.Add(ball);
                ball.transform.localPosition = Vector3.zero;
                ball.transform.localRotation = Quaternion.identity;
                ball.transform.localScale = Vector3.one;

                _childBalls     = ball.GetComponentInChildren<Image>();
                _imageExtraBall = ball.GetComponent<Image>();
                if (newExtraBallNumber <= 20)
                {
                    _imageExtraBall.sprite = _spriteRed;
                }
                else if (newExtraBallNumber <= 35)
                {
                    _imageExtraBall.sprite = _spriteBlue;
                }
                else if (newExtraBallNumber <= 59)
                {
                    _imageExtraBall.sprite = _spriteGreen;
                }
                else if (newExtraBallNumber <= 70)
                {
                    _imageExtraBall.sprite = _spriteYellow;
                }
                else
                {
                    _imageExtraBall.sprite = _spritePink;
                }
                // -- Main balls hot balls number
                int number = newExtraBallNumber;
                if (number >= 10)
                {
                    int tens = number / 10;
                    int ones = number % 10;

                    digit_main_extra_1.gameObject.SetActive(true);
                    digit_main_extra_1.sprite = sprite_balls_Numer[tens];

                    digit_main_extra_2.gameObject.SetActive(true);
                    digit_main_extra_2.sprite = sprite_balls_Numer[ones];
                }
                else
                {
                    digit_main_extra_1.gameObject.SetActive(false);
                    digit_main_extra_2.gameObject.SetActive(true);

                    digit_main_extra_2.sprite = sprite_balls_Numer[number];
                }
                // -- End
                _imageMainExtraBall.sprite  = _childBalls.sprite;
                CanvasGroup cg              = ballPoint.GetComponent<CanvasGroup>();

                if (cg != null)
                {
                    cg.enabled = false;
                }
                HotnewBall script = ballPoint.GetComponent<HotnewBall>();
                if (script != null)
                {
                    script.enabled = false;
                }
                //-- Hot ball number
                Image[] digitImages = ball.GetComponentsInChildren<Image>();
                if (digitImages.Length >= 3)
                {
                    digit_hot_ball_1 = digitImages[1]; 
                    digit_hot_ball_2 = digitImages[2];
                }
                if (number >= 10)
                {
                    int tens = number / 10;
                    int ones = number % 10;

                    digit_hot_ball_1.gameObject.SetActive(true);
                    digit_hot_ball_1.sprite   = sprite_balls_Numer[tens];

                    digit_hot_ball_2.gameObject.SetActive(true);
                    digit_hot_ball_2.sprite   = sprite_balls_Numer[ones];
                }
                else
                {
                    digit_hot_ball_1.gameObject.SetActive(false);
                    digit_hot_ball_2.gameObject.SetActive(true);
                    digit_hot_ball_2.sprite = sprite_balls_Numer[number];
                }
                //-- End hot ball
                Debug.Log("Created extra ball:" + newExtraBallNumber);

                StartCoroutine(buySuccess());
                IEnumerator buySuccess()
                {
                    _extraMainBallBackground.gameObject.SetActive(false);
                    yield return new WaitForSeconds(1);
                    _extraMainBallBackground.gameObject.SetActive(true);
                    _objectMainExtraBall.gameObject.SetActive(false);
                }
                help.ResetBall();
                return;
            }
        }

    }

    public void StartSpawn()
    {
        StartCoroutine(spawnBalls());
        isStartGame = !isStartGame;
        _mainBall.gameObject.SetActive(true);

        IEnumerator spawnBalls()
        {
            ballNumbers = randomNumber.GenerateRandomNumbers(30, 1, 99);
            int centerRowIndex = 0;

            for (int j = 0; j < pathOrder.Orders.Count; j++)
            {
                int i = pathOrder.Orders[j];
                if (i >= 23) centerRowIndex = 1;
                else centerRowIndex = 0;

                GameObject newBall = Instantiate(_ballPrefab);
                newBall.transform.SetParent(ballPoints[i].parent, false);
                _spawnBalls.Add(newBall);
                _childBalls = newBall.GetComponentInChildren<Image>();

                Image[] digitImages = newBall.GetComponentsInChildren<Image>();
                if (digitImages.Length >= 3)
                {
                    digit_ball_1 = digitImages[1]; 
                    digit_ball_2 = digitImages[2];
                }

                if (ballNumbers[i] <= 20)
                {
                    _childBalls.sprite = _spriteRed;
                }
                else if (ballNumbers[i] <= 35)
                {
                    _childBalls.sprite = _spriteBlue;
                }
                else if (ballNumbers[i] <= 59)
                {
                    _childBalls.sprite = _spriteGreen;
                }
                else if (ballNumbers[i] <= 70)
                {
                    _childBalls.sprite = _spriteYellow;
                }
                else
                {
                    _childBalls.sprite = _spritePink;
                }

                if (i < ballNumbers.Count)
                {
                    _mainBall.sprite = _childBalls.sprite;
                }

                int number = ballNumbers[i];
                if (number >= 10)
                {
                    int tens = number / 10;
                    int ones = number % 10;

                    digit_ball_1.gameObject.SetActive(true);
                    digit_mainball_1.gameObject.SetActive(true);
                    digit_ball_1.sprite = sprite_balls_Numer[tens];
                    digit_mainball_1.sprite = sprite_balls_Numer[tens];

                    digit_ball_2.gameObject.SetActive(true);
                    digit_mainball_2.gameObject.SetActive(true);
                    digit_ball_2.sprite = sprite_balls_Numer[ones];
                    digit_mainball_2.sprite = sprite_balls_Numer[ones];
                }
                else
                {
                    digit_ball_1.gameObject.SetActive(false);
                    digit_mainball_1.gameObject.SetActive(false);

                    digit_ball_2.gameObject.SetActive(true);
                    digit_mainball_2.gameObject.SetActive(true);

                    digit_ball_2.sprite     = sprite_balls_Numer[number];
                    digit_mainball_2.sprite = sprite_balls_Numer[number];
                }

                RectTransform ballRT = newBall.GetComponent<RectTransform>();
                RectTransform startRT = _startSpawnPoint.GetComponent<RectTransform>();
                RectTransform centerRT = centerPoints[centerRowIndex].GetComponent<RectTransform>();
                RectTransform targetRT = ballPoints[i].GetComponent<RectTransform>();
                ballRT.anchoredPosition = startRT.anchoredPosition;

                LeanTween.move(ballRT, centerRT.anchoredPosition, moveDuration)
                    .setEase(LeanTweenType.easeOutBack)
                    .setOnComplete(() =>
                    {
                        LeanTween.move(ballRT, targetRT.anchoredPosition, moveDuration)
                            .setEase(LeanTweenType.easeOutBack);
                        table1.StartCheckBallNumber();
                    });
                // -- Star spawn ball
                if (ballNumbers[i] == 15 || ballNumbers[i] == 10 || ballNumbers[i] == 11 || ballNumbers[i] == 12)
                {
                    textMainBallEffect.text = ballNumbers[i].ToString();
                    StartCoroutine(MainBallEffect());
                    starMainBallEffect.PlayFX();
                    starMainBallEffect.PlayFX2();
                    
                    yield return new WaitForSeconds(1f);
                    yield return StartCoroutine(SpawnFallingStar());
                }
                // -- Free ball
                if (ballNumbers[i] == 13 || ballNumbers[i] == 14 || ballNumbers[i] == 15)
                {
                    starMainBallEffect.PlayFreeBallEffect();
                    yield return new WaitForSeconds(5f);
                    foreach (var prefab in starMainBallEffect.spawnFreeBall)
                    {
                        Destroy(prefab);
                    }
                }
                // -- Wild ball
                if (ballNumbers[i] == 1 || ballNumbers[i] == 2 || ballNumbers[i] == 3)
                {
                    wildBall.ShowWildBall_Popup();
                    starMainBallEffect.WildBall_MiniBall_Effect();
                    starMainBallEffect.WildBallEffect();
                    yield return new WaitForSeconds(5f);
                    foreach (var prefab in starMainBallEffect.spawnWildBall)
                    {
                        Destroy(prefab);
                    }
                    foreach (var prefab in starMainBallEffect.spawnWildMiniBalls)
                    {
                        Destroy(prefab);
                    }
                    wildBall.HideWildBall_Popup();
                    wildBall.ShowWildContentTop();
                    wildBall.CountDown_Wildball();

                    wildBall.showWildBall_W();
                    starMainBallEffect.WildBallMainBall_W_Effect();
                    yield return new WaitForSeconds(9);
                    wildBall.HideWildContentTop();
                    wildBall.Stop_CountDown_Wildball();

                    wildBall.hideWildBall_W();
                    foreach (var prefab in starMainBallEffect.spawnWildBallMainBall)
                    {
                        Destroy(prefab);
                    }
                }
                //-- Winning Coin droping
                if (ballNumbers[i] == 20 || ballNumbers[i] == 21 || ballNumbers[i] == 31)
                {
                    _objectWinningCoin.SetActive(true);
                    starMainBallEffect.Coin_Drop_Effect();
                    starMainBallEffect.Effect_BackLight_Coin();
                    yield return new WaitForSeconds(5f);
                    foreach (var prefab in starMainBallEffect.spawnCoinDroping)
                    {
                        Destroy(prefab);
                    }
                    _objectWinningCoin.SetActive(false);
                }
                //-- Winning Rolling Reel Spin
                if (ballNumbers[i] == 70 || ballNumbers[i] == 80 || ballNumbers[i] == 90)
                {
                    _objectRollingBingoReel.SetActive(true);
                    yield return new WaitForSeconds(11f);
                    _objectRollingBingoReel.SetActive(false);
                }

                //-- Extra ball
                int counter = _spawnBalls.Count;
                if (counter == 30)
                {
                    StartCoroutine(OpenTheDoor());
                    _canvasButtonBuyExtra.alpha = 1;
                    _mainBall.gameObject.SetActive(false);
                    _extraMainBallBackground.gameObject.SetActive(true);
                }
                buttonBuyExtra.gameObject.SetActive(false);
                buttonStartGame.gameObject.SetActive(false);
                yield return new WaitForSeconds(spawnDelay);
            }


            yield return new WaitForSeconds(1.5f);
            buttonBuyExtra.gameObject.SetActive(true);
            setting.ShowPossiblePanel();
            table1.CheckWinline();
        }
    }
    IEnumerator SpawnFallingStar()
    {
        if (currentStarIndex >= startTargets.Count) yield break;

        GameObject star = Instantiate(_starPrefab);
        _spawnStar.Add(star);
        star.transform.SetParent(_startStarPosition.parent, false);

        starCount++;

        RectTransform starRT = star.GetComponent<RectTransform>();
        starRT.anchoredPosition = _startStarPosition.GetComponent<RectTransform>().anchoredPosition;

        // ⭐ EFFECT 
        GameObject impact = Instantiate(_starEffecPrefab, starRT.position, Quaternion.identity, starRT.parent);
        Destroy(impact, 1f);

        Image img = star.GetComponent<Image>();
        img.sprite = _lightStar;
        StartCoroutine(ChangeNormalStar(img, 0.3f));

        Vector2 targetPos = startTargets[currentStarIndex].GetComponent<RectTransform>().anchoredPosition;

        LeanTween.move(starRT, targetPos, 0.7f)
            .setEase(LeanTweenType.easeInQuad)
            .setOnComplete(() =>
            {
                LeanTween.scale(starRT, Vector3.one * 1.2f, 0.15f)
                    .setEase(LeanTweenType.easeOutBack)
                    .setLoopPingPong(1);
            });

        currentStarIndex++;
        yield return new WaitForSeconds(1);

        Debug.Log("⭐ spawn" + starCount);
        // -- Start effect merge
        if (starCount == 1)
        {
            Debug.Log("star == 🤟");
            yield return new WaitForSeconds(1f);
            starMainBallEffect.Effect_buttonMerg_Showrolling();
            StartCoroutine(MergeStarsToCenter());
            yield return new WaitForSeconds(0.4f);
            StartCoroutine(hideStarBG());
            yield return new WaitForSeconds(0.4f);
            StartCoroutine(showButtonRolling());
            // Debug.Log("⭐ spawn" + starCount);


        }
        else if (starCount >=2)
        {
            Debug.Log("star == 🤟🤟🤟");
            if (_buttonShowRolling != null)
            {
                float scaleFactor = 1 + Mathf.PingPong(Time.time * scaleSpeed, scaleAmount);
                _buttonShowRolling.transform.localScale = originalScale * scaleFactor;
            }
        }
    }

    IEnumerator MergeStarsToCenter()
    {
        if (_spawnStar.Count != 1) yield break;
        Vector2 centerPos = startTargets[1].GetComponent<RectTransform>().anchoredPosition;

        foreach (var starObj in _spawnStar)
        {
            RectTransform rt = starObj.GetComponent<RectTransform>();
            LeanTween.move(rt, centerPos, 0.5f)
                .setEase(LeanTweenType.easeInOutQuad);

            LeanTween.scale(rt, Vector3.one * 1.5f, 0.5f)
                .setEase(LeanTweenType.easeOutBack);
        }
        yield return new WaitForSeconds(0.5f);
        GameObject impact = Instantiate(_starBackGroundEffect, startTargets[1].position, Quaternion.identity, _startStarPosition.parent);
        Destroy(impact, 1f);
        foreach (var starObj in _spawnStar)
        {
            Destroy(starObj);
        }
        _spawnStar.Clear();
    }
    IEnumerator ChangeNormalStar(Image img, float delay)
    {
        yield return new WaitForSeconds(delay);
        img.sprite = _normalStar;
    }

    void DestroyPrefab()
    {
        //-- Clear Table Line
        winLine.ResetAllHighlights();
        _extraMainBallBackground.SetActive(false);
        //#########################
        foreach (GameObject ball in _spawnBalls)
        {
            Destroy(ball);
        }

        foreach (GameObject star in _spawnStar)
        {
            Destroy(star);
        }
        foreach (GameObject extraBall in _spawnExtraBall)
        {
            Destroy(extraBall);
        }
        // START Restore ExtraBall Point
        foreach (Transform ballPoint in extraBallPoint)
        {
            CanvasGroup cg = ballPoint.GetComponent<CanvasGroup>();
            if (cg != null)
            {
                cg.enabled = true;
            }
            HotnewBall script = ballPoint.GetComponent<HotnewBall>();
            if (script != null)
            {
                script.enabled = true;
            }
        }
        // :: END
        help.showStarBackground();
        help.isOpen = true;
        _spawnBalls.Clear();
        _spawnStar.Clear();
        _spawnExtraBall.Clear();
        currentStarIndex = 0;
        starCount = 0;
        buttonStartGame.interactable = true;
        buttonStartGame.gameObject.SetActive(true);
        buttonBuyExtra.gameObject.SetActive(true);
        _buttonShowRolling.gameObject.SetActive(false);
        StartCoroutine(OpenTheDoor());

        randomNumber.onResetNumberRandom();
    }
    IEnumerator OpenTheDoor()
    {
        yield return new WaitForSeconds(1);
        help.DoorOpen();
    }

    private IEnumerator hideStarBG()
    {
        yield return null;
        help.hideStarBackgroud();
    }
    private IEnumerator showButtonRolling()
    {
        float duration = 1f;
        _buttonShowRolling.SetActive(true);
        yield return null;
        if (_buttonShowRolling.TryGetComponent<CanvasGroup>(out var canvasGroup))
        {
            canvasGroup.alpha = 0;
            LeanTween.alphaCanvas(canvasGroup, 1f, duration);
        }
        else if (_buttonShowRolling.TryGetComponent<SpriteRenderer>(out var sprite))
        {
            Color c = sprite.color;
            sprite.color = new Color(c.r, c.g, c.b, 0);
            LeanTween.value(gameObject, 0f, 1f, duration)
                .setOnUpdate((float alpha) =>
                {
                    sprite.color = new Color(c.r, c.g, c.b, alpha);
                });
        }
        _buttonShowRolling.transform.localScale = Vector3.zero;
        LeanTween.scale(_buttonShowRolling, Vector3.one, duration)
            .setEase(LeanTweenType.easeOutBack);
    }

    IEnumerator MainBallEffect()
    {
        _mainBallExtraEffectPoint.SetActive(true);
        yield return new WaitForSeconds(2f);
        _mainBallExtraEffectPoint.SetActive(false);
    }

    public void onCLickConfirmWildBall()
    {
        wildBall.HideWildContentTop();
        wildBall.Stop_CountDown_Wildball();
        wildBall.hideWildBall_W();
        foreach (var prefab in starMainBallEffect.spawnWildBallMainBall)
        {
            Destroy(prefab);
        }
        starMainBallEffect.spawnWildBallMainBall.Clear();
        Debug.Log("Wild ball confirmed");
    }
}
