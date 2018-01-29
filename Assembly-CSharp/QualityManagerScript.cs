using UnityEngine;

// Token: 0x0200016C RID: 364
public class QualityManagerScript : MonoBehaviour {

  // Token: 0x060006BB RID: 1723 RVA: 0x00066798 File Offset: 0x00064B98
  private void Start() {
    DepthOfField34[] components = Camera.main.GetComponents<DepthOfField34>();
    this.ExperimentalDepthOfField34 = components[1];
    this.ToggleExperiment();
    if (OptionGlobals.ParticleCount == 0) {
      OptionGlobals.ParticleCount = 3;
    }
    if (OptionGlobals.DrawDistance == 0) {
      OptionGlobals.DrawDistanceLimit = 350;
      OptionGlobals.DrawDistance = 350;
    }
    this.UpdateFog();
    this.UpdateAnims();
    this.UpdateBloom();
    this.UpdateFPSIndex();
    this.UpdateShadows();
    this.UpdateParticles();
    this.UpdatePostAliasing();
    this.UpdateDrawDistance();
    this.UpdateLowDetailStudents();
  }

  // Token: 0x060006BC RID: 1724 RVA: 0x00066824 File Offset: 0x00064C24
  public void UpdateParticles() {
    if (OptionGlobals.ParticleCount == 4) {
      OptionGlobals.ParticleCount = 1;
    } else if (OptionGlobals.ParticleCount == 0) {
      OptionGlobals.ParticleCount = 3;
    }
    ParticleSystem.EmissionModule emission = this.EastRomanceBlossoms.emission;
    ParticleSystem.EmissionModule emission2 = this.WestRomanceBlossoms.emission;
    ParticleSystem.EmissionModule emission3 = this.CorridorBlossoms.emission;
    ParticleSystem.EmissionModule emission4 = this.PlazaBlossoms.emission;
    ParticleSystem.EmissionModule emission5 = this.MythBlossoms.emission;
    ParticleSystem.EmissionModule emission6 = this.Steam.emission;
    ParticleSystem.EmissionModule emission7 = this.Fountains[1].emission;
    ParticleSystem.EmissionModule emission8 = this.Fountains[2].emission;
    ParticleSystem.EmissionModule emission9 = this.Fountains[3].emission;
    emission.enabled = true;
    emission2.enabled = true;
    emission3.enabled = true;
    emission4.enabled = true;
    emission5.enabled = true;
    emission6.enabled = true;
    emission7.enabled = true;
    emission8.enabled = true;
    emission9.enabled = true;
    if (OptionGlobals.ParticleCount == 3) {
      emission.rateOverTime = 100f;
      emission2.rateOverTime = 100f;
      emission3.rateOverTime = 1000f;
      emission4.rateOverTime = 400f;
      emission5.rateOverTime = 100f;
      emission6.rateOverTime = 100f;
      emission7.rateOverTime = 100f;
      emission8.rateOverTime = 100f;
      emission9.rateOverTime = 100f;
    } else if (OptionGlobals.ParticleCount == 2) {
      emission.rateOverTime = 10f;
      emission2.rateOverTime = 10f;
      emission3.rateOverTime = 100f;
      emission4.rateOverTime = 40f;
      emission5.rateOverTime = 10f;
      emission6.rateOverTime = 10f;
      emission7.rateOverTime = 10f;
      emission8.rateOverTime = 10f;
      emission9.rateOverTime = 10f;
    } else if (OptionGlobals.ParticleCount == 1) {
      emission.enabled = false;
      emission2.enabled = false;
      emission3.enabled = false;
      emission4.enabled = false;
      emission5.enabled = false;
      emission6.enabled = false;
      emission7.enabled = false;
      emission8.enabled = false;
      emission9.enabled = false;
    }
  }

  // Token: 0x060006BD RID: 1725 RVA: 0x00066ABC File Offset: 0x00064EBC
  public void UpdateOutlines() {
    for (int i = 1; i < this.StudentManager.Students.Length; i++) {
      StudentScript studentScript = this.StudentManager.Students[i];
      if (studentScript != null && studentScript.gameObject.activeInHierarchy) {
        if (OptionGlobals.DisableOutlines) {
          this.NewHairShader = this.Toon;
          this.NewBodyShader = this.ToonOverlay;
        } else {
          this.NewHairShader = this.ToonOutline;
          this.NewBodyShader = this.ToonOutlineOverlay;
        }
        if (!studentScript.Male) {
          studentScript.MyRenderer.materials[0].shader = this.NewBodyShader;
          studentScript.MyRenderer.materials[1].shader = this.NewBodyShader;
          studentScript.MyRenderer.materials[2].shader = this.NewBodyShader;
          studentScript.Cosmetic.RightStockings[0].GetComponent<Renderer>().material.shader = this.NewBodyShader;
          studentScript.Cosmetic.LeftStockings[0].GetComponent<Renderer>().material.shader = this.NewBodyShader;
        } else {
          studentScript.MyRenderer.materials[0].shader = this.NewHairShader;
          studentScript.MyRenderer.materials[1].shader = this.NewHairShader;
          studentScript.MyRenderer.materials[2].shader = this.NewBodyShader;
        }
        if (!studentScript.Male) {
          if (!studentScript.Teacher) {
            if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null) {
              studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
            }
            if (studentScript.Cosmetic.Accessory > 0 && studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>() != null) {
              studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.NewHairShader;
            }
          } else {
            studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
            if (studentScript.Cosmetic.Accessory > 0) {
            }
          }
        } else {
          if (studentScript.Cosmetic.Hairstyle > 0) {
            studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.NewHairShader;
          }
          if (studentScript.Cosmetic.Accessory > 0) {
            Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
            if (component != null) {
              component.material.shader = this.NewHairShader;
            }
          }
        }
        if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.Club != ClubType.Council && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null) {
          Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
          if (component2 != null) {
            component2.material.shader = this.NewHairShader;
          }
        }
      }
    }
    this.Yandere.MyRenderer.materials[0].shader = this.NewBodyShader;
    this.Yandere.MyRenderer.materials[1].shader = this.NewBodyShader;
    this.Yandere.MyRenderer.materials[2].shader = this.NewBodyShader;
    for (int j = 1; j < this.Yandere.Hairstyles.Length; j++) {
      Renderer component3 = this.Yandere.Hairstyles[j].GetComponent<Renderer>();
      if (component3 != null) {
        this.YandereHairRenderer.material.shader = this.NewHairShader;
        component3.material.shader = this.NewHairShader;
      }
    }
    this.Nemesis.Cosmetic.MyRenderer.materials[0].shader = this.NewBodyShader;
    this.Nemesis.Cosmetic.MyRenderer.materials[1].shader = this.NewBodyShader;
    this.Nemesis.Cosmetic.MyRenderer.materials[2].shader = this.NewBodyShader;
    this.Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = this.NewHairShader;
  }

  // Token: 0x060006BE RID: 1726 RVA: 0x00066F8F File Offset: 0x0006538F
  public void UpdatePostAliasing() {
    this.PostAliasing.enabled = !OptionGlobals.DisablePostAliasing;
  }

  // Token: 0x060006BF RID: 1727 RVA: 0x00066FA4 File Offset: 0x000653A4
  public void UpdateBloom() {
    this.BloomEffect.enabled = !OptionGlobals.DisableBloom;
  }

  // Token: 0x060006C0 RID: 1728 RVA: 0x00066FB9 File Offset: 0x000653B9
  public void UpdateLowDetailStudents() {
    if (OptionGlobals.LowDetailStudents == 11) {
      OptionGlobals.LowDetailStudents = 0;
    } else if (OptionGlobals.LowDetailStudents == -1) {
      OptionGlobals.LowDetailStudents = 10;
    }
    this.StudentManager.LowDetailThreshold = OptionGlobals.LowDetailStudents * 10;
  }

  // Token: 0x060006C1 RID: 1729 RVA: 0x00066FF8 File Offset: 0x000653F8
  public void UpdateDrawDistance() {
    if (OptionGlobals.DrawDistance > OptionGlobals.DrawDistanceLimit) {
      OptionGlobals.DrawDistance = 10;
    } else if (OptionGlobals.DrawDistance == 0) {
      OptionGlobals.DrawDistance = OptionGlobals.DrawDistanceLimit;
    }
    Camera.main.farClipPlane = (float)OptionGlobals.DrawDistance;
    RenderSettings.fogEndDistance = (float)OptionGlobals.DrawDistance;
    this.Yandere.Smartphone.farClipPlane = (float)OptionGlobals.DrawDistance;
  }

  // Token: 0x060006C2 RID: 1730 RVA: 0x00067068 File Offset: 0x00065468
  public void UpdateFog() {
    if (!OptionGlobals.Fog) {
      this.Yandere.MainCamera.clearFlags = CameraClearFlags.Skybox;
      RenderSettings.fogMode = FogMode.Exponential;
    } else {
      this.Yandere.MainCamera.clearFlags = CameraClearFlags.Color;
      RenderSettings.fogMode = FogMode.Linear;
      RenderSettings.fogEndDistance = (float)OptionGlobals.DrawDistance;
    }
  }

  // Token: 0x060006C3 RID: 1731 RVA: 0x000670BD File Offset: 0x000654BD
  public void UpdateShadows() {
    this.Sun.shadows = ((!OptionGlobals.DisableShadows) ? LightShadows.Soft : LightShadows.None);
  }

  // Token: 0x060006C4 RID: 1732 RVA: 0x000670DB File Offset: 0x000654DB
  public void UpdateAnims() {
    this.StudentManager.DisableFarAnims = OptionGlobals.DisableFarAnimations;
  }

  // Token: 0x060006C5 RID: 1733 RVA: 0x000670F0 File Offset: 0x000654F0
  public void UpdateFPSIndex() {
    if (OptionGlobals.FPSIndex < 0) {
      OptionGlobals.FPSIndex = QualityManagerScript.FPSValues.Length - 1;
    } else if (OptionGlobals.FPSIndex >= QualityManagerScript.FPSValues.Length) {
      OptionGlobals.FPSIndex = 0;
    }
    Application.targetFrameRate = QualityManagerScript.FPSValues[OptionGlobals.FPSIndex];
  }

  // Token: 0x060006C6 RID: 1734 RVA: 0x00067144 File Offset: 0x00065544
  public void ToggleExperiment() {
    if (!this.ExperimentalSSAOEffect.enabled) {
      this.ExperimentalBloomAndLensFlares.enabled = true;
      this.ExperimentalDepthOfField34.enabled = true;
      this.ExperimentalSSAOEffect.enabled = true;
      this.BloomEffect.enabled = false;
    } else {
      this.ExperimentalBloomAndLensFlares.enabled = false;
      this.ExperimentalDepthOfField34.enabled = false;
      this.ExperimentalSSAOEffect.enabled = false;
    }
  }

  // Token: 0x060006C7 RID: 1735 RVA: 0x000671BC File Offset: 0x000655BC
  public void RimLight() {
    if (!this.RimLightActive) {
      this.RimLightActive = true;
      for (int i = 1; i < this.StudentManager.Students.Length; i++) {
        StudentScript studentScript = this.StudentManager.Students[i];
        if (studentScript != null && studentScript.gameObject.activeInHierarchy) {
          this.NewHairShader = this.ToonOutlineRimLight;
          this.NewBodyShader = this.ToonOutlineRimLight;
          studentScript.MyRenderer.materials[0].shader = this.ToonOutlineRimLight;
          studentScript.MyRenderer.materials[1].shader = this.ToonOutlineRimLight;
          studentScript.MyRenderer.materials[2].shader = this.ToonOutlineRimLight;
          this.AdjustRimLight(studentScript.MyRenderer.materials[0]);
          this.AdjustRimLight(studentScript.MyRenderer.materials[1]);
          this.AdjustRimLight(studentScript.MyRenderer.materials[2]);
          if (!studentScript.Male) {
            if (!studentScript.Teacher) {
              if (studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle] != null) {
                studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.ToonOutlineRimLight;
                this.AdjustRimLight(studentScript.Cosmetic.FemaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
              }
              if (studentScript.Cosmetic.Accessory > 0) {
                studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material.shader = this.ToonOutlineRimLight;
                this.AdjustRimLight(studentScript.Cosmetic.FemaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>().material);
              }
            } else {
              studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.ToonOutlineRimLight;
              this.AdjustRimLight(studentScript.Cosmetic.TeacherHairRenderers[studentScript.Cosmetic.Hairstyle].material);
            }
          } else {
            if (studentScript.Cosmetic.Hairstyle > 0) {
              studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material.shader = this.ToonOutlineRimLight;
              this.AdjustRimLight(studentScript.Cosmetic.MaleHairRenderers[studentScript.Cosmetic.Hairstyle].material);
            }
            if (studentScript.Cosmetic.Accessory > 0) {
              Renderer component = studentScript.Cosmetic.MaleAccessories[studentScript.Cosmetic.Accessory].GetComponent<Renderer>();
              if (component != null) {
                component.material.shader = this.ToonOutlineRimLight;
                this.AdjustRimLight(component.material);
              }
            }
          }
          if (!studentScript.Teacher && studentScript.Cosmetic.Club > ClubType.None && studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club] != null) {
            Renderer component2 = studentScript.Cosmetic.ClubAccessories[(int)studentScript.Cosmetic.Club].GetComponent<Renderer>();
            if (component2 != null) {
              component2.material.shader = this.ToonOutlineRimLight;
              this.AdjustRimLight(component2.material);
            }
          }
        }
      }
      this.Yandere.MyRenderer.materials[0].shader = this.ToonOutlineRimLight;
      this.Yandere.MyRenderer.materials[1].shader = this.ToonOutlineRimLight;
      this.Yandere.MyRenderer.materials[2].shader = this.ToonOutlineRimLight;
      this.AdjustRimLight(this.Yandere.MyRenderer.materials[0]);
      this.AdjustRimLight(this.Yandere.MyRenderer.materials[1]);
      this.AdjustRimLight(this.Yandere.MyRenderer.materials[2]);
      for (int j = 1; j < this.Yandere.Hairstyles.Length; j++) {
        Renderer component3 = this.Yandere.Hairstyles[j].GetComponent<Renderer>();
        if (component3 != null) {
          this.YandereHairRenderer.material.shader = this.ToonOutlineRimLight;
          component3.material.shader = this.ToonOutlineRimLight;
          this.AdjustRimLight(this.YandereHairRenderer.material);
          this.AdjustRimLight(component3.material);
        }
      }
      this.Nemesis.Cosmetic.MyRenderer.materials[0].shader = this.ToonOutlineRimLight;
      this.Nemesis.Cosmetic.MyRenderer.materials[1].shader = this.ToonOutlineRimLight;
      this.Nemesis.Cosmetic.MyRenderer.materials[2].shader = this.ToonOutlineRimLight;
      this.Nemesis.NemesisHair.GetComponent<Renderer>().material.shader = this.ToonOutlineRimLight;
      this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[0]);
      this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[1]);
      this.AdjustRimLight(this.Nemesis.Cosmetic.MyRenderer.materials[2]);
      this.AdjustRimLight(this.Nemesis.NemesisHair.GetComponent<Renderer>().material);
    } else {
      this.RimLightActive = false;
      this.UpdateOutlines();
    }
  }

  // Token: 0x060006C8 RID: 1736 RVA: 0x0006775C File Offset: 0x00065B5C
  public void AdjustRimLight(Material mat) {
    mat.SetFloat("_RimLightIntensity", 5f);
    mat.SetFloat("_RimCrisp", 0.5f);
    mat.SetFloat("_RimAdditive", 0.5f);
  }

  // Token: 0x040010CC RID: 4300
  public StudentManagerScript StudentManager;

  // Token: 0x040010CD RID: 4301
  public AntialiasingAsPostEffect PostAliasing;

  // Token: 0x040010CE RID: 4302
  public NemesisScript Nemesis;

  // Token: 0x040010CF RID: 4303
  public YandereScript Yandere;

  // Token: 0x040010D0 RID: 4304
  public Bloom BloomEffect;

  // Token: 0x040010D1 RID: 4305
  public Light Sun;

  // Token: 0x040010D2 RID: 4306
  public ParticleSystem EastRomanceBlossoms;

  // Token: 0x040010D3 RID: 4307
  public ParticleSystem WestRomanceBlossoms;

  // Token: 0x040010D4 RID: 4308
  public ParticleSystem CorridorBlossoms;

  // Token: 0x040010D5 RID: 4309
  public ParticleSystem PlazaBlossoms;

  // Token: 0x040010D6 RID: 4310
  public ParticleSystem MythBlossoms;

  // Token: 0x040010D7 RID: 4311
  public ParticleSystem Steam;

  // Token: 0x040010D8 RID: 4312
  public ParticleSystem[] Fountains;

  // Token: 0x040010D9 RID: 4313
  public Renderer YandereHairRenderer;

  // Token: 0x040010DA RID: 4314
  public Shader NewBodyShader;

  // Token: 0x040010DB RID: 4315
  public Shader NewHairShader;

  // Token: 0x040010DC RID: 4316
  public Shader Toon;

  // Token: 0x040010DD RID: 4317
  public Shader ToonOutline;

  // Token: 0x040010DE RID: 4318
  public Shader ToonOverlay;

  // Token: 0x040010DF RID: 4319
  public Shader ToonOutlineOverlay;

  // Token: 0x040010E0 RID: 4320
  public Shader ToonOutlineRimLight;

  // Token: 0x040010E1 RID: 4321
  public BloomAndLensFlares ExperimentalBloomAndLensFlares;

  // Token: 0x040010E2 RID: 4322
  public DepthOfField34 ExperimentalDepthOfField34;

  // Token: 0x040010E3 RID: 4323
  public SSAOEffect ExperimentalSSAOEffect;

  // Token: 0x040010E4 RID: 4324
  public bool RimLightActive;

  // Token: 0x040010E5 RID: 4325
  private static readonly int[] FPSValues = new int[]
  {
    int.MaxValue,
    30,
    60,
    120
  };

  // Token: 0x040010E6 RID: 4326
  public static readonly string[] FPSStrings = new string[]
  {
    "Unlimited",
    "30",
    "60",
    "120"
  };
}