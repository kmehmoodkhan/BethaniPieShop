using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethaniPieShop.Models
{
    public class FeedbackRepostiory : IFeedbackRepository
    {
        AppDbContext _appDbContext;
        public FeedbackRepostiory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddFeeback(Feedback feedback)
        {
            _appDbContext.Feedbacks.Add(feedback);
            _appDbContext.SaveChanges();
        }
    }
}
