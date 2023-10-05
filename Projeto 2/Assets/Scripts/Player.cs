using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forcaPulo = 7;
    private Rigidbody rb;
    public bool noChao;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("STAT");
        TryGetComponent(out rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Chão")
        {
            noChao = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Movimentação da esfera
        Debug.Log("UPDATE");
        float h = Input.GetAxis("Horizontal"); // -1 esquerda, 0 nada, 1 direita
        float v = Input.GetAxis("Vertical"); // -1 pra trás, 0 nada, 1 pra frente

        Vector3 direcao = new Vector3(h, 0, v);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forcaPulo, ForceMode.Impulse);
        }
        
        //Reseta a cena, caso o jogador caia da plataforma
        if(transform.position.y <= -10){
            // jogador caiu
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        
        
    }
}
