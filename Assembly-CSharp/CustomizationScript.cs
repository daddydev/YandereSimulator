using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200007A RID: 122
public class CustomizationScript : MonoBehaviour {

  // Token: 0x060001C8 RID: 456 RVA: 0x00023834 File Offset: 0x00021C34
  private void Awake() {
    this.Data = new CustomizationScript.CustomizationData();
    this.Data.skinColor = new global::RangeInt(3, this.MinSkinColor, this.MaxSkinColor);
    this.Data.hairstyle = new global::RangeInt(1, this.MinHairstyle, this.MaxHairstyle);
    this.Data.hairColor = new global::RangeInt(1, this.MinHairColor, this.MaxHairColor);
    this.Data.eyeColor = new global::RangeInt(1, this.MinEyeColor, this.MaxEyeColor);
    this.Data.eyewear = new global::RangeInt(0, this.MinEyewear, this.MaxEyewear);
    this.Data.facialHair = new global::RangeInt(0, this.MinFacialHair, this.MaxFacialHair);
    this.Data.maleUniform = new global::RangeInt(1, this.MinMaleUniform, this.MaxMaleUniform);
    this.Data.femaleUniform = new global::RangeInt(1, this.MinFemaleUniform, this.MaxFemaleUniform);
  }

  // Token: 0x060001C9 RID: 457 RVA: 0x00023934 File Offset: 0x00021D34
  private void Start() {
    this.LoveSick = GameGlobals.LoveSick;
    this.ApologyWindow.localPosition = new Vector3(1360f, this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
    this.CustomizePanel.alpha = 0f;
    this.UniformPanel.alpha = 0f;
    this.FinishPanel.alpha = 0f;
    this.GenderPanel.alpha = 0f;
    this.WhitePanel.alpha = 1f;
    this.UpdateFacialHair(this.Data.facialHair.Value);
    this.UpdateHairStyle(this.Data.hairstyle.Value);
    this.UpdateEyes(this.Data.eyeColor.Value);
    this.UpdateSkin(this.Data.skinColor.Value);
    if (this.LoveSick) {
      this.LoveSickColorSwap();
      this.WhitePanel.alpha = 0f;
      this.Data.femaleUniform.Value = 5;
      this.Data.maleUniform.Value = 5;
      RenderSettings.fogColor = new Color(0f, 0f, 0f, 1f);
      this.LoveSickCamera.SetActive(true);
      this.Black.color = Color.black;
      this.MyAudio.loop = false;
      this.MyAudio.clip = this.LoveSickIntro;
      this.MyAudio.Play();
    } else {
      this.Data.femaleUniform.Value = this.MinFemaleUniform;
      this.Data.maleUniform.Value = this.MinMaleUniform;
      RenderSettings.fogColor = new Color(1f, 0.5f, 1f, 1f);
      this.Black.color = new Color(0f, 0f, 0f, 0f);
      this.LoveSickCamera.SetActive(false);
    }
    this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
    this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
    this.Senpai.position = new Vector3(0f, -1f, 2f);
    this.Senpai.gameObject.SetActive(true);
    this.Senpai.GetComponent<Animation>().Play("newWalk_00");
    this.Yandere.position = new Vector3(1f, -1f, 4.5f);
    this.Yandere.gameObject.SetActive(true);
    this.Yandere.GetComponent<Animation>().Play("f02_newWalk_00");
    this.CensorCloud.SetActive(false);
    this.Hearts.SetActive(false);
  }

  // Token: 0x1700001E RID: 30
  // (get) Token: 0x060001CA RID: 458 RVA: 0x00023C33 File Offset: 0x00022033
  private int MinSkinColor {
    get {
      return 1;
    }
  }

  // Token: 0x1700001F RID: 31
  // (get) Token: 0x060001CB RID: 459 RVA: 0x00023C36 File Offset: 0x00022036
  private int MaxSkinColor {
    get {
      return 5;
    }
  }

  // Token: 0x17000020 RID: 32
  // (get) Token: 0x060001CC RID: 460 RVA: 0x00023C39 File Offset: 0x00022039
  private int MinHairstyle {
    get {
      return 0;
    }
  }

  // Token: 0x17000021 RID: 33
  // (get) Token: 0x060001CD RID: 461 RVA: 0x00023C3C File Offset: 0x0002203C
  private int MaxHairstyle {
    get {
      return this.Hairstyles.Length - 1;
    }
  }

  // Token: 0x17000022 RID: 34
  // (get) Token: 0x060001CE RID: 462 RVA: 0x00023C48 File Offset: 0x00022048
  private int MinHairColor {
    get {
      return 1;
    }
  }

  // Token: 0x17000023 RID: 35
  // (get) Token: 0x060001CF RID: 463 RVA: 0x00023C4B File Offset: 0x0002204B
  private int MaxHairColor {
    get {
      return CustomizationScript.ColorPairs.Length - 1;
    }
  }

  // Token: 0x17000024 RID: 36
  // (get) Token: 0x060001D0 RID: 464 RVA: 0x00023C56 File Offset: 0x00022056
  private int MinEyeColor {
    get {
      return 1;
    }
  }

  // Token: 0x17000025 RID: 37
  // (get) Token: 0x060001D1 RID: 465 RVA: 0x00023C59 File Offset: 0x00022059
  private int MaxEyeColor {
    get {
      return CustomizationScript.ColorPairs.Length - 1;
    }
  }

  // Token: 0x17000026 RID: 38
  // (get) Token: 0x060001D2 RID: 466 RVA: 0x00023C64 File Offset: 0x00022064
  private int MinEyewear {
    get {
      return 0;
    }
  }

  // Token: 0x17000027 RID: 39
  // (get) Token: 0x060001D3 RID: 467 RVA: 0x00023C67 File Offset: 0x00022067
  private int MaxEyewear {
    get {
      return 5;
    }
  }

  // Token: 0x17000028 RID: 40
  // (get) Token: 0x060001D4 RID: 468 RVA: 0x00023C6A File Offset: 0x0002206A
  private int MinFacialHair {
    get {
      return 0;
    }
  }

  // Token: 0x17000029 RID: 41
  // (get) Token: 0x060001D5 RID: 469 RVA: 0x00023C6D File Offset: 0x0002206D
  private int MaxFacialHair {
    get {
      return this.FacialHairstyles.Length - 1;
    }
  }

  // Token: 0x1700002A RID: 42
  // (get) Token: 0x060001D6 RID: 470 RVA: 0x00023C79 File Offset: 0x00022079
  private int MinMaleUniform {
    get {
      return 1;
    }
  }

  // Token: 0x1700002B RID: 43
  // (get) Token: 0x060001D7 RID: 471 RVA: 0x00023C7C File Offset: 0x0002207C
  private int MaxMaleUniform {
    get {
      return this.MaleUniforms.Length - 1;
    }
  }

  // Token: 0x1700002C RID: 44
  // (get) Token: 0x060001D8 RID: 472 RVA: 0x00023C88 File Offset: 0x00022088
  private int MinFemaleUniform {
    get {
      return 1;
    }
  }

  // Token: 0x1700002D RID: 45
  // (get) Token: 0x060001D9 RID: 473 RVA: 0x00023C8B File Offset: 0x0002208B
  private int MaxFemaleUniform {
    get {
      return this.FemaleUniforms.Length - 1;
    }
  }

  // Token: 0x1700002E RID: 46
  // (get) Token: 0x060001DA RID: 474 RVA: 0x00023C97 File Offset: 0x00022097
  private float CameraSpeed {
    get {
      return Time.deltaTime * 10f;
    }
  }

  // Token: 0x060001DB RID: 475 RVA: 0x00023CA4 File Offset: 0x000220A4
  private void Update() {
    if (!this.MyAudio.loop && !this.MyAudio.isPlaying) {
      this.MyAudio.loop = true;
      this.MyAudio.clip = this.LoveSickLoop;
      this.MyAudio.Play();
    }
    for (int i = 1; i < 3; i++) {
      Transform transform = this.Corridor[i];
      transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * this.ScrollSpeed);
      if (transform.position.z > 36f) {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 72f);
      }
    }
    if (this.Phase == 1) {
      if (this.WhitePanel.alpha == 0f) {
        this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, 1f, Time.deltaTime * 2f);
        if (this.GenderPanel.alpha == 1f) {
          if (Input.GetButtonDown("A")) {
            this.Phase++;
          }
          if (Input.GetButtonDown("B")) {
            this.Apologize = true;
          }
          if (Input.GetButtonDown("X")) {
            this.White.color = new Color(0f, 0f, 0f, 1f);
            this.FadeOut = true;
            this.Phase = 0;
          }
        }
      }
    } else if (this.Phase == 2) {
      this.GenderPanel.alpha = Mathf.MoveTowards(this.GenderPanel.alpha, 0f, Time.deltaTime * 2f);
      this.Black.color = new Color(0f, 0f, 0f, Mathf.MoveTowards(this.Black.color.a, 0f, Time.deltaTime * 2f));
      if (this.GenderPanel.alpha == 0f) {
        this.Senpai.gameObject.SetActive(true);
        this.Phase++;
      }
    } else if (this.Phase == 3) {
      this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, 1f, Time.deltaTime * 2f);
      if (this.CustomizePanel.alpha == 1f) {
        if (Input.GetButtonDown("A")) {
          this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, 180f, this.Senpai.localEulerAngles.z);
          this.Phase++;
        }
        bool tappedDown = this.InputManager.TappedDown;
        bool tappedUp = this.InputManager.TappedUp;
        if (tappedDown || tappedUp) {
          if (tappedDown) {
            this.Selected = ((this.Selected < 6) ? (this.Selected + 1) : 1);
          } else if (tappedUp) {
            this.Selected = ((this.Selected > 1) ? (this.Selected - 1) : 6);
          }
          this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 650f - (float)this.Selected * 150f, this.Highlight.localPosition.z);
        }
        if (this.InputManager.TappedRight) {
          if (this.Selected == 1) {
            this.Data.skinColor.Value = this.Data.skinColor.Next;
            this.UpdateSkin(this.Data.skinColor.Value);
          } else if (this.Selected == 2) {
            this.Data.hairstyle.Value = this.Data.hairstyle.Next;
            this.UpdateHairStyle(this.Data.hairstyle.Value);
          } else if (this.Selected == 3) {
            this.Data.hairColor.Value = this.Data.hairColor.Next;
            this.UpdateColor(this.Data.hairColor.Value);
          } else if (this.Selected == 4) {
            this.Data.eyeColor.Value = this.Data.eyeColor.Next;
            this.UpdateEyes(this.Data.eyeColor.Value);
          } else if (this.Selected == 5) {
            this.Data.eyewear.Value = this.Data.eyewear.Next;
            this.UpdateEyewear(this.Data.eyewear.Value);
          } else if (this.Selected == 6) {
            this.Data.facialHair.Value = this.Data.facialHair.Next;
            this.UpdateFacialHair(this.Data.facialHair.Value);
          }
        }
        if (this.InputManager.TappedLeft) {
          if (this.Selected == 1) {
            this.Data.skinColor.Value = this.Data.skinColor.Previous;
            this.UpdateSkin(this.Data.skinColor.Value);
          } else if (this.Selected == 2) {
            this.Data.hairstyle.Value = this.Data.hairstyle.Previous;
            this.UpdateHairStyle(this.Data.hairstyle.Value);
          } else if (this.Selected == 3) {
            this.Data.hairColor.Value = this.Data.hairColor.Previous;
            this.UpdateColor(this.Data.hairColor.Value);
          } else if (this.Selected == 4) {
            this.Data.eyeColor.Value = this.Data.eyeColor.Previous;
            this.UpdateEyes(this.Data.eyeColor.Value);
          } else if (this.Selected == 5) {
            this.Data.eyewear.Value = this.Data.eyewear.Previous;
            this.UpdateEyewear(this.Data.eyewear.Value);
          } else if (this.Selected == 6) {
            this.Data.facialHair.Value = this.Data.facialHair.Previous;
            this.UpdateFacialHair(this.Data.facialHair.Value);
          }
        }
      }
      if (this.Selected == 1) {
        this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -1.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.5f, this.CameraSpeed));
      } else {
        this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -0.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 1.5f, this.CameraSpeed));
      }
      base.transform.position = this.LoveSickCamera.transform.position;
    } else if (this.Phase == 4) {
      this.CustomizePanel.alpha = Mathf.MoveTowards(this.CustomizePanel.alpha, 0f, Time.deltaTime * 2f);
      if (this.CustomizePanel.alpha == 0f) {
        this.Phase++;
      }
    } else if (this.Phase == 5) {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 1f, Time.deltaTime * 2f);
      if (this.FinishPanel.alpha == 1f) {
        if (Input.GetButtonDown("A")) {
          this.Phase++;
        }
        if (Input.GetButtonDown("B")) {
          this.Selected = 1;
          this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 650f - (float)this.Selected * 150f, this.Highlight.localPosition.z);
          this.Phase = 100;
        }
      }
    } else if (this.Phase == 6) {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
      if (this.FinishPanel.alpha == 0f) {
        this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
        this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
        this.CensorCloud.SetActive(false);
        this.Yandere.gameObject.SetActive(true);
        this.Selected = 1;
        this.Phase++;
      }
    } else if (this.Phase == 7) {
      this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 1f, Time.deltaTime * 2f);
      if (this.UniformPanel.alpha == 1f) {
        if (Input.GetButtonDown("A")) {
          this.Yandere.localEulerAngles = new Vector3(this.Yandere.localEulerAngles.x, 180f, this.Yandere.localEulerAngles.z);
          this.Senpai.localEulerAngles = new Vector3(this.Senpai.localEulerAngles.x, 180f, this.Senpai.localEulerAngles.z);
          this.Phase++;
        }
        if (this.InputManager.TappedDown || this.InputManager.TappedUp) {
          this.Selected = ((this.Selected != 1) ? 1 : 2);
          this.UniformHighlight.localPosition = new Vector3(this.UniformHighlight.localPosition.x, 650f - (float)this.Selected * 150f, this.UniformHighlight.localPosition.z);
        }
        if (this.InputManager.TappedRight) {
          if (this.Selected == 1) {
            this.Data.maleUniform.Value = this.Data.maleUniform.Next;
            this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
          } else if (this.Selected == 2) {
            this.Data.femaleUniform.Value = this.Data.femaleUniform.Next;
            this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
          }
        }
        if (this.InputManager.TappedLeft) {
          if (this.Selected == 1) {
            this.Data.maleUniform.Value = this.Data.maleUniform.Previous;
            this.UpdateMaleUniform(this.Data.maleUniform.Value, this.Data.skinColor.Value);
          } else if (this.Selected == 2) {
            this.Data.femaleUniform.Value = this.Data.femaleUniform.Previous;
            this.UpdateFemaleUniform(this.Data.femaleUniform.Value);
          }
        }
      }
    } else if (this.Phase == 8) {
      this.UniformPanel.alpha = Mathf.MoveTowards(this.UniformPanel.alpha, 0f, Time.deltaTime * 2f);
      if (this.UniformPanel.alpha == 0f) {
        this.Phase++;
      }
    } else if (this.Phase == 9) {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 1f, Time.deltaTime * 2f);
      if (this.FinishPanel.alpha == 1f) {
        if (Input.GetButtonDown("A")) {
          this.Phase++;
        }
        if (Input.GetButtonDown("B")) {
          this.Selected = 1;
          this.UniformHighlight.localPosition = new Vector3(this.UniformHighlight.localPosition.x, 650f - (float)this.Selected * 150f, this.UniformHighlight.localPosition.z);
          this.Phase = 99;
        }
      }
    } else if (this.Phase == 10) {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
      if (this.FinishPanel.alpha == 0f) {
        this.White.color = new Color(0f, 0f, 0f, 1f);
        this.FadeOut = true;
        this.Phase = 0;
      }
    } else if (this.Phase == 99) {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
      if (this.FinishPanel.alpha == 0f) {
        this.Phase = 7;
      }
    } else if (this.Phase == 100) {
      this.FinishPanel.alpha = Mathf.MoveTowards(this.FinishPanel.alpha, 0f, Time.deltaTime * 2f);
      if (this.FinishPanel.alpha == 0f) {
        this.Phase = 3;
      }
    }
    if (this.Phase > 3 && this.Phase < 100) {
      if (this.Phase < 6) {
        this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, -1.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0.5f, this.CameraSpeed));
        base.transform.position = this.LoveSickCamera.transform.position;
      } else {
        this.LoveSickCamera.transform.position = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.position.x, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.y, 0.5f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.position.z, 0f, this.CameraSpeed));
        this.LoveSickCamera.transform.eulerAngles = new Vector3(Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.x, 15f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.y, 0f, this.CameraSpeed), Mathf.Lerp(this.LoveSickCamera.transform.eulerAngles.z, 0f, this.CameraSpeed));
        base.transform.eulerAngles = this.LoveSickCamera.transform.eulerAngles;
        base.transform.position = this.LoveSickCamera.transform.position;
        this.Yandere.position = new Vector3(Mathf.Lerp(this.Yandere.position.x, 1f, Time.deltaTime * 10f), Mathf.Lerp(this.Yandere.position.y, -1f, Time.deltaTime * 10f), Mathf.Lerp(this.Yandere.position.z, 3.5f, Time.deltaTime * 10f));
      }
    }
    if (this.FadeOut) {
      this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, 1f, Time.deltaTime);
      base.GetComponent<AudioSource>().volume = 1f - this.WhitePanel.alpha;
      if (this.WhitePanel.alpha == 1f) {
        SenpaiGlobals.CustomSenpai = true;
        SenpaiGlobals.SenpaiSkinColor = this.Data.skinColor.Value;
        SenpaiGlobals.SenpaiHairStyle = this.Data.hairstyle.Value;
        SenpaiGlobals.SenpaiHairColor = this.HairColorName;
        SenpaiGlobals.SenpaiEyeColor = this.EyeColorName;
        SenpaiGlobals.SenpaiEyeWear = this.Data.eyewear.Value;
        SenpaiGlobals.SenpaiFacialHair = this.Data.facialHair.Value;
        StudentGlobals.MaleUniform = this.Data.maleUniform.Value;
        StudentGlobals.FemaleUniform = this.Data.femaleUniform.Value;
        SceneManager.LoadScene("IntroScene");
      }
    } else {
      this.WhitePanel.alpha = Mathf.MoveTowards(this.WhitePanel.alpha, 0f, Time.deltaTime);
    }
    if (this.Apologize) {
      this.Timer += Time.deltaTime;
      if (this.Timer < 1f) {
        this.ApologyWindow.localPosition = new Vector3(Mathf.Lerp(this.ApologyWindow.localPosition.x, 0f, Time.deltaTime * 10f), this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
      } else {
        this.ApologyWindow.localPosition = new Vector3(Mathf.Abs((this.ApologyWindow.localPosition.x - Time.deltaTime) * 0.01f) * (Time.deltaTime * 1000f), this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
        if (this.ApologyWindow.localPosition.x < -1360f) {
          this.ApologyWindow.localPosition = new Vector3(1360f, this.ApologyWindow.localPosition.y, this.ApologyWindow.localPosition.z);
          this.Apologize = false;
          this.Timer = 0f;
        }
      }
    }
  }

  // Token: 0x060001DC RID: 476 RVA: 0x000251D0 File Offset: 0x000235D0
  private void LateUpdate() {
    this.YandereHead.LookAt(this.SenpaiHead.position);
  }

  // Token: 0x060001DD RID: 477 RVA: 0x000251E8 File Offset: 0x000235E8
  private void UpdateSkin(int skinColor) {
    this.UpdateMaleUniform(this.Data.maleUniform.Value, skinColor);
    this.SkinColorLabel.text = "Skin Color " + skinColor.ToString();
  }

  // Token: 0x060001DE RID: 478 RVA: 0x00025224 File Offset: 0x00023624
  private void UpdateHairStyle(int hairstyle) {
    for (int i = 1; i < this.Hairstyles.Length; i++) {
      this.Hairstyles[i].SetActive(false);
    }
    if (hairstyle > 0) {
      this.HairRenderer = this.Hairstyles[hairstyle].GetComponent<Renderer>();
      this.Hairstyles[hairstyle].SetActive(true);
    }
    this.HairStyleLabel.text = "Hair Style " + hairstyle.ToString();
    this.UpdateColor(this.Data.hairColor.Value);
  }

  // Token: 0x060001DF RID: 479 RVA: 0x000252B8 File Offset: 0x000236B8
  private void UpdateFacialHair(int facialHair) {
    for (int i = 1; i < this.FacialHairstyles.Length; i++) {
      this.FacialHairstyles[i].SetActive(false);
    }
    if (facialHair > 0) {
      this.FacialHairRenderer = this.FacialHairstyles[facialHair].GetComponent<Renderer>();
      this.FacialHairstyles[facialHair].SetActive(true);
    }
    this.FacialHairStyleLabel.text = "Facial Hair " + facialHair.ToString();
    this.UpdateColor(this.Data.hairColor.Value);
  }

  // Token: 0x060001E0 RID: 480 RVA: 0x0002534C File Offset: 0x0002374C
  private void UpdateColor(int hairColor) {
    KeyValuePair<Color, string> keyValuePair = CustomizationScript.ColorPairs[hairColor];
    Color key = keyValuePair.Key;
    this.HairColorName = keyValuePair.Value;
    if (this.Data.hairstyle.Value > 0) {
      this.HairRenderer = this.Hairstyles[this.Data.hairstyle.Value].GetComponent<Renderer>();
      this.HairRenderer.material.color = key;
    }
    if (this.Data.facialHair.Value > 0) {
      this.FacialHairRenderer = this.FacialHairstyles[this.Data.facialHair.Value].GetComponent<Renderer>();
      this.FacialHairRenderer.material.color = key;
      if (this.FacialHairRenderer.materials.Length > 1) {
        this.FacialHairRenderer.materials[1].color = key;
      }
    }
    this.HairColorLabel.text = "Hair Color " + hairColor.ToString();
  }

  // Token: 0x060001E1 RID: 481 RVA: 0x0002545C File Offset: 0x0002385C
  private void UpdateEyes(int eyeColor) {
    KeyValuePair<Color, string> keyValuePair = CustomizationScript.ColorPairs[eyeColor];
    Color key = keyValuePair.Key;
    this.EyeColorName = keyValuePair.Value;
    this.EyeR.material.color = key;
    this.EyeL.material.color = key;
    this.EyeColorLabel.text = "Eye Color " + eyeColor.ToString();
  }

  // Token: 0x060001E2 RID: 482 RVA: 0x000254D4 File Offset: 0x000238D4
  private void UpdateEyewear(int eyewear) {
    for (int i = 1; i < this.Eyewears.Length; i++) {
      this.Eyewears[i].SetActive(false);
    }
    if (eyewear > 0) {
      this.Eyewears[eyewear].SetActive(true);
    }
    this.EyeWearLabel.text = "Eye Wear " + eyewear.ToString();
  }

  // Token: 0x060001E3 RID: 483 RVA: 0x00025540 File Offset: 0x00023940
  private void UpdateMaleUniform(int maleUniform, int skinColor) {
    this.SenpaiRenderer.sharedMesh = this.MaleUniforms[maleUniform];
    if (maleUniform == 1) {
      this.SenpaiRenderer.materials[0].mainTexture = this.SkinTextures[skinColor];
      this.SenpaiRenderer.materials[1].mainTexture = this.MaleUniformTextures[maleUniform];
      this.SenpaiRenderer.materials[2].mainTexture = this.FaceTextures[skinColor];
    } else if (maleUniform == 2) {
      this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[maleUniform];
      this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[skinColor];
      this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[skinColor];
    } else if (maleUniform == 3) {
      this.SenpaiRenderer.materials[0].mainTexture = this.MaleUniformTextures[maleUniform];
      this.SenpaiRenderer.materials[1].mainTexture = this.FaceTextures[skinColor];
      this.SenpaiRenderer.materials[2].mainTexture = this.SkinTextures[skinColor];
    } else if (maleUniform == 4) {
      this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
      this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
      this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
    } else if (maleUniform == 5) {
      this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
      this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
      this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
    } else if (maleUniform == 6) {
      this.SenpaiRenderer.materials[0].mainTexture = this.FaceTextures[skinColor];
      this.SenpaiRenderer.materials[1].mainTexture = this.SkinTextures[skinColor];
      this.SenpaiRenderer.materials[2].mainTexture = this.MaleUniformTextures[maleUniform];
    }
    this.MaleUniformLabel.text = "Male Uniform " + maleUniform.ToString();
  }

  // Token: 0x060001E4 RID: 484 RVA: 0x0002579C File Offset: 0x00023B9C
  private void UpdateFemaleUniform(int femaleUniform) {
    this.YandereRenderer.sharedMesh = this.FemaleUniforms[femaleUniform];
    this.YandereRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
    this.YandereRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
    this.YandereRenderer.materials[2].mainTexture = this.FemaleFace;
    this.YandereRenderer.materials[3].mainTexture = this.FemaleFace;
    this.FemaleUniformLabel.text = "Female Uniform " + femaleUniform.ToString();
  }

  // Token: 0x060001E5 RID: 485 RVA: 0x00025844 File Offset: 0x00023C44
  private void LoveSickColorSwap() {
    GameObject[] array = UnityEngine.Object.FindObjectsOfType<GameObject>();
    foreach (GameObject gameObject in array) {
      UISprite component = gameObject.GetComponent<UISprite>();
      if (component != null && component.color != Color.black && component.transform.parent != this.Highlight && component.transform.parent != this.UniformHighlight) {
        component.color = new Color(1f, 0f, 0f, component.color.a);
      }
      UITexture component2 = gameObject.GetComponent<UITexture>();
      if (component2 != null) {
        component2.color = new Color(1f, 0f, 0f, component2.color.a);
      }
      UILabel component3 = gameObject.GetComponent<UILabel>();
      if (component3 != null && component3.color != Color.black) {
        component3.color = new Color(1f, 0f, 0f, component3.color.a);
      }
    }
  }

  // Token: 0x0400061A RID: 1562
  [SerializeField]
  private CustomizationScript.CustomizationData Data;

  // Token: 0x0400061B RID: 1563
  [SerializeField]
  private InputManagerScript InputManager;

  // Token: 0x0400061C RID: 1564
  [SerializeField]
  private Renderer FacialHairRenderer;

  // Token: 0x0400061D RID: 1565
  [SerializeField]
  private SkinnedMeshRenderer YandereRenderer;

  // Token: 0x0400061E RID: 1566
  [SerializeField]
  private SkinnedMeshRenderer SenpaiRenderer;

  // Token: 0x0400061F RID: 1567
  [SerializeField]
  private Renderer HairRenderer;

  // Token: 0x04000620 RID: 1568
  [SerializeField]
  private AudioSource MyAudio;

  // Token: 0x04000621 RID: 1569
  [SerializeField]
  private Renderer EyeR;

  // Token: 0x04000622 RID: 1570
  [SerializeField]
  private Renderer EyeL;

  // Token: 0x04000623 RID: 1571
  [SerializeField]
  private Transform UniformHighlight;

  // Token: 0x04000624 RID: 1572
  [SerializeField]
  private Transform ApologyWindow;

  // Token: 0x04000625 RID: 1573
  [SerializeField]
  private Transform YandereHead;

  // Token: 0x04000626 RID: 1574
  [SerializeField]
  private Transform YandereNeck;

  // Token: 0x04000627 RID: 1575
  [SerializeField]
  private Transform SenpaiHead;

  // Token: 0x04000628 RID: 1576
  [SerializeField]
  private Transform Highlight;

  // Token: 0x04000629 RID: 1577
  [SerializeField]
  private Transform Yandere;

  // Token: 0x0400062A RID: 1578
  [SerializeField]
  private Transform Senpai;

  // Token: 0x0400062B RID: 1579
  [SerializeField]
  private Transform[] Corridor;

  // Token: 0x0400062C RID: 1580
  [SerializeField]
  private UIPanel CustomizePanel;

  // Token: 0x0400062D RID: 1581
  [SerializeField]
  private UIPanel UniformPanel;

  // Token: 0x0400062E RID: 1582
  [SerializeField]
  private UIPanel FinishPanel;

  // Token: 0x0400062F RID: 1583
  [SerializeField]
  private UIPanel GenderPanel;

  // Token: 0x04000630 RID: 1584
  [SerializeField]
  private UIPanel WhitePanel;

  // Token: 0x04000631 RID: 1585
  [SerializeField]
  private UILabel FacialHairStyleLabel;

  // Token: 0x04000632 RID: 1586
  [SerializeField]
  private UILabel FemaleUniformLabel;

  // Token: 0x04000633 RID: 1587
  [SerializeField]
  private UILabel MaleUniformLabel;

  // Token: 0x04000634 RID: 1588
  [SerializeField]
  private UILabel SkinColorLabel;

  // Token: 0x04000635 RID: 1589
  [SerializeField]
  private UILabel HairStyleLabel;

  // Token: 0x04000636 RID: 1590
  [SerializeField]
  private UILabel HairColorLabel;

  // Token: 0x04000637 RID: 1591
  [SerializeField]
  private UILabel EyeColorLabel;

  // Token: 0x04000638 RID: 1592
  [SerializeField]
  private UILabel EyeWearLabel;

  // Token: 0x04000639 RID: 1593
  [SerializeField]
  private GameObject LoveSickCamera;

  // Token: 0x0400063A RID: 1594
  [SerializeField]
  private GameObject CensorCloud;

  // Token: 0x0400063B RID: 1595
  [SerializeField]
  private GameObject BigCloud;

  // Token: 0x0400063C RID: 1596
  [SerializeField]
  private GameObject Hearts;

  // Token: 0x0400063D RID: 1597
  [SerializeField]
  private GameObject Cloud;

  // Token: 0x0400063E RID: 1598
  [SerializeField]
  private UISprite Black;

  // Token: 0x0400063F RID: 1599
  [SerializeField]
  private UISprite White;

  // Token: 0x04000640 RID: 1600
  [SerializeField]
  private bool Apologize;

  // Token: 0x04000641 RID: 1601
  [SerializeField]
  private bool LoveSick;

  // Token: 0x04000642 RID: 1602
  [SerializeField]
  private bool FadeOut;

  // Token: 0x04000643 RID: 1603
  [SerializeField]
  private float ScrollSpeed;

  // Token: 0x04000644 RID: 1604
  [SerializeField]
  private float Timer;

  // Token: 0x04000645 RID: 1605
  [SerializeField]
  private int Selected = 1;

  // Token: 0x04000646 RID: 1606
  [SerializeField]
  private int Phase = 1;

  // Token: 0x04000647 RID: 1607
  [SerializeField]
  private Texture[] FemaleUniformTextures;

  // Token: 0x04000648 RID: 1608
  [SerializeField]
  private Texture[] MaleUniformTextures;

  // Token: 0x04000649 RID: 1609
  [SerializeField]
  private Texture[] FaceTextures;

  // Token: 0x0400064A RID: 1610
  [SerializeField]
  private Texture[] SkinTextures;

  // Token: 0x0400064B RID: 1611
  [SerializeField]
  private GameObject[] FacialHairstyles;

  // Token: 0x0400064C RID: 1612
  [SerializeField]
  private GameObject[] Hairstyles;

  // Token: 0x0400064D RID: 1613
  [SerializeField]
  private GameObject[] Eyewears;

  // Token: 0x0400064E RID: 1614
  [SerializeField]
  private Mesh[] FemaleUniforms;

  // Token: 0x0400064F RID: 1615
  [SerializeField]
  private Mesh[] MaleUniforms;

  // Token: 0x04000650 RID: 1616
  [SerializeField]
  private Texture FemaleFace;

  // Token: 0x04000651 RID: 1617
  [SerializeField]
  private string HairColorName = string.Empty;

  // Token: 0x04000652 RID: 1618
  [SerializeField]
  private string EyeColorName = string.Empty;

  // Token: 0x04000653 RID: 1619
  [SerializeField]
  private AudioClip LoveSickIntro;

  // Token: 0x04000654 RID: 1620
  [SerializeField]
  private AudioClip LoveSickLoop;

  // Token: 0x04000655 RID: 1621
  private static readonly KeyValuePair<Color, string>[] ColorPairs = new KeyValuePair<Color, string>[]
  {
    new KeyValuePair<Color, string>(default(Color), string.Empty),
    new KeyValuePair<Color, string>(new Color(0.5f, 0.5f, 0.5f), "Black"),
    new KeyValuePair<Color, string>(new Color(1f, 0f, 0f), "Red"),
    new KeyValuePair<Color, string>(new Color(1f, 1f, 0f), "Yellow"),
    new KeyValuePair<Color, string>(new Color(0f, 1f, 0f), "Green"),
    new KeyValuePair<Color, string>(new Color(0f, 1f, 1f), "Cyan"),
    new KeyValuePair<Color, string>(new Color(0f, 0f, 1f), "Blue"),
    new KeyValuePair<Color, string>(new Color(1f, 0f, 1f), "Purple"),
    new KeyValuePair<Color, string>(new Color(1f, 0.5f, 0f), "Orange"),
    new KeyValuePair<Color, string>(new Color(0.5f, 0.25f, 0f), "Brown"),
    new KeyValuePair<Color, string>(new Color(1f, 1f, 1f), "White")
  };

  // Token: 0x0200007B RID: 123
  private class CustomizationData {

    // Token: 0x04000656 RID: 1622
    public global::RangeInt skinColor;

    // Token: 0x04000657 RID: 1623
    public global::RangeInt hairstyle;

    // Token: 0x04000658 RID: 1624
    public global::RangeInt hairColor;

    // Token: 0x04000659 RID: 1625
    public global::RangeInt eyeColor;

    // Token: 0x0400065A RID: 1626
    public global::RangeInt eyewear;

    // Token: 0x0400065B RID: 1627
    public global::RangeInt facialHair;

    // Token: 0x0400065C RID: 1628
    public global::RangeInt maleUniform;

    // Token: 0x0400065D RID: 1629
    public global::RangeInt femaleUniform;
  }
}