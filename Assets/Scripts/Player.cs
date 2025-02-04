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
        float zDifference = 0;
        if(transform.position.z % 1 != 0)
        {
            zDifference = Mathf.RoundToInt(transform.position.z) - transform.position.z;
        }
    transform.position = (transform.position + new Vector3(1, 0, zDifference));
   }
   }
   public void FinishHop()
   {
    isHopping = false;
   }
}
