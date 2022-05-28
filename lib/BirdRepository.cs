namespace CRUDBirds
{
    public class BirdRepository : IRepository<Bird>
    {

        private List<Bird> listBirds = new List<Bird>();

        public void Add(Bird entity)
        {
            listBirds.Add(entity);
        }

        public List<Bird> Items()
        {
            return listBirds;
        }

        public int NextId()
        {
            return listBirds.Count;
        }

        public void Remove(int id)
        {
            listBirds[id].Detele();
        }

        public Bird ReturnById(int id)
        {
            return listBirds[id];
        }

        public void Update(int id, Bird entity)
        {
            listBirds[id] = entity;
        }
    }
}