using System;

namespace Recog.Controls
{
    public enum ControlType{Button=0,NullCell=1,Cell=2}
   public class AnswerEventArgs:EventArgs
    {
       public AnswerControl CurrentAnsverControl;
       public ControlType ControlType;
    }
}
