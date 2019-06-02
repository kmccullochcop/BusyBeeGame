using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeMoveScript : MonoBehaviour
{
  public float speed = 2.5f;          //Floating point variable to store the player's movement speed.

  private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

  public float flowers = 0;

  public string sceneName;
  public Scene scene;

  // Use this for initialization
  void Start()
  {
    //Get and store a reference to the Rigidbody2D component so that we can access it.
    rb2d = GetComponent<Rigidbody2D> ();
    this.scene = SceneManager.GetActiveScene();
   // Check if the name of the current Active Scene is your first Scene.
   if (scene.name == "firstLevel"){
     this.sceneName = "secondLevel";
   }
   else if(scene.name == "secondLevel"){
     this.sceneName = "thirdLevel";
   }
   else if(scene.name == "thirdLevel"){
     this.sceneName = "fourthLevel";
   }
   else if(scene.name == "fourthLevel"){
     this.sceneName = "fifthLevel";
   }
   else if(scene.name == "fifthLevel"){
     this.sceneName = "sixthLevel";
   }
   else if(scene.name == "Intro"){
     this.sceneName = "firstLevel";
   }
   else if(scene.name == "sixthLevel"){
     this.sceneName = "endScene";
   }

  }

  void Update ()
  {
      var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

      if (Input.GetKey(KeyCode.LeftArrow))
      {
          transform.position += move * speed * Time.deltaTime;
      }
      if (Input.GetKey(KeyCode.RightArrow))
      {
          transform.position += move * speed * Time.deltaTime;
      }
      if (Input.GetKey(KeyCode.UpArrow))
      {
          transform.position += move * speed * Time.deltaTime;
      }
      if (Input.GetKey(KeyCode.DownArrow))
      {
          transform.position += move * speed * Time.deltaTime;
      }

      if( transform.position.y <= -5.5f || transform.position.y >= 5.5f || transform.position.x <= -9.5 || transform.position.x >= 9.5){
        SceneManager.LoadScene(this.scene.name);
      }
  }
  void OnTriggerEnter2D(Collider2D trig){
    ;

    if(trig.gameObject.name == "finalFlower"){
      if(this.flowers != 3){
        print("Collect all the flowers!");
      }
      else{
        Destroy(trig.gameObject);
        SceneManager.LoadScene (this.sceneName);
      }
    }
    else{
      this.flowers++;
      Destroy(trig.gameObject);
    }
    if(trig.CompareTag("Enemy")){
      SceneManager.LoadScene(this.scene.name);
    }
  }


}
