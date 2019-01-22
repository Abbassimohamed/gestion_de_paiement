using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RibbonSimplePad
{
  public  class ProspectionModel
    {
      public int idclient
      {
          get;
          set;
      }

      public string raisonsoc
      {
          get;
          set;
      }
      public string numtel
      {
          get;
          set;
      }
      public string ville
      {
          get;
          set;
      }
      public string matfisc
      {
          get;
          set;
      }
      public DateTime date
      {
          get;
          set;
      }
      public string commentaire
      {
          get;
          set;
      }
   
      public ProspectionModel()
      { }

    }
}
