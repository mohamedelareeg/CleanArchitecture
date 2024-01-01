using Microsoft.Extensions.Localization;
using System.Net;

namespace CleanArchitecture.Application.Bases
{
    public class BaseResponseHandler
    {
        public readonly IStringLocalizer<BaseResponseHandler> _localizer;

        public BaseResponseHandler(IStringLocalizer<BaseResponseHandler> localizer)
        {
            _localizer = localizer;
        }

        public BaseResponse<T> Deleted<T>()
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer["DeletedSuccessfully"]
            };
        }

        public BaseResponse<T> Success<T>(T entity, object meta = null)
        {
            return new BaseResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer["Successfully"],
                Meta = meta
            };
        }

        public BaseResponse<T> Unauthorized<T>()
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = _localizer["UnAuthorized"]
            };
        }

        public BaseResponse<T> BadRequest<T>(string message, List<string> errors = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? _localizer["BadRequest"] : message,
                Errors = errors
            };
        }

        public BaseResponse<T> Conflict<T>(string message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.Conflict,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? _localizer["Conflict"] : message
            };
        }

        public BaseResponse<T> UnprocessableEntity<T>(string message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? _localizer["UnprocessableEntity"] : message
            };
        }

        public BaseResponse<T> NotFound<T>(string message = null)
        {
            return new BaseResponse<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = string.IsNullOrWhiteSpace(message) ? _localizer["NotFound"] : message
            };
        }

        public BaseResponse<T> Created<T>(T entity, object meta = null)
        {
            return new BaseResponse<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = _localizer["Created"],
                Meta = meta
            };
        }
    }
}
