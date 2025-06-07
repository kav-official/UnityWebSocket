using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System;
public class TableManageMent : MonoBehaviour
{
    public WinlineManager _winline;
    public RandomNumber randomNumber;
    public List<Sprite> digitSprites;
    [Header("Game Object:")]
    public GameObject TableContentSet1;
    public GameObject TableContentSet2;
    public GameObject TableContentSet3;
    public GameObject _objectTableSelector;
    [Header("Prefab Content:")]
    public GameObject _pefabItemTableSet1;
    public GameObject _pefabItemTableSet2;
    public GameObject _pefabItemTableSet3;
    [Header("Prefab Counter:")]
    private List<GameObject> _spawnedPrefabTable_1 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_2 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_3 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_4 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_5 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_6 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_7 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_8 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_9 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_10 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_11 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_12 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_13 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_14 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_15 = new List<GameObject>();
    private List<GameObject> _spawnedPrefabTable_16 = new List<GameObject>();
     private List<GameObject> counter_table1Item_prefab = new List<GameObject>();
    [Header("Transform table number set 1")]
    public Transform _tableSet1_Content_1;
    public Transform _tableSet1_Content_2;
    public Transform _tableSet1_Content_3;
    public Transform _tableSet1_Content_4;
    [Header("Transform table number set 2")]
    public Transform _tableSet2_Content_1;
    public Transform _tableSet2_Content_2;
    public Transform _tableSet2_Content_3;
    public Transform _tableSet2_Content_4;
    public Transform _tableSet2_Content_5;
    public Transform _tableSet2_Content_6;
    [Header("Transform table number set 3")]
    public Transform _tableSet3_Content_1;
    public Transform _tableSet3_Content_2;
    public Transform _tableSet3_Content_3;
    public Transform _tableSet3_Content_4;
    public Transform _tableSet3_Content_5;
    public Transform _tableSet3_Content_6;
    public Transform _tableSet3_Content_7;
    public Transform _tableSet3_Content_8;
    public Transform _tableSet3_Content_9;
    public Transform _tableSet3_Content_10;
    public Transform _tableSet3_Content_11;
    public Transform _tableSet3_Content_12;
    public Transform _tableSet3_Content_13;
    public Transform _tableSet3_Content_14;
    public Transform _tableSet3_Content_15;
    public Transform _tableSet3_Content_16;
    [Header("Items Prefab Table")]
    public Image _imageBackground;
    public TextMeshProUGUI _textBallTableNumber;
    [Header("Buttons:")]
    public Button buttonShowSelector;
    public Button buttonChange;
    [Header("Random Numbers:")]
    public List<int> _randomTable1;
    public List<int> _randomTable2;
    public List<int> _randomTable3;
    public List<int> _randomTable4;
    public List<int> _randomTable5;
    public List<int> _randomTable6;
    public List<int> _randomTable7;
    public List<int> _randomTable8;
    public List<int> _randomTable9;
    public List<int> _randomTable10;
    public List<int> _randomTable11;
    public List<int> _randomTable12;
    public List<int> _randomTable13;
    public List<int> _randomTable14;
    public List<int> _randomTable15;
    public List<int> _randomTable16;
    [Header("Winline Content")]
    public List<int> Indexes_Wining_line1 = new List<int> { 1, 2, 3, 4, 5 };
    public List<int> Indexes_Wining_line2 = new List<int> { 6, 7, 8, 9, 10 };
    public List<int> Indexes_Wining_line3 = new List<int> { 11, 12, 13, 14, 15 };
    public List<int> Indexes_Wining_line4 = new List<int> {3, 7 ,9, 11,15 };
    public List<int> Indexes_Wining_line5 = new List<int> { 1, 5,6,10,11,15};
    public List<int> Indexes_Wining_line6 = new List<int> { 3,7,9,11,12,13,14,15};
    public List<int> Indexes_Wining_line7 = new List<int> { 1, 5,6,7,8,9,10,13 };
    public List<int> Indexes_Wining_line8 = new List<int> { 1,3,5,7,9,11,13,15 };
    public List<int> Indexes_Wining_line9 = new List<int> { 1,2,3,4,5,7,9,12,14 };
    public List<int> Indexes_Wining_line10 = new List<int> { 6,7,8,9,10,11,12,13,14,15 };
    public List<int> Indexes_Wining_line11 = new List<int> { 1, 2,3,4,5,7,9,12,13,14 };
    public List<int> Indexes_Wining_line12 = new List<int> { 1, 3,5,6,7,8,9,10,11,13,15 };
    public List<int> Indexes_Wining_line13 = new List<int> { 1, 2,3,4,5,6,10,11,12,13,14,15 };
    public List<int> Indexes_Wining_line14 = new List<int> { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15};
    private bool isShowed = false;
    private bool isActive;
    private bool iSettedTable = false;
    private int counterTableNumber;
    [Header("Random List")]
    public List<List<int>> allRandomTables = new List<List<int>>();
    [Header("toggle table set1")]
    public Transform[] allToggleTargetsSet1;
    [Header("toggle table set2")]
    public Transform[] allToggleTargetsSet2;
    [Header("toggle table set3")]
    public Transform[] allToggleTargetsSet3;
    public Transform[] TargetsSet;
    public TextMeshProUGUI textTableCard;
   
    void Start()
    {
        TableContentSet1.SetActive(true);
        TableContentSet2.SetActive(false);
        TableContentSet3.SetActive(false);

        buttonShowSelector.onClick.AddListener(onClickShowSelector);
        buttonChange.onClick.AddListener(onCLickChangeNumber);

        TargetsSet = allToggleTargetsSet1;

        Debug.Log("object::"+TargetsSet.Length);
        CreatePrefabsWithNumbers();
    }
    public void onClickShowSelector()
    {
        isShowed = !isShowed;
        _objectTableSelector.gameObject.SetActive(isShowed);
    }
    public void onCLickChangeNumber()
    {
        ClearOldTablesPrefabs();
        CreatePrefabsWithNumbers();
        // _winline.hasShownHintLine1 = false;
        // _winline.hasShownHintLine2 = false;
        // _winline.hasShownHintLine3 = false;
        // _winline.hasShownFullLine1 = false;
        // _winline.hasShownFullLine2 = false;
        // _winline.hasShownFullLine3 = false;
    }
    void CreatePrefabsWithNumbers()
    {
        _randomTable1 = randomNumber.GetUniqueRandomNumbers(1, 15, 15);
        _randomTable2 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable3 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable4 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable5 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable6 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable7 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable8 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable9 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable10 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable11 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable12 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable13 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable14 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable15 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);
        _randomTable16 = randomNumber.GetUniqueRandomNumbers(1, 99, 15);

        // TABLE NUMBER SET 1
        for (int i = 0; i <= _randomTable1.Count - 1; i++)
        {
            GameObject Instance = Instantiate(_pefabItemTableSet1, _tableSet1_Content_1);
            _spawnedPrefabTable_1.Add(Instance);
            int number = _randomTable1[i];
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
        }

        for (int i = 0; i <= _randomTable2.Count - 1; i++)
        {
            GameObject Instance = Instantiate(_pefabItemTableSet1, _tableSet1_Content_2);
            _spawnedPrefabTable_2.Add(Instance);
            int number = _randomTable2[i];
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }


        for (int i = 0; i <= _randomTable3.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet1, _tableSet1_Content_3);     //  
            _spawnedPrefabTable_3.Add(Instance);                                              //                     
            int number = _randomTable3[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }

        for (int i = 0; i <= _randomTable4.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet1, _tableSet1_Content_4);     //  
            _spawnedPrefabTable_4.Add(Instance);                                              //                     
            int number = _randomTable4[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        // TABLE NUMBER SET 2
        for (int i = 0; i <= _randomTable1.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet2, _tableSet2_Content_1);     //  
            _spawnedPrefabTable_1.Add(Instance);                                              //                     
            int number = _randomTable1[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }

        for (int i = 0; i <= _randomTable2.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet2, _tableSet2_Content_2);     //  
            _spawnedPrefabTable_2.Add(Instance);                                              //                     
            int number = _randomTable2[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }

        for (int i = 0; i <= _randomTable3.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet2, _tableSet2_Content_3);     //  
            _spawnedPrefabTable_3.Add(Instance);                                              //                     
            int number = _randomTable3[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }

        for (int i = 0; i <= _randomTable4.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet2, _tableSet2_Content_4);     //  
            _spawnedPrefabTable_4.Add(Instance);                                              //                     
            int number = _randomTable4[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable5.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet2, _tableSet2_Content_5);     //  
            _spawnedPrefabTable_5.Add(Instance);                                              //                     
            int number = _randomTable5[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable6.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet2, _tableSet2_Content_6);     //  
            _spawnedPrefabTable_6.Add(Instance);                                              //                     
            int number = _randomTable6[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        // TABLE NUMBER SET 3
        for (int i = 0; i <= _randomTable1.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_1);     //  
            _spawnedPrefabTable_1.Add(Instance);                                              //                     
            int number = _randomTable1[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable2.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_2);     //  
            _spawnedPrefabTable_2.Add(Instance);                                              //                     
            int number = _randomTable2[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }

        for (int i = 0; i <= _randomTable3.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_3);     //  
            _spawnedPrefabTable_3.Add(Instance);                                              //                     
            int number = _randomTable3[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable4.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_4);     //  
            _spawnedPrefabTable_4.Add(Instance);                                              //                     
            int number = _randomTable4[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable5.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_5);     //  
            _spawnedPrefabTable_5.Add(Instance);                                              //                     
            int number = _randomTable5[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            {
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable6.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_6);     //  
            _spawnedPrefabTable_6.Add(Instance);                                              //                     
            int number = _randomTable6[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable7.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_7);     //  
            _spawnedPrefabTable_7.Add(Instance);                                              //                     
            int number = _randomTable7[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable8.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_8);     //  
            _spawnedPrefabTable_8.Add(Instance);                                              //                     
            int number = _randomTable8[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable9.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_9);     //  
            _spawnedPrefabTable_9.Add(Instance);                                              //                     
            int number = _randomTable9[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable10.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_10);     //  
            _spawnedPrefabTable_10.Add(Instance);                                              //                     
            int number = _randomTable10[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable11.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_11);     //  
            _spawnedPrefabTable_11.Add(Instance);                                              //                     
            int number = _randomTable11[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable12.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_12);     //  
            _spawnedPrefabTable_12.Add(Instance);                                              //                     
            int number = _randomTable12[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable13.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_13);     //  
            _spawnedPrefabTable_13.Add(Instance);                                              //                     
            int number = _randomTable13[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable13.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_13);     //  
            _spawnedPrefabTable_13.Add(Instance);                                              //                     
            int number = _randomTable13[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable14.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_14);     //  
            _spawnedPrefabTable_14.Add(Instance);                                              //                     
            int number = _randomTable14[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable15.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_15);     //  
            _spawnedPrefabTable_15.Add(Instance);                                              //                     
            int number = _randomTable15[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
        for (int i = 0; i <= _randomTable16.Count - 1; i++)                                   //     
        {
            GameObject Instance = Instantiate(_pefabItemTableSet3, _tableSet3_Content_16);     //  
            _spawnedPrefabTable_16.Add(Instance);                                              //                     
            int number = _randomTable16[i];                                                    //      
            Image digit1 = Instance.transform.Find("Number_1").GetComponent<Image>();
            Image digit2 = Instance.transform.Find("Number_2").GetComponent<Image>();

            if (number < 10)
            { 
                digit1.gameObject.SetActive(false);
                digit2.gameObject.SetActive(true);
                digit2.sprite = digitSprites[number];
            }
            else
            {
                int tens = number / 10;
                int ones = number % 10;

                digit1.gameObject.SetActive(true);
                digit2.gameObject.SetActive(true);

                digit1.sprite = digitSprites[tens];
                digit2.sprite = digitSprites[ones];
            }
           
        }
    }
    // -- COUNT TABLE ACTIVE --//
    public void onClickToggleObject(Transform targetChild)
    {
        // if (targetChild == null) return;
        // isActive = targetChild.gameObject.activeSelf;
        // targetChild.gameObject.SetActive(!isActive);
        if (targetChild == null) return;
        int activeCount = 0;
        for (int i = 0; i < counterTableNumber && i < TargetsSet.Length; i++)
        {
            Transform obj = TargetsSet[i];
            if (obj != null && obj.gameObject.activeSelf)
                activeCount++;
        }
        bool isCurrentlyActive = targetChild.gameObject.activeSelf;
        if (isCurrentlyActive && activeCount == 1)
        {
            Debug.Log("Cannot deactivate the last active object.");
            return;
        }
        targetChild.gameObject.SetActive(!isCurrentlyActive);
        CountAllObjects();
    }
     private void CountAllObjects()
    {
        int activeCount = 0;
        if (!iSettedTable)counterTableNumber = 4;

        for (int i = 0; i < counterTableNumber && i < TargetsSet.Length; i++)
        {
            Transform obj = TargetsSet[i];
            if (obj != null)
            {
                if (obj.gameObject.activeSelf)
                    activeCount++;

            }
        }
        textTableCard.text = activeCount.ToString();
    }
    // -- END  --//

    public void onClickSettableNumber(int countTable)
    {
        iSettedTable = true;
        if (countTable <= 4)
        {
            if (countTable == 1)
            {
                allToggleTargetsSet1[0].gameObject.SetActive(true);
                allToggleTargetsSet1[1].gameObject.SetActive(false);
                allToggleTargetsSet1[2].gameObject.SetActive(false);
                allToggleTargetsSet1[3].gameObject.SetActive(false);
            }
            else if (countTable == 2)
            {
                allToggleTargetsSet1[0].gameObject.SetActive(true);
                allToggleTargetsSet1[1].gameObject.SetActive(true);
                allToggleTargetsSet1[2].gameObject.SetActive(false);
                allToggleTargetsSet1[3].gameObject.SetActive(false);
            }
            else if (countTable == 3)
            {
                allToggleTargetsSet1[0].gameObject.SetActive(true);
                allToggleTargetsSet1[1].gameObject.SetActive(true);
                allToggleTargetsSet1[2].gameObject.SetActive(true);
                allToggleTargetsSet1[3].gameObject.SetActive(false);
            }
            else
            {
                allToggleTargetsSet1[0].gameObject.SetActive(true);
                allToggleTargetsSet1[1].gameObject.SetActive(true);
                allToggleTargetsSet1[2].gameObject.SetActive(true);
                allToggleTargetsSet1[3].gameObject.SetActive(true);
            }
            TableContentSet1.SetActive(true);
            TableContentSet2.SetActive(false);
            TableContentSet3.SetActive(false);
            textTableCard.text = countTable.ToString();
            counterTableNumber = countTable;
            TargetsSet = allToggleTargetsSet1;
        }
        else if (countTable <= 6)
        {
            if (countTable == 5)
            {
                allToggleTargetsSet2[0].gameObject.SetActive(true);
                allToggleTargetsSet2[1].gameObject.SetActive(true);
                allToggleTargetsSet2[2].gameObject.SetActive(true);
                allToggleTargetsSet2[3].gameObject.SetActive(true);
                allToggleTargetsSet2[4].gameObject.SetActive(true);
                allToggleTargetsSet2[5].gameObject.SetActive(false);
            }
            else
            {
                allToggleTargetsSet2[0].gameObject.SetActive(true);
                allToggleTargetsSet2[1].gameObject.SetActive(true);
                allToggleTargetsSet2[2].gameObject.SetActive(true);
                allToggleTargetsSet2[3].gameObject.SetActive(true);
                allToggleTargetsSet2[4].gameObject.SetActive(true);
                allToggleTargetsSet2[5].gameObject.SetActive(true);
            }

            TableContentSet1.SetActive(false);
            TableContentSet2.SetActive(true);
            TableContentSet3.SetActive(false);
            textTableCard.text = countTable.ToString();
            counterTableNumber = countTable;
            TargetsSet = allToggleTargetsSet2;
        }
        else if (countTable <= 16)
        {
            if (countTable == 7)
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(false);
                allToggleTargetsSet3[8].gameObject.SetActive(false);
                allToggleTargetsSet3[9].gameObject.SetActive(false);
                allToggleTargetsSet3[10].gameObject.SetActive(false);
                allToggleTargetsSet3[11].gameObject.SetActive(false);
                allToggleTargetsSet3[12].gameObject.SetActive(false);
                allToggleTargetsSet3[13].gameObject.SetActive(false);
                allToggleTargetsSet3[14].gameObject.SetActive(false);
                allToggleTargetsSet3[15].gameObject.SetActive(false);
            }
            else if (countTable == 8)
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(true);
                allToggleTargetsSet3[8].gameObject.SetActive(false);
                allToggleTargetsSet3[9].gameObject.SetActive(false);
                allToggleTargetsSet3[10].gameObject.SetActive(false);
                allToggleTargetsSet3[11].gameObject.SetActive(false);
                allToggleTargetsSet3[12].gameObject.SetActive(false);
                allToggleTargetsSet3[13].gameObject.SetActive(false);
                allToggleTargetsSet3[14].gameObject.SetActive(false);
                allToggleTargetsSet3[15].gameObject.SetActive(false);
            }
            else if (countTable == 9)
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(true);
                allToggleTargetsSet3[8].gameObject.SetActive(true);
                allToggleTargetsSet3[9].gameObject.SetActive(false);
                allToggleTargetsSet3[10].gameObject.SetActive(false);
                allToggleTargetsSet3[11].gameObject.SetActive(false);
                allToggleTargetsSet3[12].gameObject.SetActive(false);
                allToggleTargetsSet3[13].gameObject.SetActive(false);
                allToggleTargetsSet3[14].gameObject.SetActive(false);
                allToggleTargetsSet3[15].gameObject.SetActive(false);
            }
            else if (countTable == 10)
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(true);
                allToggleTargetsSet3[8].gameObject.SetActive(true);
                allToggleTargetsSet3[9].gameObject.SetActive(true);
                allToggleTargetsSet3[10].gameObject.SetActive(false);
                allToggleTargetsSet3[11].gameObject.SetActive(false);
                allToggleTargetsSet3[12].gameObject.SetActive(false);
                allToggleTargetsSet3[13].gameObject.SetActive(false);
                allToggleTargetsSet3[14].gameObject.SetActive(false);
                allToggleTargetsSet3[15].gameObject.SetActive(false);
            }
            else if (countTable == 11)
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(true);
                allToggleTargetsSet3[8].gameObject.SetActive(true);
                allToggleTargetsSet3[9].gameObject.SetActive(true);
                allToggleTargetsSet3[10].gameObject.SetActive(true);
                allToggleTargetsSet3[11].gameObject.SetActive(false);
                allToggleTargetsSet3[12].gameObject.SetActive(false);
                allToggleTargetsSet3[13].gameObject.SetActive(false);
                allToggleTargetsSet3[14].gameObject.SetActive(false);
                allToggleTargetsSet3[15].gameObject.SetActive(false);
            }
            else if (countTable == 12)
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(true);
                allToggleTargetsSet3[8].gameObject.SetActive(true);
                allToggleTargetsSet3[9].gameObject.SetActive(true);
                allToggleTargetsSet3[10].gameObject.SetActive(true);
                allToggleTargetsSet3[11].gameObject.SetActive(true);
                allToggleTargetsSet3[12].gameObject.SetActive(false);
                allToggleTargetsSet3[13].gameObject.SetActive(false);
                allToggleTargetsSet3[14].gameObject.SetActive(false);
                allToggleTargetsSet3[15].gameObject.SetActive(false);
            }
            else if (countTable == 13)
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(true);
                allToggleTargetsSet3[8].gameObject.SetActive(true);
                allToggleTargetsSet3[9].gameObject.SetActive(true);
                allToggleTargetsSet3[10].gameObject.SetActive(true);
                allToggleTargetsSet3[11].gameObject.SetActive(true);
                allToggleTargetsSet3[12].gameObject.SetActive(true);
                allToggleTargetsSet3[13].gameObject.SetActive(false);
                allToggleTargetsSet3[14].gameObject.SetActive(false);
                allToggleTargetsSet3[15].gameObject.SetActive(false);
            }
            else if (countTable == 14)
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(true);
                allToggleTargetsSet3[8].gameObject.SetActive(true);
                allToggleTargetsSet3[9].gameObject.SetActive(true);
                allToggleTargetsSet3[10].gameObject.SetActive(true);
                allToggleTargetsSet3[11].gameObject.SetActive(true);
                allToggleTargetsSet3[12].gameObject.SetActive(true);
                allToggleTargetsSet3[13].gameObject.SetActive(true);
                allToggleTargetsSet3[14].gameObject.SetActive(false);
                allToggleTargetsSet3[15].gameObject.SetActive(false);
            }
            else if (countTable == 15)
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(true);
                allToggleTargetsSet3[8].gameObject.SetActive(true);
                allToggleTargetsSet3[9].gameObject.SetActive(true);
                allToggleTargetsSet3[10].gameObject.SetActive(true);
                allToggleTargetsSet3[11].gameObject.SetActive(true);
                allToggleTargetsSet3[12].gameObject.SetActive(true);
                allToggleTargetsSet3[13].gameObject.SetActive(true);
                allToggleTargetsSet3[14].gameObject.SetActive(true);
                allToggleTargetsSet3[15].gameObject.SetActive(false);
            }
            else
            {
                allToggleTargetsSet3[0].gameObject.SetActive(true);
                allToggleTargetsSet3[1].gameObject.SetActive(true);
                allToggleTargetsSet3[2].gameObject.SetActive(true);
                allToggleTargetsSet3[3].gameObject.SetActive(true);
                allToggleTargetsSet3[4].gameObject.SetActive(true);
                allToggleTargetsSet3[5].gameObject.SetActive(true);
                allToggleTargetsSet3[6].gameObject.SetActive(true);
                allToggleTargetsSet3[7].gameObject.SetActive(true);
                allToggleTargetsSet3[8].gameObject.SetActive(true);
                allToggleTargetsSet3[9].gameObject.SetActive(true);
                allToggleTargetsSet3[10].gameObject.SetActive(true);
                allToggleTargetsSet3[11].gameObject.SetActive(true);
                allToggleTargetsSet3[12].gameObject.SetActive(true);
                allToggleTargetsSet3[13].gameObject.SetActive(true);
                allToggleTargetsSet3[14].gameObject.SetActive(true);
                allToggleTargetsSet3[15].gameObject.SetActive(true);
            }

            TableContentSet1.SetActive(false);
            TableContentSet2.SetActive(false);
            TableContentSet3.SetActive(true);
            textTableCard.text = countTable.ToString();
            counterTableNumber = countTable;
            TargetsSet = allToggleTargetsSet3;
        }
    }
    public void ClearOldTablesPrefabs()
    {
        foreach (GameObject prefab in _spawnedPrefabTable_1)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_2)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_3)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_4)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_5)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_6)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_7)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_8)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_9)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_10)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_11)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_12)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_13)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_14)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_15)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _spawnedPrefabTable_16)
        {
            if (prefab != null) Destroy(prefab);
        }

        foreach (GameObject prefab in counter_table1Item_prefab)
        {
            if (prefab != null) Destroy(prefab);
        }
        foreach (GameObject prefab in _winline.counter_winline_prefab)
        {
            if (prefab != null) Destroy(prefab);
        }

        _spawnedPrefabTable_1.Clear();
        _spawnedPrefabTable_2.Clear();
        _spawnedPrefabTable_3.Clear();
        _spawnedPrefabTable_4.Clear();
        _spawnedPrefabTable_5.Clear();
        _spawnedPrefabTable_6.Clear();
        _spawnedPrefabTable_7.Clear();
        _spawnedPrefabTable_8.Clear();
        _spawnedPrefabTable_9.Clear();
        _spawnedPrefabTable_10.Clear();
        _spawnedPrefabTable_11.Clear();
        _spawnedPrefabTable_12.Clear();
        _spawnedPrefabTable_13.Clear();
        _spawnedPrefabTable_14.Clear();
        _spawnedPrefabTable_15.Clear();
        _spawnedPrefabTable_16.Clear();
        counter_table1Item_prefab.Clear();
    }
}
