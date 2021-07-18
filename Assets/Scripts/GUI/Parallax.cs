using UnityEngine;

/// <summary>
/// Class to create background parallax. 
/// It's possible to change speed, offset and orientation.
/// </summary>
public class Parallax : MonoBehaviour
{
    /// <summary>
    /// Value for move speed background. Default: 0.25f
    /// </summary>
    [SerializeField]
    private float speed = 0.25f;
    /// <summary>
    /// Value for offset between real and duplicate object. Default: 19.2f
    /// </summary>
    [SerializeField]
    private float offset = 19.2f;
    /// <summary>
    /// Bool that indicate parallax orientation. Default: false
    /// </summary>
    [SerializeField]
    private bool toRight = false;
    /// <summary>
    /// Start position of parallax object.
    /// </summary>
    private Vector2 startPosition;
    /// <summary>
    /// Indicate the next position in X axis.
    /// </summary>
    private float nextPosition;
    /// <summary>
    /// It's the gameobject duplicate for get infinite scroll.
    /// </summary>
    private GameObject duplicate;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        startPosition = transform.position;
        createDuplicate();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        nextPosition = Mathf.Repeat(Time.time * -speed, offset);
        Vector2 orientation = toRight ? Vector2.left : Vector2.right;
        transform.position = startPosition + orientation * nextPosition;
    }

    /// <summary>
    /// Create a duplicated of this gameobject for repeat position.
    /// </summary>
    private void createDuplicate()
    {
        duplicate = GameObject.Instantiate(transform.gameObject);
        Destroy(duplicate.GetComponent<Parallax>());
        duplicate.transform.parent = transform;
        int orientation = toRight ? -1 : 1;
        duplicate.transform.position = Vector2.left * offset * orientation;
    }
}
