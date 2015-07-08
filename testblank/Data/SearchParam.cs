using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Windows.Forms;
namespace Recog.Data
{
    public class SearchParam
    {
        private List<object> _values;

        private string _predicate;

        public string Predicate
        {
            get { return _predicate; }
        }

        private ObjectParameter[] _parameters;

        public ObjectParameter[] Parameters
        {
            get { return _parameters; }
        }

        public SearchParam(ComboBox Fam, ComboBox Tests, DateTimePicker BegDate, DateTimePicker EndDate)
        {
            _values = new List<object>();
            List<ObjectParameter> _params = new List<ObjectParameter>();
            string param = "it.testdate between @begdate and @enddate ";
            _params.Add(new ObjectParameter("begdate", BegDate.Value));
            _params.Add(new ObjectParameter("enddate", EndDate.Value));

            if (Fam.Enabled==true)
            {
                param += " and it.idh = @fam ";
                _params.Add(new ObjectParameter("fam", Fam.SelectedValue));
            }

            if (Tests.Enabled == true)
            {
                param += " and it.testid = @tests ";
                _params.Add(new ObjectParameter("tests", Tests.SelectedValue));
            }
          

            _predicate = param;
            _parameters = _params.ToArray();
          
        }

       

    }
}
