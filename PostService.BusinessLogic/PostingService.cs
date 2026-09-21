using PostService.DataAccess;
using PostService.Models;

namespace PostService.BusinessLogic
{
    public class PostingService : IPostingService
    {
        private readonly IPostingRepository _repository;

        public PostingService(IPostingRepository repository)
        {
            _repository = repository;
        }

        public Posting Create(Posting newPosting)
        {
            newPosting.CreatedAt = DateTime.UtcNow;

            var postingId = _repository.Create(newPosting);

            var savedPosting = (Posting)newPosting.Clone();
            savedPosting.Id = postingId;

            return savedPosting;
        }

        public int Delete(int postingId) => _repository.Delete(postingId);

        public Posting? Find(int postingId) => _repository.GetById(postingId);

        public List<Posting> GetAll() => _repository.GetList();
    }
}
