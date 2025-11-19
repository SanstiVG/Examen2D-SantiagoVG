using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform jugador;

    private void Update()
    {
        this.transform.position = new Vector3(jugador.position.x+0.1f, jugador.position.y, -1);
    }
}
