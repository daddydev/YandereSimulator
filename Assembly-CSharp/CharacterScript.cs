using UnityEngine;

// Token: 0x0200005F RID: 95
public class CharacterScript : MonoBehaviour {

  // Token: 0x06000156 RID: 342 RVA: 0x0001645C File Offset: 0x0001485C
  private void SetAnimations() {
    Animation component = base.GetComponent<Animation>();
    component["f02_yanderePose_00"].layer = 1;
    component["f02_yanderePose_00"].weight = 0f;
    component.Play("f02_yanderePose_00");
    component["f02_shy_00"].layer = 2;
    component["f02_shy_00"].weight = 0f;
    component.Play("f02_shy_00");
    component["f02_fist_00"].layer = 3;
    component["f02_fist_00"].weight = 0f;
    component.Play("f02_fist_00");
    component["f02_mopping_00"].layer = 4;
    component["f02_mopping_00"].weight = 0f;
    component["f02_mopping_00"].speed = 2f;
    component.Play("f02_mopping_00");
    component["f02_carry_00"].layer = 5;
    component["f02_carry_00"].weight = 0f;
    component.Play("f02_carry_00");
    component["f02_mopCarry_00"].layer = 6;
    component["f02_mopCarry_00"].weight = 0f;
    component.Play("f02_mopCarry_00");
    component["f02_bucketCarry_00"].layer = 7;
    component["f02_bucketCarry_00"].weight = 0f;
    component.Play("f02_bucketCarry_00");
    component["f02_cameraPose_00"].layer = 8;
    component["f02_cameraPose_00"].weight = 0f;
    component.Play("f02_cameraPose_00");
    component["f02_dipping_00"].speed = 2f;
    component["f02_cameraPose_00"].weight = 0f;
    component["f02_shy_00"].weight = 0f;
  }

  // Token: 0x04000422 RID: 1058
  public Transform RightBreast;

  // Token: 0x04000423 RID: 1059
  public Transform LeftBreast;

  // Token: 0x04000424 RID: 1060
  public Transform ItemParent;

  // Token: 0x04000425 RID: 1061
  public Transform PelvisRoot;

  // Token: 0x04000426 RID: 1062
  public Transform RightEye;

  // Token: 0x04000427 RID: 1063
  public Transform LeftEye;

  // Token: 0x04000428 RID: 1064
  public Transform Head;

  // Token: 0x04000429 RID: 1065
  public Transform[] Spine;

  // Token: 0x0400042A RID: 1066
  public Transform[] Arm;

  // Token: 0x0400042B RID: 1067
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x0400042C RID: 1068
  public Renderer RightYandereEye;

  // Token: 0x0400042D RID: 1069
  public Renderer LeftYandereEye;
}