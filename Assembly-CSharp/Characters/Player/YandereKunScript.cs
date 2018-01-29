using UnityEngine;

// Token: 0x0200021C RID: 540
public class YandereKunScript : MonoBehaviour {

  // Token: 0x06000965 RID: 2405 RVA: 0x000A45DC File Offset: 0x000A29DC
  private void Start() {
    if (!this.Kizuna) {
      this.KunHips.parent = this.ChanHips;
      this.KunSpine.parent = this.ChanSpine;
      this.KunSpine1.parent = this.ChanSpine1;
      this.KunSpine2.parent = this.ChanSpine2;
      this.KunSpine3.parent = this.ChanSpine3;
      this.KunNeck.parent = this.ChanNeck;
      this.KunHead.parent = this.ChanHead;
      this.KunRightUpLeg.parent = this.ChanRightUpLeg;
      this.KunRightLeg.parent = this.ChanRightLeg;
      this.KunRightFoot.parent = this.ChanRightFoot;
      this.KunRightToes.parent = this.ChanRightToes;
      this.KunLeftUpLeg.parent = this.ChanLeftUpLeg;
      this.KunLeftLeg.parent = this.ChanLeftLeg;
      this.KunLeftFoot.parent = this.ChanLeftFoot;
      this.KunLeftToes.parent = this.ChanLeftToes;
      this.KunRightShoulder.parent = this.ChanRightShoulder;
      this.KunRightArm.parent = this.ChanRightArm;
      this.KunRightArmRoll.parent = this.ChanRightArmRoll;
      this.KunRightForeArm.parent = this.ChanRightForeArm;
      this.KunRightForeArmRoll.parent = this.ChanRightForeArmRoll;
      this.KunRightHand.parent = this.ChanRightHand;
      this.KunLeftShoulder.parent = this.ChanLeftShoulder;
      this.KunLeftArm.parent = this.ChanLeftArm;
      this.KunLeftArmRoll.parent = this.ChanLeftArmRoll;
      this.KunLeftForeArmRoll.parent = this.ChanLeftForeArmRoll;
      this.KunLeftForeArm.parent = this.ChanLeftForeArm;
      this.KunLeftHand.parent = this.ChanLeftHand;
      this.KunLeftHandPinky1.parent = this.ChanLeftHandPinky1;
      this.KunLeftHandPinky2.parent = this.ChanLeftHandPinky2;
      this.KunLeftHandPinky3.parent = this.ChanLeftHandPinky3;
      this.KunLeftHandRing1.parent = this.ChanLeftHandRing1;
      this.KunLeftHandRing2.parent = this.ChanLeftHandRing2;
      this.KunLeftHandRing3.parent = this.ChanLeftHandRing3;
      this.KunLeftHandMiddle1.parent = this.ChanLeftHandMiddle1;
      this.KunLeftHandMiddle2.parent = this.ChanLeftHandMiddle2;
      this.KunLeftHandMiddle3.parent = this.ChanLeftHandMiddle3;
      this.KunLeftHandIndex1.parent = this.ChanLeftHandIndex1;
      this.KunLeftHandIndex2.parent = this.ChanLeftHandIndex2;
      this.KunLeftHandIndex3.parent = this.ChanLeftHandIndex3;
      this.KunLeftHandThumb1.parent = this.ChanLeftHandThumb1;
      this.KunLeftHandThumb2.parent = this.ChanLeftHandThumb2;
      this.KunLeftHandThumb3.parent = this.ChanLeftHandThumb3;
      this.KunRightHandPinky1.parent = this.ChanRightHandPinky1;
      this.KunRightHandPinky2.parent = this.ChanRightHandPinky2;
      this.KunRightHandPinky3.parent = this.ChanRightHandPinky3;
      this.KunRightHandRing1.parent = this.ChanRightHandRing1;
      this.KunRightHandRing2.parent = this.ChanRightHandRing2;
      this.KunRightHandRing3.parent = this.ChanRightHandRing3;
      this.KunRightHandMiddle1.parent = this.ChanRightHandMiddle1;
      this.KunRightHandMiddle2.parent = this.ChanRightHandMiddle2;
      this.KunRightHandMiddle3.parent = this.ChanRightHandMiddle3;
      this.KunRightHandIndex1.parent = this.ChanRightHandIndex1;
      this.KunRightHandIndex2.parent = this.ChanRightHandIndex2;
      this.KunRightHandIndex3.parent = this.ChanRightHandIndex3;
      this.KunRightHandThumb1.parent = this.ChanRightHandThumb1;
      this.KunRightHandThumb2.parent = this.ChanRightHandThumb2;
      this.KunRightHandThumb3.parent = this.ChanRightHandThumb3;
    }
    this.MyRenderer.enabled = true;
    if (this.SecondRenderer != null) {
      this.SecondRenderer.enabled = true;
    }
    base.gameObject.SetActive(false);
  }

  // Token: 0x06000966 RID: 2406 RVA: 0x000A49F4 File Offset: 0x000A2DF4
  private void LateUpdate() {
    if (this.Kizuna) {
      this.KunItemParent.localPosition = new Vector3(0.066666f, -0.033333f, 0.02f);
      this.ChanItemParent.position = this.KunItemParent.position;
      this.KunHips.localPosition = this.ChanHips.localPosition;
      this.KunHips.localEulerAngles = this.ChanHips.localEulerAngles;
      this.KunSpine.localEulerAngles = this.ChanSpine.localEulerAngles;
      this.KunSpine1.localEulerAngles = this.ChanSpine1.localEulerAngles;
      this.KunSpine2.localEulerAngles = this.ChanSpine2.localEulerAngles;
      this.KunSpine3.localEulerAngles = this.ChanSpine3.localEulerAngles;
      this.KunNeck.localEulerAngles = this.ChanNeck.localEulerAngles;
      this.KunHead.localEulerAngles = this.ChanHead.localEulerAngles;
      this.KunRightUpLeg.localEulerAngles = this.ChanRightUpLeg.localEulerAngles;
      this.KunRightLeg.localEulerAngles = this.ChanRightLeg.localEulerAngles;
      this.KunRightFoot.localEulerAngles = this.ChanRightFoot.localEulerAngles;
      this.KunRightToes.localEulerAngles = this.ChanRightToes.localEulerAngles;
      this.KunLeftUpLeg.localEulerAngles = this.ChanLeftUpLeg.localEulerAngles;
      this.KunLeftLeg.localEulerAngles = this.ChanLeftLeg.localEulerAngles;
      this.KunLeftFoot.localEulerAngles = this.ChanLeftFoot.localEulerAngles;
      this.KunLeftToes.localEulerAngles = this.ChanLeftToes.localEulerAngles;
      this.KunRightShoulder.localEulerAngles = this.ChanRightShoulder.localEulerAngles;
      this.KunRightArm.localEulerAngles = this.ChanRightArm.localEulerAngles;
      this.KunRightArmRoll.localEulerAngles = this.ChanRightArmRoll.localEulerAngles;
      this.KunRightForeArm.localEulerAngles = this.ChanRightForeArm.localEulerAngles;
      this.KunRightForeArmRoll.localEulerAngles = this.ChanRightForeArmRoll.localEulerAngles;
      this.KunRightHand.localEulerAngles = this.ChanRightHand.localEulerAngles;
      this.KunLeftShoulder.localEulerAngles = this.ChanLeftShoulder.localEulerAngles;
      this.KunLeftArm.localEulerAngles = this.ChanLeftArm.localEulerAngles;
      this.KunLeftArmRoll.localEulerAngles = this.ChanLeftArmRoll.localEulerAngles;
      this.KunLeftForeArmRoll.localEulerAngles = this.ChanLeftForeArmRoll.localEulerAngles;
      this.KunLeftForeArm.localEulerAngles = this.ChanLeftForeArm.localEulerAngles;
      this.KunLeftHand.localEulerAngles = this.ChanLeftHand.localEulerAngles;
      this.KunLeftHandPinky1.localEulerAngles = this.ChanLeftHandPinky1.localEulerAngles;
      this.KunLeftHandPinky2.localEulerAngles = this.ChanLeftHandPinky2.localEulerAngles;
      this.KunLeftHandPinky3.localEulerAngles = this.ChanLeftHandPinky3.localEulerAngles;
      this.KunLeftHandRing1.localEulerAngles = this.ChanLeftHandRing1.localEulerAngles;
      this.KunLeftHandRing2.localEulerAngles = this.ChanLeftHandRing2.localEulerAngles;
      this.KunLeftHandRing3.localEulerAngles = this.ChanLeftHandRing3.localEulerAngles;
      this.KunLeftHandMiddle1.localEulerAngles = this.ChanLeftHandMiddle1.localEulerAngles;
      this.KunLeftHandMiddle2.localEulerAngles = this.ChanLeftHandMiddle2.localEulerAngles;
      this.KunLeftHandMiddle3.localEulerAngles = this.ChanLeftHandMiddle3.localEulerAngles;
      this.KunLeftHandIndex1.localEulerAngles = this.ChanLeftHandIndex1.localEulerAngles;
      this.KunLeftHandIndex2.localEulerAngles = this.ChanLeftHandIndex2.localEulerAngles;
      this.KunLeftHandIndex3.localEulerAngles = this.ChanLeftHandIndex3.localEulerAngles;
      this.KunLeftHandThumb1.localEulerAngles = this.ChanLeftHandThumb1.localEulerAngles;
      this.KunLeftHandThumb2.localEulerAngles = this.ChanLeftHandThumb2.localEulerAngles;
      this.KunLeftHandThumb3.localEulerAngles = this.ChanLeftHandThumb3.localEulerAngles;
      this.KunRightHandPinky1.localEulerAngles = this.ChanRightHandPinky1.localEulerAngles;
      this.KunRightHandPinky2.localEulerAngles = this.ChanRightHandPinky2.localEulerAngles;
      this.KunRightHandPinky3.localEulerAngles = this.ChanRightHandPinky3.localEulerAngles;
      this.KunRightHandRing1.localEulerAngles = this.ChanRightHandRing1.localEulerAngles;
      this.KunRightHandRing2.localEulerAngles = this.ChanRightHandRing2.localEulerAngles;
      this.KunRightHandRing3.localEulerAngles = this.ChanRightHandRing3.localEulerAngles;
      this.KunRightHandMiddle1.localEulerAngles = this.ChanRightHandMiddle1.localEulerAngles;
      this.KunRightHandMiddle2.localEulerAngles = this.ChanRightHandMiddle2.localEulerAngles;
      this.KunRightHandMiddle3.localEulerAngles = this.ChanRightHandMiddle3.localEulerAngles;
      this.KunRightHandIndex1.localEulerAngles = this.ChanRightHandIndex1.localEulerAngles;
      this.KunRightHandIndex2.localEulerAngles = this.ChanRightHandIndex2.localEulerAngles;
      this.KunRightHandIndex3.localEulerAngles = this.ChanRightHandIndex3.localEulerAngles;
      this.KunRightHandThumb1.localEulerAngles = this.ChanRightHandThumb1.localEulerAngles;
      this.KunRightHandThumb2.localEulerAngles = this.ChanRightHandThumb2.localEulerAngles;
      this.KunRightHandThumb3.localEulerAngles = this.ChanRightHandThumb3.localEulerAngles;
      if (Input.GetKeyDown(KeyCode.Space)) {
        if (this.ID > -1) {
          for (int i = 0; i < 32; i++) {
            this.SecondRenderer.SetBlendShapeWeight(i, 0f);
          }
          if (this.ID > 32) {
            this.ID = 0;
          }
          this.SecondRenderer.SetBlendShapeWeight(this.ID, 100f);
        }
        this.ID++;
      }
    }
  }

  // Token: 0x04001AF0 RID: 6896
  public Transform ChanItemParent;

  // Token: 0x04001AF1 RID: 6897
  public Transform KunItemParent;

  // Token: 0x04001AF2 RID: 6898
  public Transform ChanHips;

  // Token: 0x04001AF3 RID: 6899
  public Transform ChanSpine;

  // Token: 0x04001AF4 RID: 6900
  public Transform ChanSpine1;

  // Token: 0x04001AF5 RID: 6901
  public Transform ChanSpine2;

  // Token: 0x04001AF6 RID: 6902
  public Transform ChanSpine3;

  // Token: 0x04001AF7 RID: 6903
  public Transform ChanNeck;

  // Token: 0x04001AF8 RID: 6904
  public Transform ChanHead;

  // Token: 0x04001AF9 RID: 6905
  public Transform ChanRightUpLeg;

  // Token: 0x04001AFA RID: 6906
  public Transform ChanRightLeg;

  // Token: 0x04001AFB RID: 6907
  public Transform ChanRightFoot;

  // Token: 0x04001AFC RID: 6908
  public Transform ChanRightToes;

  // Token: 0x04001AFD RID: 6909
  public Transform ChanLeftUpLeg;

  // Token: 0x04001AFE RID: 6910
  public Transform ChanLeftLeg;

  // Token: 0x04001AFF RID: 6911
  public Transform ChanLeftFoot;

  // Token: 0x04001B00 RID: 6912
  public Transform ChanLeftToes;

  // Token: 0x04001B01 RID: 6913
  public Transform ChanRightShoulder;

  // Token: 0x04001B02 RID: 6914
  public Transform ChanRightArm;

  // Token: 0x04001B03 RID: 6915
  public Transform ChanRightArmRoll;

  // Token: 0x04001B04 RID: 6916
  public Transform ChanRightForeArm;

  // Token: 0x04001B05 RID: 6917
  public Transform ChanRightForeArmRoll;

  // Token: 0x04001B06 RID: 6918
  public Transform ChanRightHand;

  // Token: 0x04001B07 RID: 6919
  public Transform ChanLeftShoulder;

  // Token: 0x04001B08 RID: 6920
  public Transform ChanLeftArm;

  // Token: 0x04001B09 RID: 6921
  public Transform ChanLeftArmRoll;

  // Token: 0x04001B0A RID: 6922
  public Transform ChanLeftForeArm;

  // Token: 0x04001B0B RID: 6923
  public Transform ChanLeftForeArmRoll;

  // Token: 0x04001B0C RID: 6924
  public Transform ChanLeftHand;

  // Token: 0x04001B0D RID: 6925
  public Transform ChanLeftHandPinky1;

  // Token: 0x04001B0E RID: 6926
  public Transform ChanLeftHandPinky2;

  // Token: 0x04001B0F RID: 6927
  public Transform ChanLeftHandPinky3;

  // Token: 0x04001B10 RID: 6928
  public Transform ChanLeftHandRing1;

  // Token: 0x04001B11 RID: 6929
  public Transform ChanLeftHandRing2;

  // Token: 0x04001B12 RID: 6930
  public Transform ChanLeftHandRing3;

  // Token: 0x04001B13 RID: 6931
  public Transform ChanLeftHandMiddle1;

  // Token: 0x04001B14 RID: 6932
  public Transform ChanLeftHandMiddle2;

  // Token: 0x04001B15 RID: 6933
  public Transform ChanLeftHandMiddle3;

  // Token: 0x04001B16 RID: 6934
  public Transform ChanLeftHandIndex1;

  // Token: 0x04001B17 RID: 6935
  public Transform ChanLeftHandIndex2;

  // Token: 0x04001B18 RID: 6936
  public Transform ChanLeftHandIndex3;

  // Token: 0x04001B19 RID: 6937
  public Transform ChanLeftHandThumb1;

  // Token: 0x04001B1A RID: 6938
  public Transform ChanLeftHandThumb2;

  // Token: 0x04001B1B RID: 6939
  public Transform ChanLeftHandThumb3;

  // Token: 0x04001B1C RID: 6940
  public Transform ChanRightHandPinky1;

  // Token: 0x04001B1D RID: 6941
  public Transform ChanRightHandPinky2;

  // Token: 0x04001B1E RID: 6942
  public Transform ChanRightHandPinky3;

  // Token: 0x04001B1F RID: 6943
  public Transform ChanRightHandRing1;

  // Token: 0x04001B20 RID: 6944
  public Transform ChanRightHandRing2;

  // Token: 0x04001B21 RID: 6945
  public Transform ChanRightHandRing3;

  // Token: 0x04001B22 RID: 6946
  public Transform ChanRightHandMiddle1;

  // Token: 0x04001B23 RID: 6947
  public Transform ChanRightHandMiddle2;

  // Token: 0x04001B24 RID: 6948
  public Transform ChanRightHandMiddle3;

  // Token: 0x04001B25 RID: 6949
  public Transform ChanRightHandIndex1;

  // Token: 0x04001B26 RID: 6950
  public Transform ChanRightHandIndex2;

  // Token: 0x04001B27 RID: 6951
  public Transform ChanRightHandIndex3;

  // Token: 0x04001B28 RID: 6952
  public Transform ChanRightHandThumb1;

  // Token: 0x04001B29 RID: 6953
  public Transform ChanRightHandThumb2;

  // Token: 0x04001B2A RID: 6954
  public Transform ChanRightHandThumb3;

  // Token: 0x04001B2B RID: 6955
  public Transform KunHips;

  // Token: 0x04001B2C RID: 6956
  public Transform KunSpine;

  // Token: 0x04001B2D RID: 6957
  public Transform KunSpine1;

  // Token: 0x04001B2E RID: 6958
  public Transform KunSpine2;

  // Token: 0x04001B2F RID: 6959
  public Transform KunSpine3;

  // Token: 0x04001B30 RID: 6960
  public Transform KunNeck;

  // Token: 0x04001B31 RID: 6961
  public Transform KunHead;

  // Token: 0x04001B32 RID: 6962
  public Transform KunRightUpLeg;

  // Token: 0x04001B33 RID: 6963
  public Transform KunRightLeg;

  // Token: 0x04001B34 RID: 6964
  public Transform KunRightFoot;

  // Token: 0x04001B35 RID: 6965
  public Transform KunRightToes;

  // Token: 0x04001B36 RID: 6966
  public Transform KunLeftUpLeg;

  // Token: 0x04001B37 RID: 6967
  public Transform KunLeftLeg;

  // Token: 0x04001B38 RID: 6968
  public Transform KunLeftFoot;

  // Token: 0x04001B39 RID: 6969
  public Transform KunLeftToes;

  // Token: 0x04001B3A RID: 6970
  public Transform KunRightShoulder;

  // Token: 0x04001B3B RID: 6971
  public Transform KunRightArm;

  // Token: 0x04001B3C RID: 6972
  public Transform KunRightArmRoll;

  // Token: 0x04001B3D RID: 6973
  public Transform KunRightForeArm;

  // Token: 0x04001B3E RID: 6974
  public Transform KunRightForeArmRoll;

  // Token: 0x04001B3F RID: 6975
  public Transform KunRightHand;

  // Token: 0x04001B40 RID: 6976
  public Transform KunLeftShoulder;

  // Token: 0x04001B41 RID: 6977
  public Transform KunLeftArm;

  // Token: 0x04001B42 RID: 6978
  public Transform KunLeftArmRoll;

  // Token: 0x04001B43 RID: 6979
  public Transform KunLeftForeArm;

  // Token: 0x04001B44 RID: 6980
  public Transform KunLeftForeArmRoll;

  // Token: 0x04001B45 RID: 6981
  public Transform KunLeftHand;

  // Token: 0x04001B46 RID: 6982
  public Transform KunLeftHandPinky1;

  // Token: 0x04001B47 RID: 6983
  public Transform KunLeftHandPinky2;

  // Token: 0x04001B48 RID: 6984
  public Transform KunLeftHandPinky3;

  // Token: 0x04001B49 RID: 6985
  public Transform KunLeftHandRing1;

  // Token: 0x04001B4A RID: 6986
  public Transform KunLeftHandRing2;

  // Token: 0x04001B4B RID: 6987
  public Transform KunLeftHandRing3;

  // Token: 0x04001B4C RID: 6988
  public Transform KunLeftHandMiddle1;

  // Token: 0x04001B4D RID: 6989
  public Transform KunLeftHandMiddle2;

  // Token: 0x04001B4E RID: 6990
  public Transform KunLeftHandMiddle3;

  // Token: 0x04001B4F RID: 6991
  public Transform KunLeftHandIndex1;

  // Token: 0x04001B50 RID: 6992
  public Transform KunLeftHandIndex2;

  // Token: 0x04001B51 RID: 6993
  public Transform KunLeftHandIndex3;

  // Token: 0x04001B52 RID: 6994
  public Transform KunLeftHandThumb1;

  // Token: 0x04001B53 RID: 6995
  public Transform KunLeftHandThumb2;

  // Token: 0x04001B54 RID: 6996
  public Transform KunLeftHandThumb3;

  // Token: 0x04001B55 RID: 6997
  public Transform KunRightHandPinky1;

  // Token: 0x04001B56 RID: 6998
  public Transform KunRightHandPinky2;

  // Token: 0x04001B57 RID: 6999
  public Transform KunRightHandPinky3;

  // Token: 0x04001B58 RID: 7000
  public Transform KunRightHandRing1;

  // Token: 0x04001B59 RID: 7001
  public Transform KunRightHandRing2;

  // Token: 0x04001B5A RID: 7002
  public Transform KunRightHandRing3;

  // Token: 0x04001B5B RID: 7003
  public Transform KunRightHandMiddle1;

  // Token: 0x04001B5C RID: 7004
  public Transform KunRightHandMiddle2;

  // Token: 0x04001B5D RID: 7005
  public Transform KunRightHandMiddle3;

  // Token: 0x04001B5E RID: 7006
  public Transform KunRightHandIndex1;

  // Token: 0x04001B5F RID: 7007
  public Transform KunRightHandIndex2;

  // Token: 0x04001B60 RID: 7008
  public Transform KunRightHandIndex3;

  // Token: 0x04001B61 RID: 7009
  public Transform KunRightHandThumb1;

  // Token: 0x04001B62 RID: 7010
  public Transform KunRightHandThumb2;

  // Token: 0x04001B63 RID: 7011
  public Transform KunRightHandThumb3;

  // Token: 0x04001B64 RID: 7012
  public SkinnedMeshRenderer SecondRenderer;

  // Token: 0x04001B65 RID: 7013
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x04001B66 RID: 7014
  public bool Kizuna;

  // Token: 0x04001B67 RID: 7015
  public int ID;
}