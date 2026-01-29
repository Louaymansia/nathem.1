namespace PublicWorksAndRoads.Models
{
    public class Sketch
    {
        public int SketchId { get; set; }
        public int RequestId { get; set; }
        public string SketchType { get; set; }
        public byte[] SketchImage { get; set; }
    }
}
