using System;

// Token: 0x02000194 RID: 404
[Serializable]
public class GameSaveData {

  // Token: 0x0600072F RID: 1839 RVA: 0x0006D38C File Offset: 0x0006B78C
  public static GameSaveData ReadFromGlobals() {
    return new GameSaveData {
      loveSick = GameGlobals.LoveSick,
      masksBanned = GameGlobals.MasksBanned,
      paranormal = GameGlobals.Paranormal
    };
  }

  // Token: 0x06000730 RID: 1840 RVA: 0x0006D3C1 File Offset: 0x0006B7C1
  public static void WriteToGlobals(GameSaveData data) {
    GameGlobals.LoveSick = data.loveSick;
    GameGlobals.MasksBanned = data.masksBanned;
    GameGlobals.Paranormal = data.paranormal;
  }

  // Token: 0x04001227 RID: 4647
  public bool loveSick;

  // Token: 0x04001228 RID: 4648
  public bool masksBanned;

  // Token: 0x04001229 RID: 4649
  public bool paranormal;
}