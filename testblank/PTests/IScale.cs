using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
namespace Recog.PTests
{
   public interface IScale
    {
       string Name { get;}
       string Description { get;}
       double Mark { get; set; }
       int Stens { get; set; }
       string ResultDescription { get; }
       string Level { get; }
       void GetSten();
       void GetMark();
       void GetLevel();
       void GetResult();
       //костыль
       List<string> MultiResult { get; }
       void GetMultiResult();
    }
}
