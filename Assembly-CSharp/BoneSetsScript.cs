using UnityEngine;

// Token: 0x02000049 RID: 73
public class BoneSetsScript : MonoBehaviour {

  // Token: 0x06000105 RID: 261 RVA: 0x00011CC6 File Offset: 0x000100C6
  private void Start() {
  }

  // Token: 0x06000106 RID: 262 RVA: 0x00011CC8 File Offset: 0x000100C8
  private void Update() {
    if (this.Head != null) {
      this.RightArm.localPosition = this.RightArmPosition;
      this.RightArm.localEulerAngles = this.RightArmRotation;
      this.LeftArm.localPosition = this.LeftArmPosition;
      this.LeftArm.localEulerAngles = this.LeftArmRotation;
      this.RightLeg.localPosition = this.RightLegPosition;
      this.RightLeg.localEulerAngles = this.RightLegRotation;
      this.LeftLeg.localPosition = this.LeftLegPosition;
      this.LeftLeg.localEulerAngles = this.LeftLegRotation;
      this.Head.localPosition = this.HeadPosition;
    }
    base.enabled = false;
  }

  // Token: 0x04000361 RID: 865
  public Transform[] BoneSet1;

  // Token: 0x04000362 RID: 866
  public Transform[] BoneSet2;

  // Token: 0x04000363 RID: 867
  public Transform[] BoneSet3;

  // Token: 0x04000364 RID: 868
  public Transform[] BoneSet4;

  // Token: 0x04000365 RID: 869
  public Transform[] BoneSet5;

  // Token: 0x04000366 RID: 870
  public Transform[] BoneSet6;

  // Token: 0x04000367 RID: 871
  public Transform[] BoneSet7;

  // Token: 0x04000368 RID: 872
  public Transform[] BoneSet8;

  // Token: 0x04000369 RID: 873
  public Transform[] BoneSet9;

  // Token: 0x0400036A RID: 874
  public Vector3[] BoneSet1Pos;

  // Token: 0x0400036B RID: 875
  public Vector3[] BoneSet2Pos;

  // Token: 0x0400036C RID: 876
  public Vector3[] BoneSet3Pos;

  // Token: 0x0400036D RID: 877
  public Vector3[] BoneSet4Pos;

  // Token: 0x0400036E RID: 878
  public Vector3[] BoneSet5Pos;

  // Token: 0x0400036F RID: 879
  public Vector3[] BoneSet6Pos;

  // Token: 0x04000370 RID: 880
  public Vector3[] BoneSet7Pos;

  // Token: 0x04000371 RID: 881
  public Vector3[] BoneSet8Pos;

  // Token: 0x04000372 RID: 882
  public Vector3[] BoneSet9Pos;

  // Token: 0x04000373 RID: 883
  public float Timer;

  // Token: 0x04000374 RID: 884
  public Transform RightArm;

  // Token: 0x04000375 RID: 885
  public Transform LeftArm;

  // Token: 0x04000376 RID: 886
  public Transform RightLeg;

  // Token: 0x04000377 RID: 887
  public Transform LeftLeg;

  // Token: 0x04000378 RID: 888
  public Transform Head;

  // Token: 0x04000379 RID: 889
  public Vector3 RightArmPosition;

  // Token: 0x0400037A RID: 890
  public Vector3 RightArmRotation;

  // Token: 0x0400037B RID: 891
  public Vector3 LeftArmPosition;

  // Token: 0x0400037C RID: 892
  public Vector3 LeftArmRotation;

  // Token: 0x0400037D RID: 893
  public Vector3 RightLegPosition;

  // Token: 0x0400037E RID: 894
  public Vector3 RightLegRotation;

  // Token: 0x0400037F RID: 895
  public Vector3 LeftLegPosition;

  // Token: 0x04000380 RID: 896
  public Vector3 LeftLegRotation;

  // Token: 0x04000381 RID: 897
  public Vector3 HeadPosition;
}