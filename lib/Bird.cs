namespace CRUDBirds
{
    public class Bird : BaseEntity
    {
        private string PopularName { get; set; }
        private string ScientificName { get; set; }
        private Conservation ConservationState { get; set; }
        private string PhotoUrl { get; set; }
        private bool Deleted { get; set; }

        public Bird(
            int id,
            string popularName,
            string scientificName,
            Conservation conservation,
            string photoUrl)
        {
            this.Id = id;
            this.PopularName = popularName;
            this.ScientificName = scientificName;
            this.ConservationState = conservation;
            this.PhotoUrl = photoUrl;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string result = "";
            result += $"Nome Popular: {PopularName}" + Environment.NewLine;
            result += $"Nome Científico: {ScientificName}" + Environment.NewLine;
            result += $"Status de conservação: {ConservationState}";
            return result;
        }

        public int returnId() {
            return Id;
        }
        public string returnName() {
            return PopularName;
        }

        public bool isDeleted() {
            return Deleted;
        }

        public void Detele()
        {
            this.Deleted = true;
        }

    }
}