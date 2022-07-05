using System;
using System.Data;

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Tokens;

namespace Connect.IdeaBox.Models.Ideas
{
  public partial class IdeaBase : IHydratable, IPropertyAccess
  {

    #region IHydratable

    public virtual void Fill(IDataReader dr)
    {
      FillAuditFields(dr);
      IdeaId = Convert.ToInt32(Null.SetNull(dr["IdeaId"], IdeaId));
      ModuleId = Convert.ToInt32(Null.SetNull(dr["ModuleId"], ModuleId));
      Title = Convert.ToString(Null.SetNull(dr["Title"], Title));
      Description = Convert.ToString(Null.SetNull(dr["Description"], Description));
    }

    [IgnoreColumn()]
    public int KeyID
    {
      get { return IdeaId; }
      set { IdeaId = value; }
    }
    #endregion

    #region IPropertyAccess
    public virtual string GetProperty(string strPropertyName, string strFormat, System.Globalization.CultureInfo formatProvider, DotNetNuke.Entities.Users.UserInfo accessingUser, DotNetNuke.Services.Tokens.Scope accessLevel, ref bool propertyNotFound)
    {
      switch (strPropertyName.ToLower())
      {
        case "ideaid": // Int
          return IdeaId.ToString(strFormat, formatProvider);
        case "moduleid": // Int
          return ModuleId.ToString(strFormat, formatProvider);
        case "title": // NVarChar
          return PropertyAccess.FormatString(Title, strFormat);
        case "description": // NVarChar
          if (Description == null)
          {
            return "";
          };
          return PropertyAccess.FormatString(Description, strFormat);
        default:
          propertyNotFound = true;
          break;
      }

      return Null.NullString;
    }

    [IgnoreColumn()]
    public CacheLevel Cacheability
    {
      get { return CacheLevel.fullyCacheable; }
    }
    #endregion

  }
}

