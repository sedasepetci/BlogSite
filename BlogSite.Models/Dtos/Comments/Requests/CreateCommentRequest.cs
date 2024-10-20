
namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record CreateCommentRequest(string Text,int UserId,Guid PostId);
