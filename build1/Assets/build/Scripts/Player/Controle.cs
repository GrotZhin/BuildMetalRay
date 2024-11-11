using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MetalRay
{
  public class Controle : MonoBehaviour
  {
    [SerializeField] float speed = 5f;
    [SerializeField] float smoothness = 0.1f;
    [SerializeField] float leanAngle = 30f;
    [SerializeField] float leanSpeed = 5f;

    [SerializeField] GameObject model;

    [Header("Bordas da Camera")]
    [SerializeField] Transform cameraFollow;
    [SerializeField] float minX = -1.5f;
    [SerializeField] float maxX = 1.5f;
    [SerializeField] float minY = -2f;
    [SerializeField] float maxY = 2f;

    Vector3 velocidadeAtual;
    Vector3 targetPosition;
    

    void Start()
    {
      
  
    }

    void Update()
    {
      targetPosition += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f) * (speed * Time.deltaTime);
      //Calcular min e max de X e Y baseado na camera
      var minPlayerX = cameraFollow.position.x + minX;
      var maxPlayerX = cameraFollow.position.x + maxX;
      var minPlayerY = cameraFollow.position.y + minY;
      var maxPlayerY = cameraFollow.position.y + maxY;

      // junta a posicao do player a visao da camera

      targetPosition.x = Mathf.Clamp(value: targetPosition.x, minPlayerX, maxPlayerX);
      targetPosition.y = Mathf.Clamp(value: targetPosition.y, minPlayerY, maxPlayerY);

      //Lerp a posicao do player para o targetPosition
      transform.position = Vector3.SmoothDamp(current: transform.position, targetPosition, ref velocidadeAtual, smoothness);

      //calcular o efeito de rotacao
      var targetRotationAngle = -Input.GetAxisRaw("Horizontal") * leanAngle;

      var currentYRotation = transform.localEulerAngles.y;
      var newYRotation = Mathf.LerpAngle(currentYRotation, targetRotationAngle, leanSpeed * Time.deltaTime);

      // Apply the rotation effect
      transform.localEulerAngles = new Vector3(0f, newYRotation, 0f);

    }
    void OnTriggerEnter(Collider hitInfo){
         

          if (hitInfo.gameObject.CompareTag("Finish"))
          {
           
            SceneManager.LoadScene("win");
          }
    }
  
  
  }
}
