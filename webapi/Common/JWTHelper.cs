using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;

namespace webapi.Common
{
    public class JWTHelper
    {
        private IJsonSerializer _jsonSerializer;
        private IDateTimeProvider _dateTimeProvider;
        private IJwtValidator _jwtValidator;
        private IBase64UrlEncoder _base64UrlEncoder;
        private IJwtAlgorithm _jwtAlgorithm;
        private IJwtDecoder _jwtDecoder;
        private IJwtEncoder _jwtEncoder;
        public JWTHelper()
        {
            //非fluent写法
            this._jsonSerializer = new JsonNetSerializer();
            this._dateTimeProvider = new UtcDateTimeProvider();
            this._jwtValidator = new JwtValidator(_jsonSerializer, _dateTimeProvider);
            this._base64UrlEncoder = new JwtBase64UrlEncoder();
            this._jwtAlgorithm = new HMACSHA256Algorithm();
            this._jwtDecoder = new JwtDecoder(_jsonSerializer, _jwtValidator, _base64UrlEncoder);
            this._jwtEncoder = new JwtEncoder(_jwtAlgorithm, _jsonSerializer, _base64UrlEncoder);


        }
        public string Decode(string token, string key, out bool isValid, out string errMsg)
        {
            isValid = false;
            var result = string.Empty;
            try
            {
                result = _jwtDecoder.Decode(token, key, true);
                isValid = true;
                errMsg = "正确的token";
                return result;
            }
            catch (TokenExpiredException)
            {
                errMsg = "token过期";
                return result;
            }
            catch (SignatureVerificationException)
            {
                errMsg = "签名无效";
                return result;
            }
            catch (Exception)
            {
                errMsg = "token无效";
                return result;
            }
        }

        public T DecodeToObject<T>(string token, string key, out bool isValid, out string errMsg)
        {
            isValid = false;
            try
            {
                var result = _jwtDecoder.DecodeToObject<T>(token, key, true);
                isValid = true;
                errMsg = "正确的token";
                return result;
            }
            catch (TokenExpiredException)
            {
                errMsg = "token过期";
                return default(T);
            }
            catch (SignatureVerificationException)
            {
                errMsg = "签名无效";
                return default(T);
            }
            catch (Exception)
            {
                errMsg = "token无效";
                return default(T);
            }
        }

        public IDictionary<string, object> DecodeToObject(string token, string key, out bool isValid, out string errMsg)
        {
            isValid = false;
            try
            {
                var result = _jwtDecoder.DecodeToObject(token, key, true);
                isValid = true;
                errMsg = "正确的token";
                return result;
            }
            catch (TokenExpiredException)
            {
                errMsg = "token过期";
                return null;
            }
            catch (SignatureVerificationException)
            {
                errMsg = "签名无效";
                return null;
            }
            catch (Exception)
            {
                errMsg = "token无效";
                return null;
            }
        }

        #region 解密 
        public string Encode(Dictionary<string, object> payload, string key, int expiredMinute = 30)
        {
            if (!payload.ContainsKey("exp"))
            {
                var exp = Math.Round((_dateTimeProvider.GetNow().AddMinutes(expiredMinute) - new DateTime(1970, 1, 1)).TotalSeconds);
                payload.Add("exp", exp);
            }
            return _jwtEncoder.Encode(payload, key);
        }
        #endregion

    }
}
