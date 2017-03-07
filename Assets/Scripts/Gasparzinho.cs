using System.Collections;
using UnityEngine;

public class Gasparzinho : MonoBehaviour
{

    public float velocidadeX;
    public float velocidadeY;
    public float min;
    public float max;
    public float espera;

    void Start()
    {
        StartCoroutine(Move(max));
    }

    IEnumerator Move(float destino)
    {
        while (Mathf.Abs(destino - transform.localPosition.y) > 0.2f)
        {
            Vector3 direcaoY = (destino == max) ? Vector3.up : Vector3.down;
            Vector3 velocidadeVetorial = direcaoY * velocidadeX;
            transform.localPosition = transform.localPosition + velocidadeVetorial * Time.deltaTime;

            yield return null;

            Vector3 direcaoX = Vector3.left * velocidadeY;
            transform.position = transform.position + direcaoX * Time.deltaTime;
        }


        yield return new WaitForSeconds(espera);

        destino = (destino == max) ? min : max;
        StartCoroutine(Move(destino));
    }
}