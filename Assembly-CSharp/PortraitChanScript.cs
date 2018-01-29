using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000163 RID: 355
public class PortraitChanScript : MonoBehaviour {

  // Token: 0x06000686 RID: 1670 RVA: 0x0005F264 File Offset: 0x0005D664
  private void Awake() {
    this.HairColors = new Dictionary<string, Color>
    {
      {
        "Black",
        new Color(0.5f, 0.5f, 0.5f)
      },
      {
        "Red",
        new Color(1f, 0f, 0f)
      },
      {
        "Yellow",
        new Color(1f, 1f, 0f)
      },
      {
        "Green",
        new Color(0f, 1f, 0f)
      },
      {
        "Cyan",
        new Color(0f, 1f, 1f)
      },
      {
        "Blue",
        new Color(0f, 0f, 1f)
      },
      {
        "Purple",
        new Color(1f, 0f, 1f)
      },
      {
        "Orange",
        new Color(1f, 0.5f, 0f)
      },
      {
        "Brown",
        new Color(0.5f, 0.25f, 0f)
      }
    };
  }

  // Token: 0x06000687 RID: 1671 RVA: 0x0005F398 File Offset: 0x0005D798
  private void Start() {
    if (this.RightEye != null) {
      this.RightEyeRotOrigin = this.RightEye.localEulerAngles;
      this.LeftEyeRotOrigin = this.LeftEye.localEulerAngles;
      this.RightEyeOrigin = this.RightEye.localPosition;
      this.LeftEyeOrigin = this.LeftEye.localPosition;
    }
    Animation component = this.Character.GetComponent<Animation>();
    if (this.Kidnapped) {
      this.StudentID = SchoolGlobals.KidnapVictim;
      component.Play("f02_kidnapIdle_01");
      this.TwintailR.transform.localEulerAngles = new Vector3(10f, -90f, 0f);
      this.TwintailL.transform.localEulerAngles = new Vector3(10f, 90f, 0f);
    }
    if (this.Bullied) {
      this.StudentID = 7;
      component.Play("f02_bulliedPose_00");
    }
    this.Club = this.JSON.Students[this.StudentID].Club;
    this.BreastSize = this.JSON.Students[this.StudentID].BreastSize;
    this.Hairstyle = this.JSON.Students[this.StudentID].Hairstyle;
    this.Accessory = this.JSON.Students[this.StudentID].Accessory;
    if (!this.Male) {
      this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      this.UpdateHair();
    } else if (this.Club == ClubType.Occult) {
      component["sadFace_00"].layer = 1;
      component.Play("sadFace_00");
      component["sadFace_00"].weight = 1f;
    }
    this.Bandana.SetActive(false);
    if (this.Club == ClubType.Teacher) {
      this.BecomeTeacher();
    } else if (this.Club == ClubType.MartialArts) {
      this.Bandana.SetActive(true);
    }
    this.SetColors();
    if (!this.Male && !this.Teacher) {
      this.SetFemaleUniform();
    }
    this.UpdateSanity();
  }

  // Token: 0x06000688 RID: 1672 RVA: 0x0005F600 File Offset: 0x0005DA00
  private void SetColors() {
    string color = this.JSON.Students[this.StudentID].Color;
    if (!this.Male) {
      if (!this.Teacher) {
        this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
        this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
        this.MyRenderer.materials[2].mainTexture = this.HairTexture;
        this.PonyRenderer.material.mainTexture = this.HairTexture;
        this.NewLongHair.material.mainTexture = this.HairTexture;
        this.ShortHair.material.mainTexture = this.HairTexture;
        this.LongHair.material.mainTexture = this.HairTexture;
        this.PigtailR.material.mainTexture = this.HairTexture;
        this.PigtailL.material.mainTexture = this.HairTexture;
        this.Drills.materials[0].mainTexture = this.DrillTexture;
        this.Drills.materials[1].mainTexture = this.DrillTexture;
        this.Drills.materials[2].mainTexture = this.DrillTexture;
      } else if (color == "Brown") {
        this.TeacherHair[1].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
        this.TeacherHair[2].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
        this.TeacherHair[3].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
        this.TeacherHair[4].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
        this.TeacherHair[5].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
        this.TeacherHair[6].GetComponent<Renderer>().material.color = new Color(0.5f, 0.25f, 0f, 1f);
      }
      if (this.Accessory == "Bandage") {
        this.Bandage.SetActive(true);
      } else if (this.Accessory == "Eyepatch") {
        this.Eyepatch.SetActive(true);
      }
    } else {
      this.MaleHairstyles[int.Parse(this.Hairstyle)].SetActive(true);
      if (int.Parse(this.Hairstyle) < 8) {
        this.MaleHairRenderer = this.MaleHairstyles[int.Parse(this.Hairstyle)].GetComponent<Renderer>();
        Color color2;
        bool flag = this.HairColors.TryGetValue(color, out color2);
        this.MaleHairRenderer.material.color = color2;
        this.EyeR.material.color = this.MaleHairRenderer.material.color;
        this.EyeL.material.color = this.MaleHairRenderer.material.color;
        if (this.Club == ClubType.MartialArts) {
          Transform transform = this.MaleHairstyles[int.Parse(this.Hairstyle)].transform;
          transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
          this.Bandana.SetActive(true);
        }
      } else if (color == "Occult2" || color == "Occult4" || color == "Occult6") {
        this.MaleHairRenderer = this.MaleHairstyles[int.Parse(this.Hairstyle)].GetComponent<Renderer>();
        this.MyRenderer.materials[2].mainTexture = this.MaleHairRenderer.material.mainTexture;
        this.EyeR.material.mainTexture = this.MaleHairRenderer.material.mainTexture;
        this.EyeL.material.mainTexture = this.MaleHairRenderer.material.mainTexture;
      }
      if (this.Accessory == "ShinyGlasses") {
        this.ShinyGlasses.SetActive(true);
        this.IrisLight[0].SetActive(false);
        this.IrisLight[1].SetActive(false);
      }
    }
    if (!this.Male) {
      this.PigtailR.material.mainTexture = this.HairTexture;
      this.PigtailL.material.mainTexture = this.HairTexture;
      if (this.DrillTexture != null) {
        this.Drills.materials[0].mainTexture = this.DrillTexture;
        this.Drills.materials[1].mainTexture = this.DrillTexture;
        this.Drills.materials[2].mainTexture = this.DrillTexture;
      }
    }
  }

  // Token: 0x06000689 RID: 1673 RVA: 0x0005FB58 File Offset: 0x0005DF58
  private void UpdateHair() {
    this.PonyRenderer.gameObject.SetActive(false);
    this.NewLongHair.gameObject.SetActive(false);
    this.PigtailR.gameObject.SetActive(false);
    this.PigtailL.gameObject.SetActive(false);
    this.LongHair.gameObject.SetActive(false);
    this.TwinPony.gameObject.SetActive(false);
    this.Drills.gameObject.SetActive(false);
    this.OccultHair[1].SetActive(false);
    this.OccultHair[3].SetActive(false);
    this.OccultHair[5].SetActive(false);
    this.CirnoHair.SetActive(false);
    this.PippiHair.SetActive(false);
    this.ShortHair.gameObject.SetActive(false);
    if (this.Hairstyle == "PonyTail") {
      this.PonyRenderer.transform.parent.gameObject.SetActive(true);
      this.PonyRenderer.gameObject.SetActive(true);
    } else if (this.Hairstyle == "RightTail") {
      this.PonyRenderer.transform.parent.gameObject.SetActive(true);
      this.PonyRenderer.gameObject.SetActive(true);
      this.PigtailR.transform.parent.transform.parent.gameObject.SetActive(true);
      this.PigtailR.gameObject.SetActive(true);
      this.HidePony = true;
    } else if (this.Hairstyle == "LeftTail") {
      this.PonyRenderer.transform.parent.gameObject.SetActive(true);
      this.PonyRenderer.gameObject.SetActive(true);
      this.PigtailL.transform.parent.transform.parent.gameObject.SetActive(true);
      this.PigtailL.gameObject.SetActive(true);
      this.HidePony = true;
    } else if (this.Hairstyle == "PigTails") {
      this.PonyRenderer.transform.parent.gameObject.SetActive(true);
      this.PonyRenderer.gameObject.SetActive(true);
      this.PigtailR.transform.parent.transform.parent.gameObject.SetActive(true);
      this.PigtailL.transform.parent.transform.parent.gameObject.SetActive(true);
      this.PigtailR.gameObject.SetActive(true);
      this.PigtailL.gameObject.SetActive(true);
      this.HidePony = true;
    } else if (this.Hairstyle == "TriTails") {
      this.PonyRenderer.transform.parent.gameObject.SetActive(true);
      this.PonyRenderer.gameObject.SetActive(true);
      this.PigtailR.transform.parent.transform.parent.gameObject.SetActive(true);
      this.PigtailL.transform.parent.transform.parent.gameObject.SetActive(true);
      this.PigtailR.gameObject.SetActive(true);
      this.PigtailL.gameObject.SetActive(true);
      this.PigtailR.transform.localScale = new Vector3(1f, 1f, 1f);
      this.PigtailL.transform.localScale = new Vector3(1f, 1f, 1f);
    } else if (this.Hairstyle == "TwinTails") {
      this.PonyRenderer.transform.parent.gameObject.SetActive(true);
      this.PonyRenderer.gameObject.SetActive(true);
      this.PigtailR.transform.parent.transform.parent.gameObject.SetActive(true);
      this.PigtailL.transform.parent.transform.parent.gameObject.SetActive(true);
      this.PigtailR.gameObject.SetActive(true);
      this.PigtailL.gameObject.SetActive(true);
      this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
      this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
      this.HidePony = true;
    } else if (this.Hairstyle == "Drills") {
      this.PonyRenderer.transform.parent.gameObject.SetActive(true);
      this.PonyRenderer.gameObject.SetActive(true);
      this.Drills.transform.parent.transform.parent.gameObject.SetActive(true);
      this.Drills.gameObject.SetActive(true);
      this.HidePony = true;
    } else if (this.Hairstyle == "Short") {
      this.ShortHair.gameObject.SetActive(true);
    } else if (this.Hairstyle == "Pippi") {
      this.PippiHair.SetActive(true);
    } else if (this.Hairstyle == "Cirno") {
      this.CirnoHair.SetActive(true);
    } else if (this.Hairstyle == "Long") {
      this.LongHair.transform.parent.gameObject.SetActive(true);
      this.LongHair.gameObject.SetActive(true);
    } else if (this.Hairstyle == "NewLong") {
      this.NewLongHair.transform.parent.gameObject.SetActive(true);
      this.NewLongHair.gameObject.SetActive(true);
      this.VeryLongHair = false;
    } else if (this.Hairstyle == "VeryLong") {
      this.NewLongHair.transform.parent.gameObject.SetActive(true);
      this.NewLongHair.gameObject.SetActive(true);
      this.VeryLongHair = true;
    } else if (this.Hairstyle == "TwinPony") {
      this.TwinPony.transform.parent.transform.parent.gameObject.SetActive(true);
      this.TwinPony.gameObject.SetActive(true);
    } else if (this.Hairstyle == "Occult1") {
      this.OccultHair[1].SetActive(true);
    } else if (this.Hairstyle == "Occult3") {
      this.OccultHair[3].SetActive(true);
    } else if (this.Hairstyle == "Occult5") {
      this.OccultHair[5].SetActive(true);
    } else if (this.Hairstyle == "Teacher1") {
      this.TeacherHair[1].SetActive(true);
      this.TeacherGlasses[1].SetActive(true);
    } else if (this.Hairstyle == "Teacher2") {
      this.TeacherHair[2].SetActive(true);
      this.TeacherGlasses[2].SetActive(true);
    } else if (this.Hairstyle == "Teacher3") {
      this.TeacherHair[3].SetActive(true);
      this.TeacherGlasses[3].SetActive(true);
    } else if (this.Hairstyle == "Teacher4") {
      this.TeacherHair[4].SetActive(true);
      this.TeacherGlasses[4].SetActive(true);
    } else if (this.Hairstyle == "Teacher5") {
      this.TeacherHair[5].SetActive(true);
      this.TeacherGlasses[5].SetActive(true);
    } else if (this.Hairstyle == "Teacher6") {
      this.TeacherHair[6].SetActive(true);
      this.TeacherGlasses[6].SetActive(true);
    }
    if (this.HidePony) {
      this.Ponytail.parent.transform.localScale = new Vector3(1f, 1f, 0.93f);
      this.Ponytail.localScale = Vector3.zero;
      this.HairR.localScale = Vector3.zero;
      this.HairL.localScale = Vector3.zero;
    }
  }

  // Token: 0x0600068A RID: 1674 RVA: 0x0006049C File Offset: 0x0005E89C
  private void BecomeTeacher() {
    this.MyRenderer.sharedMesh = this.TeacherMesh;
    this.Teacher = true;
    this.MyRenderer.materials[0].mainTexture = this.TeacherTexture;
    this.MyRenderer.materials[1].mainTexture = this.TeacherTexture;
    this.MyRenderer.materials[2].mainTexture = this.TeacherTexture;
  }

  // Token: 0x0600068B RID: 1675 RVA: 0x0006050C File Offset: 0x0005E90C
  private void LateUpdate() {
    if (this.Kidnapped) {
      if (!this.Tortured) {
        if (this.Sanity > 0f) {
          if (this.YandereDetector.YandereDetected && Vector3.Distance(base.transform.position, this.HomeYandere.position) < 2f) {
            Quaternion b;
            if (this.HomeCamera.Target == this.HomeCamera.Targets[10]) {
              b = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - this.Sanity) / 100f)) - this.Neck.position);
              this.HairRotation = Mathf.Lerp(this.HairRotation, 0f, Time.deltaTime * 2f);
            } else {
              b = Quaternion.LookRotation(this.HomeYandere.position + Vector3.up * 1.5f - this.Neck.position);
              this.HairRotation = Mathf.Lerp(this.HairRotation, -45f, Time.deltaTime * 2f);
            }
            this.Neck.rotation = Quaternion.Slerp(this.LastRotation, b, Time.deltaTime * 2f);
            this.TwintailR.transform.localEulerAngles = new Vector3(15f, -75f, this.HairRotation);
            this.TwintailL.transform.localEulerAngles = new Vector3(15f, 75f, -this.HairRotation);
          } else {
            if (this.HomeCamera.Target == this.HomeCamera.Targets[10]) {
              Quaternion b2 = Quaternion.LookRotation(this.HomeCamera.transform.position + Vector3.down * (1.5f * ((100f - this.Sanity) / 100f)) - this.Neck.position);
              this.HairRotation = Mathf.Lerp(this.HairRotation, 0f, Time.deltaTime * 2f);
            } else {
              Quaternion b2 = Quaternion.LookRotation(base.transform.position + base.transform.forward - this.Neck.position);
              this.Neck.rotation = Quaternion.Slerp(this.LastRotation, b2, Time.deltaTime * 2f);
            }
            this.HairRotation = Mathf.Lerp(this.HairRotation, 45f, Time.deltaTime * 2f);
            this.TwintailR.transform.localEulerAngles = new Vector3(15f, -75f, this.HairRotation);
            this.TwintailL.transform.localEulerAngles = new Vector3(15f, 75f, -this.HairRotation);
          }
        } else {
          this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x - 45f, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
        }
      } else {
        this.EyeShrink += Time.deltaTime * 0.1f;
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
    }
    if (this.VeryLongHair) {
      this.LongHairBone.localScale = new Vector3(2f, this.LongHairBone.localScale.y, this.LongHairBone.localScale.z);
    }
    if (this.Emo) {
      this.HairF.localPosition = new Vector3(-0.1f, -0.285f, this.HairF.localPosition.z);
    }
    if (this.Tortured && this.RightEye != null) {
      if (this.EyeShrink > 1f) {
        this.EyeShrink = 1f;
      }
      if (this.Sanity >= 50f) {
        this.LeftEye.localPosition = new Vector3(this.LeftEye.localPosition.x - this.EyeShrink * 0.002f, this.LeftEye.localPosition.y, this.LeftEye.localPosition.z - this.EyeShrink * 0.009f);
        this.RightEye.localPosition = new Vector3(this.RightEye.localPosition.x - this.EyeShrink * 0.002f, this.RightEye.localPosition.y, this.RightEye.localPosition.z + this.EyeShrink * 0.009f);
        this.LeftEye.localEulerAngles = new Vector3(this.LeftEye.localEulerAngles.x + 5f + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink), this.LeftEye.localEulerAngles.y + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink), this.LeftEye.localEulerAngles.z + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink));
        this.RightEye.localEulerAngles = new Vector3(this.RightEye.localEulerAngles.x - 5f + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink), this.RightEye.localEulerAngles.y + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink), this.RightEye.localEulerAngles.z + UnityEngine.Random.Range(-this.EyeShrink, this.EyeShrink));
        this.LeftEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.LeftEye.localScale.z);
        this.RightEye.localScale = new Vector3(1f - this.EyeShrink * 0.5f, 1f - this.EyeShrink * 0.5f, this.RightEye.localScale.z);
      }
    }
  }

  // Token: 0x0600068C RID: 1676 RVA: 0x00060D00 File Offset: 0x0005F100
  private void UpdateSanity() {
    if (this.Kidnapped) {
      this.Sanity = StudentGlobals.GetStudentSanity(this.StudentID);
      this.RightIris.SetActive(this.Sanity == 0f);
      this.LeftIris.SetActive(this.Sanity == 0f);
    }
  }

  // Token: 0x0600068D RID: 1677 RVA: 0x00060D5C File Offset: 0x0005F15C
  private void SetFemaleUniform() {
    if (this.Tortured) {
      this.MyRenderer.sharedMesh = this.FemaleUniforms[StudentGlobals.FemaleUniform];
      this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[StudentGlobals.FemaleUniform];
      this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[StudentGlobals.FemaleUniform];
      this.PonyRenderer.material.mainTexture = this.HairTexture;
    }
  }

  // Token: 0x04001001 RID: 4097
  public StudentManagerScript StudentManager;

  // Token: 0x04001002 RID: 4098
  public HomeCameraScript HomeCamera;

  // Token: 0x04001003 RID: 4099
  public JsonScript JSON;

  // Token: 0x04001004 RID: 4100
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x04001005 RID: 4101
  public Renderer TeacherHairRenderer;

  // Token: 0x04001006 RID: 4102
  public Renderer MaleHairRenderer;

  // Token: 0x04001007 RID: 4103
  public Renderer PonyRenderer;

  // Token: 0x04001008 RID: 4104
  public Renderer NewLongHair;

  // Token: 0x04001009 RID: 4105
  public Renderer ShortHair;

  // Token: 0x0400100A RID: 4106
  public Renderer TwinPony;

  // Token: 0x0400100B RID: 4107
  public Renderer PigtailR;

  // Token: 0x0400100C RID: 4108
  public Renderer PigtailL;

  // Token: 0x0400100D RID: 4109
  public Renderer LongHair;

  // Token: 0x0400100E RID: 4110
  public Renderer Drills;

  // Token: 0x0400100F RID: 4111
  public Renderer EyeR;

  // Token: 0x04001010 RID: 4112
  public Renderer EyeL;

  // Token: 0x04001011 RID: 4113
  public Transform LongHairBone;

  // Token: 0x04001012 RID: 4114
  public Transform HomeYandere;

  // Token: 0x04001013 RID: 4115
  public Transform RightBreast;

  // Token: 0x04001014 RID: 4116
  public Transform LeftBreast;

  // Token: 0x04001015 RID: 4117
  public Transform Ponytail;

  // Token: 0x04001016 RID: 4118
  public Transform RightEye;

  // Token: 0x04001017 RID: 4119
  public Transform LeftEye;

  // Token: 0x04001018 RID: 4120
  public Transform HairF;

  // Token: 0x04001019 RID: 4121
  public Transform HairL;

  // Token: 0x0400101A RID: 4122
  public Transform HairR;

  // Token: 0x0400101B RID: 4123
  public Texture UniformTexture;

  // Token: 0x0400101C RID: 4124
  public Texture DrillTexture;

  // Token: 0x0400101D RID: 4125
  public Texture HairTexture;

  // Token: 0x0400101E RID: 4126
  public GameObject[] TeacherGlasses;

  // Token: 0x0400101F RID: 4127
  public GameObject[] TeacherHair;

  // Token: 0x04001020 RID: 4128
  public GameObject[] OccultHair;

  // Token: 0x04001021 RID: 4129
  public GameObject[] IrisLight;

  // Token: 0x04001022 RID: 4130
  public GameObject ShinyGlasses;

  // Token: 0x04001023 RID: 4131
  public GameObject CirnoHair;

  // Token: 0x04001024 RID: 4132
  public GameObject Character;

  // Token: 0x04001025 RID: 4133
  public GameObject PippiHair;

  // Token: 0x04001026 RID: 4134
  public GameObject Eyepatch;

  // Token: 0x04001027 RID: 4135
  public GameObject Bandage;

  // Token: 0x04001028 RID: 4136
  public GameObject Bandana;

  // Token: 0x04001029 RID: 4137
  public bool VeryLongHair;

  // Token: 0x0400102A RID: 4138
  public bool HidePony;

  // Token: 0x0400102B RID: 4139
  public bool Bullied;

  // Token: 0x0400102C RID: 4140
  public bool Teacher;

  // Token: 0x0400102D RID: 4141
  public bool Male;

  // Token: 0x0400102E RID: 4142
  public bool Emo;

  // Token: 0x0400102F RID: 4143
  public float BreastSize;

  // Token: 0x04001030 RID: 4144
  public string Accessory = string.Empty;

  // Token: 0x04001031 RID: 4145
  public string Hairstyle = string.Empty;

  // Token: 0x04001032 RID: 4146
  public int StudentID;

  // Token: 0x04001033 RID: 4147
  public ClubType Club;

  // Token: 0x04001034 RID: 4148
  public GameObject[] MaleHairstyles;

  // Token: 0x04001035 RID: 4149
  private Dictionary<string, Color> HairColors;

  // Token: 0x04001036 RID: 4150
  public Mesh TeacherMesh;

  // Token: 0x04001037 RID: 4151
  public Texture TeacherTexture;

  // Token: 0x04001038 RID: 4152
  public HomeYandereDetectorScript YandereDetector;

  // Token: 0x04001039 RID: 4153
  public Quaternion LastRotation;

  // Token: 0x0400103A RID: 4154
  public GameObject RightIris;

  // Token: 0x0400103B RID: 4155
  public GameObject LeftIris;

  // Token: 0x0400103C RID: 4156
  public Transform TwintailR;

  // Token: 0x0400103D RID: 4157
  public Transform TwintailL;

  // Token: 0x0400103E RID: 4158
  public Transform Neck;

  // Token: 0x0400103F RID: 4159
  public Vector3 RightEyeRotOrigin;

  // Token: 0x04001040 RID: 4160
  public Vector3 LeftEyeRotOrigin;

  // Token: 0x04001041 RID: 4161
  public Vector3 RightEyeOrigin;

  // Token: 0x04001042 RID: 4162
  public Vector3 LeftEyeOrigin;

  // Token: 0x04001043 RID: 4163
  public Vector3 Twitch;

  // Token: 0x04001044 RID: 4164
  public float HairRotation;

  // Token: 0x04001045 RID: 4165
  public float TwitchTimer;

  // Token: 0x04001046 RID: 4166
  public float NextTwitch;

  // Token: 0x04001047 RID: 4167
  public float EyeShrink;

  // Token: 0x04001048 RID: 4168
  public float Sanity;

  // Token: 0x04001049 RID: 4169
  public bool Kidnapped;

  // Token: 0x0400104A RID: 4170
  public bool Tortured;

  // Token: 0x0400104B RID: 4171
  public Mesh[] FemaleUniforms;

  // Token: 0x0400104C RID: 4172
  public Texture[] FemaleUniformTextures;
}