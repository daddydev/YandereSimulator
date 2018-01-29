using System;
using UnityEngine;

// Token: 0x020000CE RID: 206
public static class GlobalsHelper {

  // Token: 0x0600030D RID: 781 RVA: 0x00039ED2 File Offset: 0x000382D2
  public static bool GetBool(string key) {
    return PlayerPrefs.GetInt(key) == 1;
  }

  // Token: 0x0600030E RID: 782 RVA: 0x00039EDD File Offset: 0x000382DD
  public static void SetBool(string key, bool value) {
    PlayerPrefs.SetInt(key, (!value) ? 0 : 1);
  }

  // Token: 0x0600030F RID: 783 RVA: 0x00039EF2 File Offset: 0x000382F2
  public static T GetEnum<T>(string key) where T : struct, IConvertible {
    return (T)((object)PlayerPrefs.GetInt(key));
  }

  // Token: 0x06000310 RID: 784 RVA: 0x00039F04 File Offset: 0x00038304
  public static void SetEnum<T>(string key, T value) where T : struct, IConvertible {
    PlayerPrefs.SetInt(key, (int)((object)value));
  }

  // Token: 0x06000311 RID: 785 RVA: 0x00039F18 File Offset: 0x00038318
  public static Vector2 GetVector2(string key) {
    float @float = PlayerPrefs.GetFloat(key + "_X");
    float float2 = PlayerPrefs.GetFloat(key + "_Y");
    return new Vector2(@float, float2);
  }

  // Token: 0x06000312 RID: 786 RVA: 0x00039F4E File Offset: 0x0003834E
  public static void SetVector2(string key, Vector2 value) {
    PlayerPrefs.SetFloat(key + "_X", value.x);
    PlayerPrefs.SetFloat(key + "_Y", value.y);
  }

  // Token: 0x06000313 RID: 787 RVA: 0x00039F7E File Offset: 0x0003837E
  public static void DeleteVector2(string key) {
    Globals.Delete(key + "_X");
    Globals.Delete(key + "_Y");
  }

  // Token: 0x06000314 RID: 788 RVA: 0x00039FA0 File Offset: 0x000383A0
  public static void DeleteVector2Collection(string key, int[] usedKeys) {
    foreach (int num in usedKeys) {
      GlobalsHelper.DeleteVector2(key + num.ToString());
    }
    KeysHelper.Delete(key);
  }

  // Token: 0x06000315 RID: 789 RVA: 0x00039FE8 File Offset: 0x000383E8
  public static Vector3 GetVector3(string key) {
    float @float = PlayerPrefs.GetFloat(key + "_X");
    float float2 = PlayerPrefs.GetFloat(key + "_Y");
    float float3 = PlayerPrefs.GetFloat(key + "_Z");
    return new Vector3(@float, float2, float3);
  }

  // Token: 0x06000316 RID: 790 RVA: 0x0003A030 File Offset: 0x00038430
  public static void SetVector3(string key, Vector3 value) {
    PlayerPrefs.SetFloat(key + "_X", value.x);
    PlayerPrefs.SetFloat(key + "_Y", value.y);
    PlayerPrefs.SetFloat(key + "_Z", value.z);
  }

  // Token: 0x06000317 RID: 791 RVA: 0x0003A082 File Offset: 0x00038482
  public static void DeleteVector3(string key) {
    Globals.Delete(key + "_X");
    Globals.Delete(key + "_Y");
    Globals.Delete(key + "_Z");
  }

  // Token: 0x06000318 RID: 792 RVA: 0x0003A0B4 File Offset: 0x000384B4
  public static void DeleteVector3Collection(string key, int[] usedKeys) {
    foreach (int num in usedKeys) {
      GlobalsHelper.DeleteVector3(key + num.ToString());
    }
    KeysHelper.Delete(key);
  }

  // Token: 0x06000319 RID: 793 RVA: 0x0003A0FC File Offset: 0x000384FC
  public static Color GetColor(string key) {
    float @float = PlayerPrefs.GetFloat(key + "_R");
    float float2 = PlayerPrefs.GetFloat(key + "_G");
    float float3 = PlayerPrefs.GetFloat(key + "_B");
    float float4 = PlayerPrefs.GetFloat(key + "_A");
    return new Color(@float, float2, float3, float4);
  }

  // Token: 0x0600031A RID: 794 RVA: 0x0003A158 File Offset: 0x00038558
  public static void SetColor(string key, Color value) {
    PlayerPrefs.SetFloat(key + "_R", value.r);
    PlayerPrefs.SetFloat(key + "_G", value.g);
    PlayerPrefs.SetFloat(key + "_B", value.b);
    PlayerPrefs.SetFloat(key + "_A", value.a);
  }

  // Token: 0x0600031B RID: 795 RVA: 0x0003A1C4 File Offset: 0x000385C4
  public static void DeleteColor(string key) {
    Globals.Delete(key + "_R");
    Globals.Delete(key + "_G");
    Globals.Delete(key + "_B");
    Globals.Delete(key + "_A");
  }

  // Token: 0x0600031C RID: 796 RVA: 0x0003A214 File Offset: 0x00038614
  public static void DeleteColorCollection(string key, int[] usedKeys) {
    foreach (int num in usedKeys) {
      GlobalsHelper.DeleteColor(key + num.ToString());
    }
    KeysHelper.Delete(key);
  }
}