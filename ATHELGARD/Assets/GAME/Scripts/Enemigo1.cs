using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemigo1 : MonoBehaviour
{

    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool attack;


    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento_enemigo();
       
    }


    public void Comportamiento_enemigo()
    {

        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            ani.SetBool("run", false);
            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("caminar", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * Time.deltaTime * 1);
                    ani.SetBool("caminar", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1.5 && !attack)
            {
                
            
                
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

                ani.SetBool("caminar", false);
                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * Time.deltaTime * 2);
                ani.SetBool("atack", false);
            }
            else
            {
                ani.SetBool("run", false);
                ani.SetBool("caminar", false);
                ani.SetBool("atack", true);
                attack = true;
            }
        }
        }

    public void Final_Ani()
    {
        ani.SetBool("atack", false);
        attack = false;
    }
}
