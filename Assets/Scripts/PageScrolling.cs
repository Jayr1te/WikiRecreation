
using UnityEngine;

public class PageScrolling : MonoBehaviour
{
    public GameObject Background;
    public GameObject PageContent;

    public bool shouldScroll = true;
    public float scrollSpeed = 40;

    float scroll = 0;
    float scrollBottom = 0;

    Vector3 backgroundStartPosition;
    Vector3 pageContentStartPosition;

    RectTransform backgroundRect;

    // Start is called once before the first execution of Update
    void Start()
    {
        if (Background != null)
        {
            backgroundStartPosition = Background.transform.position;
            backgroundRect = Background.GetComponent<RectTransform>();

            if (backgroundRect != null)
            {
                float backgroundHeight =
                    backgroundRect.rect.height * backgroundRect.lossyScale.y;

                float screenHeight = Screen.height;

                scrollBottom = Mathf.Max(0, backgroundHeight - screenHeight);
            }
        }

        if (PageContent != null)
            pageContentStartPosition = PageContent.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldScroll && PageContent != null)
        {
            scroll -= Input.mouseScrollDelta.y * scrollSpeed;

            scroll = Mathf.Clamp(scroll, 0, scrollBottom);

            PageContent.transform.position =
                pageContentStartPosition + new Vector3(0, scroll, 0);

            if (Background != null)
            {
                Background.transform.position =
                    backgroundStartPosition + new Vector3(0, scroll, 0);
            }
        }
    }
}
