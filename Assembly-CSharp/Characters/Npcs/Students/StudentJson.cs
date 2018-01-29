using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000118 RID: 280
[Serializable]
public class StudentJson : JsonData {

  // Token: 0x170000BB RID: 187
  // (get) Token: 0x06000551 RID: 1361 RVA: 0x0004AC1E File Offset: 0x0004901E
  public static string FilePath {
    get {
      return Path.Combine(JsonData.FolderPath, "Students.json");
    }
  }

  // Token: 0x06000552 RID: 1362 RVA: 0x0004AC30 File Offset: 0x00049030
  public static StudentJson[] LoadFromJson(string path) {
    StudentJson[] array = new StudentJson[101];
    for (int i = 0; i < array.Length; i++) {
      array[i] = new StudentJson();
    }
    StudentJson studentJson = array[0];
    studentJson.name = "Info-chan";
    studentJson.club = ClubType.Nemesis;
    studentJson.persona = PersonaType.Nemesis;
    studentJson.crush = 99;
    StudentJson studentJson2 = array[90];
    studentJson2.name = "Info-chan";
    studentJson2.club = ClubType.Nemesis;
    studentJson2.persona = PersonaType.Nemesis;
    studentJson2.crush = 99;
    foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path)) {
      int num = TFUtils.LoadInt(dictionary, "ID");
      if (num == 0) {
        break;
      }
      StudentJson studentJson3 = array[num];
      studentJson3.name = TFUtils.LoadString(dictionary, "Name");
      studentJson3.gender = TFUtils.LoadInt(dictionary, "Gender");
      studentJson3.classID = TFUtils.LoadInt(dictionary, "Class");
      studentJson3.seat = TFUtils.LoadInt(dictionary, "Seat");
      studentJson3.club = (ClubType)TFUtils.LoadInt(dictionary, "Club");
      studentJson3.persona = (PersonaType)TFUtils.LoadInt(dictionary, "Persona");
      studentJson3.crush = TFUtils.LoadInt(dictionary, "Crush");
      studentJson3.breastSize = TFUtils.LoadFloat(dictionary, "BreastSize");
      studentJson3.strength = TFUtils.LoadInt(dictionary, "Strength");
      studentJson3.hairstyle = TFUtils.LoadString(dictionary, "Hairstyle");
      studentJson3.color = TFUtils.LoadString(dictionary, "Color");
      studentJson3.eyes = TFUtils.LoadString(dictionary, "Eyes");
      studentJson3.eyeType = TFUtils.LoadString(dictionary, "EyeType");
      studentJson3.stockings = TFUtils.LoadString(dictionary, "Stockings");
      studentJson3.accessory = TFUtils.LoadString(dictionary, "Accessory");
      studentJson3.info = TFUtils.LoadString(dictionary, "Info");
      if (GameGlobals.LoveSick && studentJson3.name == "Mai Waifu") {
        studentJson3.name = "Mai Wakabayashi";
      }
      if (OptionGlobals.HighPopulation && studentJson3.name == "Unknown") {
        studentJson3.name = "Random";
      }
      float[] array3 = StudentJson.ConstructTempFloatArray(TFUtils.LoadString(dictionary, "ScheduleTime"));
      string[] array4 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleDestination"));
      string[] array5 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleAction"));
      studentJson3.scheduleBlocks = new ScheduleBlock[array3.Length];
      for (int k = 0; k < studentJson3.scheduleBlocks.Length; k++) {
        studentJson3.scheduleBlocks[k] = new ScheduleBlock(array3[k], array4[k], array5[k]);
      }
      studentJson3.success = true;
    }
    return array;
  }

  // Token: 0x170000BC RID: 188
  // (get) Token: 0x06000553 RID: 1363 RVA: 0x0004AF0E File Offset: 0x0004930E
  // (set) Token: 0x06000554 RID: 1364 RVA: 0x0004AF16 File Offset: 0x00049316
  public string Name {
    get {
      return this.name;
    }
    set {
      this.name = value;
    }
  }

  // Token: 0x170000BD RID: 189
  // (get) Token: 0x06000555 RID: 1365 RVA: 0x0004AF1F File Offset: 0x0004931F
  public int Gender {
    get {
      return this.gender;
    }
  }

  // Token: 0x170000BE RID: 190
  // (get) Token: 0x06000556 RID: 1366 RVA: 0x0004AF27 File Offset: 0x00049327
  // (set) Token: 0x06000557 RID: 1367 RVA: 0x0004AF2F File Offset: 0x0004932F
  public int Class {
    get {
      return this.classID;
    }
    set {
      this.classID = value;
    }
  }

  // Token: 0x170000BF RID: 191
  // (get) Token: 0x06000558 RID: 1368 RVA: 0x0004AF38 File Offset: 0x00049338
  // (set) Token: 0x06000559 RID: 1369 RVA: 0x0004AF40 File Offset: 0x00049340
  public int Seat {
    get {
      return this.seat;
    }
    set {
      this.seat = value;
    }
  }

  // Token: 0x170000C0 RID: 192
  // (get) Token: 0x0600055A RID: 1370 RVA: 0x0004AF49 File Offset: 0x00049349
  public ClubType Club {
    get {
      return this.club;
    }
  }

  // Token: 0x170000C1 RID: 193
  // (get) Token: 0x0600055B RID: 1371 RVA: 0x0004AF51 File Offset: 0x00049351
  // (set) Token: 0x0600055C RID: 1372 RVA: 0x0004AF59 File Offset: 0x00049359
  public PersonaType Persona {
    get {
      return this.persona;
    }
    set {
      this.persona = value;
    }
  }

  // Token: 0x170000C2 RID: 194
  // (get) Token: 0x0600055D RID: 1373 RVA: 0x0004AF62 File Offset: 0x00049362
  public int Crush {
    get {
      return this.crush;
    }
  }

  // Token: 0x170000C3 RID: 195
  // (get) Token: 0x0600055E RID: 1374 RVA: 0x0004AF6A File Offset: 0x0004936A
  // (set) Token: 0x0600055F RID: 1375 RVA: 0x0004AF72 File Offset: 0x00049372
  public float BreastSize {
    get {
      return this.breastSize;
    }
    set {
      this.breastSize = value;
    }
  }

  // Token: 0x170000C4 RID: 196
  // (get) Token: 0x06000560 RID: 1376 RVA: 0x0004AF7B File Offset: 0x0004937B
  // (set) Token: 0x06000561 RID: 1377 RVA: 0x0004AF83 File Offset: 0x00049383
  public int Strength {
    get {
      return this.strength;
    }
    set {
      this.strength = value;
    }
  }

  // Token: 0x170000C5 RID: 197
  // (get) Token: 0x06000562 RID: 1378 RVA: 0x0004AF8C File Offset: 0x0004938C
  // (set) Token: 0x06000563 RID: 1379 RVA: 0x0004AF94 File Offset: 0x00049394
  public string Hairstyle {
    get {
      return this.hairstyle;
    }
    set {
      this.hairstyle = value;
    }
  }

  // Token: 0x170000C6 RID: 198
  // (get) Token: 0x06000564 RID: 1380 RVA: 0x0004AF9D File Offset: 0x0004939D
  public string Color {
    get {
      return this.color;
    }
  }

  // Token: 0x170000C7 RID: 199
  // (get) Token: 0x06000565 RID: 1381 RVA: 0x0004AFA5 File Offset: 0x000493A5
  public string Eyes {
    get {
      return this.eyes;
    }
  }

  // Token: 0x170000C8 RID: 200
  // (get) Token: 0x06000566 RID: 1382 RVA: 0x0004AFAD File Offset: 0x000493AD
  public string EyeType {
    get {
      return this.eyeType;
    }
  }

  // Token: 0x170000C9 RID: 201
  // (get) Token: 0x06000567 RID: 1383 RVA: 0x0004AFB5 File Offset: 0x000493B5
  public string Stockings {
    get {
      return this.stockings;
    }
  }

  // Token: 0x170000CA RID: 202
  // (get) Token: 0x06000568 RID: 1384 RVA: 0x0004AFBD File Offset: 0x000493BD
  // (set) Token: 0x06000569 RID: 1385 RVA: 0x0004AFC5 File Offset: 0x000493C5
  public string Accessory {
    get {
      return this.accessory;
    }
    set {
      this.accessory = value;
    }
  }

  // Token: 0x170000CB RID: 203
  // (get) Token: 0x0600056A RID: 1386 RVA: 0x0004AFCE File Offset: 0x000493CE
  public string Info {
    get {
      return this.info;
    }
  }

  // Token: 0x170000CC RID: 204
  // (get) Token: 0x0600056B RID: 1387 RVA: 0x0004AFD6 File Offset: 0x000493D6
  public ScheduleBlock[] ScheduleBlocks {
    get {
      return this.scheduleBlocks;
    }
  }

  // Token: 0x170000CD RID: 205
  // (get) Token: 0x0600056C RID: 1388 RVA: 0x0004AFDE File Offset: 0x000493DE
  public bool Success {
    get {
      return this.success;
    }
  }

  // Token: 0x0600056D RID: 1389 RVA: 0x0004AFE8 File Offset: 0x000493E8
  private static float[] ConstructTempFloatArray(string str) {
    string[] array = str.Split(new char[]
    {
      '_'
    });
    float[] array2 = new float[array.Length];
    for (int i = 0; i < array.Length; i++) {
      array2[i] = float.Parse(array[i]);
    }
    return array2;
  }

  // Token: 0x0600056E RID: 1390 RVA: 0x0004B030 File Offset: 0x00049430
  private static string[] ConstructTempStringArray(string str) {
    return str.Split(new char[]
    {
      '_'
    });
  }

  // Token: 0x04000CE7 RID: 3303
  [SerializeField]
  private string name;

  // Token: 0x04000CE8 RID: 3304
  [SerializeField]
  private int gender;

  // Token: 0x04000CE9 RID: 3305
  [SerializeField]
  private int classID;

  // Token: 0x04000CEA RID: 3306
  [SerializeField]
  private int seat;

  // Token: 0x04000CEB RID: 3307
  [SerializeField]
  private ClubType club;

  // Token: 0x04000CEC RID: 3308
  [SerializeField]
  private PersonaType persona;

  // Token: 0x04000CED RID: 3309
  [SerializeField]
  private int crush;

  // Token: 0x04000CEE RID: 3310
  [SerializeField]
  private float breastSize;

  // Token: 0x04000CEF RID: 3311
  [SerializeField]
  private int strength;

  // Token: 0x04000CF0 RID: 3312
  [SerializeField]
  private string hairstyle;

  // Token: 0x04000CF1 RID: 3313
  [SerializeField]
  private string color;

  // Token: 0x04000CF2 RID: 3314
  [SerializeField]
  private string eyes;

  // Token: 0x04000CF3 RID: 3315
  [SerializeField]
  private string eyeType;

  // Token: 0x04000CF4 RID: 3316
  [SerializeField]
  private string stockings;

  // Token: 0x04000CF5 RID: 3317
  [SerializeField]
  private string accessory;

  // Token: 0x04000CF6 RID: 3318
  [SerializeField]
  private string info;

  // Token: 0x04000CF7 RID: 3319
  [SerializeField]
  private ScheduleBlock[] scheduleBlocks;

  // Token: 0x04000CF8 RID: 3320
  [SerializeField]
  private bool success;
}