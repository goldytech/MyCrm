using System;
using System.Collections.Generic;
using System.Text;

namespace MyCrm.Shared.Schemas
{
    public class FormSchema
    {
        public int form_id { get; set; }
        public string form_name { get; set; }
        public List<FormField> form_fields { get; set; }
    }
}
