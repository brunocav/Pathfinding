using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPoints : MonoBehaviour
{
    public Transform target;//alvo segundario
    Vector3 destination;
    private float _distancia; //Armazena a distância

    public Transform[] wayPoints;
    public int wayPointAtual = 0;
    NavMeshAgent agent;
     void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }
    void Update()
    {
        _distancia = Vector3.Distance(agent.transform.position, target.transform.position); //Calculamos a distância e atribuimos a variável
        Debug.Log(_distancia); //Exibimos o valor no Log
        Perseguir();
        if (_distancia <= 10.0f){
            Perseguir();
        }
        else
        {
            Patrulhar();
        }
        }
    void Perseguir() {


        destination = target.transform.position;
        agent.destination = destination;

       
      
    }
     void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "way") {
      wayPointAtual++;
        }
    }
    void Patrulhar() {

        if (wayPointAtual >= wayPoints.Length)
        {
            wayPointAtual = 0;

        }
        if (Vector3.Distance(destination, wayPoints[wayPointAtual].position) > 1.0f)
        {
            destination = wayPoints[wayPointAtual].position;
            agent.destination = destination;
      
        }
    }
}
