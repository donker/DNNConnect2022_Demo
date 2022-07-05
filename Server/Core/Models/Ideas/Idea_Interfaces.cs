using System;
using System.Data;
using System.Xml.Serialization;

using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Tokens;

namespace Connect.IdeaBox.Models.Ideas
{

  [Serializable(), XmlRoot("Idea")]
  public partial class Idea
  {

    #region IHydratable
    public override void Fill(IDataReader dr)
    {
      base.Fill(dr);
      TotalKarma = Convert.ToInt32(Null.SetNull(dr["TotalKarma"], TotalKarma));
      CreatedByUserDisplayName = Convert.ToString(Null.SetNull(dr["CreatedByUserDisplayName"], CreatedByUserDisplayName));
      LastModifiedByUserDisplayName = Convert.ToString(Null.SetNull(dr["LastModifiedByUserDisplayName"], LastModifiedByUserDisplayName));
    }
    #endregion

    #region IPropertyAccess
    public override string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
    {
      switch (strPropertyName.ToLower())
      {
        case "totalkarma": // Int
          if (TotalKarma == null)
          {
            return "";
          };
          return ((int)TotalKarma).ToString(strFormat, formatProvider);
        case "createdbyuserdisplayname": // NVarChar
          if (CreatedByUserDisplayName == null)
          {
            return "";
          };
          return PropertyAccess.FormatString(CreatedByUserDisplayName, strFormat);
        case "lastmodifiedbyuserdisplayname": // NVarChar
          if (LastModifiedByUserDisplayName == null)
          {
            return "";
          };
          return PropertyAccess.FormatString(LastModifiedByUserDisplayName, strFormat);
        default:
          return base.GetProperty(strPropertyName, strFormat, formatProvider, accessingUser, accessLevel, ref propertyNotFound);
      }
    }
    #endregion

  }
}

