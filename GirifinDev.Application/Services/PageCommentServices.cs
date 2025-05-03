using GirifinDev.Application.Interface;
using GirifinDev.Domain.Interface;
using GirifinDev.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Application.Services
{
    public class PageCommentServices : IPageCommentServices
    {
        ICommentRepository _commentRepository;
        public PageCommentServices(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public void AddComment(_PageComment comment)
        {
            _commentRepository.AddComment(comment);
        }

        public int CountComment()
        {
            return _commentRepository.Commentcount();
        }
    }
}
