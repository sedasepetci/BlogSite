
namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record CreateCommentRequest(string Text,long UserId,Guid PostId);
