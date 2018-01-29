using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000198 RID: 408
[Serializable]
public class PlayerSaveData {

  // Token: 0x0600073B RID: 1851 RVA: 0x0006D754 File Offset: 0x0006BB54
  public static PlayerSaveData ReadFromGlobals() {
    PlayerSaveData playerSaveData = new PlayerSaveData();
    playerSaveData.alerts = PlayerGlobals.Alerts;
    playerSaveData.enlightenment = PlayerGlobals.Enlightenment;
    playerSaveData.enlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
    playerSaveData.headset = PlayerGlobals.Headset;
    playerSaveData.kills = PlayerGlobals.Kills;
    playerSaveData.numbness = PlayerGlobals.Numbness;
    playerSaveData.numbnessBonus = PlayerGlobals.NumbnessBonus;
    playerSaveData.pantiesEquipped = PlayerGlobals.PantiesEquipped;
    playerSaveData.pantyShots = PlayerGlobals.PantyShots;
    foreach (int num in PlayerGlobals.KeysOfPhoto()) {
      if (PlayerGlobals.GetPhoto(num)) {
        playerSaveData.photo.Add(num);
      }
    }
    foreach (int num2 in PlayerGlobals.KeysOfPhotoOnCorkboard()) {
      if (PlayerGlobals.GetPhotoOnCorkboard(num2)) {
        playerSaveData.photoOnCorkboard.Add(num2);
      }
    }
    foreach (int num3 in PlayerGlobals.KeysOfPhotoPosition()) {
      playerSaveData.photoPosition.Add(num3, PlayerGlobals.GetPhotoPosition(num3));
    }
    foreach (int num4 in PlayerGlobals.KeysOfPhotoRotation()) {
      playerSaveData.photoRotation.Add(num4, PlayerGlobals.GetPhotoRotation(num4));
    }
    playerSaveData.reputation = PlayerGlobals.Reputation;
    playerSaveData.seduction = PlayerGlobals.Seduction;
    playerSaveData.seductionBonus = PlayerGlobals.SeductionBonus;
    foreach (int num5 in PlayerGlobals.KeysOfSenpaiPhoto()) {
      if (PlayerGlobals.GetSenpaiPhoto(num5)) {
        playerSaveData.senpaiPhoto.Add(num5);
      }
    }
    playerSaveData.senpaiShots = PlayerGlobals.SenpaiShots;
    playerSaveData.socialBonus = PlayerGlobals.SocialBonus;
    playerSaveData.speedBonus = PlayerGlobals.SpeedBonus;
    playerSaveData.stealthBonus = PlayerGlobals.StealthBonus;
    foreach (int num6 in PlayerGlobals.KeysOfStudentFriend()) {
      if (PlayerGlobals.GetStudentFriend(num6)) {
        playerSaveData.studentFriend.Add(num6);
      }
    }
    foreach (string text in PlayerGlobals.KeysOfStudentPantyShot()) {
      if (PlayerGlobals.GetStudentPantyShot(text)) {
        playerSaveData.studentPantyShot.Add(text);
      }
    }
    return playerSaveData;
  }

  // Token: 0x0600073C RID: 1852 RVA: 0x0006D9C8 File Offset: 0x0006BDC8
  public static void WriteToGlobals(PlayerSaveData data) {
    PlayerGlobals.Alerts = data.alerts;
    PlayerGlobals.Enlightenment = data.enlightenment;
    PlayerGlobals.EnlightenmentBonus = data.enlightenmentBonus;
    PlayerGlobals.Headset = data.headset;
    PlayerGlobals.Kills = data.kills;
    PlayerGlobals.Numbness = data.numbness;
    PlayerGlobals.NumbnessBonus = data.numbnessBonus;
    PlayerGlobals.PantiesEquipped = data.pantiesEquipped;
    PlayerGlobals.PantyShots = data.pantyShots;
    foreach (int photoID in data.photo) {
      PlayerGlobals.SetPhoto(photoID, true);
    }
    foreach (int photoID2 in data.photoOnCorkboard) {
      PlayerGlobals.SetPhotoOnCorkboard(photoID2, true);
    }
    foreach (KeyValuePair<int, Vector2> keyValuePair in data.photoPosition) {
      PlayerGlobals.SetPhotoPosition(keyValuePair.Key, keyValuePair.Value);
    }
    foreach (KeyValuePair<int, float> keyValuePair2 in data.photoRotation) {
      PlayerGlobals.SetPhotoRotation(keyValuePair2.Key, keyValuePair2.Value);
    }
    PlayerGlobals.Reputation = data.reputation;
    PlayerGlobals.Seduction = data.seduction;
    PlayerGlobals.SeductionBonus = data.seductionBonus;
    foreach (int photoID3 in data.senpaiPhoto) {
      PlayerGlobals.SetSenpaiPhoto(photoID3, true);
    }
    PlayerGlobals.SenpaiShots = data.senpaiShots;
    PlayerGlobals.SocialBonus = data.socialBonus;
    PlayerGlobals.SpeedBonus = data.speedBonus;
    PlayerGlobals.StealthBonus = data.stealthBonus;
    foreach (int studentID in data.studentFriend) {
      PlayerGlobals.SetStudentFriend(studentID, true);
    }
    foreach (string studentName in data.studentPantyShot) {
      PlayerGlobals.SetStudentPantyShot(studentName, true);
    }
  }

  // Token: 0x04001242 RID: 4674
  public int alerts;

  // Token: 0x04001243 RID: 4675
  public int enlightenment;

  // Token: 0x04001244 RID: 4676
  public int enlightenmentBonus;

  // Token: 0x04001245 RID: 4677
  public bool headset;

  // Token: 0x04001246 RID: 4678
  public int kills;

  // Token: 0x04001247 RID: 4679
  public int numbness;

  // Token: 0x04001248 RID: 4680
  public int numbnessBonus;

  // Token: 0x04001249 RID: 4681
  public int pantiesEquipped;

  // Token: 0x0400124A RID: 4682
  public int pantyShots;

  // Token: 0x0400124B RID: 4683
  public IntHashSet photo = new IntHashSet();

  // Token: 0x0400124C RID: 4684
  public IntHashSet photoOnCorkboard = new IntHashSet();

  // Token: 0x0400124D RID: 4685
  public IntAndVector2Dictionary photoPosition = new IntAndVector2Dictionary();

  // Token: 0x0400124E RID: 4686
  public IntAndFloatDictionary photoRotation = new IntAndFloatDictionary();

  // Token: 0x0400124F RID: 4687
  public float reputation;

  // Token: 0x04001250 RID: 4688
  public int seduction;

  // Token: 0x04001251 RID: 4689
  public int seductionBonus;

  // Token: 0x04001252 RID: 4690
  public IntHashSet senpaiPhoto = new IntHashSet();

  // Token: 0x04001253 RID: 4691
  public int senpaiShots;

  // Token: 0x04001254 RID: 4692
  public int socialBonus;

  // Token: 0x04001255 RID: 4693
  public int speedBonus;

  // Token: 0x04001256 RID: 4694
  public int stealthBonus;

  // Token: 0x04001257 RID: 4695
  public IntHashSet studentFriend = new IntHashSet();

  // Token: 0x04001258 RID: 4696
  public StringHashSet studentPantyShot = new StringHashSet();
}