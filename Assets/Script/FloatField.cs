using UnityEngine;
using TMPro;

public class FloatField : MonoBehaviour
{
    [SerializeField] private TMP_InputField _distance;

    private float _value;

    public event System.Action<float> OnUpdateValue;

    public void SetValue(float value)
    {
        _value = value;
        _distance.text = value.ToString();
    }

    public void ChangeValue(string value)
    {
        if (float.TryParse(value, out float result))
        {
            _value = result;
            OnUpdateValue?.Invoke(_value);
        }
        else
        {
            _distance.text = _value.ToString();
        }
    }
}
