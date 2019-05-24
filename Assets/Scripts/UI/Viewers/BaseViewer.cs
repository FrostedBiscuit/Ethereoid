using UnityEngine;

public class BaseViewer : MonoBehaviour
{
    public GameObject objectToHide;
    public bool hideOnAwake = false;
    public bool isOpen { get; private set; }

    public virtual void Awake()
    {
        if (hideOnAwake)
            objectToHide.SetActive(false);
    }

    public virtual void Show() 
    { 
        if (objectToHide != null)
            objectToHide.SetActive(true);

        isOpen = true;
    }

    public virtual void Hide()
    {
        if (objectToHide != null)
            objectToHide.SetActive(false);

        isOpen = false;
    }

    public virtual void Update()
    {

    }
}