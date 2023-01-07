using UnityEngine;

public class TrajectoryPrediction : MonoBehaviour
{
    public Ball ball;
    public int maxReflectionCount = 2;
    public float maxStepDistance = 5;

    private Vector2 speedDirection;
    public LineRenderer lineRenderer;

    private Gradient gradient = new Gradient();
    private Gradient gradient_undetect = new Gradient();
    private Gradient gradient_detected = new Gradient();

    // Start is called before the first frame update
    void Start()
    {

        float alpha = 1.0f;

        gradient_undetect.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );

        gradient_detected.SetKeys(

          new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.yellow, 1.0f) },
          new GradientAlphaKey[] { new GradientAlphaKey(0, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
      );

    }

    // Update is called once per frame
    void Update()
    {
        speedDirection = ball.getDirection();
        this.DrawPredictedReflectionPattern((Vector2)ball.transform.position + speedDirection * 0.5f, speedDirection, maxReflectionCount);
    }

    private void DrawPredictedReflectionPattern(Vector2 position, Vector2 direction, int reflectionsRemaining)
    {

        if (reflectionsRemaining == 0)
        {
            return;
        }

        Vector2 startingPosition = position;
        LayerMask mask = LayerMask.GetMask("PaddleBounce", "Monsters","Wall");
        RaycastHit2D hit = Physics2D.Raycast(position, direction, Mathf.Infinity, mask);

        if (hit && hit.collider)
        {

            if (hit.collider.tag == "PaddleMerged"|| hit.collider.tag == "wall")//hit merged paddle
            {

                direction = Vector2.Reflect(direction, hit.normal);//get reflect direction
                position = hit.point + direction * 0.01f;

                //change line color
               
                gradient = gradient_detected;
                
                

            }
            else
            {//hit monster//will be never called ha
                //Debug.Log("hit "+hit.collider.name);
                
                position += direction * maxStepDistance;
                gradient = gradient_undetect;

            }
        }

        else
        {
            gradient = gradient_undetect;
            position += direction * maxStepDistance;

        }

        lineRenderer.colorGradient = gradient;
        lineRenderer.SetPosition(reflectionsRemaining, startingPosition);
        lineRenderer.SetPosition(reflectionsRemaining - 1, position);


        DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);


    }

  
}
