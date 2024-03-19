using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    int isRunningRightHash;
    int isWalkingRightHash; 
    int isRunningLeftHash;
    int isWalkingLeftHash;
    int isRunningHash;
    int isJumpingHash; 
    int isWalkingBackHash; 
    int isWalkingHash;
    Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingBackHash = Animator.StringToHash("isWalkingBack");
        isJumpingHash = Animator.StringToHash("isJumping");
        isWalkingLeftHash = Animator.StringToHash("isWalkingLeft");
        isRunningLeftHash = Animator.StringToHash("isRunningLeft");
        isWalkingRightHash = Animator.StringToHash("isWalkingRight");
        isRunningRightHash = Animator.StringToHash("isRunningRight"); 
    }

    // Update is called once per frame
    void Update()
    {
      bool isRunningRight = animator.GetBool(isRunningRightHash);
      bool isWalkingRight = animator.GetBool(isWalkingRightHash);
      bool isRunningleft = animator.GetBool(isRunningLeftHash);
      bool isWalkingLeft = animator.GetBool(isWalkingLeftHash);
      bool isJumping = animator.GetBool(isJumpingHash);
      bool isWalkingBack = animator.GetBool(isWalkingBackHash);
      bool isrunning = animator.GetBool(isRunningHash); 
      bool isWalking = animator.GetBool(isWalkingHash);
      bool backpressed = Input.GetKey("s");
      bool forwardPressed = Input.GetKey("w");
      bool runPressed = Input.GetKey("left shift");
      bool jumppressed = Input.GetKey("space");
      bool leftpressed = Input.GetKey("a");
      bool leftrunpressed = Input.GetKey("left shift");
      bool rightpressed = Input.GetKey("d");
      bool rightrunpressed = Input.GetKey("left shift");


        #region Walking Animation
      if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true); 
        }

      if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false); 
        }

        #endregion
        #region Running Animation
        if (!isrunning && (forwardPressed && runPressed || runPressed && backpressed))
        {
            animator.SetBool(isRunningHash, true); 
        }

      if (isrunning && (!forwardPressed && !backpressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false); 
        }
        #endregion
        #region Walking Animation
        if (!isWalkingBack && backpressed)
        {
            animator.SetBool(isWalkingBackHash, true);
        }

      if (isWalkingBack && !backpressed)
        {
            animator.SetBool(isWalkingBackHash, false); 
        }
        #endregion
        #region Jumping Animation
        if (!isJumping && (forwardPressed && jumppressed || backpressed && jumppressed || runPressed && jumppressed || jumppressed))
        {
            animator.SetBool(isJumpingHash, true); 
        }

        if (isJumping && (!forwardPressed && !backpressed && !runPressed || !jumppressed))
        {
            animator.SetBool(isJumpingHash, false);
        }
        #endregion
        #region Walking Left Animation
        if (!isWalkingLeft && (leftpressed))
        {
            animator.SetBool(isWalkingLeftHash, true); 
        }

        if (isWalkingLeft && (!leftpressed))
        {
            animator.SetBool(isWalkingLeftHash, false); 
        }
        #endregion
        #region Running Left Animation
        if (!isRunningleft && (leftrunpressed && leftrunpressed))
        {
            animator.SetBool(isRunningLeftHash, true); 
        }

        if (isRunningleft && (!leftpressed || !leftrunpressed))
        {
            animator.SetBool(isRunningLeftHash, false); 
        }
        #endregion
        #region Walking Right Animation
        if (!isWalkingRight && (rightpressed))
        {
            animator.SetBool(isWalkingRightHash, true); 
        }

        if (isWalkingRight && (!rightpressed))
        {
            animator.SetBool(isWalkingRightHash, false); 
        }
        #endregion
        #region Running Right Animation
        if (!isRunningRight && (rightpressed && rightrunpressed))
        {
            animator.SetBool(isRunningRightHash, true); 
        }

        if (isRunningRight && (!rightpressed || !rightrunpressed))
        {
            animator.SetBool(isRunningRightHash, false); 
        }
        #endregion
    }
}
