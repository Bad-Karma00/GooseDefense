using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Per qualche motivo su mobile gli assi sono un po' fottuti
    //Right = Su
    //Left = Indietro
    //Forward = Sinistra
    //Back = Destra

    public float speed;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -105.0f, 25.0f),
                Mathf.Clamp(transform.position.y, 130.0f, 130.0f),
                Mathf.Clamp(transform.position.z, -43.0f, -43.0f));
        }
    }

}