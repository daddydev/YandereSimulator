using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020000CF RID: 207
public static class KeysHelper {

  // Token: 0x0600031D RID: 797 RVA: 0x0003A25C File Offset: 0x0003865C
  public static int[] GetIntegerKeys(string key) {
    string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
    string[] array = KeysHelper.SplitList(keyList);
    string[] array2 = array;
    if (KeysHelper.temp == null) {
      KeysHelper.temp = new Converter<string, int>(int.Parse);
    }
    return Array.ConvertAll<string, int>(array2, KeysHelper.temp);
  }

  // Token: 0x0600031E RID: 798 RVA: 0x0003A2A4 File Offset: 0x000386A4
  public static string[] GetStringKeys(string key) {
    string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
    return KeysHelper.SplitList(keyList);
  }

  // Token: 0x0600031F RID: 799 RVA: 0x0003A2C8 File Offset: 0x000386C8
  public static T[] GetEnumKeys<T>(string key) where T : struct, IConvertible {
    string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
    string[] array = KeysHelper.SplitList(keyList);
    return Array.ConvertAll<string, T>(array, (string str) => (T)((object)Enum.Parse(typeof(T), str)));
  }

  // Token: 0x06000320 RID: 800 RVA: 0x0003A2FC File Offset: 0x000386FC
  public static KeyValuePair<T, U>[] GetKeys<T, U>(string key) where T : struct where U : struct {
    string keyList = KeysHelper.GetKeyList(KeysHelper.GetKeyListKey(key));
    string[] array = KeysHelper.SplitList(keyList);
    KeyValuePair<T, U>[] array2 = new KeyValuePair<T, U>[array.Length];
    for (int i = 0; i < array.Length; i++) {
      string[] array3 = array[i].Split(new char[]
      {
        '^'
      });
      array2[i] = new KeyValuePair<T, U>((T)((object)int.Parse(array3[0])), (U)((object)int.Parse(array3[1])));
    }
    return array2;
  }

  // Token: 0x06000321 RID: 801 RVA: 0x0003A388 File Offset: 0x00038788
  public static void AddIfMissing(string key, string id) {
    string keyListKey = KeysHelper.GetKeyListKey(key);
    string keyList = KeysHelper.GetKeyList(keyListKey);
    string[] keyListStrings = KeysHelper.SplitList(keyList);
    if (!KeysHelper.HasKey(keyListStrings, id)) {
      KeysHelper.AppendKey(keyListKey, keyList, id);
    }
  }

  // Token: 0x06000322 RID: 802 RVA: 0x0003A3C0 File Offset: 0x000387C0
  public static void Delete(string key) {
    string keyListKey = KeysHelper.GetKeyListKey(key);
    Globals.Delete(keyListKey);
  }

  // Token: 0x06000323 RID: 803 RVA: 0x0003A3DA File Offset: 0x000387DA
  private static string GetKeyListKey(string key) {
    return key + "Keys";
  }

  // Token: 0x06000324 RID: 804 RVA: 0x0003A3E7 File Offset: 0x000387E7
  private static string GetKeyList(string keyListKey) {
    return PlayerPrefs.GetString(keyListKey);
  }

  // Token: 0x06000325 RID: 805 RVA: 0x0003A3EF File Offset: 0x000387EF
  private static string[] SplitList(string keyList) {
    return (keyList.Length <= 0) ? new string[0] : keyList.Split(new char[]
    {
      '|'
    });
  }

  // Token: 0x06000326 RID: 806 RVA: 0x0003A419 File Offset: 0x00038819
  private static int FindKey(string[] keyListStrings, string key) {
    return Array.IndexOf<string>(keyListStrings, key);
  }

  // Token: 0x06000327 RID: 807 RVA: 0x0003A422 File Offset: 0x00038822
  private static bool HasKey(string[] keyListStrings, string key) {
    return KeysHelper.FindKey(keyListStrings, key) > -1;
  }

  // Token: 0x06000328 RID: 808 RVA: 0x0003A430 File Offset: 0x00038830
  private static void AppendKey(string keyListKey, string keyList, string key) {
    string value = (keyList.Length != 0) ? (keyList + '|' + key) : (keyList + key);
    PlayerPrefs.SetString(keyListKey, value);
  }

  // Token: 0x040009AC RID: 2476
  private const string KeyListPrefix = "Keys";

  // Token: 0x040009AD RID: 2477
  private const char KeyListSeparator = '|';

  // Token: 0x040009AE RID: 2478
  public const char PairSeparator = '^';

  // Token: 0x040009AF RID: 2479
  [CompilerGenerated]
  private static Converter<string, int> temp;
}