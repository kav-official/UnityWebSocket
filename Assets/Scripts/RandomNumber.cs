using UnityEngine;
using System.Linq;
using System.Collections.Generic;
public class RandomNumber : MonoBehaviour
{

    public List<int> usedNumber = new();
    public List<int> currentNumber = new();
    public List<int> GenerateRandomNumbers(int count, int min, int max)
    {
        List<int> numbers = new();
        // เตรียม pool เฉพาะเลขที่ยังไม่ถูกใช้
        List<int> pool = new();
        for (int i = min; i <= max; i++)
        {
            if (!usedNumber.Contains(i))
            {
                pool.Add(i);
            }
        }
        // ถ้าเลขเหลือไม่พอจะสุ่มได้ไม่ครบ
        int safeCount = Mathf.Min(count, pool.Count);
        // สุ่มแบบสับเปลี่ยน Fisher–Yates
        for (int i = 0; i < pool.Count; i++)
        {
            int randIndex = Random.Range(i, pool.Count);
            int temp = pool[i];
            pool[i] = pool[randIndex];
            pool[randIndex] = temp;
        }
        // เพิ่มผลลัพธ์
        for (int i = 0; i < safeCount; i++)
        {
            int num = pool[i];
            numbers.Add(num);
            usedNumber.Add(num); // เพิ่มเข้า used เพื่อไม่ให้ใช้ซ้ำ
        }
        currentNumber = new List<int>(numbers); // อัปเดตเลขปัจจุบัน
        return numbers;
    }

    public void onResetNumberRandom()
    {
        usedNumber.Clear();
        currentNumber.Clear();
    }

    public List<int> GetUniqueRandomNumbers(int min, int max, int count)
    {
        List<int> numbers = new List<int>();

        if (count > (max - min + 1))
        {
            Debug.LogError("Not enough unique numbers in range!");
            return numbers;
        }

        while (numbers.Count < count)
        {
            int randomNum = Random.Range(min, max + 1);
            if (!numbers.Contains(randomNum))
                numbers.Add(randomNum);
        }
        return numbers;
    }
    
    public List<int> GetUniqueRandomFromList(int sourceList, int count)
    {
        List<int> result = new List<int>();
        List<int> tempList = new List<int>(sourceList); // สำเนาลิสต์เพื่อไม่กระทบต้นฉบับ

        // ถ้าจำนวนที่ต้องการมากกว่าจำนวนที่มี
        if (count > tempList.Count)
        {
            Debug.LogError("❌ Count exceeds available unique numbers.");
            return result;
        }

        // สุ่มจนได้จำนวนตามที่ต้องการ
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, tempList.Count);
            result.Add(tempList[index]);
            tempList.RemoveAt(index); // ลบออกเพื่อไม่ให้ซ้ำ
        }

        return result;
    }

}
