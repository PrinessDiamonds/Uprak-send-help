using UnityEngine;



public class Player : MonoBehaviour
{
    private Animator animator;
    private bool isHopping;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

   private void Update()
   {
    if(Input.GetKeyDown(KeyCode.W) && !isHopping)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        int newZ = 0;
        if(transform.position.z % 1 != 0)
        {
            newZ = Mathf.RoundToInt(transform.position.z + 1);
        }
    transform.position = (transform.position + new Vector3(1, 0, newZ));
   }
   }
   public void FinishHop()
   {
    isHopping = false;
   }
}
