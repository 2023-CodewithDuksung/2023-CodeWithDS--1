using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


[System.Serializable]
public class Serialzation<T>
{
    public Serialzation(List<T> _target) => target = _target;
    public List<T> target;
}


[System.Serializable]
public class Item
{
    public Item(string _Type, string _Name, string _Explain, string _Number, bool _isUsing, bool _myItem)
    {
        Type = _Type; Name = _Name; Explain = _Explain; Number = _Number; isUsing = _isUsing;  myItem = _myItem;
    }

    public string Type, Name, Explain, Number;
    public bool isUsing, myItem;
}



public class GameManager : MonoBehaviour
{

    public TextAsset ItemDatabase;
    public List<Item> AllItemList, MyItemList, CurItemList;
    public string curType = "Store";
    public GameObject[] Slot, UsingImage, BuyButton;
    public Image[] TabImage, ItemImage;
    public Image Base;
    public Sprite TabIdleSprite, TabSelectSprite;
    public Sprite[] ItemSprite, WearingItem; // item slot image
    string filePath;


    void Start()
    {
        string[] line = ItemDatabase.text.Substring(0, ItemDatabase.text.Length - 1).Split('\n');
        
        for (int i = 0; i <  line.Length; i++)
        {
            string[] row = line[i].Split('\t');

            AllItemList.Add(new Item(row[0], row[1], row[2], row[3], row[4] == "TRUE", row[5] == "TRUE"));
        }
        filePath = Application.persistentDataPath + "/MyItemText.txt";
        Load();
        Base.sprite = WearingItem[MyItemList.FindIndex(x => x.isUsing)];
    }


    public void ResetItemClick()
    {
        Item BasicItem = AllItemList.Find(x => x.Name == "모두 벗기");
        MyItemList = new List<Item>() { BasicItem };
        Save();
        Load();
    }


    // 아이템 착용 (item slot 클릭시)
    public void SlotClick(int slotNum)
    {
        Item CurItem = CurItemList[slotNum]; //선택한 아이템 
        Item UsingItem = CurItemList.Find(x => x.isUsing == true); //지금 사용중인 아이템
        Base.sprite = WearingItem[AllItemList.FindIndex(x => x.Name == CurItemList[slotNum].Name)];

        if (curType == "Bag") // 가방에 있는 아이템만 착용
        {
            if (UsingItem != null) UsingItem.isUsing = false; // 착용중인 아이템 벗기
            CurItem.isUsing = true; // 선택한 아이템 착용
        }
        Save();
    }


    // 구매 버튼 클릭
    public void BuyButtonClick(int slotNum)
    {
        Item CurItem = CurItemList[slotNum];

        if (curType == "Store") // 상점에 있는 아이템만 
        {
            CurItem.myItem = true; // 여기에 돈이 얼마나 있는지 if문 추가
        }
        Save();
    }



    public void TabClick(string tabName)
    {
        //Base.sprite = WearingItem[MyItemList.FindIndex(x => x.isUsing)]; //이거때문에 위에 73줄 실행 안됨아아아ㅏ아ㅏ아아ㅏ아아아ㅏ앙야ㅑㅐㅑㅑㅑㅑㅑㅑㅑㅑ
        // 상점, 가방 버튼
        curType = tabName;
        if (curType == "Store")
        {
            CurItemList = MyItemList.FindAll(x => x.myItem == false); // 구매 안한 아이템 찾기
        } else
        {
            CurItemList = MyItemList.FindAll(x => x.myItem == true); // 구매한 아이템 찾기
        }


        for (int i = 0; i < Slot.Length; i++)
        {
            // 아이템 이름, 설명 나오게
            bool isExist = i < CurItemList.Count;
            Slot[i].SetActive(isExist);
            Slot[i].transform.GetChild(0).GetComponent<Text>().text = isExist ? CurItemList[i].Name : "";
            Slot[i].transform.GetChild(3).GetComponent<Text>().text = isExist ? CurItemList[i].Explain : "";

            
            if (isExist)
            {
                ItemImage[i].sprite = ItemSprite[AllItemList.FindIndex(x => x.Name == CurItemList[i].Name)];
                UsingImage[i].SetActive(CurItemList[i].isUsing);
                BuyButton[i].SetActive(!CurItemList[i].myItem);
            }
        }

        int tabNum = 0;
        switch (tabName)
        {
            case "Store": tabNum = 0; break;
            case "Bag": tabNum = 1; break;
        }
        for (int i = 0; i < TabImage.Length; i++)
            TabImage[i].sprite = i == tabNum ? TabSelectSprite : TabIdleSprite;
    }



    void Save()
    {
        string jdata = JsonUtility.ToJson(new Serialzation<Item>(MyItemList));

        File.WriteAllText(filePath, jdata);

        TabClick(curType);
    }



    void Load()
    {
        if (!File.Exists(filePath))
        {
            ResetItemClick(); return;
        }
        string jdata = File.ReadAllText(filePath);
        MyItemList = JsonUtility.FromJson<Serialzation<Item>>(jdata).target;

        TabClick(curType);
    }
}
