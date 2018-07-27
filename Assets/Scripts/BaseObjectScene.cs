using UnityEngine;

/// <summary>
/// Базовый класс для объектов на игровой сцене
/// </summary>
public abstract class BaseObjectScene : MonoBehaviour {

    protected int _layer;
    protected Color color;
    protected Material _material;
    protected Transform _myTransform;
    protected GameObject _instanceObject;
    protected Rigidbody _rigidbody;
    protected string _name;
    //protected bool _isVisible;

    #region UnityFunction;
    protected virtual void Awake()
    {
        _instanceObject = gameObject;
        _name = _instanceObject.name;
        Renderer rend = GetComponent<Renderer>();
        if (rend)
        {
            _material = rend.material;
        }
        _rigidbody = GetComponent<Rigidbody>();
        _myTransform = transform;
    }
    #endregion;

    #region Property
    /// <summary>
    /// Имя объекта
    /// </summary>
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            _instanceObject.name = _name;
        }
    }

    /// <summary>
    /// Слой объекта
    /// </summary>
    public int Layer
    {
        get
        {
            return _layer;
        }
        set
        {
            _layer = value;
            if(_instanceObject != null)
            {
                _instanceObject.layer = _layer;
                AskLayer(GetTransform, value);
            }
        }
    }

    /// <summary>
    /// Rigidbody объекта
    /// </summary>
    public Rigidbody GetRigidBody
    {
        get
        {
            return _rigidbody;
        }
    }

    /// <summary>
    /// Получить GameObject
    /// </summary>
    public GameObject GetInstanceObject
    {
        get
        {
            return _instanceObject;
        }
    }

    /// <summary>
    /// Получить Transform
    /// </summary>
    public Transform GetTransform
    {
        get
        {
            return _myTransform;
        }
    }
    #endregion;

    #region PrivateFunctions
    /// <summary>
    /// Выставляет слой себе и всем вложенным объектам, независимо от уровня вложенности
    /// </summary>
    /// <param name="obj">Объект</param>
    /// <param name="lvl">Слой</param>
    private void AskLayer (Transform obj, int lvl)
    {
        obj.gameObject.layer = lvl;
        if (obj.childCount > 0)
        {
            foreach (Transform child in obj)
            {
                AskLayer(child, lvl);
            }
        }
    }
    #endregion;

}