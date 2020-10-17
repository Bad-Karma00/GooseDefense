using UnityEngine;

public class CameraController : MonoBehaviour
{

    //Per qualche motivo su mobile gli assi sono un po' fottuti
    //Right = Su
    //Left = Indietro
    //Forward = Sinistra
    //Back = Destra

    public float speed = 0.05f;

    private void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -65.0f, 5.0f),
                Mathf.Clamp(transform.position.y, 130.0f, 130.0f),
                Mathf.Clamp(transform.position.z, -43.0f, -43.0f));
        }

        if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }

    }

}