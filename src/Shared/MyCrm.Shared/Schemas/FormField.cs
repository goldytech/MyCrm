namespace MyCrm.Shared.Schemas
{
    /// <summary>
    /// The form field.
    /// </summary>
    public class FormField
    {
        public int field_id { get; set; }
        public string field_title { get; set; }
        public string field_type { get; set; }
        public string field_value { get; set; }
        public bool field_required { get; set; }
    }
}