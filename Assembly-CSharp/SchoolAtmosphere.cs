// Token: 0x020001A8 RID: 424
public static class SchoolAtmosphere {

  // Token: 0x170000E3 RID: 227
  // (get) Token: 0x06000770 RID: 1904 RVA: 0x0007022C File Offset: 0x0006E62C
  public static SchoolAtmosphereType Type {
    get {
      float schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
      if (schoolAtmosphere > 0.6666667f) {
        return SchoolAtmosphereType.High;
      }
      if (schoolAtmosphere > 0.333333343f) {
        return SchoolAtmosphereType.Medium;
      }
      return SchoolAtmosphereType.Low;
    }
  }
}