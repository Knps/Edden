namespace Edden.data.access.layout.Managers
{
    public abstract class BaseManager
    {
        protected DataAccessObject Dao;
        protected BaseManager(DataAccessObject dao)
        {
            Dao = dao;
        }
        public virtual void InitializeData()
        {
            
        }
    }
}
