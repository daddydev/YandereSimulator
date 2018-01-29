using UnityEngine;

// Token: 0x02000037 RID: 55
public class ArmDetectorScript : MonoBehaviour {

  // Token: 0x060000C6 RID: 198 RVA: 0x0000D11B File Offset: 0x0000B51B
  private void Start() {
    this.DemonDress.SetActive(false);
  }

  // Token: 0x060000C7 RID: 199 RVA: 0x0000D12C File Offset: 0x0000B52C
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (!this.SummonDemon) {
      for (int i = 1; i < this.ArmArray.Length; i++) {
        if (this.ArmArray[i] != null && this.ArmArray[i].transform.parent != null) {
          this.ArmArray[i] = null;
          if (i != this.ArmArray.Length - 1) {
            this.Shuffle(i);
          }
          this.Arms--;
        }
      }
      if (this.Arms > 9) {
        this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
        this.Yandere.CanMove = false;
        this.SummonDemon = true;
        component.Play();
        this.Arms = 0;
      }
    }
    if (!this.SummonFlameDemon) {
      this.CorpsesCounted = 0;
      this.Sacrifices = 0;
      int num = 0;
      while (this.CorpsesCounted < this.Police.Corpses) {
        RagdollScript ragdollScript = this.Police.CorpseList[num];
        if (ragdollScript != null) {
          this.CorpsesCounted++;
          if (ragdollScript.Burned && ragdollScript.Sacrifice && !ragdollScript.Dragged && !ragdollScript.Carried) {
            this.Sacrifices++;
          }
        }
        num++;
      }
      if (this.Sacrifices > 4) {
        this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
        this.Yandere.CanMove = false;
        this.SummonFlameDemon = true;
        component.Play();
      }
    }
    if (this.SummonDemon) {
      if (this.Phase == 1) {
        if (this.ArmArray[1] != null) {
          for (int j = 1; j < 11; j++) {
            if (this.ArmArray[j] != null) {
              UnityEngine.Object.Instantiate<GameObject>(this.SmallDarkAura, this.ArmArray[j].transform.position, Quaternion.identity);
              UnityEngine.Object.Destroy(this.ArmArray[j]);
            }
          }
        }
        this.Timer += Time.deltaTime;
        if (this.Timer > 1f) {
          this.Timer = 0f;
          this.Phase++;
        }
      } else if (this.Phase == 2) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
        if (this.Darkness.color.a == 1f) {
          SchoolGlobals.SchoolAtmosphere = 0f;
          this.StudentManager.SetAtmosphere();
          this.Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
          this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
          this.DemonSubtitle.text = "...revenge...at last...";
          this.BloodProjector.SetActive(true);
          this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0f);
          this.Skull.Prompt.Hide();
          this.Skull.Prompt.enabled = false;
          this.Skull.enabled = false;
          component.clip = this.DemonLine;
          component.Play();
          this.Phase++;
        }
      } else if (this.Phase == 3) {
        this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
        if (this.DemonSubtitle.color.a == 1f && Input.GetButtonDown("A")) {
          this.Phase++;
        }
      } else if (this.Phase == 4) {
        this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
        if (this.DemonSubtitle.color.a == 0f) {
          component.clip = this.DemonMusic;
          component.loop = true;
          component.Play();
          this.DemonSubtitle.text = string.Empty;
          this.Phase++;
        }
      } else if (this.Phase == 5) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
        if (this.Darkness.color.a == 0f) {
          this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_demonSummon_00");
          this.Phase++;
        }
      } else if (this.Phase == 6) {
        this.Timer += Time.deltaTime;
        if (this.Timer > (float)this.ArmsSpawned) {
          GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.DemonArm, this.SpawnPoints[this.ArmsSpawned].position, Quaternion.identity);
          gameObject.transform.parent = this.Yandere.transform;
          gameObject.transform.LookAt(this.Yandere.transform);
          gameObject.transform.localEulerAngles = new Vector3(gameObject.transform.localEulerAngles.x, gameObject.transform.localEulerAngles.y + 180f, gameObject.transform.localEulerAngles.z);
          this.ArmsSpawned++;
          gameObject.GetComponent<DemonArmScript>().IdleAnim = ((this.ArmsSpawned % 2 != 1) ? "DemonArmIdle" : "DemonArmIdleOld");
        }
        if (this.ArmsSpawned == 10) {
          this.Yandere.CanMove = true;
          this.Yandere.IdleAnim = "f02_demonIdle_00";
          this.Yandere.WalkAnim = "f02_demonWalk_00";
          this.Yandere.RunAnim = "f02_demonRun_00";
          this.Yandere.Demonic = true;
          this.SummonDemon = false;
        }
      }
    }
    if (this.SummonFlameDemon) {
      if (this.Phase == 1) {
        foreach (RagdollScript ragdollScript2 in this.Police.CorpseList) {
          if (ragdollScript2 != null && ragdollScript2.Burned && ragdollScript2.Sacrifice && !ragdollScript2.Dragged && !ragdollScript2.Carried) {
            UnityEngine.Object.Instantiate<GameObject>(this.SmallDarkAura, ragdollScript2.Prompt.transform.position, Quaternion.identity);
            UnityEngine.Object.Destroy(ragdollScript2.gameObject);
            this.Yandere.NearBodies--;
            this.Police.Corpses--;
          }
        }
        this.Phase++;
      } else if (this.Phase == 2) {
        this.Timer += Time.deltaTime;
        if (this.Timer > 1f) {
          this.Timer = 0f;
          this.Phase++;
        }
      } else if (this.Phase == 3) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0f, Time.deltaTime);
        if (this.Darkness.color.a == 1f) {
          this.Yandere.transform.eulerAngles = new Vector3(0f, 180f, 0f);
          this.Yandere.transform.position = new Vector3(12f, 0.1f, 26f);
          this.DemonSubtitle.text = "You have proven your worth. Very well. I shall lend you my power.";
          this.DemonSubtitle.color = new Color(1f, 0f, 0f, 0f);
          this.Skull.Prompt.Hide();
          this.Skull.Prompt.enabled = false;
          this.Skull.enabled = false;
          component.clip = this.FlameDemonLine;
          component.Play();
          this.Phase++;
        }
      } else if (this.Phase == 4) {
        this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
        if (this.DemonSubtitle.color.a == 1f && Input.GetButtonDown("A")) {
          this.Phase++;
        }
      } else if (this.Phase == 5) {
        this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
        this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
        if (this.DemonSubtitle.color.a == 0f) {
          this.DemonDress.SetActive(true);
          this.Yandere.MyRenderer.sharedMesh = this.FlameDemonMesh;
          this.RiggedAccessory.SetActive(true);
          this.Yandere.FlameDemonic = true;
          this.Yandere.Stance.Current = StanceType.Standing;
          this.Yandere.Sanity = 100f;
          this.Yandere.MyRenderer.materials[0].mainTexture = this.Yandere.FaceTexture;
          this.Yandere.MyRenderer.materials[1].mainTexture = this.Yandere.NudePanties;
          this.Yandere.MyRenderer.materials[2].mainTexture = this.Yandere.NudePanties;
          this.DebugMenu.UpdateCensor();
          component.clip = this.DemonMusic;
          component.loop = true;
          component.Play();
          this.DemonSubtitle.text = string.Empty;
          this.Phase++;
        }
      } else if (this.Phase == 6) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
        if (this.Darkness.color.a == 0f) {
          this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_demonSummon_00");
          this.Phase++;
        }
      } else if (this.Phase == 7) {
        this.Timer += Time.deltaTime;
        if (this.Timer > 5f) {
          component.PlayOneShot(this.FlameActivate);
          this.RightFlame.SetActive(true);
          this.LeftFlame.SetActive(true);
          this.Phase++;
        }
      } else if (this.Phase == 8) {
        this.Timer += Time.deltaTime;
        if (this.Timer > 10f) {
          this.Yandere.CanMove = true;
          this.Yandere.IdleAnim = "f02_demonIdle_00";
          this.Yandere.WalkAnim = "f02_demonWalk_00";
          this.Yandere.RunAnim = "f02_demonRun_00";
          this.SummonFlameDemon = false;
        }
      }
    }
  }

  // Token: 0x060000C8 RID: 200 RVA: 0x0000E114 File Offset: 0x0000C514
  private void OnTriggerEnter(Collider other) {
    if (other.transform.parent == null) {
      PickUpScript component = other.gameObject.GetComponent<PickUpScript>();
      if (component != null) {
        BodyPartScript bodyPart = component.BodyPart;
        if (bodyPart.Sacrifice && (bodyPart.Type == 3 || bodyPart.Type == 4)) {
          bool flag = true;
          for (int i = 1; i < 11; i++) {
            if (this.ArmArray[i] == other.gameObject) {
              flag = false;
            }
          }
          if (flag) {
            this.Arms++;
            if (this.Arms < this.ArmArray.Length) {
              this.ArmArray[this.Arms] = other.gameObject;
            }
          }
        }
      }
    }
  }

  // Token: 0x060000C9 RID: 201 RVA: 0x0000E1E4 File Offset: 0x0000C5E4
  private void OnTriggerExit(Collider other) {
    PickUpScript component = other.gameObject.GetComponent<PickUpScript>();
    if (component != null && component.BodyPart) {
      BodyPartScript component2 = other.gameObject.GetComponent<BodyPartScript>();
      if (component2.Sacrifice && (other.gameObject.name == "FemaleRightArm(Clone)" || other.gameObject.name == "FemaleLeftArm(Clone)" || other.gameObject.name == "MaleRightArm(Clone)" || other.gameObject.name == "MaleLeftArm(Clone)" || other.gameObject.name == "SacrificialArm(Clone)")) {
        this.Arms--;
      }
    }
  }

  // Token: 0x060000CA RID: 202 RVA: 0x0000E2C0 File Offset: 0x0000C6C0
  private void Shuffle(int Start) {
    for (int i = Start; i < this.ArmArray.Length - 1; i++) {
      this.ArmArray[i] = this.ArmArray[i + 1];
    }
  }

  // Token: 0x040002DA RID: 730
  public StudentManagerScript StudentManager;

  // Token: 0x040002DB RID: 731
  public DebugMenuScript DebugMenu;

  // Token: 0x040002DC RID: 732
  public JukeboxScript Jukebox;

  // Token: 0x040002DD RID: 733
  public YandereScript Yandere;

  // Token: 0x040002DE RID: 734
  public PoliceScript Police;

  // Token: 0x040002DF RID: 735
  public SkullScript Skull;

  // Token: 0x040002E0 RID: 736
  public UILabel DemonSubtitle;

  // Token: 0x040002E1 RID: 737
  public UISprite Darkness;

  // Token: 0x040002E2 RID: 738
  public Transform[] SpawnPoints;

  // Token: 0x040002E3 RID: 739
  public GameObject[] ArmArray;

  // Token: 0x040002E4 RID: 740
  public GameObject RiggedAccessory;

  // Token: 0x040002E5 RID: 741
  public GameObject BloodProjector;

  // Token: 0x040002E6 RID: 742
  public GameObject SmallDarkAura;

  // Token: 0x040002E7 RID: 743
  public GameObject DemonDress;

  // Token: 0x040002E8 RID: 744
  public GameObject RightFlame;

  // Token: 0x040002E9 RID: 745
  public GameObject LeftFlame;

  // Token: 0x040002EA RID: 746
  public GameObject DemonArm;

  // Token: 0x040002EB RID: 747
  public bool SummonFlameDemon;

  // Token: 0x040002EC RID: 748
  public bool SummonDemon;

  // Token: 0x040002ED RID: 749
  public Mesh FlameDemonMesh;

  // Token: 0x040002EE RID: 750
  public int CorpsesCounted;

  // Token: 0x040002EF RID: 751
  public int ArmsSpawned;

  // Token: 0x040002F0 RID: 752
  public int Sacrifices;

  // Token: 0x040002F1 RID: 753
  public int Phase = 1;

  // Token: 0x040002F2 RID: 754
  public int Arms;

  // Token: 0x040002F3 RID: 755
  public float Timer;

  // Token: 0x040002F4 RID: 756
  public AudioClip FlameDemonLine;

  // Token: 0x040002F5 RID: 757
  public AudioClip FlameActivate;

  // Token: 0x040002F6 RID: 758
  public AudioClip DemonMusic;

  // Token: 0x040002F7 RID: 759
  public AudioClip DemonLine;
}