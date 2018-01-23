using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using webapi.Common;
using webapi.Configs;

namespace webapi.Security
{
    public class IdentityBasicAuthentication:IAuthenticationFilter
    {
        public bool AllowMultiple { get; }
        /// <summary>
        /// 请求先经过AuthenticateAsync
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            // 1、获取token
            context.Request.Headers.TryGetValues("token", out var tokenHeaders);
            // 2、如果没有token，不做任何处理
            if (tokenHeaders == null || !tokenHeaders.Any())
            {
                return Task.FromResult(0);
            }
            // 3、如果token验证通过，则写入到identity，如果未通过则设置错误
            var jwtHelper=new JWTHelper();
            var payLoadClaims=jwtHelper.DecodeToObject(tokenHeaders.FirstOrDefault(),Config.JWTKey, out bool isValid, out string errMsg);
            if (isValid)
            {
                var identity = new ClaimsIdentity("jwt", "user", "role");//只要ClaimsIdentity设置了authenticationType，authenticated就为true，后面的authority根据authenticated=true来做权限
                foreach (var keyValuePair in payLoadClaims)
                {
                    // 一个用户可以拥有多种角色 
                    if (keyValuePair.Key=="role")
                    {
                        foreach (var roleItem in keyValuePair.Value.ToString().Split(','))
                        {
                            identity.AddClaim(new Claim("role", roleItem));
                        }
                    }
                    else
                    {
                       identity.AddClaim(new Claim(keyValuePair.Key, keyValuePair.Value.ToString()));
                    }
                }
                // 最好是http上下文的principal和进程的currentPrincipal都设置
                context.Principal = new ClaimsPrincipal(identity);
                Thread.CurrentPrincipal = new ClaimsPrincipal(identity);
            }
            else
            {
                context.ErrorResult = new ResponseMessageResult(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.ProxyAuthenticationRequired,
                    Content = new StringContent(errMsg)
                });
            }
            return Task.FromResult(0);
        }

        /// <summary>
        /// 请求后经过AuthenticateAsync
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }
    }
}