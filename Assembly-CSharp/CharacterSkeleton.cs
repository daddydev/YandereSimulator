using System;
using UnityEngine;

// Token: 0x020000A0 RID: 160
[Serializable]
public class CharacterSkeleton {

  // Token: 0x17000030 RID: 48
  // (get) Token: 0x0600027A RID: 634 RVA: 0x00034142 File Offset: 0x00032542
  public Transform Head {
    get {
      return this.head;
    }
  }

  // Token: 0x17000031 RID: 49
  // (get) Token: 0x0600027B RID: 635 RVA: 0x0003414A File Offset: 0x0003254A
  public Transform Neck {
    get {
      return this.neck;
    }
  }

  // Token: 0x17000032 RID: 50
  // (get) Token: 0x0600027C RID: 636 RVA: 0x00034152 File Offset: 0x00032552
  public Transform Chest {
    get {
      return this.chest;
    }
  }

  // Token: 0x17000033 RID: 51
  // (get) Token: 0x0600027D RID: 637 RVA: 0x0003415A File Offset: 0x0003255A
  public Transform Stomach {
    get {
      return this.stomach;
    }
  }

  // Token: 0x17000034 RID: 52
  // (get) Token: 0x0600027E RID: 638 RVA: 0x00034162 File Offset: 0x00032562
  public Transform Pelvis {
    get {
      return this.pelvis;
    }
  }

  // Token: 0x17000035 RID: 53
  // (get) Token: 0x0600027F RID: 639 RVA: 0x0003416A File Offset: 0x0003256A
  public Transform RightShoulder {
    get {
      return this.rightShoulder;
    }
  }

  // Token: 0x17000036 RID: 54
  // (get) Token: 0x06000280 RID: 640 RVA: 0x00034172 File Offset: 0x00032572
  public Transform LeftShoulder {
    get {
      return this.leftShoulder;
    }
  }

  // Token: 0x17000037 RID: 55
  // (get) Token: 0x06000281 RID: 641 RVA: 0x0003417A File Offset: 0x0003257A
  public Transform RightUpperArm {
    get {
      return this.rightUpperArm;
    }
  }

  // Token: 0x17000038 RID: 56
  // (get) Token: 0x06000282 RID: 642 RVA: 0x00034182 File Offset: 0x00032582
  public Transform LeftUpperArm {
    get {
      return this.leftUpperArm;
    }
  }

  // Token: 0x17000039 RID: 57
  // (get) Token: 0x06000283 RID: 643 RVA: 0x0003418A File Offset: 0x0003258A
  public Transform RightElbow {
    get {
      return this.rightElbow;
    }
  }

  // Token: 0x1700003A RID: 58
  // (get) Token: 0x06000284 RID: 644 RVA: 0x00034192 File Offset: 0x00032592
  public Transform LeftElbow {
    get {
      return this.leftElbow;
    }
  }

  // Token: 0x1700003B RID: 59
  // (get) Token: 0x06000285 RID: 645 RVA: 0x0003419A File Offset: 0x0003259A
  public Transform RightLowerArm {
    get {
      return this.rightLowerArm;
    }
  }

  // Token: 0x1700003C RID: 60
  // (get) Token: 0x06000286 RID: 646 RVA: 0x000341A2 File Offset: 0x000325A2
  public Transform LeftLowerArm {
    get {
      return this.leftLowerArm;
    }
  }

  // Token: 0x1700003D RID: 61
  // (get) Token: 0x06000287 RID: 647 RVA: 0x000341AA File Offset: 0x000325AA
  public Transform RightPalm {
    get {
      return this.rightPalm;
    }
  }

  // Token: 0x1700003E RID: 62
  // (get) Token: 0x06000288 RID: 648 RVA: 0x000341B2 File Offset: 0x000325B2
  public Transform LeftPalm {
    get {
      return this.leftPalm;
    }
  }

  // Token: 0x1700003F RID: 63
  // (get) Token: 0x06000289 RID: 649 RVA: 0x000341BA File Offset: 0x000325BA
  public Transform RightUpperLeg {
    get {
      return this.rightUpperLeg;
    }
  }

  // Token: 0x17000040 RID: 64
  // (get) Token: 0x0600028A RID: 650 RVA: 0x000341C2 File Offset: 0x000325C2
  public Transform LeftUpperLeg {
    get {
      return this.leftUpperLeg;
    }
  }

  // Token: 0x17000041 RID: 65
  // (get) Token: 0x0600028B RID: 651 RVA: 0x000341CA File Offset: 0x000325CA
  public Transform RightKnee {
    get {
      return this.rightKnee;
    }
  }

  // Token: 0x17000042 RID: 66
  // (get) Token: 0x0600028C RID: 652 RVA: 0x000341D2 File Offset: 0x000325D2
  public Transform LeftKnee {
    get {
      return this.leftKnee;
    }
  }

  // Token: 0x17000043 RID: 67
  // (get) Token: 0x0600028D RID: 653 RVA: 0x000341DA File Offset: 0x000325DA
  public Transform RightLowerLeg {
    get {
      return this.rightLowerLeg;
    }
  }

  // Token: 0x17000044 RID: 68
  // (get) Token: 0x0600028E RID: 654 RVA: 0x000341E2 File Offset: 0x000325E2
  public Transform LeftLowerLeg {
    get {
      return this.leftLowerLeg;
    }
  }

  // Token: 0x17000045 RID: 69
  // (get) Token: 0x0600028F RID: 655 RVA: 0x000341EA File Offset: 0x000325EA
  public Transform RightFoot {
    get {
      return this.rightFoot;
    }
  }

  // Token: 0x17000046 RID: 70
  // (get) Token: 0x06000290 RID: 656 RVA: 0x000341F2 File Offset: 0x000325F2
  public Transform LeftFoot {
    get {
      return this.leftFoot;
    }
  }

  // Token: 0x04000843 RID: 2115
  [SerializeField]
  private Transform head;

  // Token: 0x04000844 RID: 2116
  [SerializeField]
  private Transform neck;

  // Token: 0x04000845 RID: 2117
  [SerializeField]
  private Transform chest;

  // Token: 0x04000846 RID: 2118
  [SerializeField]
  private Transform stomach;

  // Token: 0x04000847 RID: 2119
  [SerializeField]
  private Transform pelvis;

  // Token: 0x04000848 RID: 2120
  [SerializeField]
  private Transform rightShoulder;

  // Token: 0x04000849 RID: 2121
  [SerializeField]
  private Transform leftShoulder;

  // Token: 0x0400084A RID: 2122
  [SerializeField]
  private Transform rightUpperArm;

  // Token: 0x0400084B RID: 2123
  [SerializeField]
  private Transform leftUpperArm;

  // Token: 0x0400084C RID: 2124
  [SerializeField]
  private Transform rightElbow;

  // Token: 0x0400084D RID: 2125
  [SerializeField]
  private Transform leftElbow;

  // Token: 0x0400084E RID: 2126
  [SerializeField]
  private Transform rightLowerArm;

  // Token: 0x0400084F RID: 2127
  [SerializeField]
  private Transform leftLowerArm;

  // Token: 0x04000850 RID: 2128
  [SerializeField]
  private Transform rightPalm;

  // Token: 0x04000851 RID: 2129
  [SerializeField]
  private Transform leftPalm;

  // Token: 0x04000852 RID: 2130
  [SerializeField]
  private Transform rightUpperLeg;

  // Token: 0x04000853 RID: 2131
  [SerializeField]
  private Transform leftUpperLeg;

  // Token: 0x04000854 RID: 2132
  [SerializeField]
  private Transform rightKnee;

  // Token: 0x04000855 RID: 2133
  [SerializeField]
  private Transform leftKnee;

  // Token: 0x04000856 RID: 2134
  [SerializeField]
  private Transform rightLowerLeg;

  // Token: 0x04000857 RID: 2135
  [SerializeField]
  private Transform leftLowerLeg;

  // Token: 0x04000858 RID: 2136
  [SerializeField]
  private Transform rightFoot;

  // Token: 0x04000859 RID: 2137
  [SerializeField]
  private Transform leftFoot;
}