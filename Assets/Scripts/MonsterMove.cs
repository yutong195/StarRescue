using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private float speed;
    private Vector2 targetPosition;
    private float radius;
    private Vector2 center;
 

    // Start is called before the first frame update
    void Start()
    {
        
        speed = 0.2f;
        radius = GlobleData.getLevelRadius(GlobleData.currentLevel);
        center = GlobleData.getLevelCenter(GlobleData.currentLevel);
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(targetPosition.normalized * speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, center) > radius - 0.8f)
                targetPosition = GetRandomPosition();


    }

    // get a positon other than transform.position
    private Vector2 GetRandomPosition()
    {
        Vector2 position = GetRandomPoint(radius - 0.6f);
        while (Vector2.Distance(transform.position, position) < 0.5f)
        {
            position = GetRandomPoint(radius - 0.6f);
        }
        return position;
    }

    private Vector2 GetRandomPoint(float maxRadius)
    {
        float angle = (float)Random.Range(0f, 4 * Mathf.PI);  // get a random angle
        float radius = (float)Random.Range(0.6f, maxRadius);
        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);
        Vector2 randomPoint = new Vector2(x, y);
        return randomPoint;
    }
}
