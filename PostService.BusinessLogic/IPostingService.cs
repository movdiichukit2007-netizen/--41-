using PostService.Models;

namespace PostService.BusinessLogic
{
    public interface IPostingService
    {
        Posting Create(Posting newPosting);
        int Delete(int postingId);
        Posting? Find(int postingId);
        List<Posting> GetAll();
    }
}
