using UnityEngine;

public class CheakPattern : MonoBehaviour
{

    private int[,] _input = new int[,] 
    { 
        {0, 0, 0 },
        { 0,0, 1},
        { 0, 1, 0}
    };

    private int[,] _patern = new int[,]
    {
        { 0, 1},
        { 1, 0}
    };

    private void Start()
    {
        Debug.Log(Cheak(_input, _patern));
    }

    public bool Cheak(int[,] input, int[,] pattartn)
    {
        var countOffsetI = input.GetLength(0) - pattartn.GetLength(0);
        var countOffsetJ = input.GetLength(1) - pattartn.GetLength(1);
        for (int i = 0; i <= countOffsetI; i++)
        {
            for (int j = 0; j <= countOffsetJ; j++)
            {
                if (CheakSet(new Vector2Int(i, j), input, pattartn))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool CheakSet(Vector2Int offset, int[,] input, int[,] pattern)
    {
        for (int i = 0; i < pattern.GetLength(0); i++)
        {
            for (int j = 0; j < pattern.GetLength(0); j++)
            {
                var value = input[offset.x + i, offset.y + j];
                if (value != pattern[i, j])
                    return false;
            }
        }
        return true;
    }

}
