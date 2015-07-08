using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Recog.Data;
using System.Xml.Serialization;
using System.IO;
using Recog.Controls;
using AForge;
namespace Recog.PTests.ResultReader
{
 public  abstract class AnswersFactory
    {



     public static T GetAnswersFromTestResult<T>(testresult t)
     {
         T _answersfrombase;
         XmlSerializer mySerializer = new XmlSerializer(typeof(T));
         StringReader sr = new StringReader(t.teststream);
         _answersfrombase = (T)mySerializer.Deserialize(sr);
         return _answersfrombase;
     }

     public static void UpdateTestFromAnswers<T>(T answers, AnswersGrid grid,testresult testresult, pBaseEntities ge) where T:  IAnswers
     {
         for (int i = 0, count = grid.Answers.Count; i < count; i++)
         {
             answers.Add(grid[i].Answer.SelectedCellIndex(), grid[i].Answer.ContentDescription, "", grid[i].Answer.Id, "");
         }
         

         XmlSerializer mySerializer = new XmlSerializer(typeof(T));
         StringWriter myWriter = new StringWriter();
         mySerializer.Serialize(myWriter, answers);
         
         testresult.teststream = myWriter.ToString();
         ge.SaveChanges();
     }
 }
}
