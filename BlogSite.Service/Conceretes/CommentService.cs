
using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Service.Conceretes;

public class CommentService:ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper,IUserRepository userRepository, IPostRepository postRepository)
    {
        _commentRepository = commentRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _postRepository = postRepository;   
    }

    public ReturnModel<CommentResponseDto> Add(CreateCommentRequest create)
    {
        var user = _userRepository.GetById(create.UserId);
        if (user == null)
        {
            return new ReturnModel<CommentResponseDto>
            {
                Data = null,
                Message = "Kullanıcı bulunamadı.",
                StatusCode = 400,
                Success = false
            };
        }
        var post = _postRepository.GetById(create.PostId);
        if (post == null)
        {
            return new ReturnModel<CommentResponseDto>
            {
                Data = null,
                Message = "Gönderi bulunamadı.",
                StatusCode = 400,
                Success = false
            };
        }

        Comment createdComment = _mapper.Map<Comment>(create);
     
        _commentRepository.Add(createdComment);

        
        CommentResponseDto response = _mapper.Map<CommentResponseDto>(createdComment);
        response.UserName = user.UserName; 

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = "Açıklama eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAll()
    {
        List<Comment> comments = _commentRepository.GetAll();
        List<CommentResponseDto> result = _mapper.Map<List<CommentResponseDto>>(comments);
        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = result,
            Message = "Listelendi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto?> GetById(Guid id)
    {
        var comment = _commentRepository.GetById(id);

        var response = _mapper.Map<CommentResponseDto>(comment);
        return new ReturnModel<CommentResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> Remove(Guid id)
    {
        Comment comment = _commentRepository.GetById(id);
        Comment deletedComment = _commentRepository.Remove(comment);
        CommentResponseDto response = _mapper.Map<CommentResponseDto>(deletedComment);
        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = "Açıklama silindi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updateComment)
    {
        Comment comment = _commentRepository.GetById(updateComment.Id);

        if (comment == null)
        {
            return new ReturnModel<CommentResponseDto>
            {
                Data = null,
                Message = "Açıklama bulunamadı.",
                StatusCode = 404,
                Success = false
            };
        }
        comment.UpdatedDate = DateTime.Now;

        comment.Text = updateComment.Text;
        Comment updatedComment = _commentRepository.Update(comment);
        CommentResponseDto dto = _mapper.Map<CommentResponseDto>(updatedComment);
        return new ReturnModel<CommentResponseDto>
        {
            Data = dto,
            Message = "Açıklama başarıyla güncellendi.",
            StatusCode = 200,
            Success = true
        };
    }
}
