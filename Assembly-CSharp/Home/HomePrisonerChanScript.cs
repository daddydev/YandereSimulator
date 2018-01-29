using UnityEngine;

// Token: 0x020000FF RID: 255
public class HomePrisonerChanScript : MonoBehaviour {

  // Token: 0x06000504 RID: 1284 RVA: 0x00044734 File Offset: 0x00042B34
  private void Start() {
    if (SchoolGlobals.KidnapVictim > 0) {
      this.StudentID = SchoolGlobals.KidnapVictim;
      if (StudentGlobals.GetStudentSanity(this.StudentID) == 100f) {
        this.AnkleRopes.SetActive(false);
      }
      this.PermanentAngleR = this.TwintailR.eulerAngles;
      this.PermanentAngleL = this.TwintailL.eulerAngles;
      if (!StudentGlobals.GetStudentArrested(this.StudentID) && !StudentGlobals.GetStudentDead(this.StudentID)) {
        this.Cosmetic.StudentID = this.StudentID;
        this.Cosmetic.enabled = true;
        this.BreastSize = this.JSON.Students[this.StudentID].BreastSize;
        this.RightEyeRotOrigin = this.RightEye.localEulerAngles;
        this.LeftEyeRotOrigin = this.LeftEye.localEulerAngles;
        this.RightEyeOrigin = this.RightEye.localPosition;
        this.LeftEyeOrigin = this.LeftEye.localPosition;
        this.UpdateSanity();
        this.TwintailR.transform.localEulerAngles = new Vector3(0f, 180f, -90f);
        this.TwintailL.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
        this.Blindfold.SetActive(false);
        this.Tripod.SetActive(false);
        if (this.StudentID == 32 && SchemeGlobals.GetSchemeStage(6) > 4) {
          this.Blindfold.SetActive(true);
          this.Tripod.SetActive(true);
        }
      } else {
        SchoolGlobals.KidnapVictim = 0;
        base.gameObject.SetActive(false);
      }
    } else {
      base.gameObject.SetActive(false);
    }
  }

  // Token: 0x06000505 RID: 1285 RVA: 0x000448F8 File Offset: 0x00042CF8
  private void LateUpdate() {
    this.Skirt.transform.localPosition = new Vector3(0f, -0.135f, 0.01f);
    this.Skirt.transform.localScale = new Vector3(this.Skirt.transform.localScale.x, 1.2f, this.Skirt.transform.localScale.z);
    if (!this.Tortured) {
      if (this.Sanity > 0f) {
        if (this.LookAhead) {
          this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x - 45f, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
        } else if (this.YandereDetector.YandereDetected && Vector3.Distance(base.transform.position, this.HomeYandere.position) < 2f) {
          Quaternion b;
          if (this.HomeCamera.Target == this.HomeCamera.Targets[10]) {
            b = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - this.Sanity) / 100f)) - this.Neck.position);
            this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot1, Time.deltaTime * 2f);
          } else {
            b = Quaternion.LookRotation(this.HomeYandere.position + Vector3.up * 1.5f - this.Neck.position);
            this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot2, Time.deltaTime * 2f);
          }
          this.Neck.rotation = Quaternion.Slerp(this.LastRotation, b, Time.deltaTime * 2f);
          this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, 180f, -90f);
          this.TwintailL.transform.localEulerAngles = new Vector3(-this.HairRotation, 0f, -90f);
        } else {
          if (this.HomeCamera.Target == this.HomeCamera.Targets[10]) {
            Quaternion b2 = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - this.Sanity) / 100f)) - this.Neck.position);
            this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot3, Time.deltaTime * 2f);
          } else {
            Quaternion b2 = Quaternion.LookRotation(base.transform.position + base.transform.forward - this.Neck.position);
            this.Neck.rotation = Quaternion.Slerp(this.LastRotation, b2, Time.deltaTime * 2f);
          }
          this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot4, Time.deltaTime * 2f);
          this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, 180f, -90f);
          this.TwintailL.transform.localEulerAngles = new Vector3(-this.HairRotation, 0f, -90f);
        }
      } else {
        this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x - 45f, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
      }
    }
    this.LastRotation = this.Neck.rotation;
    if (!this.Tortured && this.Sanity < 100f && this.Sanity > 0f) {
      this.TwitchTimer += Time.deltaTime;
      if (this.TwitchTimer > this.NextTwitch) {
        this.Twitch = new Vector3((1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f), (1f - this.Sanity / 100f) * UnityEngine.Random.Range(-10f, 10f));
        this.NextTwitch = UnityEngine.Random.Range(0f, 1f);
        this.TwitchTimer = 0f;
      }
      this.Twitch = Vector3.Lerp(this.Twitch, Vector3.zero, Time.deltaTime * 10f);
      this.Neck.localEulerAngles += this.Twitch;
    }
    if (this.Tortured) {
      this.HairRotation = Mathf.Lerp(this.HairRotation, this.HairRot5, Time.deltaTime * 2f);
      this.TwintailR.transform.localEulerAngles = new Vector3(this.HairRotation, 180f, -90f);
      this.TwintailL.transform.localEulerAngles = new Vector3(-this.HairRotation, 0f, -90f);
    }
  }

  // Token: 0x06000506 RID: 1286 RVA: 0x00044EE4 File Offset: 0x000432E4
  public void UpdateSanity() {
    this.Sanity = StudentGlobals.GetStudentSanity(this.StudentID);
    bool active = this.Sanity == 0f;
    this.RightMindbrokenEye.SetActive(active);
    this.LeftMindbrokenEye.SetActive(active);
  }

  // Token: 0x04000BA0 RID: 2976
  public HomeYandereDetectorScript YandereDetector;

  // Token: 0x04000BA1 RID: 2977
  public HomeCameraScript HomeCamera;

  // Token: 0x04000BA2 RID: 2978
  public CosmeticScript Cosmetic;

  // Token: 0x04000BA3 RID: 2979
  public JsonScript JSON;

  // Token: 0x04000BA4 RID: 2980
  public Vector3 RightEyeRotOrigin;

  // Token: 0x04000BA5 RID: 2981
  public Vector3 LeftEyeRotOrigin;

  // Token: 0x04000BA6 RID: 2982
  public Vector3 PermanentAngleR;

  // Token: 0x04000BA7 RID: 2983
  public Vector3 PermanentAngleL;

  // Token: 0x04000BA8 RID: 2984
  public Vector3 RightEyeOrigin;

  // Token: 0x04000BA9 RID: 2985
  public Vector3 LeftEyeOrigin;

  // Token: 0x04000BAA RID: 2986
  public Vector3 Twitch;

  // Token: 0x04000BAB RID: 2987
  public Quaternion LastRotation;

  // Token: 0x04000BAC RID: 2988
  public Transform HomeYandere;

  // Token: 0x04000BAD RID: 2989
  public Transform RightBreast;

  // Token: 0x04000BAE RID: 2990
  public Transform LeftBreast;

  // Token: 0x04000BAF RID: 2991
  public Transform TwintailR;

  // Token: 0x04000BB0 RID: 2992
  public Transform TwintailL;

  // Token: 0x04000BB1 RID: 2993
  public Transform RightEye;

  // Token: 0x04000BB2 RID: 2994
  public Transform LeftEye;

  // Token: 0x04000BB3 RID: 2995
  public Transform Skirt;

  // Token: 0x04000BB4 RID: 2996
  public Transform Neck;

  // Token: 0x04000BB5 RID: 2997
  public GameObject RightMindbrokenEye;

  // Token: 0x04000BB6 RID: 2998
  public GameObject LeftMindbrokenEye;

  // Token: 0x04000BB7 RID: 2999
  public GameObject AnkleRopes;

  // Token: 0x04000BB8 RID: 3000
  public GameObject Blindfold;

  // Token: 0x04000BB9 RID: 3001
  public GameObject Character;

  // Token: 0x04000BBA RID: 3002
  public GameObject Tripod;

  // Token: 0x04000BBB RID: 3003
  public float HairRotation;

  // Token: 0x04000BBC RID: 3004
  public float TwitchTimer;

  // Token: 0x04000BBD RID: 3005
  public float NextTwitch;

  // Token: 0x04000BBE RID: 3006
  public float BreastSize;

  // Token: 0x04000BBF RID: 3007
  public float EyeShrink;

  // Token: 0x04000BC0 RID: 3008
  public float Sanity;

  // Token: 0x04000BC1 RID: 3009
  public float HairRot1;

  // Token: 0x04000BC2 RID: 3010
  public float HairRot2;

  // Token: 0x04000BC3 RID: 3011
  public float HairRot3;

  // Token: 0x04000BC4 RID: 3012
  public float HairRot4;

  // Token: 0x04000BC5 RID: 3013
  public float HairRot5;

  // Token: 0x04000BC6 RID: 3014
  public bool LookAhead;

  // Token: 0x04000BC7 RID: 3015
  public bool Tortured;

  // Token: 0x04000BC8 RID: 3016
  public bool Male;

  // Token: 0x04000BC9 RID: 3017
  public int StudentID;
}