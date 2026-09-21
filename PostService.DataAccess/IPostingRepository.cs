using PostService.Models;

namespace PostService.DataAccess
{
    public interface IPostingRepository
    {
        List<Posting> GetList();
        Posting? GetById(int postingId);
        int Create(Posting posting);
        void Update(Posting posting);
        int Delete(int postingId);
    }
}
