namespace TreeCode
{
    public class TreeViewData
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public List<TreeViewData>? Children { get; set; }
    }

}
