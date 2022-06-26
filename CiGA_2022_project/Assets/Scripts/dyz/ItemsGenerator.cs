using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    public GameObject Fish;
    public GameObject Coin;
    List<Vector2> positionList = new List<Vector2>();
    float x1, x2, y1, y2;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        x1 = -8f;
        x2 = 8f;
        y1 = -1f;
        y2 = 0f;

        for (int i = 0; i < 20; i++)
        {
            GenerateItems(Fish, GenerateRandomPos(x1, x2, y1, y2), Quaternion.identity);
        }

        y1 = -4.5f;
        y2 = -1.5f;

        for (int i = 0; i < 30; i++)
        {
            GenerateItems(Coin, GenerateRandomPos(x1, x2, y1, y2), Quaternion.identity);
        }
    }

    public void GenerateItems(GameObject generateItem, Vector2 generatedPos, Quaternion generateRotation)
    {
        GameObject items = Instantiate(generateItem, generatedPos, generateRotation);

        items.transform.SetParent(gameObject.transform);

        positionList.Add(generatedPos);
    }

    Vector2 GenerateRandomPos(float x1, float x2, float y1, float y2)
    {
        while (true)
        {
            Vector2 generatedPos = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));

            if (IsPosExist(generatedPos) == false)
            {
                return generatedPos;
            }
        }
    }

    bool IsPosExist(Vector2 generatedPos)
    {
        for (int i = 0; i < positionList.Count; i++)
        {
            if (generatedPos == positionList[i])
            {
                return true;
            }
        }

        return false;
    }
}
