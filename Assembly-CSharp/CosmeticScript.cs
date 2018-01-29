using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000074 RID: 116
public class CosmeticScript : MonoBehaviour {

  // Token: 0x060001AA RID: 426 RVA: 0x0001F18C File Offset: 0x0001D58C
  public void Start() {
    if (this.Kidnapped) {
    }
    if (this.RightShoe != null) {
      this.RightShoe.SetActive(false);
      this.LeftShoe.SetActive(false);
    }
    this.ColorValue = new Color(1f, 1f, 1f, 1f);
    if (this.JSON == null) {
      this.JSON = this.Student.JSON;
    }
    string text = string.Empty;
    if (!this.Initialized) {
      this.Accessory = int.Parse(this.JSON.Students[this.StudentID].Accessory);
      this.Hairstyle = int.Parse(this.JSON.Students[this.StudentID].Hairstyle);
      this.Stockings = this.JSON.Students[this.StudentID].Stockings;
      this.BreastSize = this.JSON.Students[this.StudentID].BreastSize;
      this.EyeType = this.JSON.Students[this.StudentID].EyeType;
      this.HairColor = this.JSON.Students[this.StudentID].Color;
      this.EyeColor = this.JSON.Students[this.StudentID].Eyes;
      this.Club = this.JSON.Students[this.StudentID].Club;
      text = this.JSON.Students[this.StudentID].Name;
      if (this.Yandere) {
        this.Accessory = 0;
        this.Hairstyle = 1;
        this.Stockings = "Black";
        this.BreastSize = 1f;
        this.HairColor = "White";
        this.EyeColor = "Black";
        this.Club = ClubType.None;
      }
      this.OriginalStockings = this.Stockings;
      this.Initialized = true;
    }
    if (text == "Random") {
      this.Randomize = true;
      if (!this.Male) {
        text = this.StudentManager.FirstNames[UnityEngine.Random.Range(0, this.StudentManager.FirstNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
        this.JSON.Students[this.StudentID].Name = text;
        this.Student.Name = text;
      } else {
        text = this.StudentManager.MaleNames[UnityEngine.Random.Range(0, this.StudentManager.MaleNames.Length)] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, this.StudentManager.LastNames.Length)];
        this.JSON.Students[this.StudentID].Name = text;
        this.Student.Name = text;
      }
      if (MissionModeGlobals.MissionMode && MissionModeGlobals.MissionTarget == this.StudentID) {
        this.JSON.Students[this.StudentID].Name = MissionModeGlobals.MissionTargetName;
        this.Student.Name = MissionModeGlobals.MissionTargetName;
        text = MissionModeGlobals.MissionTargetName;
      }
    }
    if (this.Randomize) {
      this.Teacher = false;
      this.BreastSize = UnityEngine.Random.Range(0.5f, 2f);
      this.Accessory = 0;
      this.Club = ClubType.None;
      if (!this.Male) {
        this.Hairstyle = 99;
        while (this.Hairstyle > 19) {
          this.Hairstyle = UnityEngine.Random.Range(1, this.FemaleHair.Length - 1);
        }
      } else {
        this.SkinColor = UnityEngine.Random.Range(0, this.SkinTextures.Length);
        this.Hairstyle = UnityEngine.Random.Range(1, this.MaleHair.Length);
      }
    }
    if (!this.Male) {
      this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
      if (this.StudentID == 32 && !this.Kidnapped && SceneManager.GetActiveScene().name == "PortraitScene") {
        this.Character.GetComponent<Animation>().Play("f02_socialCameraPose_00");
        base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + 0.05f, base.transform.position.z);
      }
    } else {
      foreach (GameObject gameObject in this.GaloAccessories) {
        gameObject.SetActive(false);
      }
      if (this.Club == ClubType.Occult) {
        this.Character.GetComponent<Animation>()["sadFace_00"].layer = 1;
        this.Character.GetComponent<Animation>().Play("sadFace_00");
        this.Character.GetComponent<Animation>()["sadFace_00"].weight = 1f;
      }
      if (this.StudentID == 13 && StudentGlobals.CustomSuitor) {
        if (StudentGlobals.CustomSuitorHair > 0) {
          this.Hairstyle = StudentGlobals.CustomSuitorHair;
        }
        if (StudentGlobals.CustomSuitorAccessory > 0) {
          this.Accessory = StudentGlobals.CustomSuitorAccessory;
          if (this.Accessory == 1) {
            Transform transform = this.MaleAccessories[1].transform;
            transform.localScale = new Vector3(1.02f, transform.localScale.y, 1.062f);
          }
        }
        if (StudentGlobals.CustomSuitorBlonde > 0) {
          this.HairColor = "Yellow";
        }
        if (StudentGlobals.CustomSuitorJewelry > 0) {
          foreach (GameObject gameObject2 in this.GaloAccessories) {
            gameObject2.SetActive(true);
          }
        }
      }
    }
    if (this.Club == ClubType.Teacher) {
      this.MyRenderer.sharedMesh = this.TeacherMesh;
      this.Teacher = true;
    } else if (this.Club == ClubType.GymTeacher) {
      if (!StudentGlobals.GetStudentReplaced(this.StudentID)) {
        this.Character.GetComponent<Animation>()["f02_smile_00"].layer = 1;
        this.Character.GetComponent<Animation>().Play("f02_smile_00");
        this.Character.GetComponent<Animation>()["f02_smile_00"].weight = 1f;
        this.RightEyeRenderer.gameObject.SetActive(false);
        this.LeftEyeRenderer.gameObject.SetActive(false);
      }
      this.MyRenderer.sharedMesh = this.CoachMesh;
      this.Teacher = true;
    } else if (this.Club == ClubType.Nurse) {
      this.MyRenderer.sharedMesh = this.NurseMesh;
      this.Teacher = true;
    } else if (this.Club == ClubType.Council) {
      string str = string.Empty;
      if (this.StudentID == 86) {
        str = "Strict";
      }
      if (this.StudentID == 87) {
        str = "Casual";
      }
      if (this.StudentID == 88) {
        str = "Grace";
      }
      if (this.StudentID == 89) {
        str = "Edgy";
      }
      this.Character.GetComponent<Animation>()["f02_faceCouncil" + str + "_00"].layer = 1;
      this.Character.GetComponent<Animation>().Play("f02_faceCouncil" + str + "_00");
      this.Character.GetComponent<Animation>()["f02_idleCouncil" + str + "_00"].time = 1f;
      this.Character.GetComponent<Animation>().Play("f02_idleCouncil" + str + "_00");
    }
    foreach (GameObject gameObject3 in this.FemaleAccessories) {
      if (gameObject3 != null) {
        gameObject3.SetActive(false);
      }
    }
    foreach (GameObject gameObject4 in this.MaleAccessories) {
      if (gameObject4 != null) {
        gameObject4.SetActive(false);
      }
    }
    foreach (GameObject gameObject5 in this.ClubAccessories) {
      if (gameObject5 != null) {
        gameObject5.SetActive(false);
      }
    }
    foreach (GameObject gameObject6 in this.TeacherAccessories) {
      if (gameObject6 != null) {
        gameObject6.SetActive(false);
      }
    }
    foreach (GameObject gameObject7 in this.TeacherHair) {
      if (gameObject7 != null) {
        gameObject7.SetActive(false);
      }
    }
    foreach (GameObject gameObject8 in this.FemaleHair) {
      if (gameObject8 != null) {
        gameObject8.SetActive(false);
      }
    }
    foreach (GameObject gameObject9 in this.MaleHair) {
      if (gameObject9 != null) {
        gameObject9.SetActive(false);
      }
    }
    foreach (GameObject gameObject10 in this.FacialHair) {
      if (gameObject10 != null) {
        gameObject10.SetActive(false);
      }
    }
    foreach (GameObject gameObject11 in this.Eyewear) {
      if (gameObject11 != null) {
        gameObject11.SetActive(false);
      }
    }
    foreach (GameObject gameObject12 in this.RightStockings) {
      if (gameObject12 != null) {
        gameObject12.SetActive(false);
      }
    }
    foreach (GameObject gameObject13 in this.LeftStockings) {
      if (gameObject13 != null) {
        gameObject13.SetActive(false);
      }
    }
    if (this.StudentID == 13 && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorEyewear > 0) {
      this.Eyewear[StudentGlobals.CustomSuitorEyewear].SetActive(true);
    }
    if (this.StudentID == 1 && SenpaiGlobals.CustomSenpai) {
      if (SenpaiGlobals.SenpaiEyeWear > 0) {
        this.Eyewear[SenpaiGlobals.SenpaiEyeWear].SetActive(true);
      }
      this.FacialHairstyle = SenpaiGlobals.SenpaiFacialHair;
      this.HairColor = SenpaiGlobals.SenpaiHairColor;
      this.EyeColor = SenpaiGlobals.SenpaiEyeColor;
      this.Hairstyle = SenpaiGlobals.SenpaiHairStyle;
    }
    if (!this.Male) {
      if (!this.Teacher) {
        this.FemaleHair[this.Hairstyle].SetActive(true);
        this.HairRenderer = this.FemaleHairRenderers[this.Hairstyle];
        this.SetFemaleUniform();
      } else {
        this.TeacherHair[this.Hairstyle].SetActive(true);
        this.HairRenderer = this.TeacherHairRenderers[this.Hairstyle];
        if (this.Club == ClubType.Teacher) {
          this.MyRenderer.materials[0].mainTexture = this.TeacherBodyTexture;
          this.MyRenderer.materials[1].mainTexture = this.DefaultFaceTexture;
          this.MyRenderer.materials[2].mainTexture = this.TeacherBodyTexture;
        } else if (this.Club == ClubType.GymTeacher) {
          if (StudentGlobals.GetStudentReplaced(this.StudentID)) {
            this.MyRenderer.materials[0].mainTexture = this.DefaultFaceTexture;
            this.MyRenderer.materials[1].mainTexture = this.CoachPaleBodyTexture;
            this.MyRenderer.materials[2].mainTexture = this.CoachPaleBodyTexture;
          } else {
            this.MyRenderer.materials[0].mainTexture = this.CoachFaceTexture;
            this.MyRenderer.materials[1].mainTexture = this.CoachBodyTexture;
            this.MyRenderer.materials[2].mainTexture = this.CoachBodyTexture;
          }
        } else if (this.Club == ClubType.Nurse) {
          this.MyRenderer.materials = this.NurseMaterials;
        }
      }
    } else {
      if (this.Hairstyle > 0) {
        this.MaleHair[this.Hairstyle].SetActive(true);
        this.HairRenderer = this.MaleHairRenderers[this.Hairstyle];
      }
      if (this.FacialHairstyle > 0) {
        this.FacialHair[this.FacialHairstyle].SetActive(true);
        this.FacialHairRenderer = this.FacialHairRenderers[this.FacialHairstyle];
      }
      this.SetMaleUniform();
    }
    if (!this.Male) {
      if (!this.Teacher) {
        if (this.FemaleAccessories[this.Accessory] != null) {
          this.FemaleAccessories[this.Accessory].SetActive(true);
        }
      } else if (this.TeacherAccessories[this.Accessory] != null) {
        this.TeacherAccessories[this.Accessory].SetActive(true);
      }
    } else if (this.MaleAccessories[this.Accessory] != null) {
      this.MaleAccessories[this.Accessory].SetActive(true);
    }
    if (this.Club < ClubType.Gaming && this.ClubAccessories[(int)this.Club] != null && !ClubGlobals.GetClubClosed(this.Club) && this.StudentID != 26) {
      this.ClubAccessories[(int)this.Club].SetActive(true);
    }
    if (!this.Male) {
      base.StartCoroutine(this.PutOnStockings());
    }
    if (!this.Randomize) {
      if (this.EyeColor != string.Empty) {
        if (this.EyeColor == "White") {
          this.CorrectColor = new Color(1f, 1f, 1f);
        } else if (this.EyeColor == "Black") {
          this.CorrectColor = new Color(0.5f, 0.5f, 0.5f);
        } else if (this.EyeColor == "Red") {
          this.CorrectColor = new Color(1f, 0f, 0f);
        } else if (this.EyeColor == "Yellow") {
          this.CorrectColor = new Color(1f, 1f, 0f);
        } else if (this.EyeColor == "Green") {
          this.CorrectColor = new Color(0f, 1f, 0f);
        } else if (this.EyeColor == "Cyan") {
          this.CorrectColor = new Color(0f, 1f, 1f);
        } else if (this.EyeColor == "Blue") {
          this.CorrectColor = new Color(0f, 0f, 1f);
        } else if (this.EyeColor == "Purple") {
          this.CorrectColor = new Color(1f, 0f, 1f);
        } else if (this.EyeColor == "Orange") {
          this.CorrectColor = new Color(1f, 0.5f, 0f);
        } else if (this.EyeColor == "Brown") {
          this.CorrectColor = new Color(0.5f, 0.25f, 0f);
        } else {
          this.CorrectColor = new Color(0f, 0f, 0f);
        }
        if (this.CorrectColor != new Color(0f, 0f, 0f)) {
          this.RightEyeRenderer.material.color = this.CorrectColor;
          this.LeftEyeRenderer.material.color = this.CorrectColor;
        }
      }
    } else {
      float r = UnityEngine.Random.Range(0f, 1f);
      float g = UnityEngine.Random.Range(0f, 1f);
      float b = UnityEngine.Random.Range(0f, 1f);
      this.RightEyeRenderer.material.color = new Color(r, g, b);
      this.LeftEyeRenderer.material.color = new Color(r, g, b);
    }
    if (!this.Randomize) {
      if (this.HairColor == "White") {
        this.ColorValue = new Color(1f, 1f, 1f);
      } else if (this.HairColor == "Black") {
        this.ColorValue = new Color(0.5f, 0.5f, 0.5f);
      } else if (this.HairColor == "Red") {
        this.ColorValue = new Color(1f, 0f, 0f);
      } else if (this.HairColor == "Yellow") {
        this.ColorValue = new Color(1f, 1f, 0f);
      } else if (this.HairColor == "Green") {
        this.ColorValue = new Color(0f, 1f, 0f);
      } else if (this.HairColor == "Cyan") {
        this.ColorValue = new Color(0f, 1f, 1f);
      } else if (this.HairColor == "Blue") {
        this.ColorValue = new Color(0f, 0f, 1f);
      } else if (this.HairColor == "Purple") {
        this.ColorValue = new Color(1f, 0f, 1f);
      } else if (this.HairColor == "Orange") {
        this.ColorValue = new Color(1f, 0.5f, 0f);
      } else if (this.HairColor == "Brown") {
        this.ColorValue = new Color(0.5f, 0.25f, 0f);
      } else {
        this.ColorValue = new Color(0f, 0f, 0f);
      }
      if (this.ColorValue == new Color(0f, 0f, 0f)) {
        this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
        this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
        this.FaceTexture = this.HairRenderer.material.mainTexture;
        this.CustomHair = true;
      }
      if (!this.CustomHair) {
        if (this.Hairstyle > 0) {
          if (GameGlobals.LoveSick) {
            this.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
          } else {
            this.HairRenderer.material.color = this.ColorValue;
          }
        }
      } else if (GameGlobals.LoveSick) {
        this.HairRenderer.material.color = new Color(0.1f, 0.1f, 0.1f);
      }
      if (!this.Male) {
        this.FemaleAccessories[6].GetComponent<Renderer>().material.color = this.ColorValue;
      }
    } else {
      this.HairRenderer.material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
    }
    if (!this.Teacher) {
      if (this.CustomHair) {
        if (!this.Male) {
          this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
        } else if (StudentGlobals.MaleUniform == 1) {
          this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
        } else if (StudentGlobals.MaleUniform < 4) {
          this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
        } else {
          this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
        }
      }
    } else if (this.Teacher && StudentGlobals.GetStudentReplaced(this.StudentID)) {
      Color studentColor = StudentGlobals.GetStudentColor(this.StudentID);
      Color studentEyeColor = StudentGlobals.GetStudentEyeColor(this.StudentID);
      this.HairRenderer.material.color = studentColor;
      this.RightEyeRenderer.material.color = studentEyeColor;
      this.LeftEyeRenderer.material.color = studentEyeColor;
    }
    if (this.Male) {
      if (this.Accessory == 2) {
        this.RightIrisLight.SetActive(false);
        this.LeftIrisLight.SetActive(false);
      }
      if (SceneManager.GetActiveScene().name == "PortraitScene") {
        this.Character.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
      }
      if (this.FacialHairRenderer != null) {
        this.FacialHairRenderer.material.color = this.ColorValue;
        if (this.FacialHairRenderer.materials.Length > 1) {
          this.FacialHairRenderer.materials[1].color = this.ColorValue;
        }
      }
    }
    if (this.StudentID > 1 && this.StudentID < 8 && (float)StudentGlobals.GetStudentReputation(7) > -33.33333f) {
      this.FemaleAccessories[6].SetActive(true);
    }
    if (this.StudentID == 17) {
      if (SchemeGlobals.GetSchemeStage(2) == 2) {
        this.FemaleAccessories[3].SetActive(false);
      }
    } else if (this.StudentID == 20 && base.transform.position != Vector3.zero) {
      this.RightEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
      this.LeftEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
      this.RightEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
      this.LeftEyeRenderer.gameObject.GetComponent<RainbowScript>().enabled = true;
    }
    if (this.Student != null && this.Student.AoT) {
      this.Student.AttackOnTitan();
    }
    if (this.HomeScene) {
      this.Student.CharacterAnimation["idle_00"].time = 9f;
      this.Student.CharacterAnimation["idle_00"].speed = 0f;
    }
    this.TaskCheck();
    this.TurnOnCheck();
    this.EyeTypeCheck();
    if (this.Kidnapped) {
      this.WearIndoorShoes();
    }
  }

  // Token: 0x060001AB RID: 427 RVA: 0x00020A10 File Offset: 0x0001EE10
  public void SetMaleUniform() {
    if (this.StudentID == 1) {
      this.SkinColor = SenpaiGlobals.SenpaiSkinColor;
      this.FaceTexture = this.FaceTextures[this.SkinColor];
    } else {
      this.FaceTexture = ((!this.CustomHair) ? this.FaceTextures[this.SkinColor] : this.HairRenderer.material.mainTexture);
      if (this.StudentID == 13 && StudentGlobals.CustomSuitor && StudentGlobals.CustomSuitorTan) {
        this.SkinColor = 6;
        this.FaceTexture = this.FaceTextures[6];
      }
    }
    this.MyRenderer.sharedMesh = this.MaleUniforms[StudentGlobals.MaleUniform];
    this.SchoolUniform = this.MaleUniforms[StudentGlobals.MaleUniform];
    this.UniformTexture = this.MaleUniformTextures[StudentGlobals.MaleUniform];
    this.CasualTexture = this.MaleCasualTextures[StudentGlobals.MaleUniform];
    this.SocksTexture = this.MaleSocksTextures[StudentGlobals.MaleUniform];
    if (StudentGlobals.MaleUniform == 1) {
      this.SkinID = 0;
      this.UniformID = 1;
      this.FaceID = 2;
    } else if (StudentGlobals.MaleUniform == 2) {
      this.UniformID = 0;
      this.FaceID = 1;
      this.SkinID = 2;
    } else if (StudentGlobals.MaleUniform == 3) {
      this.UniformID = 0;
      this.FaceID = 1;
      this.SkinID = 2;
    } else if (StudentGlobals.MaleUniform == 4) {
      this.FaceID = 0;
      this.SkinID = 1;
      this.UniformID = 2;
    } else if (StudentGlobals.MaleUniform == 5) {
      this.FaceID = 0;
      this.SkinID = 1;
      this.UniformID = 2;
    } else if (StudentGlobals.MaleUniform == 6) {
      this.FaceID = 0;
      this.SkinID = 1;
      this.UniformID = 2;
    }
    if (!this.Student.Indoors) {
      this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
      this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
      this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
    } else {
      this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
      this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
      this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
    }
  }

  // Token: 0x060001AC RID: 428 RVA: 0x00020CC0 File Offset: 0x0001F0C0
  public void SetFemaleUniform() {
    if (this.Club != ClubType.Council) {
      this.MyRenderer.sharedMesh = this.FemaleUniforms[StudentGlobals.FemaleUniform];
      this.SchoolUniform = this.FemaleUniforms[StudentGlobals.FemaleUniform];
      if (this.StudentID == 26) {
        this.UniformTexture = this.OccultUniformTextures[StudentGlobals.FemaleUniform];
        this.CasualTexture = this.OccultCasualTextures[StudentGlobals.FemaleUniform];
        this.SocksTexture = this.OccultSocksTextures[StudentGlobals.FemaleUniform];
      } else if (this.StudentID == 32) {
        this.UniformTexture = this.GanguroUniformTextures[StudentGlobals.FemaleUniform];
        this.CasualTexture = this.GanguroCasualTextures[StudentGlobals.FemaleUniform];
        this.SocksTexture = this.GanguroSocksTextures[StudentGlobals.FemaleUniform];
      } else {
        this.UniformTexture = this.FemaleUniformTextures[StudentGlobals.FemaleUniform];
        this.CasualTexture = this.FemaleCasualTextures[StudentGlobals.FemaleUniform];
        this.SocksTexture = this.FemaleSocksTextures[StudentGlobals.FemaleUniform];
      }
    } else {
      this.RightIrisLight.SetActive(false);
      this.LeftIrisLight.SetActive(false);
      this.MyRenderer.sharedMesh = this.FemaleUniforms[4];
      this.SchoolUniform = this.FemaleUniforms[4];
      this.UniformTexture = this.FemaleUniformTextures[7];
      this.CasualTexture = this.FemaleCasualTextures[7];
      this.SocksTexture = this.FemaleSocksTextures[7];
    }
    if (!this.Cutscene) {
      if (!this.Kidnapped) {
        if (!this.Student.Indoors) {
          this.MyRenderer.materials[0].mainTexture = this.CasualTexture;
          this.MyRenderer.materials[1].mainTexture = this.CasualTexture;
        } else {
          this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
          this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
        }
      } else {
        this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
        this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
      }
    } else {
      this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
      this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
    }
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    if (!this.TakingPortrait && this.Student != null && this.Student.StudentManager != null && this.Student.StudentManager.Censor) {
      this.CensorPanties();
    }
    if (this.MyStockings != null) {
      base.StartCoroutine(this.PutOnStockings());
    }
  }

  // Token: 0x060001AD RID: 429 RVA: 0x00020FAC File Offset: 0x0001F3AC
  public void CensorPanties() {
    if (!this.Student.ClubAttire && this.Student.Schoolwear == 1) {
      this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 1f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 1f);
    } else {
      this.RemoveCensor();
    }
  }

  // Token: 0x060001AE RID: 430 RVA: 0x0002101D File Offset: 0x0001F41D
  public void RemoveCensor() {
    this.MyRenderer.materials[0].SetFloat("_BlendAmount1", 0f);
    this.MyRenderer.materials[1].SetFloat("_BlendAmount1", 0f);
  }

  // Token: 0x060001AF RID: 431 RVA: 0x00021058 File Offset: 0x0001F458
  private void TaskCheck() {
    if (this.StudentID == 15) {
      if (TaskGlobals.GetTaskStatus(15) < 3 && !this.TakingPortrait) {
        this.MaleAccessories[1].SetActive(false);
      }
    } else if (this.StudentID == 33 && TaskGlobals.GetTaskStatus(33) < 3 && this.Charm != null) {
      this.Charm.SetActive(true);
    }
  }

  // Token: 0x060001B0 RID: 432 RVA: 0x000210D4 File Offset: 0x0001F4D4
  private void TurnOnCheck() {
    if (!this.TurnedOn && !this.TakingPortrait && this.Male) {
      if (this.HairColor == "Purple") {
        this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
        this.LoveManager.TotalTargets++;
      }
      if (this.MaleAccessories[2].activeInHierarchy) {
        this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
        this.LoveManager.TotalTargets++;
      }
      if (this.MaleAccessories[3].activeInHierarchy) {
        this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
        this.LoveManager.TotalTargets++;
      }
    }
    this.TurnedOn = true;
  }

  // Token: 0x060001B1 RID: 433 RVA: 0x000211E4 File Offset: 0x0001F5E4
  private void DestroyUnneccessaryObjects() {
    foreach (GameObject gameObject in this.FemaleAccessories) {
      if (gameObject != null && !gameObject.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject);
      }
    }
    foreach (GameObject gameObject2 in this.MaleAccessories) {
      if (gameObject2 != null && !gameObject2.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject2);
      }
    }
    foreach (GameObject gameObject3 in this.ClubAccessories) {
      if (gameObject3 != null && !gameObject3.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject3);
      }
    }
    foreach (GameObject gameObject4 in this.TeacherAccessories) {
      if (gameObject4 != null && !gameObject4.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject4);
      }
    }
    foreach (GameObject gameObject5 in this.TeacherHair) {
      if (gameObject5 != null && !gameObject5.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject5);
      }
    }
    foreach (GameObject gameObject6 in this.FemaleHair) {
      if (gameObject6 != null && !gameObject6.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject6);
      }
    }
    foreach (GameObject gameObject7 in this.MaleHair) {
      if (gameObject7 != null && !gameObject7.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject7);
      }
    }
    foreach (GameObject gameObject8 in this.FacialHair) {
      if (gameObject8 != null && !gameObject8.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject8);
      }
    }
    foreach (GameObject gameObject9 in this.Eyewear) {
      if (gameObject9 != null && !gameObject9.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject9);
      }
    }
    foreach (GameObject gameObject10 in this.RightStockings) {
      if (gameObject10 != null && !gameObject10.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject10);
      }
    }
    foreach (GameObject gameObject11 in this.LeftStockings) {
      if (gameObject11 != null && !gameObject11.activeInHierarchy) {
        UnityEngine.Object.Destroy(gameObject11);
      }
    }
  }

  // Token: 0x060001B2 RID: 434 RVA: 0x000214FC File Offset: 0x0001F8FC
  public IEnumerator PutOnStockings() {
    this.RightStockings[0].SetActive(false);
    this.LeftStockings[0].SetActive(false);
    if (this.Stockings == string.Empty) {
      this.MyStockings = null;
    } else if (this.Stockings == "Red") {
      this.MyStockings = this.RedStockings;
    } else if (this.Stockings == "Yellow") {
      this.MyStockings = this.YellowStockings;
    } else if (this.Stockings == "Green") {
      this.MyStockings = this.GreenStockings;
    } else if (this.Stockings == "Cyan") {
      this.MyStockings = this.CyanStockings;
    } else if (this.Stockings == "Blue") {
      this.MyStockings = this.BlueStockings;
    } else if (this.Stockings == "Purple") {
      this.MyStockings = this.PurpleStockings;
    } else if (this.Stockings == "ShortGreen") {
      this.MyStockings = this.GreenSocks;
    } else if (this.Stockings == "Black") {
      this.MyStockings = this.BlackStockings;
    } else if (this.Stockings == "Osana") {
      this.MyStockings = this.OsanaStockings;
    } else if (this.Stockings == "Kizana") {
      this.MyStockings = this.KizanaStockings;
    } else if (this.Stockings == "Council1") {
      this.MyStockings = this.TurtleStockings;
    } else if (this.Stockings == "Council2") {
      this.MyStockings = this.TigerStockings;
    } else if (this.Stockings == "Council3") {
      this.MyStockings = this.BirdStockings;
    } else if (this.Stockings == "Council4") {
      this.MyStockings = this.DragonStockings;
    } else if (this.Stockings == "Custom1") {
      WWW NewCustomStockings = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings1.png");
      yield return NewCustomStockings;
      if (NewCustomStockings.error == null) {
        this.CustomStockings[1] = NewCustomStockings.texture;
      }
      this.MyStockings = this.CustomStockings[1];
    } else if (this.Stockings == "Custom2") {
      WWW NewCustomStockings2 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings2.png");
      yield return NewCustomStockings2;
      if (NewCustomStockings2.error == null) {
        this.CustomStockings[2] = NewCustomStockings2.texture;
      }
      this.MyStockings = this.CustomStockings[2];
    } else if (this.Stockings == "Custom3") {
      WWW NewCustomStockings3 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings3.png");
      yield return NewCustomStockings3;
      if (NewCustomStockings3.error == null) {
        this.CustomStockings[3] = NewCustomStockings3.texture;
      }
      this.MyStockings = this.CustomStockings[3];
    } else if (this.Stockings == "Custom4") {
      WWW NewCustomStockings4 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings4.png");
      yield return NewCustomStockings4;
      if (NewCustomStockings4.error == null) {
        this.CustomStockings[4] = NewCustomStockings4.texture;
      }
      this.MyStockings = this.CustomStockings[4];
    } else if (this.Stockings == "Custom5") {
      WWW NewCustomStockings5 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings5.png");
      yield return NewCustomStockings5;
      if (NewCustomStockings5.error == null) {
        this.CustomStockings[5] = NewCustomStockings5.texture;
      }
      this.MyStockings = this.CustomStockings[5];
    } else if (this.Stockings == "Custom6") {
      WWW NewCustomStockings6 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings6.png");
      yield return NewCustomStockings6;
      if (NewCustomStockings6.error == null) {
        this.CustomStockings[6] = NewCustomStockings6.texture;
      }
      this.MyStockings = this.CustomStockings[6];
    } else if (this.Stockings == "Custom7") {
      WWW NewCustomStockings7 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings7.png");
      yield return NewCustomStockings7;
      if (NewCustomStockings7.error == null) {
        this.CustomStockings[7] = NewCustomStockings7.texture;
      }
      this.MyStockings = this.CustomStockings[7];
    } else if (this.Stockings == "Custom8") {
      WWW NewCustomStockings8 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings8.png");
      yield return NewCustomStockings8;
      if (NewCustomStockings8.error == null) {
        this.CustomStockings[8] = NewCustomStockings8.texture;
      }
      this.MyStockings = this.CustomStockings[8];
    } else if (this.Stockings == "Custom9") {
      WWW NewCustomStockings9 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings9.png");
      yield return NewCustomStockings9;
      if (NewCustomStockings9.error == null) {
        this.CustomStockings[9] = NewCustomStockings9.texture;
      }
      this.MyStockings = this.CustomStockings[9];
    } else if (this.Stockings == "Custom10") {
      WWW NewCustomStockings10 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomStockings10.png");
      yield return NewCustomStockings10;
      if (NewCustomStockings10.error == null) {
        this.CustomStockings[10] = NewCustomStockings10.texture;
      }
      this.MyStockings = this.CustomStockings[10];
    } else if (this.Stockings == "Loose") {
      this.MyStockings = null;
      this.RightStockings[0].SetActive(true);
      this.LeftStockings[0].SetActive(true);
    }
    if (this.MyStockings != null) {
      this.MyRenderer.materials[0].SetTexture("_OverlayTex", this.MyStockings);
      this.MyRenderer.materials[1].SetTexture("_OverlayTex", this.MyStockings);
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 1f);
    } else {
      this.MyRenderer.materials[0].SetTexture("_OverlayTex", null);
      this.MyRenderer.materials[1].SetTexture("_OverlayTex", null);
      this.MyRenderer.materials[0].SetFloat("_BlendAmount", 0f);
      this.MyRenderer.materials[1].SetFloat("_BlendAmount", 0f);
    }
    yield break;
  }

  // Token: 0x060001B3 RID: 435 RVA: 0x00021518 File Offset: 0x0001F918
  public void WearIndoorShoes() {
    if (!this.Male) {
      this.MyRenderer.materials[0].mainTexture = this.CasualTexture;
      this.MyRenderer.materials[1].mainTexture = this.CasualTexture;
    } else {
      this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
    }
  }

  // Token: 0x060001B4 RID: 436 RVA: 0x00021584 File Offset: 0x0001F984
  public void WearOutdoorShoes() {
    if (!this.Male) {
      this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
      this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
    } else {
      this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
    }
  }

  // Token: 0x060001B5 RID: 437 RVA: 0x000215EE File Offset: 0x0001F9EE
  public void EyeTypeCheck() {
  }

  // Token: 0x04000569 RID: 1385
  public StudentManagerScript StudentManager;

  // Token: 0x0400056A RID: 1386
  public TextureManagerScript TextureManager;

  // Token: 0x0400056B RID: 1387
  public SkinnedMeshUpdater SkinUpdater;

  // Token: 0x0400056C RID: 1388
  public LoveManagerScript LoveManager;

  // Token: 0x0400056D RID: 1389
  public StudentScript Student;

  // Token: 0x0400056E RID: 1390
  public JsonScript JSON;

  // Token: 0x0400056F RID: 1391
  public GameObject[] TeacherAccessories;

  // Token: 0x04000570 RID: 1392
  public GameObject[] FemaleAccessories;

  // Token: 0x04000571 RID: 1393
  public GameObject[] MaleAccessories;

  // Token: 0x04000572 RID: 1394
  public GameObject[] ClubAccessories;

  // Token: 0x04000573 RID: 1395
  public GameObject[] RightStockings;

  // Token: 0x04000574 RID: 1396
  public GameObject[] LeftStockings;

  // Token: 0x04000575 RID: 1397
  public GameObject[] TeacherHair;

  // Token: 0x04000576 RID: 1398
  public GameObject[] FacialHair;

  // Token: 0x04000577 RID: 1399
  public GameObject[] FemaleHair;

  // Token: 0x04000578 RID: 1400
  public GameObject[] MaleHair;

  // Token: 0x04000579 RID: 1401
  public GameObject[] Eyewear;

  // Token: 0x0400057A RID: 1402
  public Renderer[] TeacherHairRenderers;

  // Token: 0x0400057B RID: 1403
  public Renderer[] FacialHairRenderers;

  // Token: 0x0400057C RID: 1404
  public Renderer[] FemaleHairRenderers;

  // Token: 0x0400057D RID: 1405
  public Renderer[] MaleHairRenderers;

  // Token: 0x0400057E RID: 1406
  public Texture[] GanguroUniformTextures;

  // Token: 0x0400057F RID: 1407
  public Texture[] GanguroCasualTextures;

  // Token: 0x04000580 RID: 1408
  public Texture[] GanguroSocksTextures;

  // Token: 0x04000581 RID: 1409
  public Texture[] OccultUniformTextures;

  // Token: 0x04000582 RID: 1410
  public Texture[] OccultCasualTextures;

  // Token: 0x04000583 RID: 1411
  public Texture[] OccultSocksTextures;

  // Token: 0x04000584 RID: 1412
  public Texture[] FemaleUniformTextures;

  // Token: 0x04000585 RID: 1413
  public Texture[] FemaleCasualTextures;

  // Token: 0x04000586 RID: 1414
  public Texture[] FemaleSocksTextures;

  // Token: 0x04000587 RID: 1415
  public Texture[] MaleUniformTextures;

  // Token: 0x04000588 RID: 1416
  public Texture[] MaleCasualTextures;

  // Token: 0x04000589 RID: 1417
  public Texture[] MaleSocksTextures;

  // Token: 0x0400058A RID: 1418
  public Texture[] FaceTextures;

  // Token: 0x0400058B RID: 1419
  public Texture[] SkinTextures;

  // Token: 0x0400058C RID: 1420
  public Mesh[] FemaleUniforms;

  // Token: 0x0400058D RID: 1421
  public Mesh[] MaleUniforms;

  // Token: 0x0400058E RID: 1422
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x0400058F RID: 1423
  public Renderer FacialHairRenderer;

  // Token: 0x04000590 RID: 1424
  public Renderer RightEyeRenderer;

  // Token: 0x04000591 RID: 1425
  public Renderer LeftEyeRenderer;

  // Token: 0x04000592 RID: 1426
  public Renderer HairRenderer;

  // Token: 0x04000593 RID: 1427
  public Mesh SchoolUniform;

  // Token: 0x04000594 RID: 1428
  public Texture DefaultFaceTexture;

  // Token: 0x04000595 RID: 1429
  public Texture TeacherBodyTexture;

  // Token: 0x04000596 RID: 1430
  public Texture CoachPaleBodyTexture;

  // Token: 0x04000597 RID: 1431
  public Texture CoachBodyTexture;

  // Token: 0x04000598 RID: 1432
  public Texture CoachFaceTexture;

  // Token: 0x04000599 RID: 1433
  public Texture UniformTexture;

  // Token: 0x0400059A RID: 1434
  public Texture CasualTexture;

  // Token: 0x0400059B RID: 1435
  public Texture SocksTexture;

  // Token: 0x0400059C RID: 1436
  public Texture FaceTexture;

  // Token: 0x0400059D RID: 1437
  public Texture PurpleStockings;

  // Token: 0x0400059E RID: 1438
  public Texture YellowStockings;

  // Token: 0x0400059F RID: 1439
  public Texture BlackStockings;

  // Token: 0x040005A0 RID: 1440
  public Texture GreenStockings;

  // Token: 0x040005A1 RID: 1441
  public Texture BlueStockings;

  // Token: 0x040005A2 RID: 1442
  public Texture CyanStockings;

  // Token: 0x040005A3 RID: 1443
  public Texture RedStockings;

  // Token: 0x040005A4 RID: 1444
  public Texture GreenSocks;

  // Token: 0x040005A5 RID: 1445
  public Texture KizanaStockings;

  // Token: 0x040005A6 RID: 1446
  public Texture OsanaStockings;

  // Token: 0x040005A7 RID: 1447
  public Texture TurtleStockings;

  // Token: 0x040005A8 RID: 1448
  public Texture TigerStockings;

  // Token: 0x040005A9 RID: 1449
  public Texture BirdStockings;

  // Token: 0x040005AA RID: 1450
  public Texture DragonStockings;

  // Token: 0x040005AB RID: 1451
  public Texture[] CustomStockings;

  // Token: 0x040005AC RID: 1452
  public Texture MyStockings;

  // Token: 0x040005AD RID: 1453
  public GameObject RightIrisLight;

  // Token: 0x040005AE RID: 1454
  public GameObject LeftIrisLight;

  // Token: 0x040005AF RID: 1455
  public GameObject Character;

  // Token: 0x040005B0 RID: 1456
  public GameObject RightShoe;

  // Token: 0x040005B1 RID: 1457
  public GameObject LeftShoe;

  // Token: 0x040005B2 RID: 1458
  public GameObject Charm;

  // Token: 0x040005B3 RID: 1459
  public Transform RightBreast;

  // Token: 0x040005B4 RID: 1460
  public Transform LeftBreast;

  // Token: 0x040005B5 RID: 1461
  public Color CorrectColor;

  // Token: 0x040005B6 RID: 1462
  public Color ColorValue;

  // Token: 0x040005B7 RID: 1463
  public Mesh TeacherMesh;

  // Token: 0x040005B8 RID: 1464
  public Mesh CoachMesh;

  // Token: 0x040005B9 RID: 1465
  public Mesh NurseMesh;

  // Token: 0x040005BA RID: 1466
  public bool TakingPortrait;

  // Token: 0x040005BB RID: 1467
  public bool Initialized;

  // Token: 0x040005BC RID: 1468
  public bool CustomHair;

  // Token: 0x040005BD RID: 1469
  public bool HomeScene;

  // Token: 0x040005BE RID: 1470
  public bool Kidnapped;

  // Token: 0x040005BF RID: 1471
  public bool Randomize;

  // Token: 0x040005C0 RID: 1472
  public bool Cutscene;

  // Token: 0x040005C1 RID: 1473
  public bool TurnedOn;

  // Token: 0x040005C2 RID: 1474
  public bool Teacher;

  // Token: 0x040005C3 RID: 1475
  public bool Yandere;

  // Token: 0x040005C4 RID: 1476
  public bool Male;

  // Token: 0x040005C5 RID: 1477
  public float BreastSize;

  // Token: 0x040005C6 RID: 1478
  public string OriginalStockings = string.Empty;

  // Token: 0x040005C7 RID: 1479
  public string HairColor = string.Empty;

  // Token: 0x040005C8 RID: 1480
  public string Stockings = string.Empty;

  // Token: 0x040005C9 RID: 1481
  public string EyeColor = string.Empty;

  // Token: 0x040005CA RID: 1482
  public string EyeType = string.Empty;

  // Token: 0x040005CB RID: 1483
  public int FacialHairstyle;

  // Token: 0x040005CC RID: 1484
  public int Accessory;

  // Token: 0x040005CD RID: 1485
  public int Hairstyle;

  // Token: 0x040005CE RID: 1486
  public int SkinColor;

  // Token: 0x040005CF RID: 1487
  public int StudentID;

  // Token: 0x040005D0 RID: 1488
  public ClubType Club;

  // Token: 0x040005D1 RID: 1489
  public int ID;

  // Token: 0x040005D2 RID: 1490
  public GameObject[] GaloAccessories;

  // Token: 0x040005D3 RID: 1491
  public Material[] NurseMaterials;

  // Token: 0x040005D4 RID: 1492
  public int FaceID;

  // Token: 0x040005D5 RID: 1493
  public int SkinID;

  // Token: 0x040005D6 RID: 1494
  public int UniformID;
}