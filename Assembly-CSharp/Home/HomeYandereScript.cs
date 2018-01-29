using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000108 RID: 264
public class HomeYandereScript : MonoBehaviour {

  // Token: 0x06000526 RID: 1318 RVA: 0x00046E74 File Offset: 0x00045274
  private void Start() {
    if (this.CutsceneYandere != null) {
      this.CutsceneYandere.GetComponent<Animation>()["f02_texting_00"].speed = 0.1f;
    }
    if (SceneManager.GetActiveScene().name == "HomeScene") {
      if (!YanvaniaGlobals.DraculaDefeated) {
        base.transform.position = Vector3.zero;
        base.transform.eulerAngles = Vector3.zero;
        if (!HomeGlobals.Night) {
          this.ChangeSchoolwear();
          base.StartCoroutine(this.ApplyCustomCostume());
        } else {
          this.WearPajamas();
        }
      } else if (HomeGlobals.StartInBasement) {
        HomeGlobals.StartInBasement = false;
        base.transform.position = new Vector3(0f, -135f, 0f);
        base.transform.eulerAngles = Vector3.zero;
      } else {
        base.transform.position = new Vector3(1f, 0f, 0f);
        base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
        this.Character.GetComponent<Animation>().Play("f02_discScratch_00");
        this.Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
        this.Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
        this.HomeCamera.Destination = this.HomeCamera.Destinations[5];
        this.HomeCamera.Target = this.HomeCamera.Targets[5];
        this.Disc.SetActive(true);
        this.WearPajamas();
      }
    }
    Time.timeScale = 1f;
    this.UpdateHair();
  }

  // Token: 0x06000527 RID: 1319 RVA: 0x00047058 File Offset: 0x00045458
  private void Update() {
    if (!this.Disc.activeInHierarchy) {
      Animation component = this.Character.GetComponent<Animation>();
      if (this.CanMove) {
        this.MyController.Move(Physics.gravity * 0.01f);
        float axis = Input.GetAxis("Vertical");
        float axis2 = Input.GetAxis("Horizontal");
        Vector3 a = Camera.main.transform.TransformDirection(Vector3.forward);
        a.y = 0f;
        a = a.normalized;
        Vector3 a2 = new Vector3(a.z, 0f, -a.x);
        Vector3 vector = axis2 * a2 + axis * a;
        if (vector != Vector3.zero) {
          Quaternion b = Quaternion.LookRotation(vector);
          base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
        }
        if (axis != 0f || axis2 != 0f) {
          if (Input.GetButton("LB")) {
            component.CrossFade("f02_run_00");
            this.MyController.Move(base.transform.forward * this.RunSpeed * Time.deltaTime);
          } else {
            component.CrossFade("f02_newWalk_00");
            this.MyController.Move(base.transform.forward * this.WalkSpeed * Time.deltaTime);
          }
        } else {
          component.CrossFade("f02_idleShort_00");
        }
      } else {
        component.CrossFade("f02_idleShort_00");
      }
    } else if (this.HomeDarkness.color.a == 0f) {
      AudioSource component2 = base.GetComponent<AudioSource>();
      if (this.Timer == 0f) {
        component2.Play();
      } else if (this.Timer > component2.clip.length + 1f) {
        YanvaniaGlobals.DraculaDefeated = false;
        this.Disc.SetActive(false);
        this.HomeVideoGames.Quit();
      }
      this.Timer += Time.deltaTime;
    }
    Rigidbody component3 = base.GetComponent<Rigidbody>();
    if (component3 != null) {
      component3.velocity = Vector3.zero;
    }
    if (Input.GetKeyDown(KeyCode.H)) {
      this.UpdateHair();
    }
    if (Input.GetKeyDown(KeyCode.K)) {
      SchoolGlobals.KidnapVictim = this.VictimID;
      StudentGlobals.SetStudentSanity(this.VictimID, 100f);
      SchemeGlobals.SetSchemeStage(6, 5);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    if (Input.GetKeyDown(KeyCode.Y)) {
      YanvaniaGlobals.DraculaDefeated = true;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    if (Input.GetKeyDown(KeyCode.F1)) {
      StudentGlobals.MaleUniform = 1;
      StudentGlobals.FemaleUniform = 1;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } else if (Input.GetKeyDown(KeyCode.F2)) {
      StudentGlobals.MaleUniform = 2;
      StudentGlobals.FemaleUniform = 2;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } else if (Input.GetKeyDown(KeyCode.F3)) {
      StudentGlobals.MaleUniform = 3;
      StudentGlobals.FemaleUniform = 3;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } else if (Input.GetKeyDown(KeyCode.F4)) {
      StudentGlobals.MaleUniform = 4;
      StudentGlobals.FemaleUniform = 4;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } else if (Input.GetKeyDown(KeyCode.F5)) {
      StudentGlobals.MaleUniform = 5;
      StudentGlobals.FemaleUniform = 5;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } else if (Input.GetKeyDown(KeyCode.F6)) {
      StudentGlobals.MaleUniform = 6;
      StudentGlobals.FemaleUniform = 6;
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }

  // Token: 0x06000528 RID: 1320 RVA: 0x0004746C File Offset: 0x0004586C
  private void LateUpdate() {
    if (this.HidePony) {
      this.Ponytail.parent.transform.localScale = new Vector3(1f, 1f, 0.93f);
      this.Ponytail.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
      this.HairR.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
      this.HairL.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
    }
  }

  // Token: 0x06000529 RID: 1321 RVA: 0x0004750C File Offset: 0x0004590C
  private void UpdateHair() {
    this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3(1f, 0.75f, 1f);
    this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3(1f, 0.75f, 1f);
    this.PigtailR.gameObject.SetActive(false);
    this.PigtailL.gameObject.SetActive(false);
    this.Drills.gameObject.SetActive(false);
    this.HidePony = true;
    this.Hairstyle++;
    if (this.Hairstyle > 7) {
      this.Hairstyle = 1;
    }
    if (this.Hairstyle == 1) {
      this.HidePony = false;
      this.Ponytail.localScale = new Vector3(1f, 1f, 1f);
      this.HairR.localScale = new Vector3(1f, 1f, 1f);
      this.HairL.localScale = new Vector3(1f, 1f, 1f);
    } else if (this.Hairstyle == 2) {
      this.PigtailR.gameObject.SetActive(true);
    } else if (this.Hairstyle == 3) {
      this.PigtailL.gameObject.SetActive(true);
    } else if (this.Hairstyle == 4) {
      this.PigtailR.gameObject.SetActive(true);
      this.PigtailL.gameObject.SetActive(true);
    } else if (this.Hairstyle == 5) {
      this.PigtailR.gameObject.SetActive(true);
      this.PigtailL.gameObject.SetActive(true);
      this.HidePony = false;
      this.Ponytail.localScale = new Vector3(1f, 1f, 1f);
      this.HairR.localScale = new Vector3(1f, 1f, 1f);
      this.HairL.localScale = new Vector3(1f, 1f, 1f);
    } else if (this.Hairstyle == 6) {
      this.PigtailR.gameObject.SetActive(true);
      this.PigtailL.gameObject.SetActive(true);
      this.PigtailR.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
      this.PigtailL.transform.parent.transform.parent.transform.localScale = new Vector3(2f, 2f, 2f);
    } else if (this.Hairstyle == 7) {
      this.Drills.gameObject.SetActive(true);
    }
  }

  // Token: 0x0600052A RID: 1322 RVA: 0x00047828 File Offset: 0x00045C28
  private void ChangeSchoolwear() {
    this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[0].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[1].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    base.StartCoroutine(this.ApplyCustomCostume());
  }

  // Token: 0x0600052B RID: 1323 RVA: 0x000478B0 File Offset: 0x00045CB0
  private void WearPajamas() {
    this.MyRenderer.sharedMesh = this.PajamaMesh;
    this.MyRenderer.materials[0].mainTexture = this.PajamaTexture;
    this.MyRenderer.materials[1].mainTexture = this.PajamaTexture;
    this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
    base.StartCoroutine(this.ApplyCustomFace());
  }

  // Token: 0x0600052C RID: 1324 RVA: 0x00047924 File Offset: 0x00045D24
  private IEnumerator ApplyCustomCostume() {
    if (StudentGlobals.FemaleUniform == 1) {
      WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
      yield return CustomUniform;
      if (CustomUniform.error == null) {
        this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
        this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
      }
    } else if (StudentGlobals.FemaleUniform == 2) {
      WWW CustomLong = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
      yield return CustomLong;
      if (CustomLong.error == null) {
        this.MyRenderer.materials[0].mainTexture = CustomLong.texture;
        this.MyRenderer.materials[1].mainTexture = CustomLong.texture;
      }
    } else if (StudentGlobals.FemaleUniform == 3) {
      WWW CustomSweater = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
      yield return CustomSweater;
      if (CustomSweater.error == null) {
        this.MyRenderer.materials[0].mainTexture = CustomSweater.texture;
        this.MyRenderer.materials[1].mainTexture = CustomSweater.texture;
      }
    } else if (StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5) {
      WWW CustomBlazer = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
      yield return CustomBlazer;
      if (CustomBlazer.error == null) {
        this.MyRenderer.materials[0].mainTexture = CustomBlazer.texture;
        this.MyRenderer.materials[1].mainTexture = CustomBlazer.texture;
      }
    }
    base.StartCoroutine(this.ApplyCustomFace());
    yield break;
  }

  // Token: 0x0600052D RID: 1325 RVA: 0x00047940 File Offset: 0x00045D40
  private IEnumerator ApplyCustomFace() {
    WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
    yield return CustomFace;
    if (CustomFace.error == null) {
      this.MyRenderer.materials[2].mainTexture = CustomFace.texture;
      this.FaceTexture = CustomFace.texture;
    }
    WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
    yield return CustomHair;
    if (CustomHair.error == null) {
      this.PonytailRenderer.material.mainTexture = CustomHair.texture;
      this.PigtailR.material.mainTexture = CustomHair.texture;
      this.PigtailL.material.mainTexture = CustomHair.texture;
    }
    WWW CustomDrills = new WWW("file:///" + Application.streamingAssetsPath + "/CustomDrills.png");
    yield return CustomDrills;
    if (CustomDrills.error == null) {
      this.Drills.materials[0].mainTexture = CustomDrills.texture;
      this.Drills.materials[1].mainTexture = CustomDrills.texture;
      this.Drills.materials[2].mainTexture = CustomDrills.texture;
    }
    yield break;
  }

  // Token: 0x04000C24 RID: 3108
  public CharacterController MyController;

  // Token: 0x04000C25 RID: 3109
  public HomeVideoGamesScript HomeVideoGames;

  // Token: 0x04000C26 RID: 3110
  public HomeCameraScript HomeCamera;

  // Token: 0x04000C27 RID: 3111
  public UISprite HomeDarkness;

  // Token: 0x04000C28 RID: 3112
  public GameObject CutsceneYandere;

  // Token: 0x04000C29 RID: 3113
  public GameObject Controller;

  // Token: 0x04000C2A RID: 3114
  public GameObject Character;

  // Token: 0x04000C2B RID: 3115
  public GameObject Disc;

  // Token: 0x04000C2C RID: 3116
  public float WalkSpeed;

  // Token: 0x04000C2D RID: 3117
  public float RunSpeed;

  // Token: 0x04000C2E RID: 3118
  public bool CanMove;

  // Token: 0x04000C2F RID: 3119
  public AudioClip DiscScratch;

  // Token: 0x04000C30 RID: 3120
  public Renderer PonytailRenderer;

  // Token: 0x04000C31 RID: 3121
  public Renderer PigtailR;

  // Token: 0x04000C32 RID: 3122
  public Renderer PigtailL;

  // Token: 0x04000C33 RID: 3123
  public Renderer Drills;

  // Token: 0x04000C34 RID: 3124
  public Transform Ponytail;

  // Token: 0x04000C35 RID: 3125
  public Transform HairR;

  // Token: 0x04000C36 RID: 3126
  public Transform HairL;

  // Token: 0x04000C37 RID: 3127
  public bool HidePony;

  // Token: 0x04000C38 RID: 3128
  public int Hairstyle;

  // Token: 0x04000C39 RID: 3129
  public int VictimID;

  // Token: 0x04000C3A RID: 3130
  public float Timer;

  // Token: 0x04000C3B RID: 3131
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x04000C3C RID: 3132
  public Texture[] UniformTextures;

  // Token: 0x04000C3D RID: 3133
  public Texture FaceTexture;

  // Token: 0x04000C3E RID: 3134
  public Mesh[] Uniforms;

  // Token: 0x04000C3F RID: 3135
  public Texture PajamaTexture;

  // Token: 0x04000C40 RID: 3136
  public Mesh PajamaMesh;
}