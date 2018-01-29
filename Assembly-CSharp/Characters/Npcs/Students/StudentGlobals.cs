using UnityEngine;

// Token: 0x020000E3 RID: 227
public static class StudentGlobals {

  // Token: 0x170000AE RID: 174
  // (get) Token: 0x06000450 RID: 1104 RVA: 0x0003C153 File Offset: 0x0003A553
  // (set) Token: 0x06000451 RID: 1105 RVA: 0x0003C15F File Offset: 0x0003A55F
  public static bool CustomSuitor {
    get {
      return GlobalsHelper.GetBool("CustomSuitor");
    }
    set {
      GlobalsHelper.SetBool("CustomSuitor", value);
    }
  }

  // Token: 0x170000AF RID: 175
  // (get) Token: 0x06000452 RID: 1106 RVA: 0x0003C16C File Offset: 0x0003A56C
  // (set) Token: 0x06000453 RID: 1107 RVA: 0x0003C178 File Offset: 0x0003A578
  public static int CustomSuitorAccessory {
    get {
      return PlayerPrefs.GetInt("CustomSuitorAccessory");
    }
    set {
      PlayerPrefs.SetInt("CustomSuitorAccessory", value);
    }
  }

  // Token: 0x170000B0 RID: 176
  // (get) Token: 0x06000454 RID: 1108 RVA: 0x0003C185 File Offset: 0x0003A585
  // (set) Token: 0x06000455 RID: 1109 RVA: 0x0003C191 File Offset: 0x0003A591
  public static int CustomSuitorBlonde {
    get {
      return PlayerPrefs.GetInt("CustomSuitorBlonde");
    }
    set {
      PlayerPrefs.SetInt("CustomSuitorBlonde", value);
    }
  }

  // Token: 0x170000B1 RID: 177
  // (get) Token: 0x06000456 RID: 1110 RVA: 0x0003C19E File Offset: 0x0003A59E
  // (set) Token: 0x06000457 RID: 1111 RVA: 0x0003C1AA File Offset: 0x0003A5AA
  public static int CustomSuitorEyewear {
    get {
      return PlayerPrefs.GetInt("CustomSuitorEyewear");
    }
    set {
      PlayerPrefs.SetInt("CustomSuitorEyewear", value);
    }
  }

  // Token: 0x170000B2 RID: 178
  // (get) Token: 0x06000458 RID: 1112 RVA: 0x0003C1B7 File Offset: 0x0003A5B7
  // (set) Token: 0x06000459 RID: 1113 RVA: 0x0003C1C3 File Offset: 0x0003A5C3
  public static int CustomSuitorHair {
    get {
      return PlayerPrefs.GetInt("CustomSuitorHair");
    }
    set {
      PlayerPrefs.SetInt("CustomSuitorHair", value);
    }
  }

  // Token: 0x170000B3 RID: 179
  // (get) Token: 0x0600045A RID: 1114 RVA: 0x0003C1D0 File Offset: 0x0003A5D0
  // (set) Token: 0x0600045B RID: 1115 RVA: 0x0003C1DC File Offset: 0x0003A5DC
  public static int CustomSuitorJewelry {
    get {
      return PlayerPrefs.GetInt("CustomSuitorJewelry");
    }
    set {
      PlayerPrefs.SetInt("CustomSuitorJewelry", value);
    }
  }

  // Token: 0x170000B4 RID: 180
  // (get) Token: 0x0600045C RID: 1116 RVA: 0x0003C1E9 File Offset: 0x0003A5E9
  // (set) Token: 0x0600045D RID: 1117 RVA: 0x0003C1F5 File Offset: 0x0003A5F5
  public static bool CustomSuitorTan {
    get {
      return GlobalsHelper.GetBool("CustomSuitorTan");
    }
    set {
      GlobalsHelper.SetBool("CustomSuitorTan", value);
    }
  }

  // Token: 0x170000B5 RID: 181
  // (get) Token: 0x0600045E RID: 1118 RVA: 0x0003C202 File Offset: 0x0003A602
  // (set) Token: 0x0600045F RID: 1119 RVA: 0x0003C20E File Offset: 0x0003A60E
  public static int ExpelProgress {
    get {
      return PlayerPrefs.GetInt("ExpelProgress");
    }
    set {
      PlayerPrefs.SetInt("ExpelProgress", value);
    }
  }

  // Token: 0x170000B6 RID: 182
  // (get) Token: 0x06000460 RID: 1120 RVA: 0x0003C21B File Offset: 0x0003A61B
  // (set) Token: 0x06000461 RID: 1121 RVA: 0x0003C227 File Offset: 0x0003A627
  public static int FemaleUniform {
    get {
      return PlayerPrefs.GetInt("FemaleUniform");
    }
    set {
      PlayerPrefs.SetInt("FemaleUniform", value);
    }
  }

  // Token: 0x170000B7 RID: 183
  // (get) Token: 0x06000462 RID: 1122 RVA: 0x0003C234 File Offset: 0x0003A634
  // (set) Token: 0x06000463 RID: 1123 RVA: 0x0003C240 File Offset: 0x0003A640
  public static int MaleUniform {
    get {
      return PlayerPrefs.GetInt("MaleUniform");
    }
    set {
      PlayerPrefs.SetInt("MaleUniform", value);
    }
  }

  // Token: 0x06000464 RID: 1124 RVA: 0x0003C24D File Offset: 0x0003A64D
  public static string GetStudentAccessory(int studentID) {
    return PlayerPrefs.GetString("StudentAccessory_" + studentID.ToString());
  }

  // Token: 0x06000465 RID: 1125 RVA: 0x0003C26C File Offset: 0x0003A66C
  public static void SetStudentAccessory(int studentID, string value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentAccessory_", text);
    PlayerPrefs.SetString("StudentAccessory_" + text, value);
  }

  // Token: 0x06000466 RID: 1126 RVA: 0x0003C2A3 File Offset: 0x0003A6A3
  public static int[] KeysOfStudentAccessory() {
    return KeysHelper.GetIntegerKeys("StudentAccessory_");
  }

  // Token: 0x06000467 RID: 1127 RVA: 0x0003C2AF File Offset: 0x0003A6AF
  public static bool GetStudentArrested(int studentID) {
    return GlobalsHelper.GetBool("StudentArrested_" + studentID.ToString());
  }

  // Token: 0x06000468 RID: 1128 RVA: 0x0003C2D0 File Offset: 0x0003A6D0
  public static void SetStudentArrested(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentArrested_", text);
    GlobalsHelper.SetBool("StudentArrested_" + text, value);
  }

  // Token: 0x06000469 RID: 1129 RVA: 0x0003C307 File Offset: 0x0003A707
  public static int[] KeysOfStudentArrested() {
    return KeysHelper.GetIntegerKeys("StudentArrested_");
  }

  // Token: 0x0600046A RID: 1130 RVA: 0x0003C313 File Offset: 0x0003A713
  public static bool GetStudentBroken(int studentID) {
    return GlobalsHelper.GetBool("StudentBroken_" + studentID.ToString());
  }

  // Token: 0x0600046B RID: 1131 RVA: 0x0003C334 File Offset: 0x0003A734
  public static void SetStudentBroken(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentBroken_", text);
    GlobalsHelper.SetBool("StudentBroken_" + text, value);
  }

  // Token: 0x0600046C RID: 1132 RVA: 0x0003C36B File Offset: 0x0003A76B
  public static int[] KeysOfStudentBroken() {
    return KeysHelper.GetIntegerKeys("StudentBroken_");
  }

  // Token: 0x0600046D RID: 1133 RVA: 0x0003C377 File Offset: 0x0003A777
  public static float GetStudentBustSize(int studentID) {
    return PlayerPrefs.GetFloat("StudentBustSize_" + studentID.ToString());
  }

  // Token: 0x0600046E RID: 1134 RVA: 0x0003C398 File Offset: 0x0003A798
  public static void SetStudentBustSize(int studentID, float value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentBustSize_", text);
    PlayerPrefs.SetFloat("StudentBustSize_" + text, value);
  }

  // Token: 0x0600046F RID: 1135 RVA: 0x0003C3CF File Offset: 0x0003A7CF
  public static int[] KeysOfStudentBustSize() {
    return KeysHelper.GetIntegerKeys("StudentBustSize_");
  }

  // Token: 0x06000470 RID: 1136 RVA: 0x0003C3DB File Offset: 0x0003A7DB
  public static Color GetStudentColor(int studentID) {
    return GlobalsHelper.GetColor("StudentColor_" + studentID.ToString());
  }

  // Token: 0x06000471 RID: 1137 RVA: 0x0003C3FC File Offset: 0x0003A7FC
  public static void SetStudentColor(int studentID, Color value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentColor_", text);
    GlobalsHelper.SetColor("StudentColor_" + text, value);
  }

  // Token: 0x06000472 RID: 1138 RVA: 0x0003C433 File Offset: 0x0003A833
  public static int[] KeysOfStudentColor() {
    return KeysHelper.GetIntegerKeys("StudentColor_");
  }

  // Token: 0x06000473 RID: 1139 RVA: 0x0003C43F File Offset: 0x0003A83F
  public static bool GetStudentDead(int studentID) {
    return GlobalsHelper.GetBool("StudentDead_" + studentID.ToString());
  }

  // Token: 0x06000474 RID: 1140 RVA: 0x0003C460 File Offset: 0x0003A860
  public static void SetStudentDead(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentDead_", text);
    GlobalsHelper.SetBool("StudentDead_" + text, value);
  }

  // Token: 0x06000475 RID: 1141 RVA: 0x0003C497 File Offset: 0x0003A897
  public static int[] KeysOfStudentDead() {
    return KeysHelper.GetIntegerKeys("StudentDead_");
  }

  // Token: 0x06000476 RID: 1142 RVA: 0x0003C4A3 File Offset: 0x0003A8A3
  public static bool GetStudentDying(int studentID) {
    return GlobalsHelper.GetBool("StudentDying_" + studentID.ToString());
  }

  // Token: 0x06000477 RID: 1143 RVA: 0x0003C4C4 File Offset: 0x0003A8C4
  public static void SetStudentDying(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentDying_", text);
    GlobalsHelper.SetBool("StudentDying_" + text, value);
  }

  // Token: 0x06000478 RID: 1144 RVA: 0x0003C4FB File Offset: 0x0003A8FB
  public static int[] KeysOfStudentDying() {
    return KeysHelper.GetIntegerKeys("StudentDying_");
  }

  // Token: 0x06000479 RID: 1145 RVA: 0x0003C507 File Offset: 0x0003A907
  public static bool GetStudentExpelled(int studentID) {
    return GlobalsHelper.GetBool("StudentExpelled_" + studentID.ToString());
  }

  // Token: 0x0600047A RID: 1146 RVA: 0x0003C528 File Offset: 0x0003A928
  public static void SetStudentExpelled(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentExpelled_", text);
    GlobalsHelper.SetBool("StudentExpelled_" + text, value);
  }

  // Token: 0x0600047B RID: 1147 RVA: 0x0003C55F File Offset: 0x0003A95F
  public static int[] KeysOfStudentExpelled() {
    return KeysHelper.GetIntegerKeys("StudentExpelled_");
  }

  // Token: 0x0600047C RID: 1148 RVA: 0x0003C56B File Offset: 0x0003A96B
  public static bool GetStudentExposed(int studentID) {
    return GlobalsHelper.GetBool("StudentExposed_" + studentID.ToString());
  }

  // Token: 0x0600047D RID: 1149 RVA: 0x0003C58C File Offset: 0x0003A98C
  public static void SetStudentExposed(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentExposed_", text);
    GlobalsHelper.SetBool("StudentExposed_" + text, value);
  }

  // Token: 0x0600047E RID: 1150 RVA: 0x0003C5C3 File Offset: 0x0003A9C3
  public static int[] KeysOfStudentExposed() {
    return KeysHelper.GetIntegerKeys("StudentExposed_");
  }

  // Token: 0x0600047F RID: 1151 RVA: 0x0003C5CF File Offset: 0x0003A9CF
  public static Color GetStudentEyeColor(int studentID) {
    return GlobalsHelper.GetColor("StudentEyeColor_" + studentID.ToString());
  }

  // Token: 0x06000480 RID: 1152 RVA: 0x0003C5F0 File Offset: 0x0003A9F0
  public static void SetStudentEyeColor(int studentID, Color value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentEyeColor_", text);
    GlobalsHelper.SetColor("StudentEyeColor_" + text, value);
  }

  // Token: 0x06000481 RID: 1153 RVA: 0x0003C627 File Offset: 0x0003AA27
  public static int[] KeysOfStudentEyeColor() {
    return KeysHelper.GetIntegerKeys("StudentEyeColor_");
  }

  // Token: 0x06000482 RID: 1154 RVA: 0x0003C633 File Offset: 0x0003AA33
  public static bool GetStudentGrudge(int studentID) {
    return GlobalsHelper.GetBool("StudentGrudge_" + studentID.ToString());
  }

  // Token: 0x06000483 RID: 1155 RVA: 0x0003C654 File Offset: 0x0003AA54
  public static void SetStudentGrudge(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentGrudge_", text);
    GlobalsHelper.SetBool("StudentGrudge_" + text, value);
  }

  // Token: 0x06000484 RID: 1156 RVA: 0x0003C68B File Offset: 0x0003AA8B
  public static int[] KeysOfStudentGrudge() {
    return KeysHelper.GetIntegerKeys("StudentGrudge_");
  }

  // Token: 0x06000485 RID: 1157 RVA: 0x0003C697 File Offset: 0x0003AA97
  public static string GetStudentHairstyle(int studentID) {
    return PlayerPrefs.GetString("StudentHairstyle_" + studentID.ToString());
  }

  // Token: 0x06000486 RID: 1158 RVA: 0x0003C6B8 File Offset: 0x0003AAB8
  public static void SetStudentHairstyle(int studentID, string value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentHairstyle_", text);
    PlayerPrefs.SetString("StudentHairstyle_" + text, value);
  }

  // Token: 0x06000487 RID: 1159 RVA: 0x0003C6EF File Offset: 0x0003AAEF
  public static int[] KeysOfStudentHairstyle() {
    return KeysHelper.GetIntegerKeys("StudentHairstyle_");
  }

  // Token: 0x06000488 RID: 1160 RVA: 0x0003C6FB File Offset: 0x0003AAFB
  public static bool GetStudentKidnapped(int studentID) {
    return GlobalsHelper.GetBool("StudentKidnapped_" + studentID.ToString());
  }

  // Token: 0x06000489 RID: 1161 RVA: 0x0003C71C File Offset: 0x0003AB1C
  public static void SetStudentKidnapped(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentKidnapped_", text);
    GlobalsHelper.SetBool("StudentKidnapped_" + text, value);
  }

  // Token: 0x0600048A RID: 1162 RVA: 0x0003C753 File Offset: 0x0003AB53
  public static int[] KeysOfStudentKidnapped() {
    return KeysHelper.GetIntegerKeys("StudentKidnapped_");
  }

  // Token: 0x0600048B RID: 1163 RVA: 0x0003C75F File Offset: 0x0003AB5F
  public static bool GetStudentMissing(int studentID) {
    return GlobalsHelper.GetBool("StudentMissing_" + studentID.ToString());
  }

  // Token: 0x0600048C RID: 1164 RVA: 0x0003C780 File Offset: 0x0003AB80
  public static void SetStudentMissing(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentMissing_", text);
    GlobalsHelper.SetBool("StudentMissing_" + text, value);
  }

  // Token: 0x0600048D RID: 1165 RVA: 0x0003C7B7 File Offset: 0x0003ABB7
  public static int[] KeysOfStudentMissing() {
    return KeysHelper.GetIntegerKeys("StudentMissing_");
  }

  // Token: 0x0600048E RID: 1166 RVA: 0x0003C7C3 File Offset: 0x0003ABC3
  public static string GetStudentName(int studentID) {
    return PlayerPrefs.GetString("StudentName_" + studentID.ToString());
  }

  // Token: 0x0600048F RID: 1167 RVA: 0x0003C7E4 File Offset: 0x0003ABE4
  public static void SetStudentName(int studentID, string value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentName_", text);
    PlayerPrefs.SetString("StudentName_" + text, value);
  }

  // Token: 0x06000490 RID: 1168 RVA: 0x0003C81B File Offset: 0x0003AC1B
  public static int[] KeysOfStudentName() {
    return KeysHelper.GetIntegerKeys("StudentName_");
  }

  // Token: 0x06000491 RID: 1169 RVA: 0x0003C827 File Offset: 0x0003AC27
  public static bool GetStudentPhotographed(int studentID) {
    return GlobalsHelper.GetBool("StudentPhotographed_" + studentID.ToString());
  }

  // Token: 0x06000492 RID: 1170 RVA: 0x0003C848 File Offset: 0x0003AC48
  public static void SetStudentPhotographed(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentPhotographed_", text);
    GlobalsHelper.SetBool("StudentPhotographed_" + text, value);
  }

  // Token: 0x06000493 RID: 1171 RVA: 0x0003C87F File Offset: 0x0003AC7F
  public static int[] KeysOfStudentPhotographed() {
    return KeysHelper.GetIntegerKeys("StudentPhotographed_");
  }

  // Token: 0x06000494 RID: 1172 RVA: 0x0003C88B File Offset: 0x0003AC8B
  public static bool GetStudentReplaced(int studentID) {
    return GlobalsHelper.GetBool("StudentReplaced_" + studentID.ToString());
  }

  // Token: 0x06000495 RID: 1173 RVA: 0x0003C8AC File Offset: 0x0003ACAC
  public static void SetStudentReplaced(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentReplaced_", text);
    GlobalsHelper.SetBool("StudentReplaced_" + text, value);
  }

  // Token: 0x06000496 RID: 1174 RVA: 0x0003C8E3 File Offset: 0x0003ACE3
  public static int[] KeysOfStudentReplaced() {
    return KeysHelper.GetIntegerKeys("StudentReplaced_");
  }

  // Token: 0x06000497 RID: 1175 RVA: 0x0003C8EF File Offset: 0x0003ACEF
  public static int GetStudentReputation(int studentID) {
    return PlayerPrefs.GetInt("StudentReputation_" + studentID.ToString());
  }

  // Token: 0x06000498 RID: 1176 RVA: 0x0003C910 File Offset: 0x0003AD10
  public static void SetStudentReputation(int studentID, int value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentReputation_", text);
    PlayerPrefs.SetInt("StudentReputation_" + text, value);
  }

  // Token: 0x06000499 RID: 1177 RVA: 0x0003C947 File Offset: 0x0003AD47
  public static int[] KeysOfStudentReputation() {
    return KeysHelper.GetIntegerKeys("StudentReputation_");
  }

  // Token: 0x0600049A RID: 1178 RVA: 0x0003C953 File Offset: 0x0003AD53
  public static float GetStudentSanity(int studentID) {
    return PlayerPrefs.GetFloat("StudentSanity_" + studentID.ToString());
  }

  // Token: 0x0600049B RID: 1179 RVA: 0x0003C974 File Offset: 0x0003AD74
  public static void SetStudentSanity(int studentID, float value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentSanity_", text);
    PlayerPrefs.SetFloat("StudentSanity_" + text, value);
  }

  // Token: 0x0600049C RID: 1180 RVA: 0x0003C9AB File Offset: 0x0003ADAB
  public static int[] KeysOfStudentSanity() {
    return KeysHelper.GetIntegerKeys("StudentSanity_");
  }

  // Token: 0x0600049D RID: 1181 RVA: 0x0003C9B7 File Offset: 0x0003ADB7
  public static bool GetStudentSlave(int studentID) {
    return GlobalsHelper.GetBool("StudentSlave_" + studentID.ToString());
  }

  // Token: 0x0600049E RID: 1182 RVA: 0x0003C9D8 File Offset: 0x0003ADD8
  public static void SetStudentSlave(int studentID, bool value) {
    string text = studentID.ToString();
    KeysHelper.AddIfMissing("StudentSlave_", text);
    GlobalsHelper.SetBool("StudentSlave_" + text, value);
  }

  // Token: 0x0600049F RID: 1183 RVA: 0x0003CA0F File Offset: 0x0003AE0F
  public static int[] KeysOfStudentSlave() {
    return KeysHelper.GetIntegerKeys("StudentSlave_");
  }

  // Token: 0x060004A0 RID: 1184 RVA: 0x0003CA1C File Offset: 0x0003AE1C
  public static void DeleteAll() {
    Globals.Delete("CustomSuitor");
    Globals.Delete("CustomSuitorAccessory");
    Globals.Delete("CustomSuitorBlonde");
    Globals.Delete("CustomSuitorEyewear");
    Globals.Delete("CustomSuitorHair");
    Globals.Delete("CustomSuitorJewelry");
    Globals.Delete("CustomSuitorTan");
    Globals.Delete("ExpelProgress");
    Globals.Delete("FemaleUniform");
    Globals.Delete("MaleUniform");
    Globals.DeleteCollection("StudentAccessory_", StudentGlobals.KeysOfStudentAccessory());
    Globals.DeleteCollection("StudentArrested_", StudentGlobals.KeysOfStudentArrested());
    Globals.DeleteCollection("StudentBroken_", StudentGlobals.KeysOfStudentBroken());
    Globals.DeleteCollection("StudentBustSize_", StudentGlobals.KeysOfStudentBustSize());
    GlobalsHelper.DeleteColorCollection("StudentColor_", StudentGlobals.KeysOfStudentColor());
    Globals.DeleteCollection("StudentDead_", StudentGlobals.KeysOfStudentDead());
    Globals.DeleteCollection("StudentDying_", StudentGlobals.KeysOfStudentDying());
    Globals.DeleteCollection("StudentExpelled_", StudentGlobals.KeysOfStudentExpelled());
    Globals.DeleteCollection("StudentExposed_", StudentGlobals.KeysOfStudentExposed());
    GlobalsHelper.DeleteColorCollection("StudentEyeColor_", StudentGlobals.KeysOfStudentEyeColor());
    Globals.DeleteCollection("StudentGrudge_", StudentGlobals.KeysOfStudentGrudge());
    Globals.DeleteCollection("StudentHairstyle_", StudentGlobals.KeysOfStudentHairstyle());
    Globals.DeleteCollection("StudentKidnapped_", StudentGlobals.KeysOfStudentKidnapped());
    Globals.DeleteCollection("StudentMissing_", StudentGlobals.KeysOfStudentMissing());
    Globals.DeleteCollection("StudentName_", StudentGlobals.KeysOfStudentName());
    Globals.DeleteCollection("StudentPhotographed_", StudentGlobals.KeysOfStudentPhotographed());
    Globals.DeleteCollection("StudentReplaced_", StudentGlobals.KeysOfStudentReplaced());
    Globals.DeleteCollection("StudentReputation_", StudentGlobals.KeysOfStudentReputation());
    Globals.DeleteCollection("StudentSanity_", StudentGlobals.KeysOfStudentSanity());
    Globals.DeleteCollection("StudentSlave_", StudentGlobals.KeysOfStudentSlave());
  }

  // Token: 0x04000A28 RID: 2600
  private const string Str_CustomSuitor = "CustomSuitor";

  // Token: 0x04000A29 RID: 2601
  private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";

  // Token: 0x04000A2A RID: 2602
  private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";

  // Token: 0x04000A2B RID: 2603
  private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";

  // Token: 0x04000A2C RID: 2604
  private const string Str_CustomSuitorHair = "CustomSuitorHair";

  // Token: 0x04000A2D RID: 2605
  private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";

  // Token: 0x04000A2E RID: 2606
  private const string Str_CustomSuitorTan = "CustomSuitorTan";

  // Token: 0x04000A2F RID: 2607
  private const string Str_ExpelProgress = "ExpelProgress";

  // Token: 0x04000A30 RID: 2608
  private const string Str_FemaleUniform = "FemaleUniform";

  // Token: 0x04000A31 RID: 2609
  private const string Str_MaleUniform = "MaleUniform";

  // Token: 0x04000A32 RID: 2610
  private const string Str_StudentAccessory = "StudentAccessory_";

  // Token: 0x04000A33 RID: 2611
  private const string Str_StudentArrested = "StudentArrested_";

  // Token: 0x04000A34 RID: 2612
  private const string Str_StudentBroken = "StudentBroken_";

  // Token: 0x04000A35 RID: 2613
  private const string Str_StudentBustSize = "StudentBustSize_";

  // Token: 0x04000A36 RID: 2614
  private const string Str_StudentColor = "StudentColor_";

  // Token: 0x04000A37 RID: 2615
  private const string Str_StudentDead = "StudentDead_";

  // Token: 0x04000A38 RID: 2616
  private const string Str_StudentDying = "StudentDying_";

  // Token: 0x04000A39 RID: 2617
  private const string Str_StudentExpelled = "StudentExpelled_";

  // Token: 0x04000A3A RID: 2618
  private const string Str_StudentExposed = "StudentExposed_";

  // Token: 0x04000A3B RID: 2619
  private const string Str_StudentEyeColor = "StudentEyeColor_";

  // Token: 0x04000A3C RID: 2620
  private const string Str_StudentGrudge = "StudentGrudge_";

  // Token: 0x04000A3D RID: 2621
  private const string Str_StudentHairstyle = "StudentHairstyle_";

  // Token: 0x04000A3E RID: 2622
  private const string Str_StudentKidnapped = "StudentKidnapped_";

  // Token: 0x04000A3F RID: 2623
  private const string Str_StudentMissing = "StudentMissing_";

  // Token: 0x04000A40 RID: 2624
  private const string Str_StudentName = "StudentName_";

  // Token: 0x04000A41 RID: 2625
  private const string Str_StudentPhotographed = "StudentPhotographed_";

  // Token: 0x04000A42 RID: 2626
  private const string Str_StudentReplaced = "StudentReplaced_";

  // Token: 0x04000A43 RID: 2627
  private const string Str_StudentReputation = "StudentReputation_";

  // Token: 0x04000A44 RID: 2628
  private const string Str_StudentSanity = "StudentSanity_";

  // Token: 0x04000A45 RID: 2629
  private const string Str_StudentSlave = "StudentSlave_";
}