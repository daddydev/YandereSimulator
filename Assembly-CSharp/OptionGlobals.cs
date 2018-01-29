using UnityEngine;

// Token: 0x020000DC RID: 220
public static class OptionGlobals {

  // Token: 0x1700007E RID: 126
  // (get) Token: 0x060003BF RID: 959 RVA: 0x0003B468 File Offset: 0x00039868
  // (set) Token: 0x060003C0 RID: 960 RVA: 0x0003B474 File Offset: 0x00039874
  public static bool DisableBloom {
    get {
      return GlobalsHelper.GetBool("DisableBloom");
    }
    set {
      GlobalsHelper.SetBool("DisableBloom", value);
    }
  }

  // Token: 0x1700007F RID: 127
  // (get) Token: 0x060003C1 RID: 961 RVA: 0x0003B481 File Offset: 0x00039881
  // (set) Token: 0x060003C2 RID: 962 RVA: 0x0003B48D File Offset: 0x0003988D
  public static bool DisableFarAnimations {
    get {
      return GlobalsHelper.GetBool("DisableFarAnimations");
    }
    set {
      GlobalsHelper.SetBool("DisableFarAnimations", value);
    }
  }

  // Token: 0x17000080 RID: 128
  // (get) Token: 0x060003C3 RID: 963 RVA: 0x0003B49A File Offset: 0x0003989A
  // (set) Token: 0x060003C4 RID: 964 RVA: 0x0003B4A6 File Offset: 0x000398A6
  public static bool DisableOutlines {
    get {
      return GlobalsHelper.GetBool("DisableOutlines");
    }
    set {
      GlobalsHelper.SetBool("DisableOutlines", value);
    }
  }

  // Token: 0x17000081 RID: 129
  // (get) Token: 0x060003C5 RID: 965 RVA: 0x0003B4B3 File Offset: 0x000398B3
  // (set) Token: 0x060003C6 RID: 966 RVA: 0x0003B4BF File Offset: 0x000398BF
  public static bool DisablePostAliasing {
    get {
      return GlobalsHelper.GetBool("DisablePostAliasing");
    }
    set {
      GlobalsHelper.SetBool("DisablePostAliasing", value);
    }
  }

  // Token: 0x17000082 RID: 130
  // (get) Token: 0x060003C7 RID: 967 RVA: 0x0003B4CC File Offset: 0x000398CC
  // (set) Token: 0x060003C8 RID: 968 RVA: 0x0003B4D8 File Offset: 0x000398D8
  public static bool DisableShadows {
    get {
      return GlobalsHelper.GetBool("DisableShadows");
    }
    set {
      GlobalsHelper.SetBool("DisableShadows", value);
    }
  }

  // Token: 0x17000083 RID: 131
  // (get) Token: 0x060003C9 RID: 969 RVA: 0x0003B4E5 File Offset: 0x000398E5
  // (set) Token: 0x060003CA RID: 970 RVA: 0x0003B4F1 File Offset: 0x000398F1
  public static int DrawDistance {
    get {
      return PlayerPrefs.GetInt("DrawDistance");
    }
    set {
      PlayerPrefs.SetInt("DrawDistance", value);
    }
  }

  // Token: 0x17000084 RID: 132
  // (get) Token: 0x060003CB RID: 971 RVA: 0x0003B4FE File Offset: 0x000398FE
  // (set) Token: 0x060003CC RID: 972 RVA: 0x0003B50A File Offset: 0x0003990A
  public static int DrawDistanceLimit {
    get {
      return PlayerPrefs.GetInt("DrawDistanceLimit");
    }
    set {
      PlayerPrefs.SetInt("DrawDistanceLimit", value);
    }
  }

  // Token: 0x17000085 RID: 133
  // (get) Token: 0x060003CD RID: 973 RVA: 0x0003B517 File Offset: 0x00039917
  // (set) Token: 0x060003CE RID: 974 RVA: 0x0003B523 File Offset: 0x00039923
  public static bool Fog {
    get {
      return GlobalsHelper.GetBool("Fog");
    }
    set {
      GlobalsHelper.SetBool("Fog", value);
    }
  }

  // Token: 0x17000086 RID: 134
  // (get) Token: 0x060003CF RID: 975 RVA: 0x0003B530 File Offset: 0x00039930
  // (set) Token: 0x060003D0 RID: 976 RVA: 0x0003B53C File Offset: 0x0003993C
  public static int FPSIndex {
    get {
      return PlayerPrefs.GetInt("FPSIndex");
    }
    set {
      PlayerPrefs.SetInt("FPSIndex", value);
    }
  }

  // Token: 0x17000087 RID: 135
  // (get) Token: 0x060003D1 RID: 977 RVA: 0x0003B549 File Offset: 0x00039949
  // (set) Token: 0x060003D2 RID: 978 RVA: 0x0003B555 File Offset: 0x00039955
  public static bool HighPopulation {
    get {
      return GlobalsHelper.GetBool("HighPopulation");
    }
    set {
      GlobalsHelper.SetBool("HighPopulation", value);
    }
  }

  // Token: 0x17000088 RID: 136
  // (get) Token: 0x060003D3 RID: 979 RVA: 0x0003B562 File Offset: 0x00039962
  // (set) Token: 0x060003D4 RID: 980 RVA: 0x0003B56E File Offset: 0x0003996E
  public static int LowDetailStudents {
    get {
      return PlayerPrefs.GetInt("LowDetailStudents");
    }
    set {
      PlayerPrefs.SetInt("LowDetailStudents", value);
    }
  }

  // Token: 0x17000089 RID: 137
  // (get) Token: 0x060003D5 RID: 981 RVA: 0x0003B57B File Offset: 0x0003997B
  // (set) Token: 0x060003D6 RID: 982 RVA: 0x0003B587 File Offset: 0x00039987
  public static int ParticleCount {
    get {
      return PlayerPrefs.GetInt("ParticleCount");
    }
    set {
      PlayerPrefs.SetInt("ParticleCount", value);
    }
  }

  // Token: 0x060003D7 RID: 983 RVA: 0x0003B594 File Offset: 0x00039994
  public static void DeleteAll() {
    Globals.Delete("DisableBloom");
    Globals.Delete("DisableFarAnimations");
    Globals.Delete("DisableOutlines");
    Globals.Delete("DisablePostAliasing");
    Globals.Delete("DisableShadows");
    Globals.Delete("DrawDistance");
    Globals.Delete("DrawDistanceLimit");
    Globals.Delete("Fog");
    Globals.Delete("FPSIndex");
    Globals.Delete("HighPopulation");
    Globals.Delete("LowDetailStudents");
    Globals.Delete("ParticleCount");
  }

  // Token: 0x040009EA RID: 2538
  private const string Str_DisableBloom = "DisableBloom";

  // Token: 0x040009EB RID: 2539
  private const string Str_DisableFarAnimations = "DisableFarAnimations";

  // Token: 0x040009EC RID: 2540
  private const string Str_DisableOutlines = "DisableOutlines";

  // Token: 0x040009ED RID: 2541
  private const string Str_DisablePostAliasing = "DisablePostAliasing";

  // Token: 0x040009EE RID: 2542
  private const string Str_DisableShadows = "DisableShadows";

  // Token: 0x040009EF RID: 2543
  private const string Str_DrawDistance = "DrawDistance";

  // Token: 0x040009F0 RID: 2544
  private const string Str_DrawDistanceLimit = "DrawDistanceLimit";

  // Token: 0x040009F1 RID: 2545
  private const string Str_Fog = "Fog";

  // Token: 0x040009F2 RID: 2546
  private const string Str_FPSIndex = "FPSIndex";

  // Token: 0x040009F3 RID: 2547
  private const string Str_HighPopulation = "HighPopulation";

  // Token: 0x040009F4 RID: 2548
  private const string Str_LowDetailStudents = "LowDetailStudents";

  // Token: 0x040009F5 RID: 2549
  private const string Str_ParticleCount = "ParticleCount";
}